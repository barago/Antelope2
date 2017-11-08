CREATE TABLE [dbo].[ImportNonConformites]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Attendu] NVARCHAR(MAX) NULL, 
    [Cause] NVARCHAR(MAX) NULL, 
    [NonConformiteDomaineId] INT NOT NULL, 
    [NonConformiteGraviteId] INT NOT NULL, 
    [NonConformiteOrigineId] INT NOT NULL, 
    [SiteId] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
)
