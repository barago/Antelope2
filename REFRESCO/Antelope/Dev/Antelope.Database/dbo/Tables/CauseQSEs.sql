CREATE TABLE [dbo].[CauseQSEs] (
    [CauseQSEId]      INT            IDENTITY (1, 1) NOT NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [FicheSecuriteId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.CauseQSEs] PRIMARY KEY CLUSTERED ([CauseQSEId] ASC),
    CONSTRAINT [FK_dbo.CauseQSEs_dbo.FicheSecurites_FicheSecuriteId] FOREIGN KEY ([FicheSecuriteId]) REFERENCES [dbo].[FicheSecurites] ([FicheSecuriteID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FicheSecuriteId]
    ON [dbo].[CauseQSEs]([FicheSecuriteId] ASC);

