CREATE TABLE [dbo].[Sites] (
    [SiteID]    INT            IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (MAX) NULL,
    [Trigramme] NVARCHAR (MAX) NULL,
    [Arouperr]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Sites] PRIMARY KEY CLUSTERED ([SiteID] ASC)
);

