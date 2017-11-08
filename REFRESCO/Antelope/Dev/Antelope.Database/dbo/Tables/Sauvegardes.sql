CREATE TABLE [dbo].[Sauvegardes] (
    [SauvegardeID] INT            IDENTITY (1, 1) NOT NULL,
    [Site]         NVARCHAR (MAX) NULL,
    [Date]         FLOAT (53)     NOT NULL,
    [Volume]       REAL           NOT NULL,
    [Taux]         REAL           NOT NULL,
    [Duree]        INT            NOT NULL,
    CONSTRAINT [PK_dbo.Sauvegardes] PRIMARY KEY CLUSTERED ([SauvegardeID] ASC)
);

