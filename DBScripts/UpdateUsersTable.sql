EXEC sp_rename N'[Users].[FullName]', N'LastName', 'COLUMN';

ALTER TABLE [Users] ADD [FirstName] nvarchar(max) NULL;