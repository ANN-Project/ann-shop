CREATE TABLE [dbo].[tbl_Comment] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [ParentID]     INT            NULL,
    [PostID]       INT            NOT NULL,
    [PostType]     NVARCHAR (15)  NOT NULL,
    [Author]       NVARCHAR (150) NOT NULL,
    [Email]        NVARCHAR (250) NULL,
    [Phone]        NVARCHAR (15)  NULL,
    [Content]      NVARCHAR (MAX) NOT NULL,
    [Approved]     INT            NULL,
    [Hidden]       INT            NULL,
    [CreatedBy]    INT            NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedBy]   INT            NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_tbl_Comment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

