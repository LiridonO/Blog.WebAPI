CREATE PROCEDURE [dbo].[usp_CommentsSelect]
(
	@Id UNIQUEIDENTIFIER = NULL,
	@BlogEntityId UNIQUEIDENTIFIER = NULL,
	@CommentId UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		c.Id,
		c.Content,
		c.BlogEntityId,
		c.[Status],
		c.CommentId,
		c.InsertedBy,
		c.InsertedDate,
		c.LastEditedBy,
		c.LastEditedDate,
		c.DeletedBy,
		c.DeletedDate,
		c.IsDeleted

	FROM Comments c WITH(INDEX(0)NOLOCK) LEFT JOIN
	Blogs as b on c.Id = b.Id
	WHERE (@Id IS NULL OR c.Id = @Id) AND c.IsDeleted IS NULL

	OPTION(RECOMPILE)

END