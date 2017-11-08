CREATE TABLE [dbo].[ParametrageHSEs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [EmailDiffusionFS] NVARCHAR(250) NULL, 
    [EmailValidationRejetPlanActionFS] NVARCHAR(250) NULL, 
    [EmailDiffusionPlanAction] NVARCHAR(250) NULL, 
    [IsEmailDiffusion] BIT NOT NULL DEFAULT 1
)
