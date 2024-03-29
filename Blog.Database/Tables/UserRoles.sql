﻿CREATE TABLE [dbo].[UserRoles]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT FK_UserRoles_UserId FOREIGN KEY(UserId) REFERENCES Users(Id),
	CONSTRAINT FK_UserRoles_RoleId FOREIGN KEY(RoleId) REFERENCES Roles(Id)
)
