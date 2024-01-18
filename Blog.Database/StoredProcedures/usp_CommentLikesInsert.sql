CREATE PROCEDURE [dbo].[usp_CommentLikesInsert]
(
	@Id UNIQUEIDENTIFIER OUTPUT,
	@CommentId UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO
		CommentLikes
		(
			Id,
			CommentId,
			UserId
		)
		VALUES
		(
			@Id,
			@CommentId,
			@UserId
		)

	SELECT @Id as Id

	OPTION(RECOMPILE)
END