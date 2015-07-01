
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2015 15:05:58
-- Generated from EDMX file: G:\Projects\DataBaseDesign\DataBaseDesign.Model\DataBaseDesignModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ElectronBusiness];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoBuyInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuyInfo] DROP CONSTRAINT [FK_UserInfoBuyInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoOrderInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfo] DROP CONSTRAINT [FK_UserInfoOrderInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoProductEvaluate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductEvaluate] DROP CONSTRAINT [FK_UserInfoProductEvaluate];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductInfoProductEvaluate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductEvaluate] DROP CONSTRAINT [FK_ProductInfoProductEvaluate];
GO
IF OBJECT_ID(N'[dbo].[FK_ProviderProductInfo_Provider]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProviderProductInfo] DROP CONSTRAINT [FK_ProviderProductInfo_Provider];
GO
IF OBJECT_ID(N'[dbo].[FK_ProviderProductInfo_ProductInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProviderProductInfo] DROP CONSTRAINT [FK_ProviderProductInfo_ProductInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderInfoSellInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfo] DROP CONSTRAINT [FK_OrderInfoSellInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_SellInfoProductInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SellInfo] DROP CONSTRAINT [FK_SellInfoProductInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[ProductInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductInfo];
GO
IF OBJECT_ID(N'[dbo].[Provider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provider];
GO
IF OBJECT_ID(N'[dbo].[ProductEvaluate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductEvaluate];
GO
IF OBJECT_ID(N'[dbo].[BuyInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuyInfo];
GO
IF OBJECT_ID(N'[dbo].[SellInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SellInfo];
GO
IF OBJECT_ID(N'[dbo].[OrderInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderInfo];
GO
IF OBJECT_ID(N'[dbo].[ApiAuthorityVerification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ApiAuthorityVerification];
GO
IF OBJECT_ID(N'[dbo].[ProviderProductInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProviderProductInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [UserId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Age] int  NULL,
    [Sex] bit  NULL,
    [Phone] nvarchar(20)  NULL,
    [IsDelete] bit  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [RegisteTime] datetime  NOT NULL,
    [Account] nvarchar(20)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'ProductInfo'
CREATE TABLE [dbo].[ProductInfo] (
    [PdId] uniqueidentifier  NOT NULL,
    [PdName] nvarchar(100)  NOT NULL,
    [PdPrice] float  NOT NULL,
    [ProductDescribe] nvarchar(100)  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [IsDelete] bit  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [PdNum] int  NOT NULL
);
GO

-- Creating table 'Provider'
CREATE TABLE [dbo].[Provider] (
    [ProviderId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [RegisterTime] datetime  NOT NULL,
    [Account] nvarchar(20)  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [ProviderCredit] int  NULL,
    [IsDelete] bit  NOT NULL,
    [Password] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'ProductEvaluate'
CREATE TABLE [dbo].[ProductEvaluate] (
    [ProductEvaId] uniqueidentifier  NOT NULL,
    [PdId] uniqueidentifier  NOT NULL,
    [Item] nvarchar(1000)  NOT NULL,
    [EvaTime] datetime  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [UserInfo_UserId] uniqueidentifier  NOT NULL,
    [ProductInfo_PdId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BuyInfo'
CREATE TABLE [dbo].[BuyInfo] (
    [BuyId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [RequireProduceName] nvarchar(150)  NOT NULL,
    [DurationTime] datetime  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [Describe] nvarchar(100)  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [UserInfo_UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SellInfo'
CREATE TABLE [dbo].[SellInfo] (
    [SellId] uniqueidentifier  NOT NULL,
    [PdId] uniqueidentifier  NOT NULL,
    [PutawayTime] datetime  NOT NULL,
    [Describe] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [ProductInfo_PdId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'OrderInfo'
CREATE TABLE [dbo].[OrderInfo] (
    [OrderId] uniqueidentifier  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [SellId] uniqueidentifier  NOT NULL,
    [CreatTime] datetime  NOT NULL,
    [Remark] nvarchar(100)  NULL,
    [SubTime] datetime  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [IsConfirm] bit  NOT NULL,
    [UserInfo_UserId] uniqueidentifier  NOT NULL,
    [SellInfo_SellId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ApiAuthorityVerification'
CREATE TABLE [dbo].[ApiAuthorityVerification] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Account] nvarchar(20)  NOT NULL,
    [Password] nvarchar(20)  NOT NULL,
    [Token] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ProviderProductInfo'
CREATE TABLE [dbo].[ProviderProductInfo] (
    [Provider_ProviderId] uniqueidentifier  NOT NULL,
    [ProductInfo_PdId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [PdId] in table 'ProductInfo'
ALTER TABLE [dbo].[ProductInfo]
ADD CONSTRAINT [PK_ProductInfo]
    PRIMARY KEY CLUSTERED ([PdId] ASC);
GO

-- Creating primary key on [ProviderId] in table 'Provider'
ALTER TABLE [dbo].[Provider]
ADD CONSTRAINT [PK_Provider]
    PRIMARY KEY CLUSTERED ([ProviderId] ASC);
GO

-- Creating primary key on [ProductEvaId] in table 'ProductEvaluate'
ALTER TABLE [dbo].[ProductEvaluate]
ADD CONSTRAINT [PK_ProductEvaluate]
    PRIMARY KEY CLUSTERED ([ProductEvaId] ASC);
GO

-- Creating primary key on [BuyId] in table 'BuyInfo'
ALTER TABLE [dbo].[BuyInfo]
ADD CONSTRAINT [PK_BuyInfo]
    PRIMARY KEY CLUSTERED ([BuyId] ASC);
GO

-- Creating primary key on [SellId] in table 'SellInfo'
ALTER TABLE [dbo].[SellInfo]
ADD CONSTRAINT [PK_SellInfo]
    PRIMARY KEY CLUSTERED ([SellId] ASC);
GO

-- Creating primary key on [OrderId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [PK_OrderInfo]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [Id] in table 'ApiAuthorityVerification'
ALTER TABLE [dbo].[ApiAuthorityVerification]
ADD CONSTRAINT [PK_ApiAuthorityVerification]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Provider_ProviderId], [ProductInfo_PdId] in table 'ProviderProductInfo'
ALTER TABLE [dbo].[ProviderProductInfo]
ADD CONSTRAINT [PK_ProviderProductInfo]
    PRIMARY KEY CLUSTERED ([Provider_ProviderId], [ProductInfo_PdId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_UserId] in table 'BuyInfo'
ALTER TABLE [dbo].[BuyInfo]
ADD CONSTRAINT [FK_UserInfoBuyInfo]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoBuyInfo'
CREATE INDEX [IX_FK_UserInfoBuyInfo]
ON [dbo].[BuyInfo]
    ([UserInfo_UserId]);
GO

-- Creating foreign key on [UserInfo_UserId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_UserInfoOrderInfo]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoOrderInfo'
CREATE INDEX [IX_FK_UserInfoOrderInfo]
ON [dbo].[OrderInfo]
    ([UserInfo_UserId]);
GO

-- Creating foreign key on [UserInfo_UserId] in table 'ProductEvaluate'
ALTER TABLE [dbo].[ProductEvaluate]
ADD CONSTRAINT [FK_UserInfoProductEvaluate]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoProductEvaluate'
CREATE INDEX [IX_FK_UserInfoProductEvaluate]
ON [dbo].[ProductEvaluate]
    ([UserInfo_UserId]);
GO

-- Creating foreign key on [ProductInfo_PdId] in table 'ProductEvaluate'
ALTER TABLE [dbo].[ProductEvaluate]
ADD CONSTRAINT [FK_ProductInfoProductEvaluate]
    FOREIGN KEY ([ProductInfo_PdId])
    REFERENCES [dbo].[ProductInfo]
        ([PdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductInfoProductEvaluate'
CREATE INDEX [IX_FK_ProductInfoProductEvaluate]
ON [dbo].[ProductEvaluate]
    ([ProductInfo_PdId]);
GO

-- Creating foreign key on [Provider_ProviderId] in table 'ProviderProductInfo'
ALTER TABLE [dbo].[ProviderProductInfo]
ADD CONSTRAINT [FK_ProviderProductInfo_Provider]
    FOREIGN KEY ([Provider_ProviderId])
    REFERENCES [dbo].[Provider]
        ([ProviderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductInfo_PdId] in table 'ProviderProductInfo'
ALTER TABLE [dbo].[ProviderProductInfo]
ADD CONSTRAINT [FK_ProviderProductInfo_ProductInfo]
    FOREIGN KEY ([ProductInfo_PdId])
    REFERENCES [dbo].[ProductInfo]
        ([PdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProviderProductInfo_ProductInfo'
CREATE INDEX [IX_FK_ProviderProductInfo_ProductInfo]
ON [dbo].[ProviderProductInfo]
    ([ProductInfo_PdId]);
GO

-- Creating foreign key on [SellInfo_SellId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_OrderInfoSellInfo]
    FOREIGN KEY ([SellInfo_SellId])
    REFERENCES [dbo].[SellInfo]
        ([SellId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderInfoSellInfo'
CREATE INDEX [IX_FK_OrderInfoSellInfo]
ON [dbo].[OrderInfo]
    ([SellInfo_SellId]);
GO

-- Creating foreign key on [ProductInfo_PdId] in table 'SellInfo'
ALTER TABLE [dbo].[SellInfo]
ADD CONSTRAINT [FK_SellInfoProductInfo]
    FOREIGN KEY ([ProductInfo_PdId])
    REFERENCES [dbo].[ProductInfo]
        ([PdId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellInfoProductInfo'
CREATE INDEX [IX_FK_SellInfoProductInfo]
ON [dbo].[SellInfo]
    ([ProductInfo_PdId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------