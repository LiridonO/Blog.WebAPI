CREATE PROCEDURE [dbo].[usp_BlogsSelect]
(
	@Id UNIQUEIDENTIFIER = NULL,
	@HeaderImageId UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		b.Id,
		b.Title,
		b.ShortDescription,
		b.HeaderImageId,
		b.[Views],
		b.InsertedBy,
		b.InsertedDate,
		b.LastEditedBy,
		b.LastEditedDate,
		b.DeletedBy,
		b.DeletedDate,
		b.IsDeleted

	FROM Blogs b WITH(INDEX(0)NOLOCK) LEFT JOIN
	Documents as d on b.Id = d.Id
	WHERE (@Id IS NULL OR b.Id = @Id) AND b.IsDeleted IS NULL

	OPTION(RECOMPILE)
END