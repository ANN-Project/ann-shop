CREATE TABLE [dbo].[tbl_ProductInCategory] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [CategoryID] INT NOT NULL,
    [ProductID]  INT NOT NULL,
    [CreatedBy]        INT            NULL,
    [CreatedDate]      DATETIME       NULL,
    [ModifiedBy]       INT            NULL,
    [ModifiedDate]     DATETIME       NULL,
    CONSTRAINT [PK_tbl_ProductInCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
);

