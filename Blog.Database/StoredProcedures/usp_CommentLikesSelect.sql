CREATE PROCEDURE [dbo].[usp_CommentLikesSelect]
(
	@Id UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		
		cl.Id,
		cl.CommentId,
		cl.UserId

	FROM CommentLikes cl WITH(INDEX(0)NOLOCK) LEFT JOIN
	Comments as c on cl.Id = c.Id
	WHERE(@Id IS NULL OR cl.Id = @Id)

	OPTION(RECOMPILE)
END
