CREATE PROCEDURE [dbo].[usp_BlogFragmentsUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@BlogEntityId UNIQUEIDENTIFIER,
	@ImageId UNIQUEIDENTIFIER,
	@ImageTitle NVARCHAR(MAX),
	@ImageDescription NVARCHAR(MAX),
	@Order INT,
	@SubTitle NVARCHAR(MAX),
	@Content NVARCHAR(MAX),
	@LastEditedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE BlogFragments
		SET
		BlogEntityId = @BlogEntityId,
		ImageId = @ImageId,
		ImageTitle = @ImageTitle,
		ImageDescription = @ImageDescription,
		[Order] = @Order,
		SubTitle = @SubTitle,
		Content = @Content,
		LastEditedBy = @LastEditedBy,
		LastEditedDate = GetDate()

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END