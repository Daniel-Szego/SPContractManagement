USE [Agreement]
GO
/****** Object:  StoredProcedure [dbo].[StartImport_ByProfile]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StartImport_ByProfile]
	@importProfile nvarchar(38)
AS
BEGIN

  IF (@importProfile = '') OR (@importProfile IS NULL)
  BEGIN
	  SET @importProfile = 'SalesActual'
  END  

	-- Import-Pfad ermitteln, fall notwendig
  DECLARE @filePath nvarchar(2000)
  	SET @filePath = ''
  IF (@filePath = '') OR (@filePath IS NULL)
  BEGIN
	  SET @filePath = 
    ( 
    	SELECT [ImportFilePath] 
      FROM [ImportOption] 
      WHERE [ImportProfile]=@importProfile 
    )
  END  

	-- Import-Dateiname ermitteln, fall notwendig
  DECLARE @filePattern nvarchar(100)
  	SET @filePattern = ''
	IF (@filePattern = '') OR (@filePattern IS NULL)
  BEGIN
	  SET @filePattern = 
    ( 
    	SELECT [ImportFilePattern] 
      FROM [ImportOption] 
      WHERE [ImportProfile]=@importProfile 
    )
  END
  
  -- Import-Datei zusammenstecken
  DECLARE @importFile nvarchar(2100)
  	SET @importFile = @filePath + @filePattern
  
  -- Bulk-Import-Tabelle leeren
	TRUNCATE TABLE ImportBulk

	-- String für SQL-Befehl deklarieren
  DECLARE @sql AS nvarchar(1000)
	SET @sql = 
  '  
	BULK
 		INSERT ImportBulk
 		FROM ''' + @importFile + '''
 	WITH
	(
 		FIELDTERMINATOR = '';'',
 		ROWTERMINATOR = ''\n''
 	)
  '
 
	-- Bulk Insert ausführen
  EXEC (@sql)
  
  
	SET @sql = 
  '
  	EXEC StartImport_' + @importProfile + '
  '
 
  EXEC (@sql)
  
END


GO
/****** Object:  StoredProcedure [dbo].[StartImport_SalesActual]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StartImport_SalesActual]
AS
BEGIN
	-- Variable für Filter einrichten
	DECLARE @flt nvarchar(max)
	DECLARE @Count int
	DECLARE @AgreementID int
	DECLARE @SalesActualID int
	DECLARE @newGuid nvarchar(38)

  --SET IDENTITY_INSERT [Agreement_SalesActual] ON

	-- Import Log löschen
  TRUNCATE TABLE Import_SalesActual     
           
	-- Cursor einrichten
 	DECLARE @sql nvarchar(max)
 	SET @sql =
	'
   	DECLARE import_cursor CURSOR
    	FOR
      	SELECT
					[PSPElement]
          , A.[RefBelegnummer]
          , A.[Buchungsperiode]
          , A.[RefBelegtyp]
          , A.[Profitcenter]
          , A.[Kontonummer]
          , A.[Bezeichnung]
          , A.[Umsatz]
          , A.[Waehrung]
          , A.[WBSElementText]
          , A.[Material]
          , A.[Text]
          , A.[Debitor]
        FROM
          [vwImportBulk] A
        ORDER BY
          A.[PSPElement]
          , A.[RefBelegnummer]
          , A.[Buchungsperiode]
	'
	EXEC(@sql)
       
	-- Cursor öffnen
  OPEN import_cursor

	-- Cursor-Spalten einrichten
  DECLARE @col01 nvarchar(20)		-- PSPElement (PK)
  DECLARE @col02 nvarchar(15)		-- RefBelegnummer (PK)
  DECLARE @col03 int 						-- Buchungsperiode (PK)
  DECLARE @col04 nvarchar(5)		-- RefBelegtyp
  DECLARE @col05 nvarchar(10)		-- Profitcenter
  DECLARE @col06 nvarchar(15)		-- Kontonummer
  DECLARE @col07 nvarchar(400)	-- Bezeichnung
  DECLARE @col08 decimal(15,2)  -- Umsatz
  DECLARE @col09 nvarchar(5)		-- Waehrung
  DECLARE @col10 nvarchar(400)	-- WBSElementText
  DECLARE @col11 nvarchar(400)	-- Material
  DECLARE @col12 nvarchar(400)	-- Text
  DECLARE @col13 nvarchar(15)		-- Debitor
  
   -- Wert aus erster Zeile ermitteln
   FETCH NEXT
   	FROM
    	import_cursor
    INTO
      @col01
      , @col02
      , @col03
      , @col04
      , @col05
      , @col06
      , @col07
      , @col08
      , @col09
      , @col10
      , @col11
      , @col12
      , @col13

   -- Solange Status <> -1
   WHILE (@@FETCH_STATUS <> -1)
   BEGIN
      IF (@@FETCH_STATUS <> -2)
      BEGIN

        SET @Count = 0
 				SET @AgreementID = 0

				-- Neue GUID erzeugen
 				SET @newGuid = ( SELECT newid() )
                
        -- Ermitteln, ob Agreement-Datensatz exisitert
        SET @Count =
        (
        	SELECT COUNT(*) 
          FROM [Agreement] 
          WHERE [AgreementNumber]=@col01
        )
        -- Wenn kein Datensatz mehr exisitert
				IF ( @Count = 0 )
        	BEGIN
        	
        		-- Import-Protokoll schreiben (AgreementNotFound)
          	INSERT INTO
          	[Import_SalesActual]
            (
            	[GUID]
              , [ImportResult]
          		, [PSPElement]
          		, [RefBelegnummer]
          		, [Buchungsperiode]
							, [RefBelegtyp]
          		, [Profitcenter]
          		, [Kontonummer]
          		, [Bezeichnung]
          		, [Umsatz]
          		, [Waehrung]
          		, [WBSElementText]
          		, [Material]
          		, [Text]
          		, [Debitor]
            )
            VALUES
            (
            	@newGuid
              , 'AgreementNotFound'
      				, @col01
      				, @col02
      				, @col03
      				, @col04
      				, @col05
      				, @col06
      				, @col07
      				, @col08
      				, @col09
      				, @col10
      				, @col11
      				, @col12
      				, @col13
            )
        	
        	END
				ELSE
        	BEGIN

        		-- ID zum Agreement-Datensatz ermitteln
        		SET @AgreementID =
        		(
        			SELECT [ID] 
              FROM [Agreement] 
              WHERE [AgreementNumber]=@col01
        		)

						-- Weitersuchen: Existiert 'Agreement_SalesActual' schon?
						SET @Count =
        		(
          		SELECT COUNT(*) 
              FROM [Agreement_SalesActual] 
              WHERE [Agreement_id]=@AgreementID
              	AND [InvoiceNumber]=@col02
              	AND [MonthInvoice]=@col03
        		)
        		-- Wenn noch kein Umsatz exisitert
						IF ( @Count = 0 )
        			BEGIN
 
        				-- Umsatz importieren (SalesActualInserted)
          			INSERT INTO
          			[Agreement_SalesActual]
            		(
                	[Agreement_id]
              		, [InvoiceNumber]
              		, [InvoiceDate]
              		, [InvoiceText]
              		, [MonthActivity]
              		, [MonthInvoice]
              		, [AmountInvoice]
              		, [ExpiryDate]
              		, [AmountOutstanding]
              		, [ExpirySinceDays]
              		, [ExpiryCategory_id]
            		)
            		VALUES
            		(
              		@AgreementID
      						, @col02
                  , YEAR(GETDATE()) + CONVERT(nvarchar(2), RIGHT('00' + @col03,2)) + '01'
      						, @col12
                  , 0
                  , @col03
                  , @col08
                  , YEAR(GETDATE()) + CONVERT(nvarchar(2), RIGHT('00' + @col03,2)) + '01'
                  , 0
                  , 0
                  , NULL
            		)

        				-- Import-Protokoll schreiben (SalesActualInserted)
          			INSERT INTO
          			[Import_SalesActual]
            		(
            			[GUID]
              		, [ImportResult]
              		, [Agreement_id]
          				, [PSPElement]
          				, [RefBelegnummer]
          				, [Buchungsperiode]
									, [RefBelegtyp]
          				, [Profitcenter]
          				, [Kontonummer]
          				, [Bezeichnung]
          				, [Umsatz]
          				, [Waehrung]
          				, [WBSElementText]
          				, [Material]
          				, [Text]
          				, [Debitor]
            		)
            		VALUES
            		(
            			@newGuid
              		, 'SalesActualInserted'
              		, @AgreementID
      						, @col01
      						, @col02
      						, @col03
      						, @col04
      						, @col05
      						, @col06
      						, @col07
      						, @col08
      						, @col09
      						, @col10
      						, @col11
      						, @col12
      						, @col13
            		)
                
              END
            ELSE
            	BEGIN

								-- Umsatz-ID ermitteln
								SET @SalesActualID =
        				(
          				SELECT [ID] 
              		FROM [Agreement_SalesActual] 
              		WHERE [Agreement_id]=@AgreementID
              			AND [InvoiceNumber]=@col02
              			AND [MonthInvoice]=@col03
        				)
                
         				-- Umsatz importieren (SalesActualInserted)
          			UPDATE
          			[Agreement_SalesActual]
            		SET
              		[InvoiceDate] = YEAR(GETDATE()) + CONVERT(nvarchar(2), RIGHT('00' + @col03,2)) + '01'
              		, [InvoiceText] = @col12
              		, [MonthActivity] = 0
              		, [AmountInvoice] = @col08
              		, [ExpiryDate] = YEAR(GETDATE()) + CONVERT(nvarchar(2), RIGHT('00' + @col03,2)) + '01'
              		, [AmountOutstanding] = 0
              		, [ExpirySinceDays] = 0
              		, [ExpiryCategory_id] = NULL
								WHERE
									[ID] = @SalesActualID
                
        				-- Import-Protokoll schreiben (SalesActualUpdated)
          			INSERT INTO
          			[Import_SalesActual]
            		(
            			[GUID]
              		, [ImportResult]
              		, [Agreement_id]
          				, [PSPElement]
          				, [RefBelegnummer]
          				, [Buchungsperiode]
									, [RefBelegtyp]
          				, [Profitcenter]
          				, [Kontonummer]
          				, [Bezeichnung]
          				, [Umsatz]
          				, [Waehrung]
          				, [WBSElementText]
          				, [Material]
          				, [Text]
          				, [Debitor]
            		)
            		VALUES
            		(
            			@SalesActualID
              		, 'SalesActualUpdated'
              		, @AgreementID
      						, @col01
      						, @col02
      						, @col03
      						, @col04
      						, @col05
      						, @col06
      						, @col07
      						, @col08
      						, @col09
      						, @col10
      						, @col11
      						, @col12
      						, @col13
            		)
                
              END

        	END
        
      END
      
      -- Wert aus nächster Zeile einlesen
      FETCH NEXT
      	FROM
        	import_cursor
        INTO
      		@col01
		      , @col02
    		  , @col03
		      , @col04
		      , @col05
		      , @col06
		      , @col07
		      , @col08
		      , @col09
		      , @col10
		      , @col11
		      , @col12
		      , @col13
   END
   
	CLOSE import_cursor;
  DEALLOCATE import_cursor;
 
  --SET IDENTITY_INSERT [Agreement_SalesActual] OFF
  
END


GO
/****** Object:  Table [dbo].[Agreement]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgreementNumber] [nvarchar](50) NOT NULL,
	[ContractNumber] [nvarchar](50) NULL,
	[SAPContractNumber] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Debitor] [nvarchar](200) NULL,
	[OrderNumber] [nvarchar](50) NULL,
	[Organisation_id] [int] NULL,
	[Sector_id] [int] NULL,
	[TowerService_id] [int] NULL,
	[TowerDelivery_id] [int] NULL,
	[AgreementStatus_id] [int] NULL,
	[AmountPlanPerMonth] [decimal](19, 5) NULL,
	[RevenueTrend_id] [int] NULL,
	[RevenueDimension_id] [int] NULL,
 CONSTRAINT [pky_Agreement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_AccountUnit]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_AccountUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[AccountUnit] [int] NULL,
 CONSTRAINT [pky_Agreement_AccountUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Agreement_AccountUnit] UNIQUE NONCLUSTERED 
(
	[Agreement_id] ASC,
	[AccountUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_CostActual]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_CostActual](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[MonthActivity] [tinyint] NOT NULL,
	[MonthInvoice] [tinyint] NOT NULL,
	[AmountCost] [decimal](19, 5) NOT NULL,
	[BookingText] [nvarchar](200) NULL,
 CONSTRAINT [pky_Agreement_CostActual] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_Memo]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_Memo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[MemoTimestamp] [datetime] NOT NULL,
	[MemoText] [nvarchar](2000) NOT NULL,
	[MemoType_id] [int] NOT NULL,
	[InternalPerson_id] [int] NULL,
 CONSTRAINT [pky_Agreement_Memo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_ResponsibleExternal]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_ResponsibleExternal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[ExternalRole_id] [int] NOT NULL,
	[ExternalPerson_id] [int] NOT NULL,
 CONSTRAINT [pky_Agreement_ResponsibleExternal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Agreement_ResponsibleExternal] UNIQUE NONCLUSTERED 
(
	[Agreement_id] ASC,
	[ExternalRole_id] ASC,
	[ExternalPerson_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_ResponsibleInternal]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_ResponsibleInternal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[InternalRole_id] [int] NOT NULL,
	[InternalPerson_id] [int] NOT NULL,
 CONSTRAINT [pky_Agreement_ResponsibleInternal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Agreement_ResponsibleInternal] UNIQUE NONCLUSTERED 
(
	[Agreement_id] ASC,
	[InternalRole_id] ASC,
	[InternalPerson_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_SalesActual]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_SalesActual](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[InvoiceNumber] [nvarchar](50) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[InvoiceText] [nvarchar](2000) NULL,
	[MonthActivity] [tinyint] NOT NULL,
	[MonthInvoice] [tinyint] NOT NULL,
	[AmountInvoice] [decimal](19, 5) NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[AmountOutstanding] [decimal](19, 5) NULL,
	[ExpirySinceDays] [int] NULL,
	[ExpiryCategory_id] [int] NULL,
 CONSTRAINT [pky_Agreement_SalesActual] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_SalesPlan]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_SalesPlan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[MonthActivity] [tinyint] NOT NULL,
	[MonthInvoice] [tinyint] NOT NULL,
	[AmountPlan] [decimal](19, 5) NOT NULL,
 CONSTRAINT [pky_Agreement_SalesPlan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Agreement_Todo]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement_Todo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Agreement_id] [int] NOT NULL,
	[TodoType_id] [int] NOT NULL,
	[TodoFlag_id] [int] NOT NULL,
	[TodoPriority_id] [int] NOT NULL,
	[TodoComment] [nvarchar](2000) NOT NULL,
	[Created_InternalPerson_id] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Assigned_InternalPerson_id] [int] NOT NULL,
	[ExpriyDate] [datetime] NOT NULL,
 CONSTRAINT [pky_Agreement_Todo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Agreement_Todo] UNIQUE NONCLUSTERED 
(
	[Agreement_id] ASC,
	[TodoType_id] ASC,
	[TodoFlag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AgreementStatus]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgreementStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_AgreementStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_AgreementStatus] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractNumber] [nvarchar](50) NOT NULL,
	[ContractName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContractNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract_Document]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contract_Document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Contract_Number] [nvarchar](50) NOT NULL,
	[Agreement_id] [int] NULL,
	[DocumentType_id] [int] NOT NULL,
	[DocumentFileBinary] [varbinary](max) NULL,
	[DocumentKeyword] [nvarchar](2000) NULL,
	[DocumentFilePath] [nvarchar](1000) NULL,
 CONSTRAINT [pky_Contract_Document] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_DocumentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_DocumentType] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpiryCategory]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpiryCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_ExpiryCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_ExpiryCategory] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExternalPerson]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalPerson](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UniqueName] [nvarchar](200) NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
 CONSTRAINT [pky_ExternalPerson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExternalRole]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_ExternalRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_ExternalRole] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Import_SalesActual]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Import_SalesActual](
	[GUID] [nvarchar](38) NOT NULL,
	[ImportResult] [nvarchar](25) NULL,
	[Agreement_id] [int] NULL,
	[PSPElement] [nvarchar](20) NOT NULL,
	[RefBelegnummer] [nvarchar](15) NOT NULL,
	[Buchungsperiode] [int] NULL,
	[RefBelegtyp] [nvarchar](5) NULL,
	[Profitcenter] [nvarchar](20) NULL,
	[Kontonummer] [nvarchar](15) NULL,
	[Bezeichnung] [nvarchar](400) NULL,
	[Umsatz] [nvarchar](15) NULL,
	[Waehrung] [nvarchar](5) NULL,
	[WBSElementText] [nvarchar](400) NULL,
	[Material] [nvarchar](400) NULL,
	[Text] [nvarchar](400) NULL,
	[Debitor] [nvarchar](15) NULL,
 CONSTRAINT [pky_Import_SalesActual] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportBulk]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportBulk](
	[RefBelegtyp] [nvarchar](5) NULL,
	[RefBelegnummer] [nvarchar](15) NOT NULL,
	[RefBelegzeile] [int] NOT NULL,
	[Buchungsperiode] [int] NOT NULL,
	[Profitcenter] [nvarchar](20) NULL,
	[Kontonummer] [nvarchar](15) NULL,
	[Bezeichnung] [nvarchar](400) NULL,
	[InProfitCenterHauswaehrung] [nvarchar](15) NULL,
	[Waehrung] [nvarchar](5) NULL,
	[PSPElement] [nvarchar](20) NOT NULL,
	[WBSElementText] [nvarchar](400) NULL,
	[Material] [nvarchar](400) NULL,
	[Text] [nvarchar](400) NULL,
	[Debitor] [nvarchar](15) NULL,
 CONSTRAINT [pky_ImportBulk] PRIMARY KEY CLUSTERED 
(
	[PSPElement] ASC,
	[RefBelegnummer] ASC,
	[RefBelegzeile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportOption]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportOption](
	[ImportProfile] [nvarchar](38) NOT NULL,
	[ImportFilePath] [nvarchar](2000) NOT NULL,
	[ImportFilePattern] [nvarchar](100) NOT NULL,
	[FieldTerminator] [nvarchar](3) NOT NULL,
	[RowTerminator] [nvarchar](10) NOT NULL,
	[ServerName] [nvarchar](200) NOT NULL,
 CONSTRAINT [pky_ImportOption] PRIMARY KEY CLUSTERED 
(
	[ImportProfile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InternalPerson]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternalPerson](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UniqueName] [nvarchar](200) NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
 CONSTRAINT [pky_InternalPerson] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InternalRole]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternalRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_InternalRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_InternalRole] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemoType]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemoType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_MemoType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_MemoType] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organisation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_Organisation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Organisation] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RevenueDimension]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueDimension](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_RevenueDimension] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_RevenueDimension] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RevenueTrend]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueTrend](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_RevenueTrend] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_RevenueTrend] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sector]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_Sector] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_Sector] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TodoFlag]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoFlag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_TodoFlag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_TodoFlag] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TodoPriority]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoPriority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_TodoPriority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_TodoPriority] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TodoType]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_TodoType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_TodoType] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TowerDelivery]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TowerDelivery](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_TowerDelivery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_TowerDelivery] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TowerService]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TowerService](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](200) NULL,
 CONSTRAINT [pky_TowerService] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY],
 CONSTRAINT [uky_TowerService] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vwImportBulk]    Script Date: 4/15/2013 4:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwImportBulk]
AS
SELECT 
  IB.PSPElement,
  IB.RefBelegnummer,
  IB.Buchungsperiode,
  IB.RefBelegtyp,
  IB.Profitcenter,
  IB.Kontonummer,
  IB.Bezeichnung,
  SUM(CASE WHEN IB.InProfitCenterHauswaehrung IS NULL THEN 0 ELSE CONVERT(DECIMAL(15, 2), REPLACE(IB.InProfitCenterHauswaehrung,',','.')) END) AS [Umsatz],
  IB.Waehrung,
  IB.WBSElementText,
  NULL AS [Material], --IB.Material,
  IB.Text,
  IB.Debitor
FROM
  dbo.ImportBulk IB
GROUP BY
  IB.PSPElement,
  IB.RefBelegnummer,
  IB.Buchungsperiode,
  IB.RefBelegtyp,
  IB.Profitcenter,
  IB.Kontonummer,
  IB.Bezeichnung,
  IB.Waehrung,
  IB.WBSElementText,
  --IB.Material,
  IB.Text,
  IB.Debitor


GO
ALTER TABLE [dbo].[Import_SalesActual] ADD  CONSTRAINT [dft_Import_SalesActual_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[ImportOption] ADD  CONSTRAINT [dft_ImportOption_FieldTerminator]  DEFAULT (';') FOR [FieldTerminator]
GO
ALTER TABLE [dbo].[ImportOption] ADD  CONSTRAINT [dft_ImportOption_RowTerminator]  DEFAULT ('/n') FOR [RowTerminator]
GO
ALTER TABLE [dbo].[ImportOption] ADD  CONSTRAINT [dft_ImportOption_ServerName]  DEFAULT (@@servername) FOR [ServerName]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_AgreementStatus] FOREIGN KEY([AgreementStatus_id])
REFERENCES [dbo].[AgreementStatus] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_AgreementStatus]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Contract] FOREIGN KEY([ContractNumber])
REFERENCES [dbo].[Contract] ([ContractNumber])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_Contract]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Organisation] FOREIGN KEY([Organisation_id])
REFERENCES [dbo].[Organisation] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_Organisation]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_RevenueDimension] FOREIGN KEY([RevenueDimension_id])
REFERENCES [dbo].[RevenueDimension] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_RevenueDimension]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_RevenueTrend] FOREIGN KEY([RevenueTrend_id])
REFERENCES [dbo].[RevenueTrend] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_RevenueTrend]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Sector] FOREIGN KEY([Sector_id])
REFERENCES [dbo].[Sector] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_Sector]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_TowerDelivery] FOREIGN KEY([TowerDelivery_id])
REFERENCES [dbo].[TowerDelivery] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_TowerDelivery]
GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_TowerService] FOREIGN KEY([TowerService_id])
REFERENCES [dbo].[TowerService] ([ID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [fky_Agreement_TowerService]
GO
ALTER TABLE [dbo].[Agreement_AccountUnit]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_AccountUnit_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_AccountUnit] CHECK CONSTRAINT [fky_Agreement_AccountUnit_Agreement]
GO
ALTER TABLE [dbo].[Agreement_CostActual]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_CostActual_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_CostActual] CHECK CONSTRAINT [fky_Agreement_CostActual_Agreement]
GO
ALTER TABLE [dbo].[Agreement_Memo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Memo_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Memo] CHECK CONSTRAINT [fky_Agreement_Memo_Agreement]
GO
ALTER TABLE [dbo].[Agreement_Memo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Memo_InternalPerson] FOREIGN KEY([InternalPerson_id])
REFERENCES [dbo].[InternalPerson] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Memo] CHECK CONSTRAINT [fky_Agreement_Memo_InternalPerson]
GO
ALTER TABLE [dbo].[Agreement_Memo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Memo_MemoType] FOREIGN KEY([MemoType_id])
REFERENCES [dbo].[MemoType] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Memo] CHECK CONSTRAINT [fky_Agreement_Memo_MemoType]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleExternal_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleExternal_Agreement]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleExternal_ExternalPerson] FOREIGN KEY([ExternalPerson_id])
REFERENCES [dbo].[ExternalPerson] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleExternal_ExternalPerson]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleExternal_ExternalRole] FOREIGN KEY([ExternalRole_id])
REFERENCES [dbo].[ExternalRole] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleExternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleExternal_ExternalRole]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleInternal_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleInternal_Agreement]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleInternal_InternalPerson] FOREIGN KEY([InternalPerson_id])
REFERENCES [dbo].[InternalPerson] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleInternal_InternalPerson]
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_ResponsibleInternal_InternalRole] FOREIGN KEY([InternalRole_id])
REFERENCES [dbo].[InternalRole] ([ID])
GO
ALTER TABLE [dbo].[Agreement_ResponsibleInternal] CHECK CONSTRAINT [fky_Agreement_ResponsibleInternal_InternalRole]
GO
ALTER TABLE [dbo].[Agreement_SalesActual]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_SalesActual_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_SalesActual] CHECK CONSTRAINT [fky_Agreement_SalesActual_Agreement]
GO
ALTER TABLE [dbo].[Agreement_SalesActual]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_SalesActual_ExpiryCategory] FOREIGN KEY([ExpiryCategory_id])
REFERENCES [dbo].[ExpiryCategory] ([ID])
GO
ALTER TABLE [dbo].[Agreement_SalesActual] CHECK CONSTRAINT [fky_Agreement_SalesActual_ExpiryCategory]
GO
ALTER TABLE [dbo].[Agreement_SalesPlan]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_SalesPlan_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_SalesPlan] CHECK CONSTRAINT [fky_Agreement_SalesPlan_Agreement]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_Agreement] FOREIGN KEY([Agreement_id])
REFERENCES [dbo].[Agreement] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_Agreement]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_InternalPerson_Assigned] FOREIGN KEY([Assigned_InternalPerson_id])
REFERENCES [dbo].[InternalPerson] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_InternalPerson_Assigned]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_InternalPerson_Created] FOREIGN KEY([Created_InternalPerson_id])
REFERENCES [dbo].[InternalPerson] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_InternalPerson_Created]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_TodoFlag] FOREIGN KEY([TodoFlag_id])
REFERENCES [dbo].[TodoFlag] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_TodoFlag]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_TodoPriority] FOREIGN KEY([TodoPriority_id])
REFERENCES [dbo].[TodoPriority] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_TodoPriority]
GO
ALTER TABLE [dbo].[Agreement_Todo]  WITH CHECK ADD  CONSTRAINT [fky_Agreement_Todo_TodoType] FOREIGN KEY([TodoType_id])
REFERENCES [dbo].[TodoType] ([ID])
GO
ALTER TABLE [dbo].[Agreement_Todo] CHECK CONSTRAINT [fky_Agreement_Todo_TodoType]
GO
ALTER TABLE [dbo].[Contract_Document]  WITH CHECK ADD  CONSTRAINT [fky_Contract_Document_Contract] FOREIGN KEY([Contract_Number])
REFERENCES [dbo].[Contract] ([ContractNumber])
GO
ALTER TABLE [dbo].[Contract_Document] CHECK CONSTRAINT [fky_Contract_Document_Contract]
GO
ALTER TABLE [dbo].[Contract_Document]  WITH CHECK ADD  CONSTRAINT [fky_Contract_Document_DocumentType] FOREIGN KEY([DocumentType_id])
REFERENCES [dbo].[DocumentType] ([ID])
GO
ALTER TABLE [dbo].[Contract_Document] CHECK CONSTRAINT [fky_Contract_Document_DocumentType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'(OrigianlPfad)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_Document', @level2type=N'COLUMN',@level2name=N'DocumentFilePath'
GO
