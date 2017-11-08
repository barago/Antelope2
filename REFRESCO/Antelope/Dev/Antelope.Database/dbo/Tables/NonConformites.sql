CREATE TABLE [dbo].[NonConformites]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Date] DATE NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Attendu] NVARCHAR(MAX) NULL, 
    [Cause] NVARCHAR(MAX) NULL, 
    [NonConformiteDomaineId] INT NULL, 
    [NonConformiteGraviteId] INT NULL, 
    [NonConformiteOrigineId] INT NULL, 
    [SiteId] INT NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    [DateCreation] DATETIME NOT NULL, 
    [CompteurAnnuelSite] INT NOT NULL, 
    [ServiceTypeId] INT NOT NULL DEFAULT 7, 
    CONSTRAINT [FK_NonConformite_NonConformiteDomaines] FOREIGN KEY ([NonConformiteDomaineId]) REFERENCES [NonConformiteDomaines]([Id]), 
    CONSTRAINT [FK_NonConformites_NonConformiteOrigines] FOREIGN KEY ([NonConformiteOrigineId]) REFERENCES [NonConformiteOrigines]([Id]), 
    CONSTRAINT [FK_NonConformites_NonConformiteGravites] FOREIGN KEY ([NonConformiteGraviteId]) REFERENCES [NonConformiteGravites]([Id]), 
    CONSTRAINT [FK_NonConformites_Sites] FOREIGN KEY ([SiteId]) REFERENCES [Sites]([SiteId]), 
    CONSTRAINT [FK_NonConformites_ServiceTypes] FOREIGN KEY ([ServiceTypeId]) REFERENCES [ServiceTypes]([ServiceTypeId]) 
);

GO

CREATE INDEX [IX_NonConformites_NonConformiteDomaineId] ON [dbo].[NonConformites] (NonConformiteDomaineId);

GO
CREATE INDEX [IX_NonConformites_NonConformiteGraviteId] ON [dbo].[NonConformites] (NonConformiteGraviteId);

GO
CREATE INDEX [IX_NonConformites_NonConformiteOrigineId] ON [dbo].[NonConformites] (NonConformiteOrigineId);

GO

CREATE INDEX [IX_NonConformites_SiteId] ON [dbo].[NonConformites] (SiteId);

GO

CREATE INDEX [IX_NonConformites_ServiceTypeId] ON [dbo].[NonConformites] (ServiceTypeId);

GO