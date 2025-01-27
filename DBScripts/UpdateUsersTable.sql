EXEC sp_rename N'[Users].[FullName]', N'LastName', 'COLUMN';

ALTER TABLE [Users] ADD [FirstName] nvarchar(max) NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250127171242_UpdateUsersTable', N'9.0.1');

COMMIT;
GO