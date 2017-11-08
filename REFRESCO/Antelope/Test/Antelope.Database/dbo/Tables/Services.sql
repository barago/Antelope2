CREATE TABLE [dbo].[Services] (
    [ServiceID]     INT IDENTITY (1, 1) NOT NULL,
    [SiteId]        INT NOT NULL,
    [ServiceTypeId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Services] PRIMARY KEY CLUSTERED ([ServiceID] ASC),
    CONSTRAINT [FK_dbo.Services_dbo.ServiceTypes_ServiceTypeId] FOREIGN KEY ([ServiceTypeId]) REFERENCES [dbo].[ServiceTypes] ([ServiceTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Services_dbo.Sites_SiteId] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites] ([SiteID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SiteId]
    ON [dbo].[Services]([SiteId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ServiceTypeId]
    ON [dbo].[Services]([ServiceTypeId] ASC);

