CREATE PROCEDURE [dbo].[usp_BlogLikesUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@UserId UNIQUEIDENTIFIER,
	@BlogEntityId UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE BlogLikes
		SET
		UserId = @UserId,
		BlogEntityId = @BlogEntityId

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END
		