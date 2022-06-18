-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 18 2022 г., 21:13
-- Версия сервера: 8.0.24
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `test_data`
--

-- --------------------------------------------------------

--
-- Структура таблицы `contacts`
--

CREATE TABLE `contacts` (
  `id` int NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `number_phone` varchar(11) NOT NULL,
  `images` varchar(1000) NOT NULL,
  `note` varchar(3000) NOT NULL,
  `birthd_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `contacts`
--

INSERT INTO `contacts` (`id`, `first_name`, `last_name`, `number_phone`, `images`, `note`, `birthd_date`) VALUES
(1, 'Риддик', 'Ричард', '88005553535', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMGwlhNFVg9aFvvlRmy0KDPK6tRMRszP5Hdw&usqp=CAU', 'По версии Риддика, в одной из тюрем за двадцать ментоловых сигарет тюремный врач сделал ему операцию на глаза, поэтому его специфическое зрение, позволяющее видеть в темноте, помогает выжить героям фильма, однако позже выясняется, что это ложь. Правда о появлении этих глаз рассказывается в игре «Escape from Butcher Bay», где становится ясно, что доктор не имеет к этому отношения[4]. По сюжету игры предлагается версия, что Риддик осознал себя как фурианца, и связь с предками вернула ему родное зрение. В книге «Хроники Риддика» Алана Дина Фостера предлагается иная версия, по которой Риддик был элитным бойцом Альянса, искусственно выведенным элементалями, которые пытались воскресить расу фурианцев, но вместо этого у них получился только Риддик и чешуйчатые собаки (Риддик встречается с ними на планете-тюрьме Крематория, и они сразу узнают его).', '2015-07-20');

-- --------------------------------------------------------

--
-- Структура таблицы `notes`
--

CREATE TABLE `notes` (
  `id` int NOT NULL,
  `header` varchar(250) NOT NULL,
  `text` varchar(500) NOT NULL,
  `imageuri` varchar(1000) NOT NULL,
  `DeadLine` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `notes`
--

INSERT INTO `notes` (`id`, `header`, `text`, `imageuri`, `DeadLine`) VALUES
(1, 'Выгулять рыбок', 'необходимо слетать на марс', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRoxezM2_rCliYl7B0CFrJZvr6GE1oBILbnKg&usqp=CAU', '2022-05-28'),
(5, 'выгулять слона', 'угу', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeUh_2vi2MoVZNH3CtcdYligooTAD6LhVjMA&usqp=CAU', '2022-05-30');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `login` varchar(15) NOT NULL,
  `password` varchar(200) NOT NULL,
  `LastDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `LastDate`) VALUES
(1, 'admin', 'admin', '2022-05-26 19:08:39'),
(2, 'rolf', 'ralf', '2022-05-26 19:14:16'),
(4, 'aaa', 'aaa', '2022-05-26 20:33:16'),
(5, 'bbb', 'bbb', '2022-05-26 20:35:37');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `contacts`
--
ALTER TABLE `contacts`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `notes`
--
ALTER TABLE `notes`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `uniq` (`login`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `contacts`
--
ALTER TABLE `contacts`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `notes`
--
ALTER TABLE `notes`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
