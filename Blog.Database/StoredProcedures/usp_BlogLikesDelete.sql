﻿CREATE PROCEDURE [dbo].[usp_BlogLikesDelete]
(
	@Id UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON
	
	DELETE FROM Tags Where Id = @Id
	OPTION(RECOMPILE)
END