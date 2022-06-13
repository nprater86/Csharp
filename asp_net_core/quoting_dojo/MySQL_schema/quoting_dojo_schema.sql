-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema quoting_dojo_schema
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema quoting_dojo_schema
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `quoting_dojo_schema` DEFAULT CHARACTER SET utf8 ;
USE `quoting_dojo_schema` ;

-- -----------------------------------------------------
-- Table `quoting_dojo_schema`.`quotes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quoting_dojo_schema`.`quotes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `quote` TEXT NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;