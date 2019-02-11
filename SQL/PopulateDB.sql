SET IDENTITY_INSERT [CustomerTransactionData].[dbo].[Customers] ON
SET IDENTITY_INSERT [CustomerTransactionData].[dbo].[Transactions] OFF
INSERT INTO [CustomerTransactionData].[dbo].[Customers]
  ( [CustomerId], [Name], [Email], [Mobile])
VALUES
  (1000000000, 'Geralt of Rivia', 'geralt@thewithcer.com', 10000000000),
  (1000000001, 'Cirilla', 'cirilla@thewithcer.com', 1000000001),
  (1000000002, 'Yenifer of Vengerberg', 'yenifer@thewithcer.com', 1000000002) 

GO

SET IDENTITY_INSERT [CustomerTransactionData].[dbo].[Customers] OFF
SET IDENTITY_INSERT [CustomerTransactionData].[dbo].[Transactions] ON
INSERT INTO [CustomerTransactionData].[dbo].[Transactions]
  ( [Id],[CustomerId], [Date], [Amount], [Currency], [Status])
VALUES
  (1, 1000000000, '01.01.2018', 10, 'RIV', 2),
  (2, 1000000000, '01.01.2019', 10, 'RIV', 2),
  (3, 1000000000, '01.01.2020', 10, 'RIV', 1),
  (4, 1000000000, '01.01.2021', 10, 'RIV', 2),
  (5, 1000000000, '01.01.2022', 10, 'RIV', 2),
  (6, 1000000000, '01.01.2023', 10, 'RIV', 1),
  (7, 1000000001, '01.01.2018', 10, 'CIN', 2),
  (8, 1000000002, '01.01.2018', 10, 'VEN', 2)