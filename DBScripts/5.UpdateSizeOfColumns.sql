EXEC sp_rename N'[Users].[Username]', N'UserName', 'COLUMN';

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'WhatsApp');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Users] ALTER COLUMN [WhatsApp] nvarchar(100) NULL;

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'UserName');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Users] ALTER COLUMN [UserName] nvarchar(50) NULL;

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Role');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Users] ALTER COLUMN [Role] nvarchar(50) NOT NULL;

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(100) NULL;

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'LastName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Users] ALTER COLUMN [LastName] nvarchar(100) NULL;

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'FirstName');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var7 + '];');
UPDATE [Users] SET [FirstName] = N'' WHERE [FirstName] IS NULL;
ALTER TABLE [Users] ALTER COLUMN [FirstName] nvarchar(100) NOT NULL;
ALTER TABLE [Users] ADD DEFAULT N'' FOR [FirstName];

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(100) NULL;

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Description');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Users] ALTER COLUMN [Description] nvarchar(200) NULL;

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Address');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Users] ALTER COLUMN [Address] nvarchar(200) NULL;

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Status');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Projects] ALTER COLUMN [Status] nvarchar(100) NULL;

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Name');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Projects] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Description');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Projects] ALTER COLUMN [Description] nvarchar(200) NULL;

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Coordinator');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Projects] ALTER COLUMN [Coordinator] nvarchar(100) NULL;

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Projects]') AND [c].[name] = N'Category');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Projects] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Projects] ALTER COLUMN [Category] nvarchar(100) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250130153518_UpdateSizeOfColumns', N'9.0.1');