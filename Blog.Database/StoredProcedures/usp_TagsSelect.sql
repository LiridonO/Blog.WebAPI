	CREATE PROCEDURE [dbo].[usp_TagsSelect]
(
	@Id UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		t.Id,
		t.[Name],
		t.[Description],
		t.InsertedBy,
		t.InsertedDate,
		t.LastEditedBy,
		t.LastEditedDate,
		t.DeletedBy,
		t.DeletedDate,
		t.IsDeleted

	FROM Tags as t WITH(INDEX(0)NOLOCK)
	WHERE (@Id IS NULL OR t.Id = @Id) AND t.IsDeleted IS NULL

	OPTION(RECOMPILE)

END