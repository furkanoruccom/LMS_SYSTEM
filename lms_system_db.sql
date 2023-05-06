-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 06 May 2023, 09:56:43
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `lms_system_db`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `lessons`
--

CREATE TABLE `lessons` (
  `Id` int(11) NOT NULL,
  `lessons_name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `lessons`
--

INSERT INTO `lessons` (`Id`, `lessons_name`) VALUES
(1, 'deneme ders'),
(2, 'Coğrafya'),
(3, 'Matematik'),
(4, 'Sunucu İşletim Sistemleri'),
(5, 'Ağ Temelleri'),
(6, 'Grafik Tasarım');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `school_work`
--

CREATE TABLE `school_work` (
  `Id` int(11) NOT NULL,
  `work_name` longtext NOT NULL,
  `teacherId` int(11) NOT NULL,
  `work_detail` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `school_work`
--

INSERT INTO `school_work` (`Id`, `work_name`, `teacherId`, `work_detail`) VALUES
(3, 'Bilgisayar Donanım Tarihinin Araştırılması', 4, 'strfdsfsing'),
(4, 'Matematik Formüllerinin Tarhinin Araştırlması', 5, 'deneme detay'),
(5, 'Otomasyon sistemi programlaması', 6, 'deneme detay'),
(6, 'Ynei Çağ Ana kadrtlar nelerdir', 7, 'deneme detay'),
(7, 'İngilizcede En Az Konuşulan diller nelerdir', 8, 'deneme detay');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `student_to_work`
--

CREATE TABLE `student_to_work` (
  `Id` int(11) NOT NULL,
  `studentId` int(11) NOT NULL,
  `workId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `student_to_work`
--

INSERT INTO `student_to_work` (`Id`, `studentId`, `workId`) VALUES
(1, 2, 1),
(2, 10, 3),
(3, 11, 4),
(4, 12, 5);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `teacher_to_lesson`
--

CREATE TABLE `teacher_to_lesson` (
  `Id` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `lessonsId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `teacher_to_lesson`
--

INSERT INTO `teacher_to_lesson` (`Id`, `userId`, `lessonsId`) VALUES
(1, 4, 1),
(2, 5, 2),
(3, 6, 3),
(4, 7, 4);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `name` longtext NOT NULL,
  `user_name` longtext NOT NULL,
  `password` longtext NOT NULL,
  `authorityId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `users`
--

INSERT INTO `users` (`Id`, `name`, `user_name`, `password`, `authorityId`) VALUES
(2, 'Abdulkadir Koçer', 'akocer', '123456', 2),
(3, 'Furkan Oruç', 'foruc', '123456', 3),
(4, 'Erokan Canbazoğlu', 'ecanbaz', 'stri123456g', 2),
(5, 'Hasan Özalp', 'halp', 'stri123456g', 2),
(6, 'Ekrem Saydam', 'esaydam', 'stri123456g', 2),
(7, 'Esra Çekiç', 'ecekic', 'stri123456g', 2),
(8, 'Recep Özen', 'rözen', 'stri123456g', 2),
(9, 'Engin Bolat', 'ebolat', 'strin435346546g', 0),
(10, 'Ahmet Balgil', 'abalgil', 'strin435346546g', 0),
(11, 'Anıl Gül', 'agul', 'strin435346546g', 0),
(12, 'Ahmet cankur', 'acakurt', 'strin435346546g', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users_authority`
--

CREATE TABLE `users_authority` (
  `Id` int(11) NOT NULL,
  `authority_name` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `users_authority`
--

INSERT INTO `users_authority` (`Id`, `authority_name`) VALUES
(1, 'Admin'),
(2, 'Öğretmen'),
(3, 'Öğrenci');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20230505132734_DbInit', '7.0.5');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `lessons`
--
ALTER TABLE `lessons`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `school_work`
--
ALTER TABLE `school_work`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `student_to_work`
--
ALTER TABLE `student_to_work`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `teacher_to_lesson`
--
ALTER TABLE `teacher_to_lesson`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `users_authority`
--
ALTER TABLE `users_authority`
  ADD PRIMARY KEY (`Id`);

--
-- Tablo için indeksler `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `lessons`
--
ALTER TABLE `lessons`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `school_work`
--
ALTER TABLE `school_work`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `student_to_work`
--
ALTER TABLE `student_to_work`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `teacher_to_lesson`
--
ALTER TABLE `teacher_to_lesson`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tablo için AUTO_INCREMENT değeri `users_authority`
--
ALTER TABLE `users_authority`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
