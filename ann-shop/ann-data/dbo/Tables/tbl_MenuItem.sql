CREATE TABLE [dbo].[tbl_MenuItem]
(
	[ID] INT IDENTITY (1, 1) NOT NULL, 
    [MenuID] INT NOT NULL, 
    [ParentID] INT NOT NULL DEFAULT 0, 
    [Name] NVARCHAR(150) NULL,
	[URL] NVARCHAR(250) NULL, 
    [Order] INT NULL DEFAULT 0,
    [CreateBy] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL,
    CONSTRAINT [PK_tbl_MenuItem] PRIMARY KEY CLUSTERED ([ID] ASC)
)
