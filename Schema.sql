USE [master]
GO
/****** Object:  Database [VHS-rental]    Script Date: 2023-03-12 11:09:43 ******/
CREATE DATABASE [VHS-rental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VHS-rental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\VHS-rental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VHS-rental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\VHS-rental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [VHS-rental] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VHS-rental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VHS-rental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VHS-rental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VHS-rental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VHS-rental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VHS-rental] SET ARITHABORT OFF 
GO
ALTER DATABASE [VHS-rental] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VHS-rental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VHS-rental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VHS-rental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VHS-rental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VHS-rental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VHS-rental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VHS-rental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VHS-rental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VHS-rental] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VHS-rental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VHS-rental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VHS-rental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VHS-rental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VHS-rental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VHS-rental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VHS-rental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VHS-rental] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VHS-rental] SET  MULTI_USER 
GO
ALTER DATABASE [VHS-rental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VHS-rental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VHS-rental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VHS-rental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VHS-rental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VHS-rental] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VHS-rental] SET QUERY_STORE = ON
GO
ALTER DATABASE [VHS-rental] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [VHS-rental]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EAN] [numeric](18, 0) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [smallint] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CustomerPrice] [money] NOT NULL,
	[CompanyCommission] [money] NOT NULL,
	[NumberOfCopies] [smallint] NOT NULL,
	[CopiesOutNow] [smallint] NOT NULL,
	[TotalNumberOfRentals] [int] NOT NULL,
	[LastRentalDate] [datetime] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cassette](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[IsOutNow] [bit] NOT NULL,
	[NumberOfRentals] [int] NOT NULL,
	[LastRentalDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[CassetteActive] [bit] NOT NULL,
	[EAN] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Cassette] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AvailableCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AvailableCassette] AS
SELECT C.ID, M.EAN AS MovieEAN, C.EAN AS CassetteEAN, M.Title, M.[Year], M.CustomerPrice, M.NumberOfCopies FROM dbo.Cassette C LEFT JOIN dbo.Movie M ON M.ID=C.MovieID WHERE C.IsOutNow=0 AND C.CassetteActive=1

