CREATE PROCEDURE [dbo].[usp_CommentsUpdate]
(
	@Id UNIQUEIDENTIFIER,
	@Content NVARCHAR(MAX),
	@BlogEntityId UNIQUEIDENTIFIER,
	@Status TINYINT,
	@CommentId UNIQUEIDENTIFIER,
	@LastEditedBy UNIQUEIDENTIFIER
)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE Comments
		SET
		Content = @Content,
		BlogEntityId = @BlogEntityId,
		[Status] = @Status,
		CommentId = @CommentId,
		LastEditedBy = @LastEditedBy,
		LastEditedDate = GETDATE()

		WHERE
		(
			Id = @Id
		)
		OPTION(RECOMPILE)
END
		