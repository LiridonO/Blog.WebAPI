CREATE PROCEDURE [dbo].[usp_BlogFragmentsDelete]
(
	@Id UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON
	
	update BlogFragments  set IsDeleted = 1, DeletedBy = @DeletedBy, DeletedDate = GetDate()
		where id = @id
	
	OPTION(RECOMPILE)
END