CREATE PROCEDURE [dbo].[usp_TagsDelete]
(
	@Id UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Tags
		SET
			IsDeleted = 1,
			DeletedBy = @DeletedBy,
			DeletedDate = GETDATE()

	OPTION(RECOMPILE)
END