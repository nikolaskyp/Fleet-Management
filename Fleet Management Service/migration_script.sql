IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Fleets] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Fleets] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vessels] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [IMONumber] nvarchar(max) NOT NULL,
    [MaximumCapacity] int NOT NULL,
    [FleetId] int NULL,
    CONSTRAINT [PK_Vessels] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vessels_Fleets_FleetId] FOREIGN KEY ([FleetId]) REFERENCES [Fleets] ([Id])
);
GO

CREATE TABLE [Containers] (
    [Id] int NOT NULL IDENTITY,
    [ContainerId] nvarchar(max) NOT NULL,
    [Weight] int NOT NULL,
    [VesselId] int NOT NULL,
    CONSTRAINT [PK_Containers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Containers_Vessels_VesselId] FOREIGN KEY ([VesselId]) REFERENCES [Vessels] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Containers_VesselId] ON [Containers] ([VesselId]);
GO

CREATE INDEX [IX_Vessels_FleetId] ON [Vessels] ([FleetId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230828163725_InitialCreate', N'7.0.10');
GO

COMMIT;
GO

