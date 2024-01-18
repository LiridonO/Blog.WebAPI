CREATE PROCEDURE [dbo].[usp_DocumentsDelete]
(
	@Id UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Documents
	SET IsDeleted = 1,
		DeletedBy = @DeletedBy,
		DeletedDate = GETDATE()

	OPTION(RECOMPILE)
END