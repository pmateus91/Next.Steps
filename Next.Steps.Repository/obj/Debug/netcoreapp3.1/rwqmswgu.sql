IF SCHEMA_ID(N'NextSteps') IS NULL EXEC(N'CREATE SCHEMA [NextSteps];');
GO


CREATE TABLE [NextSteps].[Person] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Profession] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [NextSteps].[Hobby] (
    [PersonId] int NOT NULL,
    [Id] int NOT NULL IDENTITY,
    [HobbyName] nvarchar(max) NULL,
    CONSTRAINT [PK_Hobby] PRIMARY KEY ([PersonId], [Id]),
    CONSTRAINT [FK_Hobby_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [NextSteps].[Person] ([Id]) ON DELETE CASCADE
);
GO


