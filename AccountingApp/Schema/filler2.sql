DROP DATABASE IF EXISTS [AccountingApp];
CREATE DATABASE [AccountingApp];

DROP TABLE IF EXISTS [Department];

CREATE TABLE [Department] ([id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY);

ALTER TABLE [Department] ADD
	[name] VARCHAR(30) NOT NULL;