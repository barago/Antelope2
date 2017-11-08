CREATE TABLE [dbo].[FicheSecurites] (
    [FicheSecuriteID]              INT            IDENTITY (1, 1) NOT NULL,
    [Code]                         NVARCHAR (MAX) NULL,
    [Type]                         NVARCHAR (MAX) NULL,
    [Age]                          NVARCHAR (MAX) NULL,
    [PosteDeTravailId]             INT            NULL,
    [ServiceId]                    INT            NULL,
    [DateCreation]                 DATETIME       NOT NULL,
    [DateEvenement]                DATETIME       NOT NULL,
    [PersonnesConcernees]          NVARCHAR (MAX) NULL,
    [Description]                  NVARCHAR (MAX) NOT NULL,
    [ActionImmediate1]             NVARCHAR (MAX) NULL,
    [ActionImmediate2]             NVARCHAR (MAX) NULL,
    [Temoins]                      NVARCHAR (MAX) NULL,
    [CotationFrequence]            SMALLINT       NOT NULL,
    [CotationGravite]              SMALLINT       NOT NULL,
    [FicheSecuriteTypeId]          INT            NOT NULL,
    [RisqueId]                     INT            NOT NULL,
    [DangerId]                     INT            NOT NULL,
    [CorpsHumainZoneId]            INT            NOT NULL,
    [PlageHoraireId]               INT            NULL,
    [SiteId]                       INT            NOT NULL,
    [ZoneId]                       INT            NULL,
    [LieuId]                       INT            NULL,
    [EnqueteRealisee]              BIT            NOT NULL,
    [EnqueteDate]                  DATETIME       NULL,
    [EnqueteProtagoniste]          NVARCHAR (MAX) NULL,
    [CHSCTMembre]                  NVARCHAR (MAX) NULL,
    [PersonneConcerneeId]          INT            NULL,
    [ResponsableId]                INT            NULL,
    [WorkFlowDiffusee]             BIT            NOT NULL DEFAULT 0,
    [WorkFlowAttenteASEValidation] BIT            NOT NULL DEFAULT 0,
    [WorkFlowASEValidee]           BIT            NOT NULL DEFAULT 0,
    [WorkFlowASERejetee]           BIT            NOT NULL DEFAULT 0,
    [WorkFlowCloturee]             BIT            NOT NULL DEFAULT 0,
    [WorkFlowASERejeteeCause] NVARCHAR(MAX) NULL, 
    [CompteurAnnuelSite] INT NOT NULL DEFAULT 1, 
    [WorkFlowFicheSecuriteCloturee] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_dbo.FicheSecurites] PRIMARY KEY CLUSTERED ([FicheSecuriteID] ASC),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.CorpsHumainZones_CorpsHumainZoneId] FOREIGN KEY ([CorpsHumainZoneId]) REFERENCES [dbo].[CorpsHumainZones] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Dangers_DangerId] FOREIGN KEY ([DangerId]) REFERENCES [dbo].[Dangers] ([DangerID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.FicheSecuriteTypes_FicheSecuriteTypeId] FOREIGN KEY ([FicheSecuriteTypeId]) REFERENCES [dbo].[FicheSecuriteTypes] ([FicheSecuriteTypeID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Lieux_LieuId] FOREIGN KEY ([LieuId]) REFERENCES [dbo].[Lieux] ([LieuID]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Personnes_PersonneConcerneeId] FOREIGN KEY ([PersonneConcerneeId]) REFERENCES [dbo].[Personnes] ([PersonneId]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Personnes_ResponsableId] FOREIGN KEY ([ResponsableId]) REFERENCES [dbo].[Personnes] ([PersonneId]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.PlageHoraires_PlageHoraireId] FOREIGN KEY ([PlageHoraireId]) REFERENCES [dbo].[PlageHoraires] ([PlageHoraireID]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.PosteDeTravails_PosteDeTravailId] FOREIGN KEY ([PosteDeTravailId]) REFERENCES [dbo].[PosteDeTravails] ([PosteDeTravailId]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Risques_RisqueId] FOREIGN KEY ([RisqueId]) REFERENCES [dbo].[Risques] ([RisqueId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Services] ([ServiceID]),
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Sites_SiteId] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([SiteID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.FicheSecurites_dbo.Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zones] ([ZoneID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[FicheSecurites]([ZoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ServiceId]
    ON [dbo].[FicheSecurites]([ServiceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RisqueId]
    ON [dbo].[FicheSecurites]([RisqueId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ResponsableId]
    ON [dbo].[FicheSecurites]([ResponsableId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlageHoraireId]
    ON [dbo].[FicheSecurites]([PlageHoraireId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersonneConcerneeId]
    ON [dbo].[FicheSecurites]([PersonneConcerneeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LieuId]
    ON [dbo].[FicheSecurites]([LieuId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SiteId]
    ON [dbo].[FicheSecurites]([SiteId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PosteDeTravailId]
    ON [dbo].[FicheSecurites]([PosteDeTravailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FicheSecuriteTypeId]
    ON [dbo].[FicheSecurites]([FicheSecuriteTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DangerId]
    ON [dbo].[FicheSecurites]([DangerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CorpsHumainZoneId]
    ON [dbo].[FicheSecurites]([CorpsHumainZoneId] ASC);

