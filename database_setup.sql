CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (50)  NULL,
    [Img_url]     NVARCHAR (200) NULL,
    [Unit]        NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[ProductDeliveryTimes] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [fromDay]   INT NULL,
    [toDay]     INT NULL,
    [days]      INT NULL,
    [ProductId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DeliveryTimes_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

insert into Products (name, Description, Img_url, Unit) values ('Adhesive', 'Very high quality adhesive', 'https://abro.com/wp-content/uploads/2020/07/CA-3KG.png', 'kg')
insert into Products(name, Description, Img_url, Unit) values ('Ink', 'Very high quality printer ink', 'https://venturebeat.com/product-comparisons?wp-content=uploads/2021/01/color.jpg', 'L')
insert into Products(name, Description, Img_url, Unit) values ('Wrench', 'Very high quality wrench', 'https://www.harborfreight.com/media/catalog/product/cache/9fc4a8332f9638515cd199dd0f9238da/6/7/67150_W3.jpg', '-')

insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (0, 9, 1, 1)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (10, 19, 2, 1)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (20, 100, 3, 1)

insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (0, 49, 1, 2)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (50, 199, 3, 2)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (200, 1000, 10, 2)

insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (0, 9, 1, 3)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (10, 19, 2, 3)
insert into ProductDeliveryTimes(fromDay, toDay, days, ProductId) values (20, 100, 3, 3)
