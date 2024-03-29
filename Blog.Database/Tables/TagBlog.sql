﻿CREATE TABLE [dbo].[TagBlog]
(
	[BlogId] UNIQUEIDENTIFIER NOT NULL,
	[TagId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT FK_TagBlog_BlogId FOREIGN KEY(BlogId) REFERENCES Blogs(Id),
	CONSTRAINT FK_TagBlog_TagId FOREIGN KEY(TagId) REFERENCES Tags(Id),
	CONSTRAINT PK_TagBlog Primary KEY(TagId, BlogId) 
)
