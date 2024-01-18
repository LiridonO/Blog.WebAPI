CREATE PROCEDURE [dbo].[usp_BlogsInsert]
(
	@Title NVARCHAR(MAX),
	@ShortDescription NVARCHAR(MAX),
	@HeaderImageId UNIQUEIDENTIFIER NULL,
	@Views INT,
	@InsertedBy UNIQUEIDENTIFIER,
	@InsertedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON

	declare @id UNIQUEIDENTIFIER;

	select @id = newid()

	INSERT INTO
			Blogs
			(
				Id,
				Title,
				ShortDescription,
				HeaderImageId,
				[Views],
				InsertedBy,
				InsertedDate
			)
			VALUES
			(
				@Id,
				@Title,
				@ShortDescription,
				@HeaderImageId,
				@Views,
				@InsertedBy,
				@InsertedDate
			)

	select * from Blogs where id = @id

	OPTION(RECOMPILE)
END