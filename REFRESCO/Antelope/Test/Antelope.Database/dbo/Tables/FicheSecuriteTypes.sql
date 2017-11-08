CREATE TABLE [dbo].[FicheSecuriteTypes] (
    [FicheSecuriteTypeID] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]                 NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.FicheSecuriteTypes] PRIMARY KEY CLUSTERED ([FicheSecuriteTypeID] ASC)
);

