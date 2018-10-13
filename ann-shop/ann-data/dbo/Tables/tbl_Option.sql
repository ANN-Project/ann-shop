CREATE TABLE [dbo].[tbl_Option] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (200) NOT NULL,
    [Value] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tbl_Option] PRIMARY KEY CLUSTERED ([ID] ASC)
);

