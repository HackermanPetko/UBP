-- phpMyAdmin SQL Dump
-- version 4.2.9.1
-- http://www.phpmyadmin.net
--
-- Počítač: localhost
-- Vytvořeno: Úte 05. čen 2018, 16:00
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
  `IdTask` int(11) NOT NULL,
  `State` bit(1) NOT NULL COMMENT '1 = succesful',
  `ErrorMsg` mediumtext COLLATE utf8_czech_ci,
  `Date` datetime NOT NULL,
  `LogLocation` varchar(1000) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Backup`
--

INSERT INTO `Backup` (`Id`, `idDaemon`, `IdTask`, `State`, `ErrorMsg`, `Date`, `LogLocation`) VALUES
(4, 3, 1, b'0', 'Fungujeto', '2018-03-06 00:00:00', 'c'),
(5, 3, 1, b'0', 'TestPost', '2018-03-06 00:00:00', 'c'),
(6, 3, 1, b'0', 'TestPost', '2018-03-06 00:00:00', 'JsemGodNeboNe?'),
(7, 3, 5, b'1', 'succesful', '2018-06-03 18:23:28', '');

-- --------------------------------------------------------

--
-- Struktura tabulky `Config`
--

CREATE TABLE IF NOT EXISTS `Config` (
  `Id` int(11) NOT NULL,
  `Comment` varchar(1000) COLLATE utf8_czech_ci DEFAULT NULL,
  `LastChecked` datetime NOT NULL,
  `TimeStamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Config`
--

INSERT INTO `Config` (`Id`, `Comment`, `LastChecked`, `TimeStamp`) VALUES
(3, 'Testovací config', '2018-03-02 00:00:00', '2018-05-01 17:32:02');

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
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Daemon`
--

INSERT INTO `Daemon` (`Id`, `IsNew`, `DaemonName`, `DaemonMAC`, `LastConnected`, `Comment`) VALUES
(3, b'1', 'Test-PC', '7A7919528CFA', '2018-03-03 00:00:00', 'Testování'),
(4, b'1', 'Test-PC', 'AB-68-8C-F0-21-5B', '2018-03-03 00:00:00', 'Testování'),
(58, b'1', 'L107PC05', '1866DA140DC7', '0001-01-01 00:00:00', 'New Daemon'),
(65, b'1', 'DAN-ASUS', '7A7919528CFF', '2018-03-06 19:09:48', 'New Daemon');

-- --------------------------------------------------------

--
-- Struktura tabulky `Destination`
--

