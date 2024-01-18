CREATE PROCEDURE [dbo].[usp_BlogFragmentsInsert]
(
	@BlogEntityId UNIQUEIDENTIFIER,
	@ImageId UNIQUEIDENTIFIER,
	@ImageTitle NVARCHAR(MAX),
	@ImageDescription NVARCHAR(MAX),
	@Order INT,
	@SubTitle NVARCHAR(MAX),
	@Content NVARCHAR(MAX),
	@InsertedBy UNIQUEIDENTIFIER,
	@InsertedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON;

	declare @id UNIQUEIDENTIFIER;

	select @id = newid()

	INSERT INTO
			BlogFragments
			(
				Id,
				BlogEntityId,
				ImageId,
				ImageTitle,
				ImageDescription,
				[Order],
				SubTitle,
				Content,
				InsertedBy,
				InsertedDate
			)
			VALUES
			(
				@Id,
				@BlogEntityId,
				@ImageId,
				@ImageTitle,
				@ImageDescription,
				@Order,
				@SubTitle,
				@Content,
				@InsertedBy,
				@InsertedDate
			)
	
		select * from BlogFragments where id = @id

		OPTION(RECOMPILE)

	
END