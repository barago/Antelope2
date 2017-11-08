CREATE TABLE [dbo].[Book] (
    [IdBook]       INT            IDENTITY (1, 1) NOT NULL,
    [IdAuthor]     INT            NOT NULL,
    [IdCollection] INT            NOT NULL,
    [Title]        NVARCHAR (500) NOT NULL,
    [Summary]      NTEXT          NOT NULL,
    [ISBN]         NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_LIVRE] PRIMARY KEY CLUSTERED ([IdBook] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([IdAuthor]) REFERENCES [dbo].[Author] ([IdAuthor]),
    CONSTRAINT [FK_Book_Collection] FOREIGN KEY ([IdCollection]) REFERENCES [dbo].[Collection] ([IdCollection])
);


GO