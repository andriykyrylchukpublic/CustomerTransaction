IF db_id('CustomerTransactionDataTest') IS NULL 
    CREATE DATABASE CustomerTransactionDataTest
GO

CREATE TABLE [CustomerTransactionDataTest].[dbo].[Customers] (
    [CustomerId] bigint NOT NULL IDENTITY,
    [Name] nvarchar(30) NULL,
    [Email] nvarchar(25) NULL,
    [Mobile] bigint NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
);

GO

CREATE TABLE [CustomerTransactionDataTest].[dbo].[Transactions] (
    [Id] int NOT NULL IDENTITY,
    [CustomerId] bigint NOT NULL,
    [Date] datetime2 NOT NULL,
    [Amount] decimal(10,2) NOT NULL,
    [Currency] nvarchar(3) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE
);

GO

CREATE INDEX [Transactions_CustomerId] ON [CustomerTransactionDataTest].[dbo].[Transactions] ([CustomerId]);


