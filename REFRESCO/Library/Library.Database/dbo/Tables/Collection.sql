CREATE TABLE [dbo].[Collection] (
    [IdCollection] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED ([IdCollection] ASC)
);

