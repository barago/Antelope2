CREATE TABLE [dbo].[ADRoles] (
    [ADRoleID] INT            IDENTITY (1, 1) NOT NULL,
    [RoleCode] NVARCHAR (MAX) NULL,
    [RoleType] NVARCHAR (MAX) NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Guid]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ADRoles] PRIMARY KEY CLUSTERED ([ADRoleID] ASC)
);

