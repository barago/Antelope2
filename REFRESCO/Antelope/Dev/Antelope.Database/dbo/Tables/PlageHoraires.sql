CREATE TABLE [dbo].[PlageHoraires] (
    [PlageHoraireID] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]            NVARCHAR (MAX) NULL,
    [Rang] INT NULL, 
    CONSTRAINT [PK_dbo.PlageHoraires] PRIMARY KEY CLUSTERED ([PlageHoraireID] ASC)
);

