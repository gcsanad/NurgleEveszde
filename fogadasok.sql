-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Sze 26. 14:19
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `fogadasok`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bets`
--

CREATE TABLE `bets` (
  `BetsID` int(11) NOT NULL,
  `BetDate` date NOT NULL,
  `Odds` float NOT NULL,
  `Amount` int(11) NOT NULL,
  `BettorsID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL,
  `Status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `bets`
--

INSERT INTO `bets` (`BetsID`, `BetDate`, `Odds`, `Amount`, `BettorsID`, `EventID`, `Status`) VALUES
(1, '2024-02-20', 1.5, 100, 1, 1, 1),
(2, '2024-02-21', 2, 150, 2, 2, 1),
(3, '2024-03-01', 1.8, 200, 3, 3, 0),
(4, '2024-03-05', 2.5, 50, 4, 4, 1),
(5, '2024-04-01', 1.3, 300, 5, 5, 0),
(6, '2024-04-05', 3, 80, 6, 6, 1),
(7, '2024-05-01', 2.2, 120, 1, 7, 1),
(8, '2024-05-10', 1.9, 220, 2, 8, 0),
(9, '2024-06-15', 1.7, 90, 3, 9, 1),
(10, '2024-06-18', 2.8, 60, 4, 10, 1),
(11, '2024-07-10', 1.4, 250, 5, 1, 0),
(12, '2024-07-12', 3.5, 75, 6, 2, 1),
(13, '2024-08-20', 1.6, 110, 1, 3, 1),
(14, '2024-08-22', 2.1, 130, 2, 4, 0),
(15, '2024-09-10', 1.2, 180, 3, 5, 1),
(16, '2024-09-15', 2.9, 70, 4, 6, 1),
(17, '2024-10-10', 1.3, 500, 5, 7, 0),
(18, '2024-10-15', 4, 40, 6, 8, 1),
(19, '2024-11-01', 2.6, 200, 1, 9, 1),
(20, '2024-11-10', 1.8, 150, 2, 10, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bettors`
--

CREATE TABLE `bettors` (
  `BettorsID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Balance` int(11) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `JoinDate` date NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `bettors`
--

INSERT INTO `bettors` (`BettorsID`, `Username`, `Password`, `Balance`, `Email`, `JoinDate`, `IsActive`) VALUES
(1, 'speedster01', 'hashed_password1', 1000, 'speedster01@example.com', '2024-01-15', 1),
(2, 'racefan92', 'hashed_password2', 500, 'racefan92@example.com', '2024-02-10', 1),
(3, 'fastlane88', 'hashed_password3', 1500, 'fastlane88@example.com', '2024-03-05', 1),
(4, 'trackmaster', 'hashed_password4', 300, 'trackmaster@example.com', '2024-01-20', 1),
(5, 'f1lover', 'hashed_password5', 250, 'f1lover@example.com', '2024-02-15', 1),
(6, 'pitstopking', 'hashed_password6', 600, 'pitstopking@example.com', '2024-03-10', 1),
(7, 'checkeredflag', 'hashed_password7', 800, 'checkeredflag@example.com', '2024-04-01', 1),
(8, 'podiumfinisher', 'hashed_password8', 700, 'podiumfinisher@example.com', '2024-01-25', 1),
(9, 'racinghero', 'hashed_password9', 900, 'racinghero@example.com', '2024-02-20', 1),
(10, 'trackwizard', 'hashed_password10', 100, 'trackwizard@example.com', '2024-03-15', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `events`
--

CREATE TABLE `events` (
  `EventID` int(11) NOT NULL,
  `EventName` varchar(100) NOT NULL,
  `EventDate` date NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Location` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `events`
--

INSERT INTO `events` (`EventID`, `EventName`, `EventDate`, `Category`, `Location`) VALUES
(1, 'Bahrain Grand Prix', '2024-03-03', 'Race', 'Bahrain International Circuit, Bahrain'),
(2, 'Saudi Arabian Grand Prix', '2024-03-10', 'Race', 'Jeddah Corniche Circuit, Saudi Arabia'),
(3, 'Australian Grand Prix', '2024-03-24', 'Race', 'Albert Park Circuit, Australia'),
(4, 'Azerbaijan Grand Prix', '2024-04-07', 'Race', 'Baku City Circuit, Azerbaijan'),
(5, 'Miami Grand Prix', '2024-05-05', 'Race', 'Miami International Autodrome, USA'),
(6, 'Monaco Grand Prix', '2024-05-26', 'Race', 'Circuit de Monaco, Monaco'),
(7, 'Spanish Grand Prix', '2024-06-02', 'Race', 'Circuit de Barcelona-Catalunya, Spain'),
(8, 'Canadian Grand Prix', '2024-06-16', 'Race', 'Circuit Gilles Villeneuve, Canada'),
(9, 'Austrian Grand Prix', '2024-07-07', 'Race', 'Red Bull Ring, Austria'),
(10, 'British Grand Prix', '2024-07-14', 'Race', 'Silverstone Circuit, United Kingdom');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bets`
--
ALTER TABLE `bets`
  ADD PRIMARY KEY (`BetsID`),
  ADD KEY `BettorsID` (`BettorsID`),
  ADD KEY `EventID` (`EventID`);

--
-- A tábla indexei `bettors`
--
ALTER TABLE `bettors`
  ADD PRIMARY KEY (`BettorsID`);

--
-- A tábla indexei `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`EventID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `bets`
--
ALTER TABLE `bets`
  MODIFY `BetsID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `bettors`
--
ALTER TABLE `bettors`
  MODIFY `BettorsID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `events`
--
ALTER TABLE `events`
  MODIFY `EventID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `bets`
--
ALTER TABLE `bets`
  ADD CONSTRAINT `bets_ibfk_1` FOREIGN KEY (`BettorsID`) REFERENCES `bettors` (`BettorsID`),
  ADD CONSTRAINT `bets_ibfk_2` FOREIGN KEY (`EventID`) REFERENCES `events` (`EventID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
