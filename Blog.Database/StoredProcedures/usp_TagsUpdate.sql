CREATE PROCEDURE [dbo].[usp_TagsUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX),
	@LastEditedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Tags
		SET
		[Name] = @Name,
		[Description] = @Description,
		LastEditedBy = @LastEditedBy,
		LastEditedDate = GETDATE()

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END