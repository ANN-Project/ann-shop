CREATE TABLE [dbo].[tbl_ProductInTag] (
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [ProductID] INT NOT NULL,
    [TagID]     INT NOT NULL,
    CONSTRAINT [PK_tbl_ProductInTag] PRIMARY KEY CLUSTERED ([ID] ASC)
);

