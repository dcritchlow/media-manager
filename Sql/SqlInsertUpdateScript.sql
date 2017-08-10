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
--				WITH (STATISTICS_NORECOMPUTE = ON, DATA_COMPRESSION = PAGE) ON PRIMARYALT
--		) ON PRIMARYALT
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

PRINT N'Running postSchemaDataUpdates.sql'

GO