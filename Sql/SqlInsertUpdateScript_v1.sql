/*
STEP 1
This is the script to be used during a release if any data setup is required PRIOR to modifying the structure.
*/

--!!Scripts must be re-runnable!!

--Example insertion of data 

--BEGIN TRY
--	BEGIN TRANSACTION InsertTestData

--		DELETE
-- 		FROM [dbo].[TestTable]
-- 		where TestColumn = 'TestData'

--		INSERT [dbo].[TestTable]
--		(TestColumn)
--		VALUES
--		('TestData')

--	COMMIT TRANSACTION InsertTestData

--SELECT 'ExecutionSuccessful' as Status;

--END TRY

--BEGIN CATCH
--    SELECT  ERROR_NUMBER() AS ErrorNumber
--    ,       ERROR_SEVERITY() AS ErrorSeverity
--    ,       ERROR_STATE() AS ErrorState
--    ,       ERROR_PROCEDURE() AS ErrorProcedure
--    ,       ERROR_LINE() AS ErrorLine
--    ,       ERROR_MESSAGE() AS ErrorMessage
--    ,       'Failed to insert TestData' AS 'CustomErrorText';
--    ROLLBACK TRANSACTION CreateTableTransaction;
--END CATCH;


PRINT N'Running preSchemaDataUpdates.sql'

GO

/*
STEP 2
!!SCript must be re-runnable!!
*/
PRINT N'Starting Schema Updates Script'

GO

/* Start of Main Schema Update section */

--Example checks
		--IF COL_LENGTH('Correlation.Batch','StagingCompleted') IS NULL

		--IF EXISTS (SELECT 1 
		--  FROM sys.foreign_keys 
		--   WHERE object_id = OBJECT_ID(N'CorrelationClaim.FK_Claim_Adjustment')
		--   AND parent_object_id = OBJECT_ID(N'[CorrelationClaim].[Claim]')
		--)

		--IF COL_LENGTH('Branding','ShowcaseUrl') IS NULL

		--IF (NOT EXISTS (SELECT 1 
		--                 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
		--                 WHERE CONSTRAINT_SCHEMA = 'dbo' 
		--                 AND  CONSTRAINT_NAME = 'FK_DollarsTransferredAppliedToTaxForms_Payment'))

		--IF NOT EXISTS (SELECT 1 FROM sys.filegroups WHERE filegroups.name = 'CorrelationClaim')

		--IF NOT EXISTS (SELECT 1 FROM sys.database_files WHERE database_files.name like '%CorrelationClaimIndexes')

		--IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[Correlation].[ClaimLine]') AND type IN (N'U'))

		--IF NOT EXISTS ( SELECT  1
            --FROM    sys.indexes
            --WHERE   object_id = OBJECT_ID('dbo.Partner')
            --        AND NAME = 'IX_Partner_PartnerSurrogateKeyID' )

    --IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'ExampleSchema')

		
--Example CREATE TABLE

--IF NOT EXISTS 
--(
--	SELECT 1 
--	FROM sys.objects 
--	WHERE object_id = OBJECT_ID(N'[dbo].[TableName]') 
--	AND type IN (N'U')
--)
--BEGIN TRY
--    BEGIN TRANSACTION CreateTableTransaction;
--		CREATE TABLE dbo.TableName 
--		(
--			TableNameID INT IDENTITY (1,1)
--			, ColumnNameA VARCHAR(50) NOT NULL
--			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
--			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
--			, AuditInfo_ModifiedAt DATETIME2(2) NULL
--			, AuditInfo_ModifiedBy VARCHAR(200) NULL
--			, CONSTRAINT PK_TableName PRIMARY KEY CLUSTERED 
--				(
--					TableNameID
--				)
--
--		)
--    COMMIT TRANSACTION	CreateTableTransaction;

--	  SELECT 'ExecutionSuccessful' as Status;

--END TRY

