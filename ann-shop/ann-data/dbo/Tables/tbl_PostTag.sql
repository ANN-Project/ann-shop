﻿CREATE TABLE [dbo].[tbl_PostTag] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (250) NOT NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [Slug]            NVARCHAR (250) NULL,
    [Image]           NVARCHAR (250) NULL,
    [MetaTitle]       NVARCHAR (250) NULL,
    [MetaDescription] NVARCHAR (MAX) NULL,
    [CreatedBy]       INT            NULL,
    [CreatedDate]     DATETIME       NULL,
    [ModifiedBy]      INT            NULL,
    [ModifiedDate]    DATETIME       NULL,
    CONSTRAINT [PK_tbl_PostTag] PRIMARY KEY CLUSTERED ([ID] ASC)
);

