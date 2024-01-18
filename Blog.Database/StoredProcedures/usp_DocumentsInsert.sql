CREATE PROCEDURE [dbo].[usp_DocumentsInsert]
(
	@Name NVARCHAR(MAX),
	@FileNameGuid NVARCHAR(MAX),
	@FileMimeType NVARCHAR(MAX),
	@InsertedBy UNIQUEIDENTIFIER,
	@InsertedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON;

	declare @id UNIQUEIDENTIFIER

	select @id = NEWID()

	INSERT INTO
			Documents
			(
				Id,
				[Name],
				FileNameGuid,
				FileMimeType,
				InsertedBy,
				InsertedDate
			)
			VALUES
			(
				@Id,
				@Name,
				@FileNameGuid,
				@FileMimeType,
				@InsertedBy,
				@InsertedDate
			)

	SELECT * FROM Documents WHERE id = @id

	OPTION(RECOMPILE)
END
