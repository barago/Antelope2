CREATE TABLE [dbo].[NonConformiteOrigines]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Nom] NVARCHAR(50) NULL, 
    [ServiceTypeId] INT NOT NULL DEFAULT 7

	CONSTRAINT [FK_NonConformiteOrigines_ServiceTypes]FOREIGN KEY ([ServiceTypeId]) REFERENCES [ServiceTypes]([ServiceTypeId]) 

);

GO

CREATE INDEX [IX_NonConformiteOrigines_ServiceTypeId] ON [dbo].[NonConformiteOrigines] (ServiceTypeId);
