CREATE TABLE [dbo].[Risques] (
    [RisqueId]     INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [RisqueTypeId] INT            NULL,
    CONSTRAINT [PK_dbo.Risques] PRIMARY KEY CLUSTERED ([RisqueId] ASC),
    CONSTRAINT [FK_dbo.Risques_dbo.RisqueTypes_RisqueTypeId] FOREIGN KEY ([RisqueTypeId]) REFERENCES [dbo].[RisqueTypes] ([RisqueTypeId])
);


GO
CREATE NONCLUSTERED INDEX [IX_RisqueTypeId]
    ON [dbo].[Risques]([RisqueTypeId] ASC);

