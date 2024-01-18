CREATE PROCEDURE [dbo].[usp_CommentsDelete]
(
	@Id UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	Update Comments
		Set IsDeleted = 1,
			DeletedBy = @DeletedBy,
			DeletedDate = GetDate()

		where id = @id

	OPTION(RECOMPILE)

END