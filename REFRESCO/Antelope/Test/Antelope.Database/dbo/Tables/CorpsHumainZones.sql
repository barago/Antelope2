CREATE TABLE [dbo].[CorpsHumainZones] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Nom]  NVARCHAR (MAX) NULL,
    [Code] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.CorpsHumainZones] PRIMARY KEY CLUSTERED ([Id] ASC)
);

