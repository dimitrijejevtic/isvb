
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/06/2016 19:07:58
-- Generated from EDMX file: C:\Users\mita2\Documents\GitHubVisualStudio\isvb\isvb.dev\EFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [isvb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CartUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carts] DROP CONSTRAINT [FK_CartUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CartItemCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartItems] DROP CONSTRAINT [FK_CartItemCart];
GO
IF OBJECT_ID(N'[dbo].[FK_CartItemProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartItems] DROP CONSTRAINT [FK_CartItemProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderCart];
GO
IF OBJECT_ID(N'[dbo].[FK_BillCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_BillCart];
GO
IF OBJECT_ID(N'[dbo].[FK_BillOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [FK_BillOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductImage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_ProductImage];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_CommentUser];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PostComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_PostComment];
GO
IF OBJECT_ID(N'[dbo].[FK_VisitorUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visitors] DROP CONSTRAINT [FK_VisitorUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carts];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[CartItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartItems];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Bills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bills];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Visitors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visitors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [CartId] int IDENTITY(1,1) NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'CartItems'
CREATE TABLE [dbo].[CartItems] (
    [CartItemId] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [Cart_CartId] int  NOT NULL,
    [Product_ProductId] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [LatName] nvarchar(250)  NOT NULL,
    [Price] float  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostId] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(300)  NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Timestamp] datetime  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [Cart_CartId] int  NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'Bills'
CREATE TABLE [dbo].[Bills] (
    [BillId] int IDENTITY(1,1) NOT NULL,
    [Cart_CartId] int  NOT NULL,
    [Order_OrderId] int  NOT NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [ImageId] int IDENTITY(1,1) NOT NULL,
    [URI] nvarchar(max)  NOT NULL,
    [Alt] nvarchar(max)  NOT NULL,
    [ProductProductId] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [ComentId] int IDENTITY(1,1) NOT NULL,
    [PostPostId] int  NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'Visitors'
CREATE TABLE [dbo].[Visitors] (
    [VisitorId] int IDENTITY(1,1) NOT NULL,
    [VisitorIP] nvarchar(max)  NOT NULL,
    [VisitorCountry] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CartId] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([CartId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [CartItemId] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [PK_CartItems]
    PRIMARY KEY CLUSTERED ([CartItemId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [PostId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostId] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [BillId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [PK_Bills]
    PRIMARY KEY CLUSTERED ([BillId] ASC);
GO

-- Creating primary key on [ImageId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([ImageId] ASC);
GO

-- Creating primary key on [ComentId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([ComentId] ASC);
GO

-- Creating primary key on [VisitorId] in table 'Visitors'
ALTER TABLE [dbo].[Visitors]
ADD CONSTRAINT [PK_Visitors]
    PRIMARY KEY CLUSTERED ([VisitorId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_UserId] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_CartUser]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CartUser'
CREATE INDEX [IX_FK_CartUser]
ON [dbo].[Carts]
    ([User_UserId]);
GO

-- Creating foreign key on [Cart_CartId] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [FK_CartItemCart]
    FOREIGN KEY ([Cart_CartId])
    REFERENCES [dbo].[Carts]
        ([CartId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CartItemCart'
CREATE INDEX [IX_FK_CartItemCart]
ON [dbo].[CartItems]
    ([Cart_CartId]);
GO

-- Creating foreign key on [Product_ProductId] in table 'CartItems'
ALTER TABLE [dbo].[CartItems]
ADD CONSTRAINT [FK_CartItemProduct]
    FOREIGN KEY ([Product_ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CartItemProduct'
CREATE INDEX [IX_FK_CartItemProduct]
ON [dbo].[CartItems]
    ([Product_ProductId]);
GO

-- Creating foreign key on [Cart_CartId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderCart]
    FOREIGN KEY ([Cart_CartId])
    REFERENCES [dbo].[Carts]
        ([CartId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCart'
CREATE INDEX [IX_FK_OrderCart]
ON [dbo].[Orders]
    ([Cart_CartId]);
GO

-- Creating foreign key on [Cart_CartId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_BillCart]
    FOREIGN KEY ([Cart_CartId])
    REFERENCES [dbo].[Carts]
        ([CartId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillCart'
CREATE INDEX [IX_FK_BillCart]
ON [dbo].[Bills]
    ([Cart_CartId]);
GO

-- Creating foreign key on [Order_OrderId] in table 'Bills'
ALTER TABLE [dbo].[Bills]
ADD CONSTRAINT [FK_BillOrder]
    FOREIGN KEY ([Order_OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BillOrder'
CREATE INDEX [IX_FK_BillOrder]
ON [dbo].[Bills]
    ([Order_OrderId]);
GO

-- Creating foreign key on [ProductProductId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_ProductImage]
    FOREIGN KEY ([ProductProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductImage'
CREATE INDEX [IX_FK_ProductImage]
ON [dbo].[Images]
    ([ProductProductId]);
GO

-- Creating foreign key on [User_UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_CommentUser]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentUser'
CREATE INDEX [IX_FK_CommentUser]
ON [dbo].[Comments]
    ([User_UserId]);
GO

-- Creating foreign key on [User_UserId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderUser]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderUser'
CREATE INDEX [IX_FK_OrderUser]
ON [dbo].[Orders]
    ([User_UserId]);
GO

-- Creating foreign key on [PostPostId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_PostComment]
    FOREIGN KEY ([PostPostId])
    REFERENCES [dbo].[Posts]
        ([PostId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostComment'
CREATE INDEX [IX_FK_PostComment]
ON [dbo].[Comments]
    ([PostPostId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------