CREATE PROCEDURE [dbo].[usp_BlogLikesSelect]
(
	@Id UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		
		bl.Id,
		bl.UserId,
		bl.BlogEntityId

	FROM BlogLikes bl WITH(INDEX(0)NOLOCK) LEFT JOIN
	Blogs as b on bl.Id = b.Id
	WHERE(@Id IS NULL OR bl.Id = @Id)

	OPTION(RECOMPILE)
END
