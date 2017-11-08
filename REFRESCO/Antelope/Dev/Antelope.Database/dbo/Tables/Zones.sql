CREATE TABLE [dbo].[Zones] (
    [ZoneID]     INT IDENTITY (1, 1) NOT NULL,
    [SiteId]     INT NOT NULL,
    [ZoneTypeId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Zones] PRIMARY KEY CLUSTERED ([ZoneID] ASC),
    CONSTRAINT [FK_dbo.Zones_dbo.Sites_SiteId] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([SiteID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Zones_dbo.ZoneTypes_ZoneTypeId] FOREIGN KEY ([ZoneTypeId]) REFERENCES [dbo].[ZoneTypes] ([ZoneTypeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneTypeId]
    ON [dbo].[Zones]([ZoneTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SiteId]
    ON [dbo].[Zones]([SiteId] ASC);

