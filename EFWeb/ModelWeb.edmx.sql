
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/05/2017 15:03:08
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
    ALTER TABLE [dbo].[booking] DROP CONSTRAINT [FK_booking_client];
GO
IF OBJECT_ID(N'[dbo].[FK_booking_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[booking] DROP CONSTRAINT [FK_booking_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_booking_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[booking] DROP CONSTRAINT [FK_booking_product];
GO
IF OBJECT_ID(N'[dbo].[FK_client_user1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[client] DROP CONSTRAINT [FK_client_user1];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_client]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[clientcomment] DROP CONSTRAINT [FK_clientcomment_client];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[clientcomment] DROP CONSTRAINT [FK_clientcomment_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_clientcomment_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[clientcomment] DROP CONSTRAINT [FK_clientcomment_product];
GO
IF OBJECT_ID(N'[dbo].[FK_delivery_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[delivery] DROP CONSTRAINT [FK_delivery_user];
GO
IF OBJECT_ID(N'[dbo].[FK_DeliveryPrice_deliverytype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[deliveryprice] DROP CONSTRAINT [FK_DeliveryPrice_deliverytype];
GO
IF OBJECT_ID(N'[dbo].[FK_deliverytype_delivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[deliverytype] DROP CONSTRAINT [FK_deliverytype_delivery];
GO
IF OBJECT_ID(N'[dbo].[FK_message_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[message] DROP CONSTRAINT [FK_message_user];
GO
IF OBJECT_ID(N'[dbo].[FK_moneytransaction_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[moneytransaction] DROP CONSTRAINT [FK_moneytransaction_user];
GO
IF OBJECT_ID(N'[dbo].[FK_moneytransaction_user1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[moneytransaction] DROP CONSTRAINT [FK_moneytransaction_user1];
GO
IF OBJECT_ID(N'[dbo].[FK_photo_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[photo] DROP CONSTRAINT [FK_photo_user];
GO
IF OBJECT_ID(N'[dbo].[FK_product_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[product] DROP CONSTRAINT [FK_product_user];
GO
IF OBJECT_ID(N'[dbo].[FK_productprice_producttype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productprice] DROP CONSTRAINT [FK_productprice_producttype];
GO
IF OBJECT_ID(N'[dbo].[FK_report_booking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[report] DROP CONSTRAINT [FK_report_booking];
GO
IF OBJECT_ID(N'[dbo].[FK_video_product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[video] DROP CONSTRAINT [FK_video_product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[booking];
GO
IF OBJECT_ID(N'[dbo].[client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[client];
GO
IF OBJECT_ID(N'[dbo].[clientcomment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[clientcomment];
GO
IF OBJECT_ID(N'[dbo].[delivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[delivery];
GO
IF OBJECT_ID(N'[dbo].[deliveryprice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deliveryprice];
GO
IF OBJECT_ID(N'[dbo].[deliverytype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deliverytype];
GO
IF OBJECT_ID(N'[dbo].[feedback]', 'U') IS NOT NULL
    DROP TABLE [dbo].[feedback];
GO
IF OBJECT_ID(N'[dbo].[message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[message];
GO
IF OBJECT_ID(N'[dbo].[moneytransaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[moneytransaction];
GO
IF OBJECT_ID(N'[dbo].[photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[photo];
GO
IF OBJECT_ID(N'[dbo].[product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[product];
GO
IF OBJECT_ID(N'[dbo].[productprice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productprice];
GO
IF OBJECT_ID(N'[dbo].[producttype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[producttype];
GO
IF OBJECT_ID(N'[dbo].[report]', 'U') IS NOT NULL
    DROP TABLE [dbo].[report];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO
IF OBJECT_ID(N'[dbo].[video]', 'U') IS NOT NULL
    DROP TABLE [dbo].[video];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'bookings'
CREATE TABLE [dbo].[bookings] (
    [id] bigint  NOT NULL,
    [clientid] bigint  NOT NULL,
    [productid] bigint  NOT NULL,
    [deliveryid] bigint  NULL,
    [productprice] decimal(16,2)  NULL,
    [deliveryprice] decimal(16,2)  NULL,
    [location] nvarchar(max)  NULL,
    [paymentmode] char(1)  NOT NULL,
    [totalcost] decimal(16,2)  NOT NULL,
    [producttype] bigint  NOT NULL,
    [productrespond] char(1)  NULL,
    [deliveryrespond] char(1)  NULL,
    [datetime] datetime  NULL,
    [createddate] datetime  NULL,
    [status] char(1)  NULL,
    [isdeleted] bit  NULL,
    [modifieddate] datetime  NOT NULL
);
GO

-- Creating table 'clients'
CREATE TABLE [dbo].[clients] (
    [id] bigint  NOT NULL,
    [clientcode] nvarchar(50)  NOT NULL,
    [paymentmode] int  NOT NULL,
    [ccholder] nvarchar(50)  NULL,
    [ccnumber] nvarchar(max)  NULL,
    [ccexpiredmonth] int  NULL,
    [ccexpiredyear] int  NULL,
    [ccpin] nvarchar(max)  NULL,
    [userid] bigint  NOT NULL,
    [isvalid] bit  NOT NULL,
    [createddate] datetime  NOT NULL,
    [modifieddate] datetime  NULL,
    [balance] decimal(16,2)  NOT NULL,
    [cancelcount] int  NOT NULL
);
GO

-- Creating table 'clientcomments'
CREATE TABLE [dbo].[clientcomments] (
    [id] bigint  NOT NULL,
    [clientid] bigint  NOT NULL,
    [memberid] bigint  NULL,
    [deliveryid] bigint  NULL,
    [rate] int  NULL,
    [note] nvarchar(1)  NOT NULL,
    [createddate] datetime  NOT NULL
);
GO

-- Creating table 'deliveries'
CREATE TABLE [dbo].[deliveries] (
    [id] bigint  NOT NULL,
    [deliverycode] varchar(50)  NOT NULL,
    [name] varchar(255)  NOT NULL,
    [address] varchar(255)  NOT NULL,
    [lowestprice] decimal(16,2)  NULL,
    [highestprice] decimal(16,2)  NULL,
    [quality] int  NULL,
    [phone] varchar(50)  NOT NULL,
    [email] varchar(100)  NULL,
    [disctrict] varchar(50)  NOT NULL,
    [city] varchar(50)  NOT NULL,
    [userid] bigint  NOT NULL,
    [commission] decimal(16,2)  NULL
);
GO

-- Creating table 'deliveryprices'
CREATE TABLE [dbo].[deliveryprices] (
    [id] bigint  NOT NULL,
    [deliverytypeid] bigint  NULL,
    [price] decimal(16,2)  NULL,
    [active] bit  NULL
);
GO

-- Creating table 'deliverytypes'
CREATE TABLE [dbo].[deliverytypes] (
    [id] bigint  NOT NULL,
    [deliveryid] bigint  NOT NULL,
    [deliverytype1] bigint  NOT NULL,
    [deliverydescription] nvarchar(max)  NULL,
    [active] bit  NOT NULL,
    [extrafee] nvarchar(max)  NULL,
    [createddate] datetime  NOT NULL,
    [modifieddate] datetime  NOT NULL
);
GO

-- Creating table 'feedbacks'
CREATE TABLE [dbo].[feedbacks] (
    [id] bigint  NOT NULL,
    [title] varchar(100)  NOT NULL,
    [content] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'messages'
CREATE TABLE [dbo].[messages] (
    [id] bigint  NOT NULL,
    [from] varchar(50)  NOT NULL,
    [to] bigint  NOT NULL,
    [subject] varchar(50)  NOT NULL,
    [body] nvarchar(max)  NOT NULL,
    [datetime] datetime  NOT NULL,
    [status] bit  NOT NULL,
    [isdeleted] bit  NULL
);
GO

-- Creating table 'moneytransactions'
CREATE TABLE [dbo].[moneytransactions] (
    [id] bigint  NOT NULL,
    [code] varchar(50)  NOT NULL,
    [receiptphoto] varbinary(max)  NULL,
    [value] decimal(16,2)  NOT NULL,
    [trandate] datetime  NOT NULL,
    [remark] nvarchar(max)  NULL,
    [status] char(1)  NOT NULL,
    [sourceid] bigint  NOT NULL,
    [destinationid] bigint  NOT NULL,
    [paymentdate] datetime  NULL,
    [ccname] varchar(100)  NULL,
    [ccno] varchar(100)  NULL,
    [ccexpiredmonth] int  NULL,
    [ccexpiredyear] int  NULL,
    [ccpin] nvarchar(max)  NULL,
    [createddate] datetime  NOT NULL,
    [modifieddate] datetime  NULL
);
GO

-- Creating table 'photos'
CREATE TABLE [dbo].[photos] (
    [id] bigint  NOT NULL,
    [userid] bigint  NOT NULL,
    [photo1] binary(1)  NOT NULL,
    [photolink] varchar(255)  NULL,
    [uploadeddate] datetime  NOT NULL,
    [photodescription] varchar(255)  NULL,
    [createddate] datetime  NOT NULL,
    [modifieddate] datetime  NULL,
    [isvisble] bit  NULL,
    [vipmemberonly] bit  NULL,
    [status] char(1)  NULL
);
GO

-- Creating table 'products'
CREATE TABLE [dbo].[products] (
    [id] bigint  NOT NULL,
    [productcode] varchar(50)  NOT NULL,
    [group] varchar(50)  NULL,
    [language1] varchar(50)  NULL,
    [language2] varchar(50)  NULL,
    [price] decimal(16,2)  NOT NULL,
    [preferrablelocation] varchar(50)  NOT NULL,
    [bankname] varchar(100)  NULL,
    [bankaccount] varchar(100)  NULL,
    [bankaccnumber] varchar(100)  NULL,
    [createddate] datetime  NOT NULL,
    [modifeddate] datetime  NULL,
    [isactive] bit  NOT NULL,
    [isblocked] bit  NOT NULL,
    [isavailable] bit  NULL,
    [cancelcount] int  NOT NULL,
    [userid] bigint  NOT NULL,
    [productdescription] nvarchar(max)  NOT NULL,
    [balance] decimal(16,2)  NOT NULL,
    [commission] decimal(16,2)  NULL,
    [reward] decimal(16,2)  NULL
);
GO

-- Creating table 'productprices'
CREATE TABLE [dbo].[productprices] (
    [id] bigint  NOT NULL,
    [producttypeid] bigint  NOT NULL,
    [price] decimal(16,2)  NOT NULL,
    [active] bit  NOT NULL,
    [productid] bigint  NULL,
    [reward] decimal(10,0)  NULL
);
GO

-- Creating table 'producttypes'
CREATE TABLE [dbo].[producttypes] (
    [id] bigint  NOT NULL,
    [producttype1] varchar(50)  NOT NULL,
    [actvice] bit  NOT NULL,
    [flag] char(1)  NOT NULL
);
GO

-- Creating table 'reports'
CREATE TABLE [dbo].[reports] (
    [id] bigint  NOT NULL,
    [bookingid] bigint  NOT NULL,
    [report1] nvarchar(max)  NOT NULL,
    [systemrespond] nvarchar(max)  NULL,
    [refundamount] decimal(16,2)  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] bigint  NOT NULL,
    [username] varchar(25)  NOT NULL,
    [password] varchar(100)  NOT NULL,
    [fullname] varchar(100)  NOT NULL,
    [dateofbirth] datetime  NOT NULL,
    [active] bit  NOT NULL,
    [email] varchar(100)  NULL,
    [phone] varchar(15)  NULL,
    [accounttype] varchar(45)  NOT NULL,
    [isblocked] bit  NOT NULL,
    [gcmkey] nvarchar(max)  NULL,
    [isnotify] bit  NULL,
    [securityquestionid] smallint  NOT NULL,
    [securityanswer] varchar(45)  NOT NULL,
    [createddate] datetime  NULL,
    [modifieddate] datetime  NULL,
    [lastlogin] datetime  NULL
);
GO

-- Creating table 'videos'
CREATE TABLE [dbo].[videos] (
    [id] bigint  NOT NULL,
    [memberid] bigint  NOT NULL,
    [video1] binary(1)  NULL,
    [videolink] nvarchar(max)  NULL,
    [uploadeddate] datetime  NOT NULL,
    [videodescription] varchar(255)  NULL,
    [createddate] datetime  NULL,
    [modifieddate] datetime  NULL,
    [isvisible] bit  NULL,
    [vipmemberonly] bit  NULL,
    [status] char(1)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'bookings'
ALTER TABLE [dbo].[bookings]
ADD CONSTRAINT [PK_bookings]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [PK_clients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'clientcomments'
ALTER TABLE [dbo].[clientcomments]
ADD CONSTRAINT [PK_clientcomments]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'deliveries'
ALTER TABLE [dbo].[deliveries]
ADD CONSTRAINT [PK_deliveries]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'deliveryprices'
ALTER TABLE [dbo].[deliveryprices]
ADD CONSTRAINT [PK_deliveryprices]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'deliverytypes'
ALTER TABLE [dbo].[deliverytypes]
ADD CONSTRAINT [PK_deliverytypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'feedbacks'
ALTER TABLE [dbo].[feedbacks]
ADD CONSTRAINT [PK_feedbacks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'messages'
ALTER TABLE [dbo].[messages]
ADD CONSTRAINT [PK_messages]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'moneytransactions'
ALTER TABLE [dbo].[moneytransactions]
ADD CONSTRAINT [PK_moneytransactions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'photos'
ALTER TABLE [dbo].[photos]
ADD CONSTRAINT [PK_photos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [PK_products]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'productprices'
ALTER TABLE [dbo].[productprices]
ADD CONSTRAINT [PK_productprices]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'producttypes'
ALTER TABLE [dbo].[producttypes]
ADD CONSTRAINT [PK_producttypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'reports'
ALTER TABLE [dbo].[reports]
ADD CONSTRAINT [PK_reports]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'videos'
ALTER TABLE [dbo].[videos]
ADD CONSTRAINT [PK_videos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [clientid] in table 'bookings'
ALTER TABLE [dbo].[bookings]
ADD CONSTRAINT [FK_booking_client]
    FOREIGN KEY ([clientid])
    REFERENCES [dbo].[clients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_client'
CREATE INDEX [IX_FK_booking_client]
ON [dbo].[bookings]
    ([clientid]);
GO

-- Creating foreign key on [deliveryid] in table 'bookings'
ALTER TABLE [dbo].[bookings]
ADD CONSTRAINT [FK_booking_delivery]
    FOREIGN KEY ([deliveryid])
    REFERENCES [dbo].[deliveries]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_delivery'
CREATE INDEX [IX_FK_booking_delivery]
ON [dbo].[bookings]
    ([deliveryid]);
GO

-- Creating foreign key on [productid] in table 'bookings'
ALTER TABLE [dbo].[bookings]
ADD CONSTRAINT [FK_booking_product]
    FOREIGN KEY ([productid])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_booking_product'
CREATE INDEX [IX_FK_booking_product]
ON [dbo].[bookings]
    ([productid]);
GO

-- Creating foreign key on [bookingid] in table 'reports'
ALTER TABLE [dbo].[reports]
ADD CONSTRAINT [FK_report_booking]
    FOREIGN KEY ([bookingid])
    REFERENCES [dbo].[bookings]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_report_booking'
CREATE INDEX [IX_FK_report_booking]
ON [dbo].[reports]
    ([bookingid]);
GO

-- Creating foreign key on [userid] in table 'clients'
ALTER TABLE [dbo].[clients]
ADD CONSTRAINT [FK_client_user1]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_client_user1'
CREATE INDEX [IX_FK_client_user1]
ON [dbo].[clients]
    ([userid]);
GO

-- Creating foreign key on [clientid] in table 'clientcomments'
ALTER TABLE [dbo].[clientcomments]
ADD CONSTRAINT [FK_clientcomment_client]
    FOREIGN KEY ([clientid])
    REFERENCES [dbo].[clients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_client'
CREATE INDEX [IX_FK_clientcomment_client]
ON [dbo].[clientcomments]
    ([clientid]);
GO

-- Creating foreign key on [deliveryid] in table 'clientcomments'
ALTER TABLE [dbo].[clientcomments]
ADD CONSTRAINT [FK_clientcomment_delivery]
    FOREIGN KEY ([deliveryid])
    REFERENCES [dbo].[deliveries]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_delivery'
CREATE INDEX [IX_FK_clientcomment_delivery]
ON [dbo].[clientcomments]
    ([deliveryid]);
GO

-- Creating foreign key on [memberid] in table 'clientcomments'
ALTER TABLE [dbo].[clientcomments]
ADD CONSTRAINT [FK_clientcomment_product]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_clientcomment_product'
CREATE INDEX [IX_FK_clientcomment_product]
ON [dbo].[clientcomments]
    ([memberid]);
GO

-- Creating foreign key on [userid] in table 'deliveries'
ALTER TABLE [dbo].[deliveries]
ADD CONSTRAINT [FK_delivery_user]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_delivery_user'
CREATE INDEX [IX_FK_delivery_user]
ON [dbo].[deliveries]
    ([userid]);
GO

-- Creating foreign key on [deliveryid] in table 'deliverytypes'
ALTER TABLE [dbo].[deliverytypes]
ADD CONSTRAINT [FK_deliverytype_delivery]
    FOREIGN KEY ([deliveryid])
    REFERENCES [dbo].[deliveries]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_deliverytype_delivery'
CREATE INDEX [IX_FK_deliverytype_delivery]
ON [dbo].[deliverytypes]
    ([deliveryid]);
GO

-- Creating foreign key on [deliverytypeid] in table 'deliveryprices'
ALTER TABLE [dbo].[deliveryprices]
ADD CONSTRAINT [FK_DeliveryPrice_deliverytype]
    FOREIGN KEY ([deliverytypeid])
    REFERENCES [dbo].[deliverytypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryPrice_deliverytype'
CREATE INDEX [IX_FK_DeliveryPrice_deliverytype]
ON [dbo].[deliveryprices]
    ([deliverytypeid]);
GO

-- Creating foreign key on [to] in table 'messages'
ALTER TABLE [dbo].[messages]
ADD CONSTRAINT [FK_message_user]
    FOREIGN KEY ([to])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_message_user'
CREATE INDEX [IX_FK_message_user]
ON [dbo].[messages]
    ([to]);
GO

-- Creating foreign key on [sourceid] in table 'moneytransactions'
ALTER TABLE [dbo].[moneytransactions]
ADD CONSTRAINT [FK_moneytransaction_user]
    FOREIGN KEY ([sourceid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_moneytransaction_user'
CREATE INDEX [IX_FK_moneytransaction_user]
ON [dbo].[moneytransactions]
    ([sourceid]);
GO

-- Creating foreign key on [destinationid] in table 'moneytransactions'
ALTER TABLE [dbo].[moneytransactions]
ADD CONSTRAINT [FK_moneytransaction_user1]
    FOREIGN KEY ([destinationid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_moneytransaction_user1'
CREATE INDEX [IX_FK_moneytransaction_user1]
ON [dbo].[moneytransactions]
    ([destinationid]);
GO

-- Creating foreign key on [userid] in table 'photos'
ALTER TABLE [dbo].[photos]
ADD CONSTRAINT [FK_photo_user]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_photo_user'
CREATE INDEX [IX_FK_photo_user]
ON [dbo].[photos]
    ([userid]);
GO

-- Creating foreign key on [userid] in table 'products'
ALTER TABLE [dbo].[products]
ADD CONSTRAINT [FK_product_user]
    FOREIGN KEY ([userid])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_product_user'
CREATE INDEX [IX_FK_product_user]
ON [dbo].[products]
    ([userid]);
GO

-- Creating foreign key on [memberid] in table 'videos'
ALTER TABLE [dbo].[videos]
ADD CONSTRAINT [FK_video_product]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[products]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_video_product'
CREATE INDEX [IX_FK_video_product]
ON [dbo].[videos]
    ([memberid]);
GO

-- Creating foreign key on [producttypeid] in table 'productprices'
ALTER TABLE [dbo].[productprices]
ADD CONSTRAINT [FK_productprice_producttype]
    FOREIGN KEY ([producttypeid])
    REFERENCES [dbo].[producttypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_productprice_producttype'
CREATE INDEX [IX_FK_productprice_producttype]
ON [dbo].[productprices]
    ([producttypeid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------