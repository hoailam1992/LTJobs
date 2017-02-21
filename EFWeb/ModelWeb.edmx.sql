
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/21/2017 16:14:04
-- Generated from EDMX file: E:\Desmond_Website\JT\LTJobs\EFWeb\ModelWeb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbweb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_booking_client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_booking_client];
GO
IF OBJECT_ID(N'[dbo].[FK_booking_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_booking_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_booking_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_booking_product];
GO
IF OBJECT_ID(N'[dbo].[FK_client_user1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_client_user1];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientComments] DROP CONSTRAINT [FK_clientcomment_client];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientComments] DROP CONSTRAINT [FK_clientcomment_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientComments] DROP CONSTRAINT [FK_clientcomment_product];
GO
IF OBJECT_ID(N'[dbo].[FK_delivery_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Deliveries] DROP CONSTRAINT [FK_delivery_user];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliveryPrice_deliverytype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliveryPrices] DROP CONSTRAINT [FK_DeliveryPrice_deliverytype];
GO
IF OBJECT_ID(N'[dbo].[FK_deliverytype_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliveryTypes] DROP CONSTRAINT [FK_deliverytype_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_message_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_message_user];
GO
IF OBJECT_ID(N'[dbo].[FK_moneytransaction_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoneyTransactions] DROP CONSTRAINT [FK_moneytransaction_user];
GO
IF OBJECT_ID(N'[dbo].[FK_moneytransaction_user1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MoneyTransactions] DROP CONSTRAINT [FK_moneytransaction_user1];
GO
IF OBJECT_ID(N'[dbo].[FK_photo_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photos] DROP CONSTRAINT [FK_photo_user];
GO
IF OBJECT_ID(N'[dbo].[FK_product_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_product_user];
GO
IF OBJECT_ID(N'[dbo].[FK_productprice_producttype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductPrices] DROP CONSTRAINT [FK_productprice_producttype];
GO
IF OBJECT_ID(N'[dbo].[FK_productprices_products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductPrices] DROP CONSTRAINT [FK_productprices_products];
GO
IF OBJECT_ID(N'[dbo].[FK_report_booking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_report_booking];
GO
IF OBJECT_ID(N'[dbo].[FK_video_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Videos] DROP CONSTRAINT [FK_video_product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[ClientComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientComments];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Deliveries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Deliveries];
GO
IF OBJECT_ID(N'[dbo].[DeliveryPrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryPrices];
GO
IF OBJECT_ID(N'[dbo].[DeliveryTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveryTypes];
GO
IF OBJECT_ID(N'[dbo].[FeedBacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeedBacks];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[MoneyTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MoneyTransactions];
GO
IF OBJECT_ID(N'[dbo].[Photos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photos];
GO
IF OBJECT_ID(N'[dbo].[ProductPrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductPrices];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProductTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductTypes];
GO
IF OBJECT_ID(N'[dbo].[Reports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reports];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Videos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Videos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ClientId] bigint  NOT NULL,
    [ProductId] bigint  NOT NULL,
    [DeliveryId] bigint  NULL,
    [ProductPrice] decimal(16,2)  NULL,
    [DeliveryPrice] decimal(16,2)  NULL,
    [Location] nvarchar(max)  NULL,
    [PaymentMode] char(1)  NOT NULL,
    [TotalCost] decimal(16,2)  NOT NULL,
    [ProductType] bigint  NOT NULL,
    [ProductRespond] char(1)  NULL,
    [DeliveryRespond] char(1)  NULL,
    [DateTime] datetime  NULL,
    [CreatedDate] datetime  NULL,
    [Status] char(1)  NULL,
    [IsDeleted] bit  NULL,
    [ModifiedDate] datetime  NOT NULL,
    [ProductValue] decimal(18,0)  NULL,
    [DeliveryValue] decimal(18,0)  NULL
);
GO

-- Creating table 'ClientComments'
CREATE TABLE [dbo].[ClientComments] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ClientId] bigint  NOT NULL,
    [ProductId] bigint  NULL,
    [DeliveryId] bigint  NULL,
    [Rate] int  NULL,
    [Note] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(50)  NOT NULL,
    [PaymentMode] int  NOT NULL,
    [CCHolder] nvarchar(50)  NULL,
    [CCNumber] nvarchar(max)  NULL,
    [CCExpiredMonth] int  NULL,
    [CCExpiredYear] int  NULL,
    [CCPin] nvarchar(max)  NULL,
    [UserId] bigint  NOT NULL,
    [IsValid] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [Balance] decimal(16,2)  NOT NULL,
    [CancelCount] int  NOT NULL
);
GO

-- Creating table 'Deliveries'
CREATE TABLE [dbo].[Deliveries] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Address] varchar(255)  NOT NULL,
    [LowestPrice] decimal(16,2)  NULL,
    [HighestPrice] decimal(16,2)  NULL,
    [Quality] int  NULL,
    [Phone] varchar(50)  NOT NULL,
    [Email] varchar(100)  NULL,
    [Disctrict] varchar(50)  NOT NULL,
    [City] varchar(50)  NOT NULL,
    [UserId] bigint  NOT NULL,
    [Commission] decimal(16,2)  NULL
);
GO

-- Creating table 'DeliveryPrices'
CREATE TABLE [dbo].[DeliveryPrices] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DeliveryId] bigint  NULL,
    [Price] decimal(16,2)  NULL,
    [Active] bit  NULL
);
GO

-- Creating table 'DeliveryTypes'
CREATE TABLE [dbo].[DeliveryTypes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DeliveryId] bigint  NOT NULL,
    [Code] bigint  NOT NULL,
    [DeliveryDescription] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [ExtraFee] nvarchar(max)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [Price] decimal(16,2)  NULL
);
GO

-- Creating table 'FeedBacks'
CREATE TABLE [dbo].[FeedBacks] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] varchar(100)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [From] varchar(50)  NOT NULL,
    [To] bigint  NOT NULL,
    [Subject] varchar(50)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Status] bit  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'MoneyTransactions'
CREATE TABLE [dbo].[MoneyTransactions] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [ReceiptPhoto] varbinary(max)  NULL,
    [Value] decimal(16,2)  NOT NULL,
    [Trandate] datetime  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [Status] char(1)  NOT NULL,
    [SourceId] bigint  NOT NULL,
    [DestinationId] bigint  NOT NULL,
    [PaymentDate] datetime  NULL,
    [CCName] varchar(100)  NULL,
    [CCNumber] varchar(100)  NULL,
    [CCExpiredMonth] int  NULL,
    [CCExpiredYear] int  NULL,
    [CCPin] nvarchar(max)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [TrackingId] bigint  NULL
);
GO

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL,
    [Image] varbinary(max)  NOT NULL,
    [PhotoLink] varchar(255)  NULL,
    [UploadedDate] datetime  NOT NULL,
    [PhotoDescription] varchar(255)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [IsVisble] bit  NULL,
    [VIPMemberOnly] bit  NULL,
    [Status] char(1)  NULL
);
GO

-- Creating table 'ProductPrices'
CREATE TABLE [dbo].[ProductPrices] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProductTypeId] bigint  NOT NULL,
    [Price] decimal(16,2)  NOT NULL,
    [Active] bit  NOT NULL,
    [ProductId] bigint  NULL,
    [Reward] decimal(10,0)  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [Group] varchar(50)  NULL,
    [Language1] varchar(50)  NULL,
    [Language2] varchar(50)  NULL,
    [Price] decimal(16,2)  NOT NULL,
    [PreferrableLocation] varchar(50)  NOT NULL,
    [BankName] varchar(100)  NULL,
    [BankAccount] varchar(100)  NULL,
    [BankAccNumber] varchar(100)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifedDate] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [IsBlocked] bit  NOT NULL,
    [IsAvailable] bit  NULL,
    [CancelCount] int  NOT NULL,
    [UserId] bigint  NOT NULL,
    [ProductDescription] nvarchar(max)  NOT NULL,
    [Balance] decimal(16,2)  NOT NULL,
    [Commission] decimal(16,2)  NULL,
    [Reward] decimal(16,2)  NULL
);
GO

-- Creating table 'ProductTypes'
CREATE TABLE [dbo].[ProductTypes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [Flag] char(1)  NOT NULL
);
GO

-- Creating table 'Reports'
CREATE TABLE [dbo].[Reports] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [BookingId] bigint  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SystemRespond] nvarchar(max)  NULL,
    [RefundAmount] decimal(16,2)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserName] varchar(25)  NOT NULL,
    [Password] varchar(100)  NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Active] bit  NOT NULL,
    [Email] varchar(100)  NULL,
    [Phone] varchar(15)  NULL,
    [AccountType] varchar(45)  NOT NULL,
    [IsBlocked] bit  NOT NULL,
    [GCMkey] nvarchar(max)  NULL,
    [IsNotify] bit  NULL,
    [SecurityQuestionId] smallint  NOT NULL,
    [SecurityAnswer] varchar(45)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [LastLogin] datetime  NULL
);
GO

