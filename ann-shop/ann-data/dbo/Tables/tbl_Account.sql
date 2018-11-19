CREATE TABLE [dbo].[tbl_Account] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [Name]         NVARCHAR (100) NULL,
    [Email]        NVARCHAR (200) NOT NULL,
    [Status]       INT            NULL,
    [Role]         NVARCHAR (100) NULL,
    [CustomerID]   INT            NULL,
    [CreatedBy]    INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_tbl_Account] PRIMARY KEY CLUSTERED ([ID] ASC)
);

