CREATE TABLE [dbo].[tbl_ProductInCategory] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [ProductID]  INT NOT NULL,
    [CategoryID] INT NOT NULL,
    CONSTRAINT [PK_tbl_ProductInCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
);

