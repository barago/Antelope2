CREATE TABLE [dbo].[FilePaths]
(
	[FilePathId] INT NOT NULL PRIMARY KEY, 
    [FileName] TEXT NOT NULL, 
    [FileType] NVARCHAR(100) NOT NULL, 
    [NonConformiteId] INT NULL, 
    [FicheSecuriteId] INT NULL,
	[Show] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_FilePaths_NonConformites] FOREIGN KEY ([NonConformiteId]) REFERENCES [NonConformites]([Id]),
	CONSTRAINT [FK_FilePaths_FicheSecurites] FOREIGN KEY ([FicheSecuriteId]) REFERENCES [FicheSecurites]([FicheSecuriteId])
)