CREATE TABLE IF NOT EXISTS `Destination` (
`Id` int(11) NOT NULL,
  `IdTask` int(11) NOT NULL,
  `DestinationType` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `Destination` varchar(5000) COLLATE utf8_czech_ci NOT NULL,
  `DestinationAddress` varchar(10000) COLLATE utf8_czech_ci DEFAULT NULL,
  `DestinationUser` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `DestinationPassword` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
  `Port` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Destination`
--

INSERT INTO `Destination` (`Id`, `IdTask`, `DestinationType`, `Destination`, `DestinationAddress`, `DestinationUser`, `DestinationPassword`, `Port`) VALUES
(2, 1, 'LOCAL', 'c:\\destination', NULL, NULL, NULL, NULL),
(4, 1, 'FTP', 'localhost', 'full', 'test2', 'test', 21),
(5, 1, 'SFTP', 'localhost', 'full', 'test', 'test', 22),
(6, 3, 'LOCAL', 'c:\\destinationDIFF', NULL, NULL, NULL, NULL),
(7, 4, 'LOCAL', 'c:\\destinationINCR', NULL, NULL, NULL, NULL),
(14, 3, 'FTP', 'localhost', 'diff', 'test2', 'test', 21),
(15, 3, 'SFTP', 'localhost', 'diff', 'test', 'test', 22),
(16, 4, 'FTP', 'localhost', 'incr', 'test2', 'test', 21),
(17, 4, 'SFTP', 'localhost', 'incr', 'test', 'test', 22),
(18, 5, 'LOCAL', 'c:\\Databases', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Struktura tabulky `Source`
--

CREATE TABLE IF NOT EXISTS `Source` (
`Id` int(11) NOT NULL,
  `IdTask` int(11) NOT NULL,
  `SourcePath` varchar(5000) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Source`
--

INSERT INTO `Source` (`Id`, `IdTask`, `SourcePath`) VALUES
(1, 1, 'c:\\Source'),
(2, 1, 'c:\\Source2'),
(7, 3, 'c:\\source'),
(8, 4, 'c:\\source'),
(9, 5, 'server=mysqlstudenti.litv.sssvt.cz;user=poulmarek;pwd=123456;database=3b1_poulmarek_db1;');

-- --------------------------------------------------------

--
-- Struktura tabulky `Task`
--

CREATE TABLE IF NOT EXISTS `Task` (
`Id` int(11) NOT NULL,
  `IdConfig` int(11) NOT NULL,
  `BackupType` int(11) NOT NULL,
  `Format` int(11) NOT NULL,
  `RepeatInterval` varchar(11656) COLLATE utf8_czech_ci NOT NULL,
  `MaxBackups` int(11) NOT NULL DEFAULT '0' COMMENT '0 = nekonečno'
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Task`
--

INSERT INTO `Task` (`Id`, `IdConfig`, `BackupType`, `Format`, `RepeatInterval`, `MaxBackups`) VALUES
(1, 3, 2, 1, '* * * * *', 0),
(3, 3, 2, 0, '*/2 * * * *', 5),
(4, 3, 3, 0, '01.05.2018 20:39', -1),
(5, 3, 4, 0, '25.01.2018 23:23', -1);

-- --------------------------------------------------------

--
-- Struktura tabulky `Token`
--

CREATE TABLE IF NOT EXISTS `Token` (
`Id` int(11) NOT NULL,
  `IdUser` int(11) NOT NULL,
  `UserToken` varchar(500) COLLATE utf8_czech_ci NOT NULL,
  `IsValid` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `Token`
--

INSERT INTO `Token` (`Id`, `IdUser`, `UserToken`, `IsValid`) VALUES
(70, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjE2MTk1OSwiZXhwIjoxNTIyNzY2NzU5LCJpYXQiOjE1MjIxNjE5NTksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.ndfkEsuwsrQhCEwj7SgjEdH5vPcWoNWLPy3DvG-gDWI', 1),
(71, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjYxNTk1NiwiZXhwIjoxNTIzMjIwNzU2LCJpYXQiOjE1MjI2MTU5NTYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.11sU6r3HWMYa8htjNomia4vqx8OHSuFB0R3oZ_mJc8c', 1),
(72, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjc2NTIxMSwiZXhwIjoxNTIzMzcwMDExLCJpYXQiOjE1MjI3NjUyMTEsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.39V700QLl56YbKVFBoWqZwDBB8M3oBkPOp5ZP3Sy4MY', 1),
(73, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjc5MTI1NCwiZXhwIjoxNTIzMzk2MDU0LCJpYXQiOjE1MjI3OTEyNTQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.W1q0KhuATlXLM3Om2ZWrXojRnQdhLI7iSeooYpf8x7U', 1),
(74, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjgzMTkzOSwiZXhwIjoxNTIzNDM2NzM5LCJpYXQiOjE1MjI4MzE5MzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.-QsQ6QudpnqxyAMYjXCIuzk3Mk4dW2zlv3ARQx0wW20', 1),
(75, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjgzNjY1NywiZXhwIjoxNTIzNDQxNDU3LCJpYXQiOjE1MjI4MzY2NTcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.V-bVeQu3MEOWLt8e39GnFDcLlD6mIKDzuIPp9tS74ec', 1),
(76, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMjgzNjY4NSwiZXhwIjoxNTIzNDQxNDg1LCJpYXQiOjE1MjI4MzY2ODUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.8-URRcnN7Yqj9QE5RzHLpiSPf_W_DbSX5aUmwhyvxlc', 1),
(77, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMzM1MDc5OCwiZXhwIjoxNTIzOTU1NTk4LCJpYXQiOjE1MjMzNTA3OTgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.QsQqpBfYrE7C32_yLaGktOKscxF2X6yxmU8-FhkWUBw', 1),
(78, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMzQyNjM2MywiZXhwIjoxNTI0MDMxMTYzLCJpYXQiOjE1MjM0MjYzNjMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.AYHAkdMxyOvMUa3HiXfQ1SLTeNCM23uiLC6C_dPJvJQ', 1),
(79, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMzQyNjM2MywiZXhwIjoxNTI0MDMxMTYzLCJpYXQiOjE1MjM0MjYzNjMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.AYHAkdMxyOvMUa3HiXfQ1SLTeNCM23uiLC6C_dPJvJQ', 1),
(80, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMzQ0MTA0MCwiZXhwIjoxNTI0MDQ1ODQwLCJpYXQiOjE1MjM0NDEwNDAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.L-nus4FyzM3f_qju-0zoVvlYKc6ApqVFyQnmzt71pMI', 1),
(81, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyMzkwNzYxNSwiZXhwIjoxNTI0NTEyNDE1LCJpYXQiOjE1MjM5MDc2MTUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.UTcfZaqboQkOdReBcmv07-ghrN_-WHG7mllqGPflBHA', 1),
(82, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDE1MDY2MCwiZXhwIjoxNTI0NzU1NDYwLCJpYXQiOjE1MjQxNTA2NjAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.-kbW9mzKix8elodQfbwSEvLA4ljoBnyeSHTQARzhcVQ', 1),
(83, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDE1MDY2MCwiZXhwIjoxNTI0NzU1NDYwLCJpYXQiOjE1MjQxNTA2NjAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.-kbW9mzKix8elodQfbwSEvLA4ljoBnyeSHTQARzhcVQ', 1),
(84, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDU3OTk5MiwiZXhwIjoxNTMzMjE5OTkyLCJpYXQiOjE1MjQ1Nzk5OTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.fL0lsgNQ4I-eMtCxCcA_9BPzFhoxOk8F0OWLxqrCr5Y', 1),
(85, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDYwMjcyMiwiZXhwIjoxNTMzMjQyNzIyLCJpYXQiOjE1MjQ2MDI3MjIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.OPvqIzI461D90-AQvK4e-GVTbrOTz1UWZmUSJWXOCWY', 1),
(86, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNDYwMjcyMywiZXhwIjoxNTMzMjQyNzIzLCJpYXQiOjE1MjQ2MDI3MjMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.J-QdCkUeUPfPi5FoUDdjNunb4G5__wKMi2pEHx533do', 1),
(87, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNTIxMTY2MywiZXhwIjoxNTMzODUxNjYzLCJpYXQiOjE1MjUyMTE2NjMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.d9Pz1qauT8lkeLDBFkb7FIIK0R-zuJ-EBQJitk6zQMA', 1),
(88, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNTIxNDcxOCwiZXhwIjoxNTMzODU0NzE4LCJpYXQiOjE1MjUyMTQ3MTgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.XIRC4YHXxPJK9LbhZTNstEw_ragJkvhc0vgay-7IDe0', 1),
(89, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNTIxODE5NSwiZXhwIjoxNTMzODU4MTk1LCJpYXQiOjE1MjUyMTgxOTUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.2z3KVmvt7zJg4zXBTNdbTC2Yucz8TCsEiyvQMBBlnj4', 1),
(90, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNTI1NTkwMSwiZXhwIjoxNTMzODk1OTAxLCJpYXQiOjE1MjUyNTU5MDEsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.9X60ncjoa_myAXeC9OJFnNxEek88iH1QVtoTo9xTfR8', 1),
(91, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNzA3MDQyNiwiZXhwIjoxNTM1NzEwNDI2LCJpYXQiOjE1MjcwNzA0MjYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.ZCLk4UYcZ5id6764eRogXgUUELtcg4IV2yrYWMCUQNk', 1),
(92, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNzE4NTM5MywiZXhwIjoxNTM1ODI1MzkzLCJpYXQiOjE1MjcxODUzOTMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.W9U28WsLz0d9h5brODFRHr9H8nFMxxWOW9LhCUm2XkA', 1),
(93, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNzIyMjUzNiwiZXhwIjoxNTM1ODYyNTM2LCJpYXQiOjE1MjcyMjI1MzYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.gNA8AAZNX271euniA2iqLPj9cnUjlnpeD19Ygk9765o', 1),
(94, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNzY3NTE4NiwiZXhwIjoxNTM2MzE1MTg2LCJpYXQiOjE1Mjc2NzUxODYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.1QN1QBAy7tRxYo9nI3rfzX_MQAw6WBhZ-d_YTL8qJt8', 1),
(95, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyNzY3NjAzNCwiZXhwIjoxNTM2MzE2MDM0LCJpYXQiOjE1Mjc2NzYwMzQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.NsgqoMz7ekhHEmV8Z2lz4AUJk4yalJ5gz4BfQz20iAA', 1),
(101, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0NjU1MiwiZXhwIjoxNTM2Nzg2NTUyLCJpYXQiOjE1MjgxNDY1NTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.UE1kEUvTLPinXoPqmg2ZwUI8yG6cP2QrlBe4xJo6N8c', 1),
(102, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0NjY2MywiZXhwIjoxNTM2Nzg2NjYzLCJpYXQiOjE1MjgxNDY2NjMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.smuUo3XDBHf1DXHsYFe_a3bEtmxVrwV7HbUSNmHvkj4', 1),
(103, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0NjY2NCwiZXhwIjoxNTM2Nzg2NjY0LCJpYXQiOjE1MjgxNDY2NjQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.ndL9wGXqeiHhUpse1PiIUp8J2kVhfwN1FC_oW4dKhxQ', 1),
(104, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0Nzg5MiwiZXhwIjoxNTM2Nzg3ODkyLCJpYXQiOjE1MjgxNDc4OTIsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.gMra64yuJ6EW-U00O38lQU1Ynlw-IHYMDgtI8XuvJ-E', 1),
(105, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0Nzg5MywiZXhwIjoxNTM2Nzg3ODkzLCJpYXQiOjE1MjgxNDc4OTMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.6JJpq0IplFtQl87s-5FMlKq1W7IttBLX1RRv5_5ZU_U', 1),
(106, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0Nzk1NiwiZXhwIjoxNTM2Nzg3OTU2LCJpYXQiOjE1MjgxNDc5NTYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.WZZ9vPeD7ZXVTeatHpPeoAbxx5MlHYUUjOjqv-FayoI', 1),
(107, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0ODM1OSwiZXhwIjoxNTM2Nzg4MzU5LCJpYXQiOjE1MjgxNDgzNTksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.yxPwvPZIVf1tMI6bPPUkz4dOwXlxJpez49wHtiHMJMA', 1),
(108, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0OTAyOSwiZXhwIjoxNTM2Nzg5MDI5LCJpYXQiOjE1MjgxNDkwMjksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.eVUHcIHc92NBdD2CCaG-r5ar5W6mOZB4838pHBaJtG8', 1),
(109, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0OTQ1NywiZXhwIjoxNTM2Nzg5NDU3LCJpYXQiOjE1MjgxNDk0NTcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.JpS56IYRrOT2gjvKfGq3tNyqJytFsW-BLnhOIE5BUxM', 1),
(110, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0OTUwMywiZXhwIjoxNTM2Nzg5NTAzLCJpYXQiOjE1MjgxNDk1MDMsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.IhNT-HyStIHtDdIY4K_OC1ZnnrD-byV24w8b9Be6Prg', 1),
(111, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE0OTgyNCwiZXhwIjoxNTM2Nzg5ODI0LCJpYXQiOjE1MjgxNDk4MjQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.BI3cblahbWf0jhyyFfe-YdsSkZYt_-IQXtmCJlhzO3U', 1),
(112, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE4NDYzOSwiZXhwIjoxNTM2ODI0NjM5LCJpYXQiOjE1MjgxODQ2MzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.kbQUe7m9lhluQRVqQDARiX6Dd31OVTPDp9_kbnHxpwA', 1),
(113, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE4NjUxNywiZXhwIjoxNTM2ODI2NTE3LCJpYXQiOjE1MjgxODY1MTcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.uqbGzggtXQ3c5yfqe97dgaspGSwAeqe9ApHDrbx4-Es', 1),
(114, 4, 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsIm5iZiI6MTUyODE4NjkwOSwiZXhwIjoxNTM2ODI2OTA5LCJpYXQiOjE1MjgxODY5MDksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjM2OTkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjYzNjk5In0.VfJrPOz07fQIiJLAjQlPwe7w2la4gEcjMz1s7CTAhss', 1);

-- --------------------------------------------------------

--
-- Struktura tabulky `User`
--

CREATE TABLE IF NOT EXISTS `User` (
`ID` int(254) NOT NULL,
  `Username` varchar(20) COLLATE utf8_czech_ci NOT NULL,
  `Password` varchar(60) COLLATE utf8_czech_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `User`
--

INSERT INTO `User` (`ID`, `Username`, `Password`, `Email`) VALUES
(3, 'User', 'User', 'aaa'),
(4, 'Tom', '$2a$10$2Tqt6BKuhOutyhDrn6PYsekfaduSgtTEOF3MyFVnSqBFivHt8p.ly', 'ahoj@sssvt.cz');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `Backup`
--
ALTER TABLE `Backup`
 ADD PRIMARY KEY (`Id`), ADD KEY `FkBackupIdDaemon` (`idDaemon`), ADD KEY `FKBackupIdTask` (`IdTask`);

--
-- Klíče pro tabulku `Config`
--
ALTER TABLE `Config`
 ADD PRIMARY KEY (`Id`);

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
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT pro tabulku `Daemon`
--
ALTER TABLE `Daemon`
MODIFY `Id` int(254) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=66;
--
-- AUTO_INCREMENT pro tabulku `Destination`
--
ALTER TABLE `Destination`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT pro tabulku `Source`
--
ALTER TABLE `Source`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT pro tabulku `Task`
--
ALTER TABLE `Task`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT pro tabulku `Token`
--
ALTER TABLE `Token`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=115;
--
-- AUTO_INCREMENT pro tabulku `User`
--
ALTER TABLE `User`
MODIFY `ID` int(254) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=15;
--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `Backup`
--
ALTER TABLE `Backup`
ADD CONSTRAINT `Backup_ibfk_1` FOREIGN KEY (`idDaemon`) REFERENCES `Daemon` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
ADD CONSTRAINT `Backup_ibfk_2` FOREIGN KEY (`IdTask`) REFERENCES `Task` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `Config`
--
ALTER TABLE `Config`
ADD CONSTRAINT `Config_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `Daemon` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
