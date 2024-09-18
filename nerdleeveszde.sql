-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Sze 18. 11:15
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
-- Adatbázis: `nerdleeveszde`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `accounts`
--

CREATE TABLE `accounts` (
  `Account_Id` int(11) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Mobil` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Status` varchar(255) NOT NULL,
  `Registration_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `accounts`
--

INSERT INTO `accounts` (`Account_Id`, `Username`, `Password`, `Mobil`, `Email`, `Address`, `Status`, `Registration_Date`) VALUES
(1, 'admin', 'admin', '06 20 555 5555', 'admin@example.com', '0000 admin utca 00, Debrecen', 'Admin', '2023-01-01'),
(2, 'Ava Sinclair', 'password123', '06 20 012 3456', 'ava.sinclair@example.com', '4034 Fő utca 22, Debrecen', 'User', '2023-01-15'),
(3, 'Leo Martinez', 'password456', '06 30 123 4567', 'leo.martinez@example.com', '4035 Kossuth Lajos utca 15, Debrecen', 'User', '2023-02-20'),
(4, 'Mia Thompson', 'password789', '06 20 234 5678', 'mia.thompson@example.com', '4036 Széchenyi utca 30, Debrecen', 'User', '2023-03-05'),
(5, 'Elijah Bennett', 'passwordabc', '06 30 345 6789', 'elijah.bennett@example.com', '4037 Petőfi utca 5, Debrecen', 'User', '2023-04-10'),
(6, 'Harper Lee', 'passworddef', '06 20 456 7890', 'harper.lee@example.com', '4038 Rákóczi út 10, Debrecen', 'User', '2023-05-25'),
(7, 'Samuel Cooper', 'passwordghi', '06 30 567 8901', 'samuel.cooper@example.com', '4039 Andrássy út 8, Debrecen', 'User', '2023-06-15'),
(8, 'Zoe Patel', 'passwordjkl', '06 20 678 9012', 'zoe.patel@example.com', '4040 Bartók Béla út 12, Debrecen', 'User', '2023-07-30'),
(9, 'Isaac Ramirez', 'passwordmno', '06 30 789 0123', 'isaac.ramirez@example.com', '4041 Móricz Zsigmond körtér 20, Debrecen', 'User', '2023-08-12'),
(10, 'Clara Hayes', 'passwordpqr', '06 20 890 1234', 'clara.hayes@example.com', '4042 Jókai Mór utca 25, Debrecen', 'User', '2023-09-18'),
(11, 'Nolan Reed', 'passwordstu', '06 30 901 2345', 'nolan.reed@example.com', '4043 Zrinyi Miklós utca 18, Debrecen', 'User', '2023-10-22'),
(12, 'Lily Chen', 'passwordvwx', '06 20 012 3457', 'lily.chen@example.com', '4044 Váci út 27, Debrecen', 'User', '2023-11-02'),
(13, 'Max Anderson', 'passwordyz', '06 30 123 4568', 'max.anderson@example.com', '4045 Ferihegyi út 11, Debrecen', 'User', '2023-11-15'),
(14, 'Grace Kim', 'password1234', '06 20 234 5679', 'grace.kim@example.com', '4046 Eötvös utca 14, Debrecen', 'User', '2023-12-01'),
(15, 'Oliver Scott', 'adminpass1', '06 30 345 6780', 'oliver.scott@example.com', '4047 Fő tér 19, Debrecen', 'Admin', '2024-01-05'),
(16, 'Ruby Foster', 'password5678', '06 20 456 7891', 'ruby.foster@example.com', '4048 Kossuth Lajos tér 13, Debrecen', 'User', '2024-02-14'),
(17, 'Henry James', 'password8765', '06 30 567 8902', 'henry.james@example.com', '4049 Szent István körút 16, Debrecen', 'User', '2024-03-20'),
(18, 'Stella Nguyen', 'password4321', '06 20 678 9013', 'stella.nguyen@example.com', '4050 Bajcsy-Zsilinszky út 21, Debrecen', 'User', '2024-04-25'),
(19, 'Benjamin Ross', 'adminpass2', '06 30 789 0124', 'benjamin.ross@example.com', '4051 Árpád fejedelem útja 24, Debrecen', 'Admin', '2024-05-30'),
(20, 'Aria Price', 'password1111', '06 20 890 1235', 'aria.price@example.com', '4052 Munkás utca 23, Debrecen', 'User', '2024-06-15'),
(21, 'Lucas King', 'password2222', '06 30 901 2346', 'lucas.king@example.com', '4053 Rákóczi tér 26, Debrecen', 'User', '2024-07-10'),
(22, 'Julia Morgan', 'password3333', '06 20 012 3458', 'julia.morgan@example.com', '4054 Hősök tere 29, Debrecen', 'User', '2024-08-05'),
(23, 'Jack Wilson', 'password4444', '06 30 123 4569', 'jack.wilson@example.com', '4055 Széchenyi tér 15, Debrecen', 'User', '2024-09-01');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `foods`
--

CREATE TABLE `foods` (
  `Food_Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Ingredients` varchar(255) NOT NULL,
  `Cost` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `foods`
--

INSERT INTO `foods` (`Food_Id`, `Name`, `Ingredients`, `Cost`) VALUES
(1, 'Hagyományos Margherita', 'paradicsomos_alap-mozzarella-friss_bazsalikom', 1500),
(2, 'Szalámi Kedvenc', 'paradicsomos_alap-mozzarella-szalámi-olívabogyó', 1800),
(3, 'Bacon Varázs', 'paradicsomos_alap-mozzarella-bacon-hagyma', 1900),
(4, 'Zöldséges Élvezet', 'paradicsomos_alap-mozzarella-paprika-gomba-cukkini', 1600),
(5, 'Sonka és Ananász', 'paradicsomos_alap-mozzarella-sonka-ananász', 1700),
(6, 'Fűszeres Csirke', 'paradicsomos_alap-mozzarella-csirke-fűszerkeverék', 2000),
(7, 'Tenger Gyümölcsei', 'paradicsomos_alap-mozzarella-rák-kagyló-gyöngyösi_hagyma', 2500),
(8, 'Gombás Különlegesség', 'paradicsomos_alap-mozzarella-gomba-olívabogyó', 1750),
(9, 'Füstölt Lazac', 'tejfölös_alap-mozzarella-füstölt_lazac-hagyma-kapribogyó', 2400),
(10, 'Chili Extravaganza', 'paradicsomos_alap-mozzarella-szalámi-chili-paprika', 1900),
(11, 'Klasszikus Quattro Stagioni', 'paradicsomos_alap-mozzarella-sonka-gomba-olívabogyó-articsóka', 2200),
(12, 'Vegán Kaland', 'paradicsomos_alap-növényi_sajtszósz-zöldségek', 1600),
(13, 'Kéksajtos Élvezet', 'tejfölös_alap-mozzarella-kéksajt-dió-pezsgő-gyümölcs', 2300),
(14, 'Pikáns Kolbász', 'paradicsomos_alap-mozzarella-pikáns_kolbász-hagyma', 2000),
(15, 'Fokhagymás Rák', 'tejfölös_alap-mozzarella-fokhagyma-rák-kapribogyó', 2500),
(16, 'Mushroom Delight', 'paradicsomos_alap-mozzarella-varázsgomba-hagyma', 1900),
(17, 'Túró és Sonka', 'tejfölös_alap-mozzarella-túró-sonka-friss_hagyma', 1800),
(18, 'Diós Különlegesség', 'tejfölös_alap-mozzarella-dió-kéksajt', 2400),
(19, 'Kapros Tejfölös', 'tejfölös_alap-mozzarella-kapros_tejföl-hagyma', 1700),
(20, 'Sörös Húsimádó', 'paradicsomos_alap-mozzarella-sörben_pácolt_hús', 2100),
(21, 'Pikáns Tölteni Való', 'paradicsomos_alap-mozzarella-pikáns_töltelék', 2000),
(22, 'Kecskesajtos Különlegesség', 'tejfölös_alap-mozzarella-kecskesajt-olívabogyó', 2300),
(23, 'Sütőtökös Csoda', 'tejfölös_alap-mozzarella-sütőtök-pisztráng', 2100),
(24, 'Csemege Csemege', 'paradicsomos_alap-mozzarella-csemege_ízek', 1900),
(25, 'Halas Téli Álmok', 'tejfölös_alap-mozzarella-halas_töltelék', 2500);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingredients`
--

CREATE TABLE `ingredients` (
  `Ingredient_Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Available` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingredients`
--

INSERT INTO `ingredients` (`Ingredient_Id`, `Name`, `Available`) VALUES
(1, 'paradicsomos_alap', 14),
(2, 'tejfölös_alap', 88),
(3, 'mozzarella', 97),
(4, 'friss_bazsalikom', 20),
(5, 'szalámi', 9),
(6, 'olívabogyó', 86),
(7, 'bacon', 2),
(8, 'hagyma', 50),
(9, 'paprika', 44),
(10, 'gomba', 71),
(11, 'cukkini', 22),
(12, 'sonka', 98),
(13, 'ananász', 20),
(14, 'csirke', 9),
(15, 'fűszerkeverék', 83),
(16, 'rák', 86),
(17, 'kagyló', 83),
(18, 'gyöngyösi_hagyma', 54),
(19, 'növényi_sajtszósz', 23),
(20, 'kéksajt', 50),
(21, 'dió', 83),
(22, 'pezsgő', 62),
(23, 'pikáns_kolbász', 61),
(24, 'fokhagyma', 19),
(25, 'varázsgomba', 11),
(26, 'túró', 98),
(27, 'friss_hagyma', 58),
(28, 'kapros_tejföl', 93),
(29, 'sörben_pácolt_hús', 90),
(30, 'pikáns_töltelék', 72),
(31, 'kecskesajt', 90),
(32, 'sütőtök', 32),
(33, 'pisztráng', 89),
(34, 'csemege_ízek', 51),
(35, 'halas_töltelék', 87);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

CREATE TABLE `orders` (
  `Order_Id` int(11) NOT NULL,
  `Account_Id` int(11) NOT NULL,
  `Food_Id` int(11) NOT NULL,
  `Number` int(11) NOT NULL,
  `Cost` int(11) NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`Account_Id`);

--
-- A tábla indexei `foods`
--
ALTER TABLE `foods`
  ADD PRIMARY KEY (`Food_Id`);

--
-- A tábla indexei `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`Ingredient_Id`);

--
-- A tábla indexei `orders`
--
ALTER TABLE `orders`
  ADD KEY `Account_Id` (`Account_Id`),
  ADD KEY `Food_Id` (`Food_Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `accounts`
--
ALTER TABLE `accounts`
  MODIFY `Account_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT a táblához `foods`
--
ALTER TABLE `foods`
  MODIFY `Food_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT a táblához `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `Ingredient_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`Account_Id`) REFERENCES `accounts` (`Account_Id`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`Food_Id`) REFERENCES `foods` (`Food_Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
