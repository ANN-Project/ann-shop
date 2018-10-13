CREATE TABLE [dbo].[tbl_AttributeValue] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [AttributeID]    INT            NOT NULL,
    [AttributeName]  NVARCHAR (50)  NULL,
    [AttributeValue] NVARCHAR (100) NULL,
    [SKUText]        NVARCHAR (50)  NULL,
    [CreatedBy]      INT            NULL,
    [CreatedDate]    DATETIME       NULL,
    CONSTRAINT [PK_tbl_AttributeValue] PRIMARY KEY CLUSTERED ([ID] ASC)
);

