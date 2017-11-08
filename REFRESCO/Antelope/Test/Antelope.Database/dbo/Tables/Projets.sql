CREATE TABLE [dbo].[Projets] (
    [ProjetID]       INT            IDENTITY (1, 1) NOT NULL,
    [NomProjet]      NVARCHAR (MAX) NULL,
    [StatutCouleur]  INT            NOT NULL,
    [StatutVisage]   INT            NOT NULL,
    [Commentaire]    NVARCHAR (MAX) NULL,
    [ProchaineEtape] NVARCHAR (MAX) NULL,
    [DateOuverture]  NVARCHAR (MAX) NULL,
    [DateCloture]    NVARCHAR (MAX) NULL,
    [Service]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Projets] PRIMARY KEY CLUSTERED ([ProjetID] ASC)
);

