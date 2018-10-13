CREATE TABLE [dbo].[tbl_Post] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (250) NOT NULL,
    [ShortDescription] NVARCHAR (MAX) NULL,
    [Content]          NVARCHAR (MAX) NULL,
    [Slug]             NVARCHAR (250) NOT NULL,
    [MetaTitle]        NVARCHAR (250) NULL,
    [MetaDescription]  NVARCHAR (MAX) NULL,
    [Status]           INT            NULL,
    [CommentSatus]     INT            NULL,
    [Image]            NVARCHAR (250) NULL,
    [ViewCount]        INT            NULL,
    [Featured]         INT            NULL,
    [CreatedBy]        INT            NULL,
    [CreatedDate]      DATETIME       NULL,
    [ModifiedBy]       INT            NULL,
    [ModifiedDate]     DATETIME       NULL,
    CONSTRAINT [PK_tbl_Post] PRIMARY KEY CLUSTERED ([ID] ASC)
);

