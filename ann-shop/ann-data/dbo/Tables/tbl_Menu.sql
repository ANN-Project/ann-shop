CREATE TABLE [dbo].[tbl_Menu]
(
	[ID] INT IDENTITY (1, 1) NOT NULL, 
    [Slug] NVARCHAR(100) NULL, 
    [Name] NVARCHAR(150) NULL, 
    [Location] NVARCHAR(150) NULL,
    [Order] INT NULL DEFAULT 0,
    [CreateBy] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [PK_tbl_Menu] PRIMARY KEY CLUSTERED ([ID] ASC)
)
