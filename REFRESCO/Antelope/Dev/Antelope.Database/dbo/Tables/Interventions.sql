CREATE TABLE [dbo].[Interventions] (
    [InterventionID]    INT            IDENTITY (1, 1) NOT NULL,
    [Intervenant]       NVARCHAR (MAX) NULL,
    [DateIntervention]  NVARCHAR (MAX) NULL,
    [Planifie]          BIT            NOT NULL,
    [Demandeur]         NVARCHAR (MAX) NULL,
    [Motif]             NVARCHAR (MAX) NULL,
    [DureeIntervention] INT            NOT NULL,
    [NoteFrais]         BIT            NOT NULL,
    [PrimeIntervention] REAL           NOT NULL,
    [PrimeDimanche]     REAL           NOT NULL,
    [Valide]            BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Interventions] PRIMARY KEY CLUSTERED ([InterventionID] ASC)
);

