CREATE PROCEDURE [dbo].[usp_BlogFragmentsSelect]
(
	@Id UNIQUEIDENTIFIER = NULL,
	@BlogEntityId UNIQUEIDENTIFIER = NULL,
	@ImageId UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		bf.Id,
		bf.BlogEntityId,
		bf.ImageId,
		bf.ImageTitle,
		bf.ImageDescription,
		bf.[Order],
		bf.SubTitle,
		bf.Content,
		bf.InsertedBy,
		bf.InsertedDate,
		bf.LastEditedBy,
		bf.LastEditedDate,
		bf.DeletedBy,
		bf.DeletedDate,
		bf.IsDeleted

	FROM BlogFragments as bf WITH(INDEX(0)NOLOCK) LEFT JOIN
	Blogs as b on bf.Id = b.Id LEFT JOIN
	Documents as d on bf.Id = d.Id
	WHERE (@Id IS NULL OR bf.Id = @Id) and bf.IsDeleted is null

	OPTION(RECOMPILE)

END