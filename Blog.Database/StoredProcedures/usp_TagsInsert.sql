CREATE PROCEDURE [dbo].[usp_TagsInsert]
(
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX),
	@InsertedBy UNIQUEIDENTIFIER,
	@InsertedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON;

	declare @id UNIQUEIDENTIFIER;

	select @id = NEWID()

	INSERT INTO
			Tags
			(
				Id,
				[Name],
				[Description],
				InsertedBy,
				InsertedDate
			)
			VALUES
			(
				@Id,
				@Name,
				@Description,
				@InsertedBy,
				@InsertedDate
			)
	
	SELECT * FROM Tags WHERE id = @id

	OPTION(RECOMPILE)
END