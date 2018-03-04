-- phpMyAdmin SQL Dump
-- version 4.2.9.1
-- http://www.phpmyadmin.net
--
-- Počítač: localhost
-- Vytvořeno: Ned 04. bře 2018, 14:08
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
-- Struktura tabulky `Backup`
--

CREATE TABLE IF NOT EXISTS `Backup` (
`Id` int(11) NOT NULL,
  `idDaemon` int(11) NOT NULL,
  `State` bit(1) NOT NULL,
  `ErrorMsg` mediumtext COLLATE utf8_czech_ci,
  `BackupType` int(11) NOT NULL,
  `Date` datetime NOT NULL,
  `LogLocation` varchar(1000) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Backup`
--

INSERT INTO `Backup` (`Id`, `idDaemon`, `State`, `ErrorMsg`, `BackupType`, `Date`, `LogLocation`) VALUES
(4, 3, b'0', 'Fungujeto', 0, '2018-03-06 00:00:00', 'c');

-- --------------------------------------------------------

--
-- Struktura tabulky `Config`
--

CREATE TABLE IF NOT EXISTS `Config` (
`Id` int(11) NOT NULL,
  `idDaemon` int(11) NOT NULL,
  `Comment` varchar(1000) COLLATE utf8_czech_ci DEFAULT NULL,
  `LastChecked` datetime NOT NULL,
  `TimeStamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Config`
--

INSERT INTO `Config` (`Id`, `idDaemon`, `Comment`, `LastChecked`, `TimeStamp`) VALUES
(4, 3, 'Testovací config', '2018-03-02 00:00:00', '2018-03-04 10:30:39'),
(5, 3, 'Testovací config2', '2018-03-02 00:00:00', '2018-03-04 10:30:39');

-- --------------------------------------------------------

--
-- Struktura tabulky `Daemon`
--

CREATE TABLE IF NOT EXISTS `Daemon` (
`Id` int(254) NOT NULL,
  `IsNew` bit(1) NOT NULL,
  `DaemonName` varchar(100) COLLATE utf8_czech_ci NOT NULL,
  `DaemonMAC` varchar(200) COLLATE utf8_czech_ci NOT NULL,
  `LastConnected` datetime NOT NULL,
  `Comment` varchar(1000) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Daemon`
--

INSERT INTO `Daemon` (`Id`, `IsNew`, `DaemonName`, `DaemonMAC`, `LastConnected`, `Comment`) VALUES
(3, b'1', 'Test-PC', 'AB-68-8C-F0-21-5B', '2018-03-03 00:00:00', 'Testování');

-- --------------------------------------------------------

--
-- Struktura tabulky `Destination`
--

CREATE TABLE IF NOT EXISTS `Destination` (
`Id` int(11) NOT NULL,
  `IdTask` int(11) NOT NULL,
  `DestinationType` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `DestinationAddress` varchar(10000) COLLATE utf8_czech_ci NOT NULL,
  `DestinationUser` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `DestinationPassword` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `FTPport` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Destination`
--

INSERT INTO `Destination` (`Id`, `IdTask`, `DestinationType`, `DestinationAddress`, `DestinationUser`, `DestinationPassword`, `FTPport`) VALUES
(2, 1, 'LOCAL', 'c:\\destination', NULL, NULL, NULL),
(3, 1, 'LOCAL', 'c:\\destination2', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `Source`
--

CREATE TABLE IF NOT EXISTS `Source` (
`Id` int(11) NOT NULL,
  `IdTask` int(11) NOT NULL,
  `SourcePath` varchar(5000) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Source`
--

INSERT INTO `Source` (`Id`, `IdTask`, `SourcePath`) VALUES
(1, 1, 'c:\\Source'),
(2, 1, 'c:\\Source2');

-- --------------------------------------------------------

--
-- Struktura tabulky `Task`
--

CREATE TABLE IF NOT EXISTS `Task` (
`Id` int(11) NOT NULL,
  `IdConfig` int(11) NOT NULL,
  `BackupType` int(11) NOT NULL,
  `Format` int(11) NOT NULL,
  `RepeatInterval` int(11) NOT NULL COMMENT '0 = neopakovat'
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Task`
--

INSERT INTO `Task` (`Id`, `IdConfig`, `BackupType`, `Format`, `RepeatInterval`) VALUES
(1, 4, 1, 0, 0),
(2, 4, 0, 0, 0);

-- --------------------------------------------------------

--
-- Struktura tabulky `Token`
--

CREATE TABLE IF NOT EXISTS `Token` (
`Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `UserToken` varchar(500) COLLATE utf8_czech_ci NOT NULL,
  `IsValid` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Token`
--

INSERT INTO `Token` (`Id`, `IdUser`, `UserToken`, `IsValid`) VALUES
(24, 1, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkRlbW8iLCJuYmYiOjE1MjAxNjAzMzMsImV4cCI6MTUyMDE5MDMzMywiaWF0IjoxNTIwMTYwMzMzfQ.j0cig3Q0qacQEkWOKma_DqLDh26VqOHD2XoIQytreF8', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `User`
--

CREATE TABLE IF NOT EXISTS `User` (
`ID` int(254) NOT NULL,
  `Username` varchar(20) COLLATE utf8_czech_ci NOT NULL,
  `Password` varchar(60) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `User`
--

INSERT INTO `User` (`ID`, `Username`, `Password`, `Email`) VALUES
(1, 'Demo', 'Demo', 'demo@sssvt.cz'),
(3, 'User', 'User', 'aaa');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `Backup`
--
ALTER TABLE `Backup`
 ADD PRIMARY KEY (`Id`), ADD KEY `FkBackupIdDaemon` (`idDaemon`);

--
-- Klíče pro tabulku `Config`
--
ALTER TABLE `Config`
 ADD PRIMARY KEY (`Id`), ADD KEY `FkConfigIdDaemon` (`idDaemon`);

--
-- Klíče pro tabulku `Daemon`
--
ALTER TABLE `Daemon`
 ADD PRIMARY KEY (`Id`);

--
-- Klíče pro tabulku `Destination`
--
ALTER TABLE `Destination`
 ADD PRIMARY KEY (`Id`), ADD KEY `FkDestinationIdTask` (`IdTask`);

--
-- Klíče pro tabulku `Source`
--
ALTER TABLE `Source`
 ADD PRIMARY KEY (`Id`), ADD KEY `Id` (`IdTask`);

--
-- Klíče pro tabulku `Task`
--
ALTER TABLE `Task`
 ADD PRIMARY KEY (`Id`), ADD KEY `IdConfig` (`IdConfig`);

--
-- Klíče pro tabulku `Token`
--
ALTER TABLE `Token`
 ADD PRIMARY KEY (`Id`), ADD KEY `FkTokenIdUser` (`IdUser`);

--
-- Klíče pro tabulku `User`
--
ALTER TABLE `User`
 ADD PRIMARY KEY (`ID`), ADD UNIQUE KEY `Username` (`Username`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `Backup`
--
ALTER TABLE `Backup`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pro tabulku `Config`
--
ALTER TABLE `Config`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pro tabulku `Daemon`
--
ALTER TABLE `Daemon`
MODIFY `Id` int(254) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pro tabulku `Destination`
--
ALTER TABLE `Destination`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pro tabulku `Source`
--
ALTER TABLE `Source`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pro tabulku `Task`
--
ALTER TABLE `Task`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pro tabulku `Token`
--
ALTER TABLE `Token`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=25;
--
-- AUTO_INCREMENT pro tabulku `User`
--
ALTER TABLE `User`
MODIFY `ID` int(254) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `Backup`
--
ALTER TABLE `Backup`
ADD CONSTRAINT `Backup_ibfk_1` FOREIGN KEY (`idDaemon`) REFERENCES `Daemon` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Config`
--
ALTER TABLE `Config`
ADD CONSTRAINT `Config_ibfk_1` FOREIGN KEY (`idDaemon`) REFERENCES `Daemon` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Destination`
--
ALTER TABLE `Destination`
ADD CONSTRAINT `Destination_ibfk_1` FOREIGN KEY (`IdTask`) REFERENCES `Task` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Source`
--
ALTER TABLE `Source`
ADD CONSTRAINT `Source_ibfk_1` FOREIGN KEY (`IdTask`) REFERENCES `Task` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Task`
--
ALTER TABLE `Task`
ADD CONSTRAINT `Task_ibfk_1` FOREIGN KEY (`IdConfig`) REFERENCES `Config` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Token`
--
ALTER TABLE `Token`
ADD CONSTRAINT `Token_ibfk_1` FOREIGN KEY (`IdUser`) REFERENCES `User` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
