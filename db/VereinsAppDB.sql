--
-- Datenbank: `VereinsAppDB`
--

CREATE TABLE `cashflow` (
  `flow_id` bigint(20) NOT NULL,
  `flow_data_date` date DEFAULT NULL,
  `flow_cash_date` date DEFAULT NULL,
  `flow_description` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `flow_target` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `flow_amount` decimal(15,2) DEFAULT NULL,
  `flow_additional_information` mediumtext COLLATE utf16_unicode_ci,
  `flow_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `flow_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci;


CREATE TABLE `expeditions` (
  `exp_id` bigint(20) NOT NULL,
  `exp_name` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `exp_city` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `exp_organisation` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `exp_date_from` date DEFAULT NULL,
  `exp_date_to` date DEFAULT NULL,
  `exp_start_time` time DEFAULT NULL,
  `exp_additionals` mediumtext COLLATE utf16_unicode_ci,
  `exp_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `exp_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci COMMENT='Ausrückungen';

CREATE TABLE `expedition_members` (
  `exp_mem_exp_id` bigint(20) NOT NULL,
  `exp_mem_id` int(11) NOT NULL,
  `exp_mem_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `exp_mem_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci;

CREATE TABLE `members` (
  `mem_id` int(11) NOT NULL,
  `mem_name` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_firstname` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_street` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_zip` varchar(10) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_city` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_country` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_phone` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_mail` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_function` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_grade` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `mem_birthday` date DEFAULT NULL,
  `mem_start` date DEFAULT NULL,
  `mem_end` date DEFAULT NULL,
  `mem_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `mem_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci COMMENT='Mitglieder';

CREATE TABLE `system` (
  `sys_key` varchar(32) COLLATE utf16_unicode_ci NOT NULL DEFAULT '',
  `sys_value` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `sys_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `sys_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci COMMENT='System-Hinterlegungen';


INSERT INTO `system` (`sys_key`, `sys_value`, `sys_change`, `sys_user`) VALUES
('version', 'v1r1m0', NULL, 'system');

CREATE TABLE `users` (
  `user_id` varchar(128) COLLATE utf16_unicode_ci NOT NULL,
  `user_password` varchar(128) COLLATE utf16_unicode_ci NOT NULL,
  `user_name` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL,
  `user_last_login` timestamp NULL DEFAULT NULL,
  `user_status` tinyint(1) DEFAULT NULL,
  `user_sec_user` tinyint(1) DEFAULT NULL,
  `user_sec_member` tinyint(1) DEFAULT NULL,
  `user_sec_expedition` tinyint(1) DEFAULT NULL,
  `user_sec_cash` tinyint(1) DEFAULT NULL,
  `user_change` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `user_user` varchar(128) COLLATE utf16_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci;


INSERT INTO `users` (`user_id`, `user_password`, `user_name`, `user_last_login`, `user_status`, `user_sec_user`, `user_sec_member`, `user_sec_expedition`, `user_sec_cash`, `user_change`, `user_user`) VALUES
('admin', '21232f297a57a5a743894a0e4a801fc3', 'Administrator', NULL, 1, 1, 1, 1, 1, NULL, 'system');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `cashflow`
--
ALTER TABLE `cashflow`
  ADD PRIMARY KEY (`flow_id`);

--
-- Indizes für die Tabelle `expeditions`
--
ALTER TABLE `expeditions`
  ADD PRIMARY KEY (`exp_id`);

--
-- Indizes für die Tabelle `expedition_members`
--
ALTER TABLE `expedition_members`
  ADD PRIMARY KEY (`exp_mem_exp_id`,`exp_mem_id`);

--
-- Indizes für die Tabelle `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`mem_id`);

--
-- Indizes für die Tabelle `system`
--
ALTER TABLE `system`
  ADD PRIMARY KEY (`sys_key`);

--
-- Indizes für die Tabelle `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);
COMMIT;