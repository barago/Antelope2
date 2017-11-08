CREATE TABLE [dbo].[ActionQSEs] (
    [ActionQSEId]                       INT            IDENTITY (1, 1) NOT NULL,
    [Description]                       NVARCHAR (MAX) NULL,
    [DateButoireInitiale]               DATETIME       NOT NULL,
    [DateButoireNouvelle]               DATETIME       NULL,
    [ResponsableId]                     INT            NOT NULL,
    [Avancement]                        NVARCHAR (MAX) NULL,
    [CotationHumain]                    SMALLINT       NOT NULL,
    [CotationOrganisationnel]           SMALLINT       NOT NULL,
    [CotationTechnique]                 SMALLINT       NOT NULL,
    [CotationEfficacite]                SMALLINT       NOT NULL,
    [VerificateurId]                    INT            NULL,
    [PreuveVerification]                NVARCHAR (MAX) NULL,
    [CommentaireEfficaciteVerification] NVARCHAR (MAX) NULL,
    [Realise]                           BIT            NOT NULL,
    [RealiseDate]                       DATETIME       NULL,
    [Verifie]                           BIT            NOT NULL,
    [VerifieDate]                       DATETIME       NULL,
    [Cloture]                           BIT            NOT NULL,
    [ClotureDate]                       DATETIME       NULL,
    [CauseQSEId]                        INT            NULL,
    [NonConformiteId] INT NULL, 
    [CritereEfficaciteVerification] NVARCHAR(MAX) NULL, 
    [Titre] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_dbo.ActionQSEs] PRIMARY KEY CLUSTERED ([ActionQSEId] ASC),
    CONSTRAINT [FK_dbo.ActionQSEs_dbo.CauseQSEs_CauseQSEId] FOREIGN KEY ([CauseQSEId]) REFERENCES [dbo].[CauseQSEs] ([CauseQSEId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActionQSEs_dbo.Personnes_ResponsableId] FOREIGN KEY ([ResponsableId]) REFERENCES [dbo].[Personnes] ([PersonneId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActionQSEs_dbo.Personnes_VerificateurId] FOREIGN KEY ([VerificateurId]) REFERENCES [dbo].[Personnes] ([PersonneId]), 
    CONSTRAINT [FK_ActionQSEs_NonConformites] FOREIGN KEY ([NonConformiteId]) REFERENCES [NonConformites]([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_VerificateurId]
    ON [dbo].[ActionQSEs]([VerificateurId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ResponsableId]
    ON [dbo].[ActionQSEs]([ResponsableId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CauseQSEId]
    ON [dbo].[ActionQSEs]([CauseQSEId] ASC);

