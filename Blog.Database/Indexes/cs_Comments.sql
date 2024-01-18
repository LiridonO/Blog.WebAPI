CREATE NONCLUSTERED COLUMNSTORE INDEX [cs_Comments]
	on Comments
	(
		[BlogEntityId],
		[CommentId]
	)