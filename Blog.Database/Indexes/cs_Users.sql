CREATE NONCLUSTERED COLUMNSTORE INDEX [cs_Users]
	ON Users
	(
		[UserName],
		[Email]
	)