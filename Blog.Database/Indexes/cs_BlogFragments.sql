CREATE NONCLUSTERED COLUMNSTORE INDEX [cs_BlogFragments]
	ON BlogFragments
	(
		[BlogEntityId],
		[ImageId]
	)