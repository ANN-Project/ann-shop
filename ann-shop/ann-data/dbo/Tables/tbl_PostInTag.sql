CREATE TABLE [dbo].[tbl_PostInTag] (
    [ID]     INT IDENTITY (1, 1) NOT NULL,
    [PostID] INT NOT NULL,
    [TagID]  INT NOT NULL,
    CONSTRAINT [PK_tbl_PostInTag] PRIMARY KEY CLUSTERED ([ID] ASC)
);

