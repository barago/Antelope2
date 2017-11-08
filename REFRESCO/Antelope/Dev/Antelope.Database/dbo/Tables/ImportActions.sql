CREATE TABLE [dbo].[ImportActions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [NonConformiteId] INT NOT NULL, 
    [Titre] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [DateButoireInitiale] DATETIME NOT NULL, 
    [DateButoireNouvelle] DATETIME NULL, 
    [ResponsableNom] NVARCHAR(255) NOT NULL, 
    [ResponsablePrenom] NVARCHAR(255) NOT NULL, 
    [VerificateurNom] NVARCHAR(255) NULL, 
    [VerificateurPrenom] NVARCHAR(255) NULL, 
    [Avancement] NVARCHAR(MAX) NULL, 
    [CritereEfficaciteVerification] NVARCHAR(MAX) NULL, 
    [CommentaireEfficaciteVerification] NVARCHAR(MAX) NULL, 
    [RealiseDate] DATETIME NULL, 
    [VerifieDate] DATETIME NULL, 
)