--BEGIN CATCH
--    SELECT  ERROR_NUMBER() AS ErrorNumber
--    ,       ERROR_SEVERITY() AS ErrorSeverity
--    ,       ERROR_STATE() AS ErrorState
--    ,       ERROR_PROCEDURE() AS ErrorProcedure
--    ,       ERROR_LINE() AS ErrorLine
--    ,       ERROR_MESSAGE() AS ErrorMessage
--    ,       'Failed to create TableName table' AS 'CustomErrorText';
--    ROLLBACK TRANSACTION CreateTableTransaction;
--END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[MPAARating]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateMPAARatingTableTransaction;
		CREATE TABLE MediaManager.MPAARating 
		(
			MPAARatingID INT IDENTITY (1,1)
			, MPAARating VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_MPAARating PRIMARY KEY CLUSTERED 
				(
					MPAARatingID
				)
		)
   COMMIT TRANSACTION	CreateMPAARatingTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create MPAARating table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateMPAARatingTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[TVRating]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateTVRatingTableTransaction;
		CREATE TABLE MediaManager.TVRating 
		(
			TVRatingID INT IDENTITY (1,1)
			, TVShowRating VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_TVRating PRIMARY KEY CLUSTERED 
				(
					TVRatingID
				)
		)
   COMMIT TRANSACTION	CreateTVRatingTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create TVRating table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateTVRatingTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[Format]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateFormatTableTransaction;
		CREATE TABLE MediaManager.Format 
		(
			FormatID INT IDENTITY (1,1)
			, FormatName VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_Format PRIMARY KEY CLUSTERED 
				(
					FormatID
				)
		)
   COMMIT TRANSACTION	CreateFormatTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create Format table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateFormatTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[Owner]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateOwnerTableTransaction;
		CREATE TABLE MediaManager.Owner 
		(
			OwnerID INT IDENTITY (1,1)
			, OwnerName VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_Owner PRIMARY KEY CLUSTERED 
				(
					OwnerID
				)
		)
   COMMIT TRANSACTION	CreateOwnerTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create Owner table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateOwnerTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[Movie]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateMovieTableTransaction;
		CREATE TABLE MediaManager.Movie 
		(
			MovieID INT IDENTITY (1,1)
			, MovieTitle VARCHAR(200) NOT NULL
			, MovieSummary VARCHAR(MAX) NULL
			, ReleaseDate DATETIME2(2) NULL
            , Purchased BIT NOT NULL
			, MPAARatingId INT NOT NULL
			, FormatId INT NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_Movie PRIMARY KEY CLUSTERED 
				(
					MovieID
				)
            , CONSTRAINT FK_Movie_MPAARating FOREIGN KEY (MPAARatingID) 
                REFERENCES MediaManager.MPAARating (MPAARatingID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
            , CONSTRAINT FK_Movie_Format FOREIGN KEY (FormatID) 
                REFERENCES MediaManager.Format (FormatID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateMovieTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create Movie table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateMovieTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[MovieOwner]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateMovieOwnerTableTransaction;
		CREATE TABLE MediaManager.MovieOwner 
		(
			MovieOwnerID INT IDENTITY (1,1)
			, MovieID INT NOT NULL
            , OwnerID INT NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_MovieOwner PRIMARY KEY CLUSTERED 
				(
					MovieOwnerID
				)
            , CONSTRAINT FK_MovieOwner_Movie FOREIGN KEY (MovieID) 
                REFERENCES MediaManager.Movie (MovieID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
            , CONSTRAINT FK_MovieOwner_Owner FOREIGN KEY (OwnerID) 
                REFERENCES MediaManager.Owner (OwnerID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateMovieOwnerTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create MovieOwner table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateMovieOwnerTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[MovieWishList]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION MovieWishListTableTransaction;
		CREATE TABLE MediaManager.MovieWishList 
		(
			MovieWishListID INT IDENTITY (1,1)
			, MovieID INT NOT NULL
            , Purchased BIT
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_MovieWishList PRIMARY KEY CLUSTERED 
				(
					MovieWishListID
				)
            , CONSTRAINT FK_MovieWishList_Movie FOREIGN KEY (MovieID) 
                REFERENCES MediaManager.Movie (MovieID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	MovieWishListTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create MovieWishList table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION MovieWishListTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[TVShow]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateTVTableTransaction;
		CREATE TABLE MediaManager.TVShow 
		(
			TVShowID INT IDENTITY (1,1)
			, TVShowTitle VARCHAR(200) NOT NULL
			, TVShowSummary VARCHAR(MAX) NULL
			, ReleaseDate DATETIME2(2) NULL
			, EndDate DATETIME2(2) NULL
			, NumberOfSeasons INT NULL
            , Purchased BIT NOT NULL
			, TVRatingID INT NOT NULL
			, FormatId INT NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_TVShow PRIMARY KEY CLUSTERED 
				(
					TVShowID
				)
            , CONSTRAINT FK_TVShow_TVRating FOREIGN KEY (TVRatingID) 
                REFERENCES MediaManager.TVRating (TVRatingID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateTVTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create TVShow table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateTVShowTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[TVOwner]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateTVOwnerTableTransaction;
		CREATE TABLE MediaManager.TVOwner 
		(
			TVOwnerID INT IDENTITY (1,1)
			, TVShowID INT NOT NULL
            , OwnerID INT NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_TVOwner PRIMARY KEY CLUSTERED 
				(
					TVOwnerID
				)
            , CONSTRAINT FK_TVOwner_TVShow FOREIGN KEY (TVShowID) 
                REFERENCES MediaManager.TVShow (TVShowID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
            , CONSTRAINT FK_TVOwner_Owner FOREIGN KEY (OwnerID) 
                REFERENCES MediaManager.Owner (OwnerID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateTVOwnerTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create TVOwner table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateTVOwnerTableTransaction;
END CATCH;


IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[TVWishList]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateTVWishListTableTransaction;
		CREATE TABLE MediaManager.TVShowWishList 
		(
			TVShowWishListID INT IDENTITY (1,1)
			, TVShowID INT NOT NULL
            , Purchased BIT
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_TVShowWishList PRIMARY KEY CLUSTERED 
				(
					TVShowWishListID
				)
            , CONSTRAINT FK_TVShowWishList_TVShow FOREIGN KEY (TVShowID) 
                REFERENCES MediaManager.TVShow (TVShowID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateTVWishListTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create TVShowWishList table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateTVWishListTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[MovieVote]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateMovieVoteTableTransaction;
		CREATE TABLE MediaManager.MovieVote 
		(
			MovieVoteID INT IDENTITY (1,1)
			, MovieID INT NOT NULL
            , MovieVoteCount INT NOT NULL
            , UserName VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_MovieVote PRIMARY KEY CLUSTERED 
				(
					MovieVoteID
				)
            , CONSTRAINT FK_MovieVote_Movie FOREIGN KEY (MovieID) 
                REFERENCES MediaManager.Movie (MovieID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateMovieVoteTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create MovieVote table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateMovieVoteTableTransaction;
END CATCH;

IF NOT EXISTS 
(
	SELECT 1 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[MediaManager].[TVVote]') 
	AND type IN (N'U')
)
BEGIN TRY
   BEGIN TRANSACTION CreateTVVoteTableTransaction;
		CREATE TABLE MediaManager.TVShowVote 
		(
			TVShowVoteID INT IDENTITY (1,1)
			, TVShowID INT NOT NULL
            , TVShowVoteCount INT NOT NULL
            , UserName VARCHAR(200) NOT NULL
			, AuditInfo_CreatedAt DATETIME2(2) NOT NULL
			, AuditInfo_CreatedBy VARCHAR(200) NOT NULL
			, AuditInfo_ModifiedAt DATETIME2(2) NULL
			, AuditInfo_ModifiedBy VARCHAR(200) NULL
			, CONSTRAINT PK_TVShowVote PRIMARY KEY CLUSTERED 
				(
					TVShowVoteID
				)
            , CONSTRAINT FK_TVShowVote_TVShow FOREIGN KEY (TVShowID) 
                REFERENCES MediaManager.TVShow (TVShowID) 
                ON DELETE CASCADE
                ON UPDATE CASCADE
		)
   COMMIT TRANSACTION	CreateTVShowVoteTableTransaction;

	  SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to create TVShowVote table' AS 'CustomErrorText';
   ROLLBACK TRANSACTION CreateTVShowVoteTableTransaction;
END CATCH;

/* End of Main Schema Update section */
PRINT N'Ending Schema Updates Script'

GO

/*
STEP 3
This is the script to be used during a release if any data setup is required AFTER to modifying the structure.
*/

--if running from Management Studio, need to uncomment line below and update the name for the environment!
--:setvar DatabaseName "DatabaseName"

--!!Scripts must be re-runnable!!

--Example insertion of data 

--BEGIN TRY
--	BEGIN TRANSACTION InsertTestData

--		DELETE
-- 		FROM [dbo].[TestTable]
-- 		where TestColumn = 'TestData'

--		INSERT [dbo].[TestTable]
--		(TestColumn)
--		VALUES
--		('TestData')

--	COMMIT TRANSACTION InsertTestData

--SELECT 'ExecutionSuccessful' as Status;

--END TRY

--BEGIN CATCH
--    SELECT  ERROR_NUMBER() AS ErrorNumber
--    ,       ERROR_SEVERITY() AS ErrorSeverity
--    ,       ERROR_STATE() AS ErrorState
--    ,       ERROR_PROCEDURE() AS ErrorProcedure
--    ,       ERROR_LINE() AS ErrorLine
--    ,       ERROR_MESSAGE() AS ErrorMessage
--    ,       'Failed to insert TestData' AS 'CustomErrorText';
--    ROLLBACK TRANSACTION CreateTableTransaction;
--END CATCH;

BEGIN TRY
	BEGIN TRANSACTION InsertFormatData
		
        DELETE FROM [MediaManager].[Format] where FormatName = 'DVD'
        DELETE FROM [MediaManager].[Format] where FormatName = 'Blu-ray'

		INSERT [MediaManager].[Format] (FormatName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('DVD', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[Format] (FormatName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('Blu-ray', SYSDATETIME(), CURRENT_USER)

	COMMIT TRANSACTION InsertFormatData

SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to insert FormatData' AS 'CustomErrorText';
   ROLLBACK TRANSACTION InsertFormatData;
END CATCH;

BEGIN TRY
	BEGIN TRANSACTION InsertMPAARatingData
		
        DELETE FROM [MediaManager].[MPAARating] where MPAARating = 'G'
        DELETE FROM [MediaManager].[MPAARating] where MPAARating = 'PG'
        DELETE FROM [MediaManager].[MPAARating] where MPAARating = 'PG-13'
        DELETE FROM [MediaManager].[MPAARating] where MPAARating = 'R'
        DELETE FROM [MediaManager].[MPAARating] where MPAARating = 'NC-17'

		INSERT [MediaManager].[MPAARating] (MPAARating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('G', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[MPAARating] (MPAARating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('PG', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[MPAARating] (MPAARating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('PG-13', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[MPAARating] (MPAARating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('R', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[MPAARating] (MPAARating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('NC-17', SYSDATETIME(), CURRENT_USER)

	COMMIT TRANSACTION InsertMPAARatingData

SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to insert MPAARatingData' AS 'CustomErrorText';
   ROLLBACK TRANSACTION InsertMPAARatingData;
END CATCH;

BEGIN TRY
	BEGIN TRANSACTION InsertTVRatingData
		
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV Y'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV Y7'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV Y7 FV'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV G'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV PG'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV 14'
        DELETE FROM [MediaManager].[TVRating] where TVShowRating = 'TV MA'

		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV Y', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV Y7', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV Y7 FV', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV G', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV PG', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV 14', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[TVRating] (TVShowRating, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('TV MA', SYSDATETIME(), CURRENT_USER)

	COMMIT TRANSACTION InsertTVRatingData

SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to insert TVRatingData' AS 'CustomErrorText';
   ROLLBACK TRANSACTION InsertTVRatingData;
END CATCH;

BEGIN TRY
	BEGIN TRANSACTION InsertOwnerData
		
        DELETE FROM [MediaManager].[Owner] where OwnerName = 'Jeremy Simons'
        DELETE FROM [MediaManager].[Owner] where OwnerName = 'Richard Simons'
        DELETE FROM [MediaManager].[Owner] where OwnerName = 'Todd Simons'
        DELETE FROM [MediaManager].[Owner] where OwnerName = 'Darin Critchlow'

		INSERT [MediaManager].[Owner] (OwnerName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('Jeremy Simons', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[Owner] (OwnerName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('Richard Simons', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[Owner] (OwnerName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('Todd Simons', SYSDATETIME(), CURRENT_USER)
		INSERT [MediaManager].[Owner] (OwnerName, AuditInfo_CreatedAt, AuditInfo_CreatedBy) VALUES ('Darin Critchlow', SYSDATETIME(), CURRENT_USER)

	COMMIT TRANSACTION InsertOwnerData

SELECT 'ExecutionSuccessful' as Status;

END TRY

BEGIN CATCH
   SELECT  ERROR_NUMBER() AS ErrorNumber
   ,       ERROR_SEVERITY() AS ErrorSeverity
   ,       ERROR_STATE() AS ErrorState
   ,       ERROR_PROCEDURE() AS ErrorProcedure
   ,       ERROR_LINE() AS ErrorLine
   ,       ERROR_MESSAGE() AS ErrorMessage
   ,       'Failed to insert OwnerData' AS 'CustomErrorText';
   ROLLBACK TRANSACTION InsertOwnerData;
END CATCH;

PRINT N'Running postSchemaDataUpdates.sql'

GO