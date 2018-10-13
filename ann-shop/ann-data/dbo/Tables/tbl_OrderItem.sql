CREATE TABLE [dbo].[tbl_OrderItem] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [OrderID]          INT            NOT NULL,
    [ProductID]        INT            NULL,
    [ProductVariantID] INT            NULL,
    [SystemUsername]   NVARCHAR (50)  NULL,
    [SKU]              NVARCHAR (30)  NULL,
    [Name]             NVARCHAR (200) NULL,
    [Quantity]         INT            NULL,
    [Price]            FLOAT (53)     NULL,
    [Discount]         FLOAT (53)     NULL,
    [Status]           INT            NULL,
    [CreatedBy]        INT            NULL,
    [CreatedDate]      DATETIME       NULL,
    [ModifiedBy]       INT            NULL,
    [ModifiedDate]     DATETIME       NULL,
    CONSTRAINT [PK_tbl_OrderItem] PRIMARY KEY CLUSTERED ([ID] ASC)
);

