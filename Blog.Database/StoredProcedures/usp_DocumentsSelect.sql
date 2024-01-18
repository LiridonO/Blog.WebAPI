CREATE PROCEDURE [dbo].[usp_DocumentsSelect]
(
	@Id UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		d.Id,
		d.[Name],
		d.FileNameGuid,
		d.FileMimeType,
		d.InsertedBy,
		d.InsertedDate,
		d.LastEditedBy,
		d.LastEditedDate,
		d.DeletedBy,
		d.DeletedDate,
		d.IsDeleted

	FROM Documents as d WITH(INDEX(0)NOLOCK)
	WHERE(@Id IS NULL OR d.Id = @Id) AND d.IsDeleted IS NULL

	OPTION(RECOMPILE)
END