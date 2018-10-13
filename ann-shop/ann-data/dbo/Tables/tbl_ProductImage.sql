CREATE TABLE [dbo].[tbl_ProductImage] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductID]   INT            NOT NULL,
    [Image]       NVARCHAR (250) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedBy]   INT            NULL,
    [CreatedDate] DATETIME       NULL,
    CONSTRAINT [PK_tbl_ProductImage] PRIMARY KEY CLUSTERED ([ID] ASC)
);

