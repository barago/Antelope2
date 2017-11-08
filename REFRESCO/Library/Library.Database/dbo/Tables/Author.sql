CREATE TABLE [dbo].[Author] (
    [IdAuthor]  INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NULL,
    [BirthDate] DATETIME      NULL,
    CONSTRAINT [PK_Auteur] PRIMARY KEY CLUSTERED ([IdAuthor] ASC)
);

