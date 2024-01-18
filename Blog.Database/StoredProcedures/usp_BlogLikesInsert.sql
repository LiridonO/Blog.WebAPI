CREATE PROCEDURE [dbo].[usp_BlogLikesInsert]
(
	@Id UNIQUEIDENTIFIER OUTPUT,
	@UserId UNIQUEIDENTIFIER NULL,
	@BlogEntityId UNIQUEIDENTIFIER NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO
		BlogLikes
		(
			Id,
			UserId,
			BlogEntityId
		)
		VALUES
		(
			@Id,
			@UserId,
			@BlogEntityId
		)

	SELECT @Id as Id

	OPTION(RECOMPILE)
END