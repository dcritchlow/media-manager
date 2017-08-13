
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/12/2017 19:26:13
-- Generated from EDMX file: C:\Users\richa\Dev\media-manager\MediaManager\MediaManager.Web\Models\EFMediaManager.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MediaManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Formats'
CREATE TABLE [dbo].[Formats] (
    [FormatId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [MPAARatingId] int  NOT NULL,
    [Tittle] nvarchar(max)  NOT NULL,
    [Summary] varchar(max)  NULL
);
GO

-- Creating table 'MPAARatings'
CREATE TABLE [dbo].[MPAARatings] (
    [MPAARatingId] int IDENTITY(1,1) NOT NULL,
    [Rating] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Owns'
CREATE TABLE [dbo].[Owns] (
    [OwnId] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [FormatId] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [PurchasingId] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'Votes'
CREATE TABLE [dbo].[Votes] (
    [VotesId] int IDENTITY(1,1) NOT NULL,
    [MovieId] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FormatId] in table 'Formats'
ALTER TABLE [dbo].[Formats]
ADD CONSTRAINT [PK_Formats]
    PRIMARY KEY CLUSTERED ([FormatId] ASC);
GO

-- Creating primary key on [MovieId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [MPAARatingId] in table 'MPAARatings'
ALTER TABLE [dbo].[MPAARatings]
ADD CONSTRAINT [PK_MPAARatings]
    PRIMARY KEY CLUSTERED ([MPAARatingId] ASC);
GO

-- Creating primary key on [OwnId] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [PK_Owns]
    PRIMARY KEY CLUSTERED ([OwnId] ASC);
GO

-- Creating primary key on [PurchasingId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([PurchasingId] ASC);
GO

-- Creating primary key on [VotesId] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [PK_Votes]
    PRIMARY KEY CLUSTERED ([VotesId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FormatId] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [FK_Own_Format]
    FOREIGN KEY ([FormatId])
    REFERENCES [dbo].[Formats]
        ([FormatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Own_Format'
CREATE INDEX [IX_FK_Own_Format]
ON [dbo].[Owns]
    ([FormatId]);
GO

-- Creating foreign key on [MPAARatingId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [FK_Movie_MPAARating]
    FOREIGN KEY ([MPAARatingId])
    REFERENCES [dbo].[MPAARatings]
        ([MPAARatingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Movie_MPAARating'
CREATE INDEX [IX_FK_Movie_MPAARating]
ON [dbo].[Movies]
    ([MPAARatingId]);
GO

-- Creating foreign key on [MovieId] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [FK_Own_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Own_Movie'
CREATE INDEX [IX_FK_Own_Movie]
ON [dbo].[Owns]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_Purchase_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Purchase_Movie'
CREATE INDEX [IX_FK_Purchase_Movie]
ON [dbo].[Purchases]
    ([MovieId]);
GO

-- Creating foreign key on [MovieId] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [FK_Vote_Movie]
    FOREIGN KEY ([MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vote_Movie'
CREATE INDEX [IX_FK_Vote_Movie]
ON [dbo].[Votes]
    ([MovieId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------