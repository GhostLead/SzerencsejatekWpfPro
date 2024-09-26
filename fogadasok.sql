-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Sze 26. 10:16
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
(1, '2023-09-10', 2, 100, 1, 1, 1),
(2, '2023-09-12', 1.8, 200, 2, 2, 0),
(3, '2023-09-14', 1.5, 150, 3, 3, 1),
(4, '2023-09-16', 2.2, 300, 4, 4, 1),
(5, '2023-09-18', 1.9, 250, 5, 5, 0),
(6, '2023-09-19', 2.1, 50, 6, 6, 1),
(7, '2023-09-21', 1.7, 100, 7, 7, 1),
(8, '2023-09-22', 2.3, 400, 8, 8, 0),
(9, '2023-09-23', 1.6, 150, 9, 9, 1),
(10, '2023-09-24', 1.95, 300, 10, 10, 1),
(11, '2023-09-25', 1.8, 200, 1, 1, 0),
(12, '2023-09-26', 2, 100, 2, 2, 1),
(13, '2023-09-27', 2.5, 350, 3, 3, 1),
(14, '2023-09-28', 1.85, 80, 4, 4, 0),
(15, '2023-09-29', 1.75, 150, 5, 5, 1),
(16, '2023-09-30', 2.1, 120, 6, 6, 0),
(17, '2023-10-01', 1.9, 500, 7, 7, 1),
(18, '2023-10-02', 2.2, 250, 8, 8, 1),
(19, '2023-10-03', 1.65, 350, 9, 9, 0),
(20, '2023-10-04', 1.95, 400, 10, 10, 1);

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
  `JoinDate` date NOT NULL DEFAULT current_timestamp(),
  `IsActive` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `bettors`
--

INSERT INTO `bettors` (`BettorsID`, `Username`, `Password`, `Balance`, `Email`, `JoinDate`, `IsActive`) VALUES
(1, 'john_doe', 'hashed_password_1', 1200, 'john@example.com', '2023-01-10', 1),
(2, 'jane_smith', 'hashed_password_2', 850, 'jane@example.com', '2023-01-15', 1),
(3, 'alice_jones', 'hashed_password_3', 1750, 'alice@example.com', '2023-02-01', 1),
(4, 'bob_brown', 'hashed_password_4', 600, 'bob@example.com', '2023-02-10', 1),
(5, 'charlie_davis', 'hashed_password_5', 2500, 'charlie@example.com', '2023-03-05', 1),
(6, 'david_wilson', 'hashed_password_6', 900, 'david@example.com', '2023-03-15', 1),
(7, 'eve_miller', 'hashed_password_7', 300, 'eve@example.com', '2023-04-01', 1),
(8, 'frank_thompson', 'hashed_password_8', 1100, 'frank@example.com', '2023-04-20', 1),
(9, 'grace_martin', 'hashed_password_9', 500, 'grace@example.com', '2023-05-05', 1),
(10, 'henry_clark', 'hashed_password_10', 2000, 'henry@example.com', '2023-05-10', 1),
(11, 'user', 'user', 1200, 'user@default.com', '2024-09-26', 1),
(12, 'admin', 'admin', 1200, 'admin@default.com', '2024-09-26', 1),
(13, 'organizer', 'org', 1200, 'organizer@default.com', '2024-09-26', 1);


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
(1, 'Champions League Final', '2023-09-15', 'Sports', 'Wembley Stadium'),
(2, 'World Music Festival', '2023-09-20', 'Music', 'Central Park'),
(3, 'Local Art Exhibition', '2023-09-25', 'Art', 'Art Gallery 1'),
(4, 'Basketball Championship', '2023-10-01', 'Sports', 'Arena 1'),
(5, 'Theater Play Opening Night', '2023-10-05', 'Theater', 'Main Theater'),
(6, 'Tech Conference 2023', '2023-10-10', 'Conference', 'Convention Center'),
(7, 'Charity Gala', '2023-10-15', 'Charity', 'City Hall'),
(8, 'Film Festival', '2023-10-20', 'Film', 'Cinema 1'),
(9, 'Comedy Night', '2023-10-25', 'Comedy', 'Comedy Club'),
(10, 'Marathon Race', '2023-10-30', 'Sports', 'City Streets');

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
  MODIFY `BettorsID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

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
