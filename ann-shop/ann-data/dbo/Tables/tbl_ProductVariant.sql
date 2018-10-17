CREATE TABLE [dbo].[tbl_ProductVariant] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [ParentID]      INT            NOT NULL,
    [ParentSKU]      NVARCHAR (25)  NOT NULL,
    [SKU]            NVARCHAR (30)  NOT NULL,
    [Name]           NVARCHAR (250) NULL,
    [WholesalePrice] FLOAT (53)     NULL,
    [RetailPrice]    FLOAT (53)     NULL,
    [CostOfGoods]    FLOAT (53)     NULL,
    [ManageStock]    INT            NULL,
    [StockStatus]    INT            NULL,
    [Status]         INT            NULL,
    [Image]          NVARCHAR (250) NULL,
    [Hidden]         INT            NULL,
    [CreatedBy]      INT            NULL,
    [CreatedDate]    DATETIME       NULL,
    [ModifiedBy]     INT            NULL,
    [ModifiedDate]   DATETIME       NULL,
    CONSTRAINT [PK_tbl_ProductVariant] PRIMARY KEY CLUSTERED ([ID] ASC)
);

