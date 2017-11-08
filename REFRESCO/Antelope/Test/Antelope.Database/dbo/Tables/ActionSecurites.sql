CREATE TABLE [dbo].[ActionSecurites] (
    [ActionSecuriteId] INT            IDENTITY (1, 1) NOT NULL,
    [FicheSecuriteId]  INT            NOT NULL,
    [Code]             NVARCHAR (MAX) NULL,
    [Description]      NVARCHAR (MAX) NULL,
    [FaitPar]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ActionSecurites] PRIMARY KEY CLUSTERED ([ActionSecuriteId] ASC),
    CONSTRAINT [FK_dbo.ActionSecurites_dbo.FicheSecurites_FicheSecuriteId] FOREIGN KEY ([FicheSecuriteId]) REFERENCES [dbo].[FicheSecurites] ([FicheSecuriteID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FicheSecuriteId]
    ON [dbo].[ActionSecurites]([FicheSecuriteId] ASC);

