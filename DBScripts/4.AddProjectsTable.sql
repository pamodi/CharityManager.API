CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [Category] nvarchar(max) NULL,
    [Coordinator] nvarchar(max) NULL,
    [DeletedAt] datetimeoffset NULL,
    [CreatedAt] datetimeoffset NOT NULL,
    [UpdatedAt] datetimeoffset NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250129164032_AddProjectsTable', N'9.0.1');
