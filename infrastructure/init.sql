CREATE DATABASE IF NOT EXISTS `poc`;
USE `poc`;

CREATE TABLE IF NOT EXISTS `Person`
(
    `Id`         BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Json`       JSON        NULL,
    `SHA2`       CHAR(64)

)
DEFAULT CHARACTER SET = 'utf8mb4';

ALTER TABLE `Person` ADD UNIQUE INDEX `SHA2_IDX`(`SHA2`)