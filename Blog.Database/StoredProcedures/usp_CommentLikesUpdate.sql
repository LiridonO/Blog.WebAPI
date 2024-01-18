CREATE PROCEDURE [dbo].[usp_CommentLikesUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@CommentId UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE CommentLikes
		SET
		CommentId = @CommentId,
		UserId = @UserId

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END
		