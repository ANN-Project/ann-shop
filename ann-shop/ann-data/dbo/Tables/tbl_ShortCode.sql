CREATE TABLE [dbo].[tbl_ShortCode]
(
    [ID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [Container] NVARCHAR(MAX) NULL,
    [CreateBy] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [ModifiedBy] INT NULL, 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [PK_tbl_ShortCode] PRIMARY KEY CLUSTERED ([ID] ASC)
)
