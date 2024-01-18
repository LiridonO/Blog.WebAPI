CREATE PROCEDURE [dbo].[usp_BlogsUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@Title NVARCHAR(MAX),
	@ShortDescription NVARCHAR(MAX),
	@HeaderImageId UNIQUEIDENTIFIER,
	@Views INT,
	@LastEditedBy UNIQUEIDENTIFIER,
	@LastEditedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Blogs
		SET
		Title = @Title,
		ShortDescription = @ShortDescription,
		HeaderImageId = @HeaderImageId,
		[Views] = @Views,
		LastEditedBy = @LastEditedBy,
		LastEditedDate = GETDATE()

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END