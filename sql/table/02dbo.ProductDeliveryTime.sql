﻿USE WebShopIncDB
GO

CREATE TABLE [dbo].[ProductDeliveryTime] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [fromDay]   INT NULL,
    [toDay]     INT NULL,
    [days]      INT NULL,
    [ProductId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DeliveryTimes_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

