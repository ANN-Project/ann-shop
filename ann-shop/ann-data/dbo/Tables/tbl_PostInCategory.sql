CREATE TABLE [dbo].[tbl_PostInCategory] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [PostID]     INT NOT NULL,
    [CategoryID] INT NOT NULL,
    CONSTRAINT [PK_tbl_PostInCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
);

