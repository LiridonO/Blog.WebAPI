CREATE PROCEDURE [dbo].[usp_DocumentsUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(MAX),
	@FileNameGuid NVARCHAR(MAX),
	@FileMimeType NVARCHAR(MAX),
	@LastEditedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

		UPDATE Documents
		SET
			[Name] = @Name,
			FileNameGuid = @FileNameGuid,
			FileMimeType = @FileMimeType,
			LastEditedBy = @LastEditedBy,
			LastEditedDate = GETDATE()

		WHERE
		(
			Id = @Id
		)

		OPTION(RECOMPILE)
END