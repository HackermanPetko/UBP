-- phpMyAdmin SQL Dump
-- version 4.2.9.1
-- http://www.phpmyadmin.net
--
-- Počítač: localhost
-- Vytvořeno: Pon 12. úno 2018, 23:10
-- Verze serveru: 5.5.55-0+deb7u1
-- Verze PHP: 5.4.45-0+deb7u8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databáze: `3b1_poulmarek_db1`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `Config`
--

CREATE TABLE IF NOT EXISTS `Config` (
`idConfig` int(254) NOT NULL,
  `idDaemon` int(254) NOT NULL,
  `BackupType` int(10) NOT NULL,
  `DestinationType` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `DestinationAddress` varchar(10000) COLLATE utf8_czech_ci DEFAULT NULL,
  `DestinationPassword` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `DestinationUser` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `FTPport` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `Format` int(10) NOT NULL,
  `Repeatable` tinyint(1) NOT NULL,
  `Interval` int(11) NOT NULL,
  `LastChecked` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Config`
--

INSERT INTO `Config` (`idConfig`, `idDaemon`, `BackupType`, `DestinationType`, `DestinationAddress`, `DestinationPassword`, `DestinationUser`, `FTPport`, `Format`, `Repeatable`, `Interval`, `LastChecked`) VALUES
(1, 0, 0, 'null', NULL, NULL, NULL, '0', 0, 0, 0, '0001-01-01 00:00:00'),
(2, 1, 0, 'null', NULL, NULL, NULL, '0', 0, 0, 0, '0001-01-01 00:00:00');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `Config`
--
ALTER TABLE `Config`
 ADD PRIMARY KEY (`idConfig`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Config`
--
ALTER TABLE `Config`
MODIFY `idConfig` int(254) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
