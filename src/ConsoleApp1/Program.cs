var dto = new
{
    Body = """
    (TEST)(광고)[넥슨]
    호시절zxc님, 지금 넥슨 현대카드 회원은 어디서나 결제만 해도 최대 35만원 상당 혜택 받아간다구요!

    ♥ 혜택 1. 아래 5종 중 원하는 보상 받기! (택 1)
     * 17만원 넥슨 캐시 
     * FIFA ONLINE 4 8강 선수 확정팩 등
     * 메이플스토리 아케인셰이드 무기상자 등
     * 서든어택 60,000SP 등
     * 17만 넥슨 현대카드 포인트
       (넥슨 현대카드 또는 넥슨 현대카드 UNLIMITED로 누적 20만원 사용)

    ♥ 혜택 2. 매월 최대 18% 넥슨 현대카드 포인트 적립!
     * 6개월 간 최대 18만원 적립
     * 넥슨 현대카드 CHECK제외

    - https://nexon.link/50f
    - 이벤트 참여기간 : 2022.10.27~2022.11.30

    - 연회비
     · 넥슨 현대카드 : 국내전용/국내외겸용(MasterCard/AMEX) 1만원  
     · 넥슨 현대카드 UNLIMITED : 국내전용/국내외겸용(MasterCard World) 15만원  
     · 넥슨 현대카드 CHECK : 국내전용 2천원(2~5년차 연회비 면제)
    > 카드 이용대금 연체 시 약정금리 + 연체가산금리 3%의 연체이자율이 적용됩니다. (회원별, 이용 상품별 차등 적용/법정 최고금리 20% 이내)
    단, 연체 발생시점에 약정금리가 없는 경우 아래와 같이 적용
      > 일시불 : 거래 발생시점 기준 최소 기간(2개월)의 유이자할부 약정금리 + 연체가산금리 3%
      > 무이자할부 : 거래 발생시점 기준 동일한 할부 계약 기간의 유이자할부 약정금리 + 연체가산금리 3%
    > 상환 능력에 비해 신용카드 이용금액이 과도할 경우, 귀하의 개인신용평점이 하락할 수 있습니다. 
    > 개인신용평점 하락 시 금융거래와 관련된 불이익이 발생할 수 있습니다. 
    > 일정 기간 원리금을 연체할 경우, 모든 원리금을 변제할 의무가 발생할 수 있습니다.
    - 신용카드 발급이 부적정한 경우(연체금 보유, 개인신용평점 낮음 등) 카드 발급이 제한될 수 있습니다. 
    - 카드 이용대금과 이에 수반되는 모든 수수료를 지정된 대금 결제일에 상환합니다. 
    - 금융소비자는 금융소비자보호법 제19조 제1항에 따라 해당 상품 또는 서비스에 대하여 설명을 받을 권리가 있습니다. 
    - 모든 가맹점은 현대카드 등록 가맹점 분류 기준을 따릅니다. 
    - 자세한 내용 및 이용 조건은 카드 신청 전 현대카드 홈페이지 및 상품설명서, 약관 참고 
    - 여신금융협회 심의필 제 2022 - C1f - 09531호 ( 2022.10.27 ~ 20
    """,
};


await using var conn = new MySql.Data.MySqlClient.MySqlConnection(@"Server=127.0.0.1;Database=poc;Uid=root;Pwd=root");
await conn.OpenAsync();

var json = JsonSerializer.Serialize(dto);
//var sha = SHA256.HashData(Encoding.UTF8.GetBytes(json));
var sha = Convert.ToHexString(SHA256.HashData(json.AsMemory().AsBytes().Span));
Console.WriteLine($"{sha}");
var sql = "INSERT INTO Person (Json, SHA2) VALUES (@Json, @Sha)";
var ret = await conn.ExecuteAsync(sql, new
{
    Json = JsonSerializer.Serialize(dto),
    Sha = sha
});


