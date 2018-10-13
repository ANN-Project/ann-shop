CREATE TABLE [dbo].[tbl_Attribute] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Slug]         NVARCHAR (250) NOT NULL,
    [CreatedBy]    INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_tbl_Attribute] PRIMARY KEY CLUSTERED ([ID] ASC)
);