-- Creating table 'Videos'
CREATE TABLE [dbo].[Videos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProductId] bigint  NOT NULL,
    [Source] binary(8000)  NULL,
    [VideoLink] nvarchar(max)  NULL,
    [UploadedDate] datetime  NOT NULL,
    [VideoDescription] varchar(255)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [IsVisible] bit  NULL,
    [VIPMemberOnly] bit  NULL,
    [Status] char(1)  NOT NULL
);
GO

-- Creating table 'Trackings'
CREATE TABLE [dbo].[Trackings] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [BookingId] bigint  NOT NULL,
    [ProductConfirm] nvarchar(max)  NULL,
    [ClientConfirm] nvarchar(max)  NOT NULL,
    [DeliveryConfirm] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [RemarkProduct] nvarchar(max)  NULL,
    [RemarkClient] nvarchar(max)  NULL,
    [RemarkDelivery] nvarchar(max)  NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientComments'
ALTER TABLE [dbo].[ClientComments]
ADD CONSTRAINT [PK_ClientComments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [PK_Deliveries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliveryPrices'
ALTER TABLE [dbo].[DeliveryPrices]
ADD CONSTRAINT [PK_DeliveryPrices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliveryTypes'
ALTER TABLE [dbo].[DeliveryTypes]
ADD CONSTRAINT [PK_DeliveryTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeedBacks'
ALTER TABLE [dbo].[FeedBacks]
ADD CONSTRAINT [PK_FeedBacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MoneyTransactions'
ALTER TABLE [dbo].[MoneyTransactions]
ADD CONSTRAINT [PK_MoneyTransactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductPrices'
ALTER TABLE [dbo].[ProductPrices]
ADD CONSTRAINT [PK_ProductPrices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductTypes'
ALTER TABLE [dbo].[ProductTypes]
ADD CONSTRAINT [PK_ProductTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [PK_Reports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [PK_Videos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trackings'
ALTER TABLE [dbo].[Trackings]
ADD CONSTRAINT [PK_Trackings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_booking_client]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_client'
CREATE INDEX [IX_FK_booking_client]
ON [dbo].[Bookings]
    ([ClientId]);
GO

-- Creating foreign key on [DeliveryId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_booking_delivery]
    FOREIGN KEY ([DeliveryId])
    REFERENCES [dbo].[Deliveries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_delivery'
CREATE INDEX [IX_FK_booking_delivery]
ON [dbo].[Bookings]
    ([DeliveryId]);
GO

-- Creating foreign key on [ProductId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_booking_product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_product'
CREATE INDEX [IX_FK_booking_product]
ON [dbo].[Bookings]
    ([ProductId]);
GO

-- Creating foreign key on [BookingId] in table 'Reports'
ALTER TABLE [dbo].[Reports]
ADD CONSTRAINT [FK_report_booking]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_report_booking'
CREATE INDEX [IX_FK_report_booking]
ON [dbo].[Reports]
    ([BookingId]);
GO

-- Creating foreign key on [ClientId] in table 'ClientComments'
ALTER TABLE [dbo].[ClientComments]
ADD CONSTRAINT [FK_clientcomment_client]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_client'
CREATE INDEX [IX_FK_clientcomment_client]
ON [dbo].[ClientComments]
    ([ClientId]);
GO

-- Creating foreign key on [DeliveryId] in table 'ClientComments'
ALTER TABLE [dbo].[ClientComments]
ADD CONSTRAINT [FK_clientcomment_delivery]
    FOREIGN KEY ([DeliveryId])
    REFERENCES [dbo].[Deliveries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_delivery'
CREATE INDEX [IX_FK_clientcomment_delivery]
ON [dbo].[ClientComments]
    ([DeliveryId]);
GO

-- Creating foreign key on [ProductId] in table 'ClientComments'
ALTER TABLE [dbo].[ClientComments]
ADD CONSTRAINT [FK_clientcomment_product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_product'
CREATE INDEX [IX_FK_clientcomment_product]
ON [dbo].[ClientComments]
    ([ProductId]);
GO

-- Creating foreign key on [UserId] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_client_user1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_client_user1'
CREATE INDEX [IX_FK_client_user1]
ON [dbo].[Clients]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [FK_delivery_user]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_delivery_user'
CREATE INDEX [IX_FK_delivery_user]
ON [dbo].[Deliveries]
    ([UserId]);
GO

-- Creating foreign key on [DeliveryId] in table 'DeliveryTypes'
ALTER TABLE [dbo].[DeliveryTypes]
ADD CONSTRAINT [FK_deliverytype_delivery]
    FOREIGN KEY ([DeliveryId])
    REFERENCES [dbo].[Deliveries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_deliverytype_delivery'
CREATE INDEX [IX_FK_deliverytype_delivery]
ON [dbo].[DeliveryTypes]
    ([DeliveryId]);
GO

-- Creating foreign key on [DeliveryId] in table 'DeliveryPrices'
ALTER TABLE [dbo].[DeliveryPrices]
ADD CONSTRAINT [FK_DeliveryPrice_deliverytype]
    FOREIGN KEY ([DeliveryId])
    REFERENCES [dbo].[DeliveryTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryPrice_deliverytype'
CREATE INDEX [IX_FK_DeliveryPrice_deliverytype]
ON [dbo].[DeliveryPrices]
    ([DeliveryId]);
GO

-- Creating foreign key on [To] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_message_user]
    FOREIGN KEY ([To])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_message_user'
CREATE INDEX [IX_FK_message_user]
ON [dbo].[Messages]
    ([To]);
GO

-- Creating foreign key on [SourceId] in table 'MoneyTransactions'
ALTER TABLE [dbo].[MoneyTransactions]
ADD CONSTRAINT [FK_moneytransaction_user]
    FOREIGN KEY ([SourceId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_moneytransaction_user'
CREATE INDEX [IX_FK_moneytransaction_user]
ON [dbo].[MoneyTransactions]
    ([SourceId]);
GO

-- Creating foreign key on [DestinationId] in table 'MoneyTransactions'
ALTER TABLE [dbo].[MoneyTransactions]
ADD CONSTRAINT [FK_moneytransaction_user1]
    FOREIGN KEY ([DestinationId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_moneytransaction_user1'
CREATE INDEX [IX_FK_moneytransaction_user1]
ON [dbo].[MoneyTransactions]
    ([DestinationId]);
GO

-- Creating foreign key on [UserId] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [FK_photo_user]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_photo_user'
CREATE INDEX [IX_FK_photo_user]
ON [dbo].[Photos]
    ([UserId]);
GO

-- Creating foreign key on [ProductTypeId] in table 'ProductPrices'
ALTER TABLE [dbo].[ProductPrices]
ADD CONSTRAINT [FK_productprice_producttype]
    FOREIGN KEY ([ProductTypeId])
    REFERENCES [dbo].[ProductTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productprice_producttype'
CREATE INDEX [IX_FK_productprice_producttype]
ON [dbo].[ProductPrices]
    ([ProductTypeId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductPrices'
ALTER TABLE [dbo].[ProductPrices]
ADD CONSTRAINT [FK_productprices_products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productprices_products'
CREATE INDEX [IX_FK_productprices_products]
ON [dbo].[ProductPrices]
    ([ProductId]);
GO

-- Creating foreign key on [UserId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_product_user]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_product_user'
CREATE INDEX [IX_FK_product_user]
ON [dbo].[Products]
    ([UserId]);
GO

-- Creating foreign key on [ProductId] in table 'Videos'
ALTER TABLE [dbo].[Videos]
ADD CONSTRAINT [FK_video_product]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_video_product'
CREATE INDEX [IX_FK_video_product]
ON [dbo].[Videos]
    ([ProductId]);
GO

-- Creating foreign key on [BookingId] in table 'Trackings'
ALTER TABLE [dbo].[Trackings]
ADD CONSTRAINT [FK_BookingTracking]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingTracking'
CREATE INDEX [IX_FK_BookingTracking]
ON [dbo].[Trackings]
    ([BookingId]);
GO

-- Creating foreign key on [TrackingId] in table 'MoneyTransactions'
ALTER TABLE [dbo].[MoneyTransactions]
ADD CONSTRAINT [FK_TrackingMoneyTransaction]
    FOREIGN KEY ([TrackingId])
    REFERENCES [dbo].[Trackings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrackingMoneyTransaction'
CREATE INDEX [IX_FK_TrackingMoneyTransaction]
ON [dbo].[MoneyTransactions]
    ([TrackingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------