﻿CREATE TABLE [dbo].[UserLogins]
(
	[LoginProvider] NVARCHAR(450) NOT NULL,
	[ProviderKey] NVARCHAR(450) NOT NULL,
	[ProviderDisplayName] NVARCHAR(MAX) NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT PK_UserLogins_LoginProvider PRIMARY KEY(LoginProvider) WITH(FILLFACTOR=90),
	CONSTRAINT FK_UserLogins_UserId FOREIGN KEY(UserId) REFERENCES Users(Id)
)
