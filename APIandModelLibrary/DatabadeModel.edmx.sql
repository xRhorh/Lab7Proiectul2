
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/22/2020 23:02:25
-- Generated from EDMX file: C:\Users\Pintilii\source\repos\MyPhotos\APIandModelLibrary\DatabadeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPhotosDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ImagineProprietateImagine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProprietateImagines] DROP CONSTRAINT [FK_ImagineProprietateImagine];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaListImagine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imagines] DROP CONSTRAINT [FK_MediaListImagine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Imagines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagines];
GO
IF OBJECT_ID(N'[dbo].[ProprietateImagines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProprietateImagines];
GO
IF OBJECT_ID(N'[dbo].[MediaLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MediaLists];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Imagines'
CREATE TABLE [dbo].[Imagines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullPath] nvarchar(max)  NOT NULL,
    [Available] tinyint  NOT NULL,
    [MediaList_Id] int  NOT NULL
);
GO

-- Creating table 'ProprietateImagines'
CREATE TABLE [dbo].[ProprietateImagines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ImagineId] int  NOT NULL
);
GO

-- Creating table 'MediaLists'
CREATE TABLE [dbo].[MediaLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NrImagini] int  NOT NULL,
    [NrFilme] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Imagines'
ALTER TABLE [dbo].[Imagines]
ADD CONSTRAINT [PK_Imagines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProprietateImagines'
ALTER TABLE [dbo].[ProprietateImagines]
ADD CONSTRAINT [PK_ProprietateImagines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MediaLists'
ALTER TABLE [dbo].[MediaLists]
ADD CONSTRAINT [PK_MediaLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ImagineId] in table 'ProprietateImagines'
ALTER TABLE [dbo].[ProprietateImagines]
ADD CONSTRAINT [FK_ImagineProprietateImagine]
    FOREIGN KEY ([ImagineId])
    REFERENCES [dbo].[Imagines]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImagineProprietateImagine'
CREATE INDEX [IX_FK_ImagineProprietateImagine]
ON [dbo].[ProprietateImagines]
    ([ImagineId]);
GO

-- Creating foreign key on [MediaList_Id] in table 'Imagines'
ALTER TABLE [dbo].[Imagines]
ADD CONSTRAINT [FK_MediaListImagine]
    FOREIGN KEY ([MediaList_Id])
    REFERENCES [dbo].[MediaLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaListImagine'
CREATE INDEX [IX_FK_MediaListImagine]
ON [dbo].[Imagines]
    ([MediaList_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------