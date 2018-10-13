CREATE TABLE [dbo].[tbl_Customer] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NULL,
    [Level]        NVARCHAR (20)  NULL,
    [Nick]         NVARCHAR (100) NULL,
    [Phone]        NVARCHAR (15)  NULL,
    [Phone2]       NVARCHAR (15)  NULL,
    [Email]        NVARCHAR (250) NULL,
    [Address]      NVARCHAR (250) NULL,
    [Zalo]         NVARCHAR (100) NULL,
    [Facebook]     NVARCHAR (MAX) NULL,
    [Note]         NVARCHAR (MAX) NULL,
    [Avatar]       NVARCHAR (MAX) NULL,
    [Status]       INT            NULL,
    [CreatedBy]    INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_tbl_Customer] PRIMARY KEY CLUSTERED ([ID] ASC)
);

