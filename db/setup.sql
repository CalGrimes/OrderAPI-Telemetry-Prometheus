CREATE DATABASE ToolStore
GO

USE ToolStore
GO

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tools] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(150) NOT NULL,
    [Description] varchar(350) NULL,
    [Price] float NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Tools] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tools_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Tools_CategoryId] ON [Tools] ([CategoryId]);
GO


CREATE TABLE [Inventory] (
    [ToolId] int NOT NULL,
    [Amount] int NOT NULL,
    CONSTRAINT [FK_Inventory_Tools] FOREIGN KEY ([ToolId]) REFERENCES [Tools] ([Id]) ON DELETE NO ACTION
);
GO


CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [CustomerName] varchar(350) NOT NULL,
    [Address] varchar(350) NOT NULL,
    [Telephone] varchar(350) NOT NULL,
    [City] varchar(350) NOT NULL,
    [TotalAmount] float NOT NULL,
    [Status] varchar(150) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
);
GO

CREATE TABLE [Tools_Orders] (
    [ToolId] int NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_Tools_Orders] PRIMARY KEY (ToolId, OrderId),
    CONSTRAINT [FK_Tools] FOREIGN KEY ([ToolId]) REFERENCES [Tools] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION
);
GO