GO
/****** Object:  Table [dbo].[Company]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Information] [nvarchar](max) NULL,
	[DefaultCommission] [money] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[CassetteOverview]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CassetteOverview] AS
SELECT
M.ID, M.EAN, M.Title, M.[Year], M.CompanyID, C.[Name] AS CompanyName, M.NumberOfCopies, M.CopiesOutNow, (M.NumberOfCopies-M.CopiesOutNow) AS Available
FROM dbo.Movie M
LEFT JOIN dbo.Company C ON C.ID=M.CompanyID
WHERE M.NumberOfCopies>0
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [nvarchar](50) NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[MovieID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CassetteID] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[StaffID] [int] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalEventTransaction]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalEventTransaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
	[Canceled] [bit] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerSSN] [nvarchar](50) NOT NULL,
	[CustomerAddress1] [nvarchar](50) NOT NULL,
	[CustomerAddress2] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](10) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](50) NOT NULL,
	[CustomerNumber] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_RentalEventTransaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalEvent]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[RentalEventTransaction] [int] NOT NULL,
	[DefaultCustomerPrice] [money] NOT NULL,
	[CompanyCommission] [money] NOT NULL,
 CONSTRAINT [PK_RentalEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RentalView]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RentalView] AS

SELECT
E.ID AS EventID,
RE.ID AS RentalEventID,
RE.RentalEventTransaction AS RentalEventTransactionID,
E.EventTime,
E.CassetteID,
C.IsOutNow,
C.CassetteActive,
E.MovieID,
M.Title AS MovieTitle,
M.[Year] AS MovieYear,
E.CustomerID,
E.CompanyID,
E.Amount,
E.[Description],
E.StaffID,
RE.DefaultCustomerPrice,
RET.Amount AS ActualCustomerPrice,
RE.CompanyCommission,
RET.Canceled
FROM dbo.[Event] E
LEFT JOIN dbo.Movie M ON M.ID=E.MovieID
LEFT JOIN dbo.RentalEvent RE ON RE.EventID=E.ID
LEFT JOIN dbo.RentalEventTransaction RET ON RET.ID=RE.RentalEventTransaction
LEFT JOIN dbo.Cassette C ON C.ID=E.CassetteID
WHERE EventType='Rental'


GO
/****** Object:  View [dbo].[CassetteView]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CassetteView] AS
SELECT C.ID, M.EAN AS MovieEAN, C.EAN AS CassetteEAN, M.Title, M.[Year], M.CustomerPrice, M.NumberOfCopies FROM dbo.Cassette C LEFT JOIN dbo.Movie M ON M.ID=C.MovieID WHERE C.CassetteActive=1

GO
/****** Object:  View [dbo].[UnavailableCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UnavailableCassette] AS
SELECT C.ID, M.EAN AS MovieEAN, C.EAN AS CassetteEAN, M.Title, M.[Year], M.CustomerPrice, M.NumberOfCopies FROM dbo.Cassette C LEFT JOIN dbo.Movie M ON M.ID=C.MovieID WHERE C.IsOutNow=1 AND C.CassetteActive=1

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NOT NULL,
	[Address2] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](10) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[CustomerNumber] [nvarchar](12) NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[LastCassette] [int] NULL,
	[LastMovie] [int] NULL,
	[TotalNumberOfRentals] [int] NOT NULL,
	[CassettesOutNow] [int] NOT NULL,
	[LastActivity] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CustomerView]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerView] AS

SELECT
C.ID, C.[Name], C.SSN, C.Address1, C.Address2, C.ZipCode, C.City, C.Phone, C.EMail, C.CustomerNumber, C.IsBlocked,
C.LastCassette, Ca.EAN AS CassetteEAN, Ca.CustomerID AS CassetteLastCustomerID, Cu.[Name] AS CassetteLastCustomerName,
C.LastMovie AS LastMovieID, M.EAN AS LastMovieEAN, M.Title AS LastMovieTitle, C.TotalNumberOfRentals, C.CassettesOutNow, C.LastActivity
FROM dbo.Customer C
LEFT JOIN dbo.Cassette Ca ON Ca.ID=C.ID
LEFT JOIN dbo.Customer Cu ON Cu.ID=Ca.CustomerID
LEFT JOIN dbo.Movie M ON M.ID=C.LastMovie
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[SettingName] [nvarchar](50) NOT NULL,
	[StringValue] [nvarchar](200) NULL,
	[MoneyValue] [money] NULL,
	[IntValue] [int] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[SettingName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AssignEanToCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AssignEanToCassette](@ID INT, @EAN NUMERIC(18, 0)) AS
BEGIN

	DECLARE @MovieCount INT=(SELECT COUNT(*) FROM dbo.Movie WHERE EAN=@EAN)
	DECLARE @CassetteCount INT=(SELECT COUNT(*) FROM dbo.Cassette WHERE EAN=@EAN)
	IF (@MovieCount > 0 OR @CassetteCount > 0)
	BEGIN

		SELECT 0 AS Result

	END
	ELSE
	BEGIN

		UPDATE dbo.Cassette SET EAN=@EAN WHERE ID=@ID
		SELECT 1 AS Result

	END
END

GO
/****** Object:  StoredProcedure [dbo].[CloseRentalTransaction]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CloseRentalTransaction](@ID int, @Amount MONEY, @Canceled BIT) AS
BEGIN

UPDATE dbo.RentalEventTransaction SET Amount=@Amount, Canceled=@Canceled WHERE ID=@ID

DECLARE @OutNow BIT

IF @Canceled=1
SET @OutNow=0
ELSE
SET @OutNow=1

DECLARE @CustomerID INT
DECLARE @StaffID INT
SELECT @CustomerID=CustomerID, @StaffID=StaffID FROM dbo.RentalEventTransaction WHERE ID=@ID

DECLARE @CassetteID INT
DECLARE @MovieID INT

DECLARE @RentalEventID INT
DECLARE c CURSOR FOR SELECT ID FROM dbo.RentalEvent WHERE RentalEventTransaction=@ID
OPEN c
FETCH NEXT FROM c INTO @RentalEventID
WHILE @@FETCH_STATUS=0
BEGIN

SELECT @CassetteID=E.CassetteID, @MovieID=E.MovieID FROM dbo.RentalEvent RE
LEFT JOIN dbo.[Event] E ON E.ID=RE.EventID WHERE RE.ID=@RentalEventID

IF @Canceled=1
UPDATE dbo.Cassette SET IsOutNow=@OutNow WHERE ID=@CassetteID
ELSE
UPDATE dbo.Cassette SET IsOutNow=@OutNow, CustomerID=@CustomerID, LastRentalDate=GETDATE() WHERE ID=@CassetteID

EXEC dbo.UpdateStatisticsForCassette @CassetteID
EXEC dbo.UpdateStatisticsForMovie @MovieID

FETCH NEXT FROM c INTO @RentalEventID
END
CLOSE c
DEALLOCATE c

EXEC dbo.UpdateStatisticsForCustomer @CustomerID
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRental]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRental](@TransactionID INT, @StaffID INT, @CustomerID INT, @CassetteID INT, @Amount MONEY, @EventTime DATETIME, @Description NVARCHAR(MAX)) AS
BEGIN

DECLARE @StaffActive BIT=ISNULL((SELECT TOP 1 Active FROM dbo.Staff WHERE ID=@StaffID), 0)

DECLARE @SSN NVARCHAR(50)
DECLARE @IsBlocked BIT

SELECT TOP 1
@SSN=SSN,
@IsBlocked=IsBlocked
FROM dbo.Customer WHERE ID=@CustomerID

DECLARE @MovieID INT
DECLARE @CassetteActive BIT

SELECT TOP 1
@MovieID=MovieID,
@CassetteActive=CassetteActive
FROM dbo.Cassette WHERE ID=@CassetteID

DECLARE @CompanyID INT
DECLARE @DefaultCustomerPrice MONEY
DECLARE @CompanyCommission MONEY

SELECT TOP 1 @CompanyID=CompanyID, @DefaultCustomerPrice=CustomerPrice, @CompanyCommission=CompanyCommission FROM dbo.Movie WHERE ID=@MovieID

IF @StaffActive != 1
BEGIN

SELECT -5 AS ID, CAST('Staff inactive or not found.' AS NVARCHAR(50)) AS Message

END
ELSE IF ISNULL(@SSN, '')=''
BEGIN

SELECT -4 AS ID, CAST('Customer not found.' AS NVARCHAR(50)) AS Message

END
ELSE IF ISNULL(@IsBlocked, 0)=1
BEGIN

SELECT -3 AS ID, CAST('Customer is blocked.' AS NVARCHAR(50)) AS Message

END
ELSE IF ISNULL(@CassetteActive, 0)<= 0
BEGIN

SELECT -1 AS ID, CAST('Cassette inactive.' AS NVARCHAR(50)) AS Message

END
ELSE IF ISNULL(@MovieID, 0)<= 0
BEGIN

SELECT -2 AS ID, CAST('Cassette not found.' AS NVARCHAR(50)) AS Message

END
ELSE IF @MovieID>0 AND @CompanyID>0
BEGIN

INSERT INTO [dbo].[Event]
([EventType],
[EventTime],
[MovieID],
[CustomerID],
[CompanyID],
[CassetteID],
[Amount],
[Description],
[StaffID])
VALUES
('Rental', @EventTime, @MovieID, @CustomerID, @CompanyID, @CassetteID, @Amount, @Description, @StaffID)

DECLARE @Result INT = (SELECT CAST(SCOPE_IDENTITY() AS INT))

INSERT INTO dbo.RentalEvent
(EventID, RentalEventTransaction, DefaultCustomerPrice, CompanyCommission)
VALUES
(@Result, @TransactionID, @DefaultCustomerPrice, @CompanyCommission)

SELECT @Result AS ID, CAST('OK.' AS NVARCHAR(50)) AS Message

END
ELSE
BEGIN

SELECT 0 AS ID, CAST('Movie or company not found.' AS NVARCHAR(50)) AS Message

END
END
GO
/****** Object:  StoredProcedure [dbo].[CreateRentalEventTransaction]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRentalEventTransaction](@CustomerID INT, @StaffID INT, @EventTime DATETIME) AS
BEGIN

DECLARE @CustomerName NVARCHAR(50)
DECLARE @CustomerSSN NVARCHAR(50)
DECLARE @CustomerAddress1 NVARCHAR(50)
DECLARE @CustomerAddress2 NVARCHAR(50)
DECLARE @ZipCode NVARCHAR(10)
DECLARE @City NVARCHAR(50)
DECLARE @Phone NVARCHAR(50)
DECLARE @EMail NVARCHAR(50)
DECLARE @CustomerNumber NVARCHAR(12)
DECLARE @IsBlocked BIT
SELECT
@CustomerName=[Name],
@CustomerSSN=SSN,
@CustomerAddress1=Address1,
@CustomerAddress2=Address2,
@ZipCode=ZipCode,
@City=City,
@Phone=Phone,
@EMail=EMail,
@CustomerNumber=CustomerNumber,
@IsBlocked=IsBlocked
FROM dbo.Customer WHERE ID=@CustomerID

IF ISNULL(@CustomerSSN, '')=''
BEGIN

SELECT -4 AS ID, CAST('Customer not found.' AS NVARCHAR(50)) AS Message

END
ELSE IF ISNULL(@IsBlocked, 0)=1
BEGIN

SELECT -3 AS ID, CAST('Customer is blocked.' AS NVARCHAR(50)) AS Message

END
ELSE
BEGIN

INSERT INTO [dbo].[RentalEventTransaction](
[CustomerID],
[StaffID],
[EventTime],
[Amount],
[Canceled],
[CustomerName],
[CustomerSSN],
[CustomerAddress1],
[CustomerAddress2],
[ZipCode],
[City],
[Phone],
[EMail],
[CustomerNumber])
VALUES(
@CustomerID,
@StaffID,
@EventTime,
0,
0,
@CustomerName,
@CustomerSSN,
@CustomerAddress1,
@CustomerAddress2,
@ZipCode,
@City,
@Phone,
@EMail,
@CustomerNumber)

DECLARE @Result INT = (SELECT CAST(SCOPE_IDENTITY() AS INT))
SELECT @Result AS ID, CAST('OK.' AS NVARCHAR(50)) AS Message

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableCassettesFromMovieEAN]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAvailableCassettesFromMovieEAN](@EAN NUMERIC(18,0)) AS
BEGIN

SELECT TOP 10 ID, Title, [Year], CustomerPrice, NumberOfCopies FROM dbo.AvailableCassette WHERE MovieEAN=@EAN

END

GO
/****** Object:  StoredProcedure [dbo].[GetBasicCassetteInformation]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBasicCassetteInformation](@ID INT) AS
BEGIN

SELECT TOP 1 ID, MovieEAN, CassetteEAN, Title, [Year] FROM dbo.CassetteView WHERE ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[GetCassetteFromEAN]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCassetteFromEAN](@EAN NUMERIC(18,0)) AS
BEGIN

SELECT TOP 1 ID, Title, [Year], CustomerPrice, NumberOfCopies FROM dbo.CassetteView WHERE CassetteEAN=@EAN

END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomer](@ID INT) AS
BEGIN

SELECT TOP 1
ID,
[Name],
SSN,
Address1,
Address2,
ZipCode,
City,
Phone,
EMail,
CustomerNumber,
IsBlocked,
LastCassette,
CassetteEAN,
CassetteLastCustomerID,
CassetteLastCustomerName,
LastMovieID,
LastMovieEAN,
LastMovieTitle,
TotalNumberOfRentals,
CassettesOutNow,
LastActivity
FROM dbo.CustomerView WHERE ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerContactInformation]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerContactInformation](@SSN NVARCHAR(50)) AS
BEGIN

	IF LEN(@SSN)>0 AND LEN(@SSN)<13
	BEGIN

		SELECT TOP 1 ID, [Name], SSN, Address1, Address2, ZipCode, City, Phone, EMail, CustomerNumber, IsBlocked FROM dbo.Customer
			WHERE SSN=@SSN OR CustomerNumber=@SSN

	END
	ELSE
	BEGIN
	
		SELECT TOP 1 ID, [Name], SSN, Address1, Address2, ZipCode, City, Phone, EMail, CustomerNumber, IsBlocked FROM dbo.Customer
			WHERE SSN=@SSN

	END

END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomerContactInformationByID]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerContactInformationByID](@ID INT) AS
BEGIN

SELECT TOP 1 ID, Name, SSN, Address1, Address2, ZipCode, City, Phone, EMail, CustomerNumber, IsBlocked FROM dbo.Customer
WHERE ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerContactInformationByName]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerContactInformationByName](@Name NVARCHAR(50)) AS
BEGIN

	IF LEN(@Name)>0
	BEGIN

		SELECT TOP 1 ID, [Name], SSN, Address1, Address2, ZipCode, City, Phone, EMail, CustomerNumber, IsBlocked FROM dbo.Customer
			WHERE [Name] LIKE @Name + '%'

	END

END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerFromSSN]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerFromSSN](@SSN NVARCHAR(50)) AS
BEGIN

SELECT TOP 1
ID, [Name], SSN, Address1, Address2, ZipCode, City, Phone, EMail, CustomerNumber, IsBlocked,
LastCassette, CassetteEAN, CassetteLastCustomerID, CassetteLastCustomerName,
LastMovieID, LastMovieEAN, LastMovieTitle, TotalNumberOfRentals, CassettesOutNow, LastActivity
FROM dbo.CustomerView WHERE SSN=@SSN

END
GO
/****** Object:  StoredProcedure [dbo].[GetMoneySetting]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMoneySetting](@SettingName NVARCHAR(50), @Value MONEY OUTPUT) AS
BEGIN
SET @Value=(SELECT TOP 1 MoneyValue AS [Value] FROM dbo.Setting WHERE SettingName=@SettingName)
END
GO
/****** Object:  StoredProcedure [dbo].[GetStaffFromID]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStaffFromID](@ID INT) AS
BEGIN

	SELECT TOP 1 ID, [Name], SSN, Active FROM dbo.Staff WHERE ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[GetStaffFromSSN]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStaffFromSSN](@SSN NVARCHAR(50)) AS
BEGIN
SELECT TOP 1 ID, [Name], SSN, Active FROM dbo.Staff WHERE SSN=@SSN
END
GO
/****** Object:  StoredProcedure [dbo].[GetUnavailableCassettesFromMovieEAN]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUnavailableCassettesFromMovieEAN](@EAN NUMERIC(18,0)) AS
BEGIN

SELECT TOP 10 ID, Title, [Year], CustomerPrice, NumberOfCopies FROM dbo.UnavailableCassette WHERE MovieEAN=@EAN

END
GO
/****** Object:  StoredProcedure [dbo].[IsCassetteOut]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[IsCassetteOut](@ID INT) AS
BEGIN

DECLARE @Result BIT=ISNULL((SELECT TOP 1 IsOutNow FROM dbo.Cassette WHERE ID=@ID), 1)
SELECT @Result AS IsOutNow

END




GO
/****** Object:  StoredProcedure [dbo].[RegisterCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterCassette](@MovieID INT, @EAN NUMERIC(18,0)) AS
BEGIN

INSERT INTO dbo.Cassette (MovieID, IsOutNow, NumberOfRentals, LastRentalDate, CustomerID, CassetteActive, EAN)
VALUES (@MovieID, 0, 0, NULL, NULL, 1, @EAN)

DECLARE @Copies INT=ISNULL((SELECT COUNT(*) FROM dbo.Cassette WHERE MovieID=@MovieID AND CassetteActive=1), 0)

UPDATE dbo.Movie SET NumberOfCopies=@Copies WHERE ID=@MovieID
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterCompany]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterCompany](@Name NVARCHAR(50)) AS
BEGIN

	DECLARE @DefaultCompanyCommission MONEY
	EXEC dbo.GetMoneySetting 'DefaultCompanyCommission', @DefaultCompanyCommission OUTPUT

	INSERT INTO dbo.Company ([Name], Information, DefaultCommission)
		VALUES (@Name, '', @DefaultCompanyCommission)

	SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterCustomer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterCustomer](@Name NVARCHAR(50), @SSN NVARCHAR(50), @Address1 NVARCHAR(50), @Address2 NVARCHAR(50), @ZipCode NVARCHAR(10), @City NVARCHAR(50), @Phone NVARCHAR(50), @EMail NVARCHAR(100)) AS
BEGIN

	DECLARE @Count INT=(SELECT COUNT(*) FROM dbo.Customer WHERE SSN=@SSN)

	if (@Count <= 0)
	BEGIN

		INSERT INTO [dbo].[Customer]
			([Name],
			[SSN],
			[Address1],
			[Address2],
			[ZipCode],
			[City],
			[Phone],
			[EMail],
			[CustomerNumber],
			[IsBlocked],
			[LastCassette],
			[LastMovie],
			[TotalNumberOfRentals],
			[CassettesOutNow],
			LastActivity)
		VALUES
			(@Name, @SSN, @Address1, @Address2, @ZipCode, @City, @Phone, @EMail, '', 0, NULL, NULL, 0, 0, NULL)

		SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

	END
	ELSE
	BEGIN

		SELECT 0 AS ID

	END

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterMovie]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterMovie](@EAN NUMERIC, @Title NVARCHAR(50), @Year SMALLINT, @CompanyID INT, @CassetteCount INT) AS
BEGIN

	DECLARE @DefaultCustomerPrice MONEY
	EXEC dbo.GetMoneySetting 'DefaultCustomerPrice', @DefaultCustomerPrice OUTPUT

	DECLARE @DefaultCompanyCommission MONEY
	EXEC dbo.GetMoneySetting 'DefaultCompanyCommission', @DefaultCompanyCommission OUTPUT

	INSERT INTO [dbo].[Movie] (
		[EAN],
		[Title],
		[Year],
		[CompanyID],
		[CustomerPrice],
		[CompanyCommission],
		[NumberOfCopies],
		[CopiesOutNow],
		[TotalNumberOfRentals],
		[LastRentalDate])
		VALUES (
		@EAN,
		@Title,
		@Year,
		@CompanyID,
		@DefaultCustomerPrice,
		@DefaultCompanyCommission,
		0,
		0,
		0,
		null)

	DECLARE @MovieID INT=CAST(SCOPE_IDENTITY() AS INT)

	IF @CassetteCount>0
	BEGIN

		DECLARE @Count INT=0

		WHILE @Count<@CassetteCount
		BEGIN

			EXEC dbo.RegisterCassette @MovieID, 0
			SET @Count=@Count+1

		END

	END

	SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterMovieWithCassetteEANs]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterMovieWithCassetteEANs](@EAN NUMERIC, @Title NVARCHAR(50), @Year SMALLINT, @CompanyID INT, @CassetteEANs NVARCHAR(MAX)) AS
BEGIN

DECLARE @DefaultCustomerPrice MONEY
EXEC dbo.GetMoneySetting 'DefaultCustomerPrice', @DefaultCustomerPrice OUTPUT

DECLARE @DefaultCompanyCommission MONEY
EXEC dbo.GetMoneySetting 'DefaultCompanyCommission', @DefaultCompanyCommission OUTPUT

INSERT INTO [dbo].[Movie] (
[EAN],
[Title],
[Year],
[CompanyID],
[CustomerPrice],
[CompanyCommission],
[NumberOfCopies],
[CopiesOutNow],
[TotalNumberOfRentals],
[LastRentalDate])
VALUES (
@EAN,
@Title,
@Year,
@CompanyID,
@DefaultCustomerPrice,
@DefaultCompanyCommission,
0,
0,
0,
null)

DECLARE @MovieID INT=CAST(SCOPE_IDENTITY() AS INT)

DECLARE @EANAsString NVARCHAR(40)
DECLARE @ParsedEAN NUMERIC(18,0)

DECLARE c CURSOR FOR SELECT * FROM STRING_SPLIT(@CassetteEANs, ',')
OPEN c

FETCH NEXT FROM c INTO @EANAsString
WHILE @@FETCH_STATUS=0
BEGIN
SET @ParsedEAN=CAST(@EANAsString AS NUMERIC(18,0))
EXEC dbo.RegisterCassette @MovieID, @ParsedEAN
FETCH NEXT FROM c INTO @EANAsString
END
CLOSE c
DEALLOCATE c

SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterStaff]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterStaff](@Name NVARCHAR(50), @SSN NVARCHAR(50)) AS
BEGIN

	DECLARE @Count INT=(SELECT COUNT(*) FROM dbo.Staff WHERE SSN=@SSN)

	IF (@Count <= 0)
	BEGIN

		INSERT INTO dbo.Staff ([Name], SSN, Active) VALUES (@Name, @SSN, 1)
		SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

	END
	ELSE
	BEGIN

		SELECT 0 AS ID

	END

END
GO
/****** Object:  StoredProcedure [dbo].[ReturnCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReturnCassette](@ID INT, @StaffID INT, @Description NVARCHAR(MAX)) AS
BEGIN

DECLARE @CustomerID INT
DECLARE @IsOutNow BIT
DECLARE @MovieID INT
DECLARE @CompanyID INT

SELECT @CustomerID=CustomerID, @IsOutNow=IsOutNow, @MovieID=MovieID FROM dbo.Cassette WHERE ID=@ID

SELECT @CompanyID=CompanyID FROM dbo.Movie WHERE ID=@MovieID

IF @IsOutNow=1 AND @CustomerID>0
BEGIN
UPDATE dbo.Cassette SET IsOutNow=0 WHERE ID=@ID

DECLARE @CassettesOutNow INT=ISNULL((SELECT COUNT(*) FROM dbo.RentalView WHERE CustomerID=@ID AND Canceled=0 AND IsOutNow=1),0)

UPDATE dbo.Customer SET CassettesOutNow=@CassettesOutNow WHERE ID=@CustomerID

INSERT INTO dbo.[Event]
(EventType, EventTime, MovieID, CustomerID, CompanyID, CassetteID, Amount, [Description], StaffID)
VALUES
('ReturnCassette', GETDATE(), @MovieID, @CustomerID, @CompanyID, @ID, 0, @Description, @StaffID)
END

END
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SearchCustomer](@SearchString NVARCHAR(200)) AS
BEGIN

SELECT TOP 500 ID, [Name], SSN, IsBlocked, LastMovieTitle, TotalNumberOfRentals, CassettesOutNow, LastActivity FROM dbo.CustomerView ORDER BY CassettesOutNow DESC

END
GO
/****** Object:  StoredProcedure [dbo].[SetSetting]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetSetting](@SettingName NVARCHAR(50), @StringValue NVARCHAR(200), @MoneyValue MONEY, @IntValue INT) AS
BEGIN

	DELETE FROM dbo.Setting WHERE SettingName=@SettingName

	INSERT INTO dbo.Setting (SettingName, StringValue, MoneyValue, IntValue)
		VALUES (@SettingName, @StringValue, @MoneyValue, @IntValue)

END
GO
/****** Object:  StoredProcedure [dbo].[SuggestPrice]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SuggestPrice](@CassetteID INT) AS
BEGIN

DECLARE @Result MONEY=ISNULL((SELECT TOP 1 M.CustomerPrice FROM dbo.Cassette C LEFT JOIN dbo.Movie M ON C.MovieID=M.ID), 0)

IF @Result=0
BEGIN

SET @Result=ISNULL((SELECT TOP 1 MoneyValue FROM dbo.Setting WHERE SettingName='DefaultCustomerPrice'),0)

END

SELECT @Result AS SuggestedPrice
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCustomer](
@ID INT,
@Name NVARCHAR(50),
@Address1 NVARCHAR(50),
@Address2 NVARCHAR(50),
@ZipCode NVARCHAR(10),
@City NVARCHAR(50),
@Phone NVARCHAR(50),
@EMail NVARCHAR(100),
@IsBlocked BIT) AS
BEGIN

UPDATE dbo.Customer SET
[Name]=@Name,
Address1=@Address1,
Address2=@Address2,
ZipCode=@ZipCode,
City=@City,
Phone=@Phone,
EMail=@EMail,
IsBlocked=@IsBlocked
WHERE ID=@ID

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomerSsn]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomerSsn](@ID INT, @SSN NVARCHAR(50)) AS
BEGIN

	DECLARE @Count INT=(SELECT COUNT(*) FROM dbo.Customer WHERE ID != @ID AND SSN = @SSN)

	IF (@Count > 0)
	BEGIN

		SELECT 0 AS Result

	END
	ELSE
	BEGIN

		UPDATE dbo.Customer SET SSN=@SSN WHERE ID=@ID
		SELECT 1 AS Result

	END

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateStatisticsForCassette]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStatisticsForCassette](@ID INT) AS
BEGIN

DECLARE @EventTime DATETIME
DECLARE @CustomerID INT
DECLARE @NumberOfRentals INT
SELECT TOP 1
@EventTime=EventTime,
@CustomerID=CustomerID,
@NumberOfRentals=ISNULL((SELECT COUNT(*) FROM dbo.RentalView WHERE CassetteID=@ID AND Canceled=0),0)
FROM dbo.RentalView WHERE CassetteID=@ID AND Canceled=0 ORDER BY EventTime DESC

UPDATE dbo.Cassette SET
NumberOfRentals=@NumberOfRentals,
LastRentalDate=@EventTime,
CustomerID=@CustomerID
WHERE ID=@ID

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStatisticsForCustomer]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStatisticsForCustomer](@ID INT) AS
BEGIN

DECLARE @LastCassette INT
DECLARE @LastMovie INT

SELECT TOP 1 @LastCassette=CassetteID, @LastMovie=MovieID FROM dbo.RentalView WHERE CustomerID=@ID AND Canceled=0 ORDER BY EventTime DESC

DECLARE @LastRentalDate DATETIME=(SELECT TOP 1 EventTime FROM dbo.RentalView WHERE CustomerID=@ID AND Canceled=0 ORDER BY EventTime DESC)

DECLARE @CassettesOutNow INT=ISNULL((SELECT COUNT(*) FROM dbo.RentalView WHERE CustomerID=@ID AND Canceled=0 AND IsOutNow=1),0)

DECLARE @TotalNumberOfRentals INT=ISNULL((SELECT COUNT(*) FROM dbo.RentalView WHERE CustomerID=@ID AND Canceled=0),0)

UPDATE dbo.Customer SET LastCassette=@LastCassette, LastMovie=@LastMovie, CassettesOutNow=@CassettesOutNow, TotalNumberOfRentals=@TotalNumberOfRentals, LastActivity=@LastRentalDate WHERE ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStatisticsForMovie]    Script Date: 2023-03-12 11:09:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateStatisticsForMovie](@ID INT) AS
BEGIN

DECLARE @NumberOfCopies INT=ISNULL((SELECT COUNT(*) FROM dbo.Cassette WHERE MovieID=@ID AND CassetteActive=1),0)
DECLARE @CopiesOutNow INT=ISNULL((SELECT COUNT(*) FROM dbo.Cassette WHERE MovieID=@ID AND CassetteActive=1 AND IsOutNow=1),0)
DECLARE @TotalNumberOfRentals INT=ISNULL((SELECT COUNT(*) FROM dbo.RentalView WHERE MovieID=@ID AND Canceled=0),0)
DECLARE @LastRentalDate DATETIME=(SELECT TOP 1 EventTime FROM dbo.RentalView WHERE MovieID=@ID AND Canceled=0 ORDER BY EventTime DESC)

UPDATE dbo.Movie SET NumberOfCopies=@NumberOfCopies, CopiesOutNow=@CopiesOutNow, TotalNumberOfRentals=@TotalNumberOfRentals, LastRentalDate=@LastRentalDate WHERE ID=@ID

END
GO
USE [master]
GO
ALTER DATABASE [VHS-rental] SET  READ_WRITE 
GO
