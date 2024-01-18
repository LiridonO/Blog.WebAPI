CREATE PROCEDURE [dbo].[usp_CommentsInsert]
(
	@Content NVARCHAR(MAX),
	@BlogEntityId UNIQUEIDENTIFIER,
	@Status TINYINT,
	@CommentId UNIQUEIDENTIFIER,
	@InsertedBy UNIQUEIDENTIFIER,
	@InsertedDate DATETIME
)
AS
BEGIN
	SET NOCOUNT ON;

	declare @id UNIQUEIDENTIFIER;

	select @id = newid()

	INSERT INTO
			Comments
			(
				Id,
				Content,
				BlogEntityId,
				[Status],
				CommentId,
				InsertedBy,
				InsertedDate
			)
			VALUES
			(
				@Id,
				@Content,
				@BlogEntityId,
				@Status,
				@CommentId,
				@InsertedBy,
				@InsertedDate
			)

	select * from Comments where id = @id

	OPTION(RECOMPILE)
END