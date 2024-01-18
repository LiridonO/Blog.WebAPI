CREATE PROCEDURE [dbo].[usp_BlogsDelete]
(
	@Id UNIQUEIDENTIFIER,
	@DeletedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON
	
	update Blogs  set IsDeleted = 1, DeletedBy = @DeletedBy, DeletedDate = GetDate()
		where id = @id
	
	OPTION(RECOMPILE)
END