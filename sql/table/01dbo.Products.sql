USE WebShopIncDB
GO
CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (50)  NULL,
    [Img_url]     NVARCHAR (150) NULL,
    [Unit]        NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

