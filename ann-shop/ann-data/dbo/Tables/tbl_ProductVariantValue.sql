CREATE TABLE [dbo].[tbl_ProductVariantValue] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [VariantID]      INT            NOT NULL,
    [VariantSKU]     NVARCHAR (30)  NOT NULL,
    [AttributeID]    INT            NOT NULL,
    [AttributeName]  NVARCHAR (50)  NULL,
    [AttributeValue] NVARCHAR (100) NULL,
    [CreatedBy]      INT            NULL,
    [CreatedDate]    DATETIME       NULL,
    CONSTRAINT [PK_tbl_ProductVariantValue] PRIMARY KEY CLUSTERED ([ID] ASC)
);

