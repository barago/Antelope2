CREATE TABLE [dbo].[Lieux] (
    [LieuID]     INT            IDENTITY (1, 1) NOT NULL,
    [ZoneId]     INT            NOT NULL,
    [LieuTypeId] INT            NULL,
    [Nom]        NVARCHAR (100) NULL,
    [Rang] INT NULL, 
    CONSTRAINT [PK_dbo.Lieux] PRIMARY KEY CLUSTERED ([LieuID] ASC),
    CONSTRAINT [FK_dbo.Lieux_dbo.Zones_ZoneId] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zones] ([ZoneID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ZoneId]
    ON [dbo].[Lieux]([ZoneId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LieuTypeId]
    ON [dbo].[Lieux]([LieuTypeId] ASC);

