CREATE TABLE [dbo].[RisqueTypes] (
    [RisqueTypeId] INT            IDENTITY (1, 1) NOT NULL,
    [Nom]          NVARCHAR (MAX) NULL,
    [Rang] INT NULL, 
    CONSTRAINT [PK_dbo.RisqueTypes] PRIMARY KEY CLUSTERED ([RisqueTypeId] ASC)
);

