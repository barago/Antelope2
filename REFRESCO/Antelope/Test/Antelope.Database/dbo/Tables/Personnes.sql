CREATE TABLE [dbo].[Personnes] (
    [PersonneId] INT              IDENTITY (1, 1) NOT NULL,
    [Nom]        NVARCHAR (MAX)   COLLATE French_CI_AI NULL,
    [Prenom]     NVARCHAR (MAX)   COLLATE French_CI_AI NULL,
    [Guid]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Personnes] PRIMARY KEY CLUSTERED ([PersonneId] ASC)
);
