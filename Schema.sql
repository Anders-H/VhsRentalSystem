USE [master]
GO
/****** Object:  Database [VHS-rental]    Script Date: 2022-04-14 18:25:30 ******/
CREATE DATABASE [VHS-rental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VHS-rental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VHS-rental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VHS-rental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VHS-rental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VHS-rental] SET COMPATIBILITY_LEVEL = 150
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
ALTER DATABASE [VHS-rental] SET QUERY_STORE = OFF
GO
USE [VHS-rental]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  Table [dbo].[Movie]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  View [dbo].[CassetteOverview]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  Table [dbo].[Cassette]    Script Date: 2022-04-14 18:25:30 ******/
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
 CONSTRAINT [PK_Cassette] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  Table [dbo].[Event]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  Table [dbo].[RentalEvent]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalEvent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[DefaultCustomerPrice] [money] NOT NULL,
	[CompanyCommission] [money] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerSSN] [nvarchar](50) NOT NULL,
	[CustomerAddress1] [nvarchar](50) NOT NULL,
	[CustomerAddress2] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](10) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](50) NOT NULL,
	[CustomerNumber] [nvarchar](12) NOT NULL,
	[RentalNumber] [int] NOT NULL,
 CONSTRAINT [PK_RentalEvent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  Table [dbo].[Staff]    Script Date: 2022-04-14 18:25:30 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateRental]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRental](@StaffID INT, @CustomerID INT, @CassetteID INT, @Amount MONEY, @EventTime DATETIME, @Description NVARCHAR(MAX)) AS
BEGIN

DECLARE @SSN NVARCHAR(50)
DECLARE @IsBlocked BIT
DECLARE @TotalNumberOfRentals INT

SELECT TOP 1
	@SSN=SSN,
	@IsBlocked=IsBlocked,
	@TotalNumberOfRentals=TotalNumberOfRentals
FROM dbo.Customer WHERE ID=@CustomerID

DECLARE @MovieID INT
DECLARE @NumberOfRentals INT
DECLARE @CassetteActive BIT

SELECT TOP 1
	@MovieID=MovieID,
	@NumberOfRentals=NumberOfRentals,
	@CassetteActive=CassetteActive
FROM dbo.Cassette WHERE ID=@CassetteID

DECLARE @CompanyID INT=ISNULL((SELECT TOP 1 CompanyID FROM dbo.Movie WHERE ID=@MovieID), 0)

IF ISNULL(@SSN, '')=''
BEGIN

	SELECT -4 AS ID, CAST('Customer not found.' AS NVARCHAR(20)) AS Message

END
ELSE IF ISNULL(@IsBlocked, 0)=1
BEGIN

	SELECT -3 AS ID, CAST('Customer is blocked.' AS NVARCHAR(20)) AS Message

END
ELSE IF ISNULL(@CassetteActive, 0)<= 0
BEGIN

	SELECT -1 AS ID, CAST('Cassette inactive.' AS NVARCHAR(20)) AS Message

END
ELSE IF ISNULL(@MovieID, 0)<= 0
BEGIN

	SELECT -2 AS ID, CAST('Cassette not found.' AS NVARCHAR(20)) AS Message

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

	SET @NumberOfRentals=@NumberOfRentals+1
	UPDATE dbo.Cassette SET IsOutNow=1, NumberOfRentals=@NumberOfRentals, LastRentalDate=@EventTime, CustomerID=@CustomerID WHERE ID=@CassetteID

	SET @TotalNumberOfRentals=@TotalNumberOfRentals+1
	UPDATE dbo.Customer SET LastCassette=@CassetteID, LastMovie=@MovieID, TotalNumberOfRentals=@TotalNumberOfRentals, LastActivity=@EventTime WHERE ID=@CustomerID

	SELECT @Result AS ID, CAST('OK.' AS NVARCHAR(20)) AS Message

END
ELSE
BEGIN

	SELECT 0 AS ID, CAST('Movie or company not found.' AS NVARCHAR(20)) AS Message

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetMoneySetting]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMoneySetting](@SettingName NVARCHAR(50), @Value MONEY OUTPUT) AS
BEGIN
	SET @Value=(SELECT TOP 1 MoneyValue AS [Value] FROM dbo.Setting WHERE SettingName=@SettingName)
END
GO
/****** Object:  StoredProcedure [dbo].[GetStaffFromSSN]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStaffFromSSN](@SSN NVARCHAR(50)) AS
BEGIN
	SELECT TOP 1 ID, [Name], SSN, Active FROM dbo.Staff WHERE SSN=@SSN
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterCassette]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterCassette](@MovieID INT) AS
BEGIN

	INSERT INTO dbo.Cassette (MovieID, IsOutNow, NumberOfRentals, LastRentalDate, CustomerID, CassetteActive)
	VALUES (@MovieID, 0, 0, NULL, NULL, 1)

	DECLARE @Copies INT=ISNULL((SELECT COUNT(*) FROM dbo.Cassette WHERE MovieID=@MovieID AND CassetteActive=1), 0)

	UPDATE dbo.Movie SET NumberOfCopies=@Copies WHERE ID=@MovieID
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterCompany]    Script Date: 2022-04-14 18:25:30 ******/
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

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterCustomer]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterCustomer](@Name NVARCHAR(50), @SSN NVARCHAR(50), @Address1 NVARCHAR(50), @Address2 NVARCHAR(50), @ZipCode NVARCHAR(10), @City NVARCHAR(50), @Phone NVARCHAR(50), @EMail NVARCHAR(100)) AS
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
GO
/****** Object:  StoredProcedure [dbo].[RegisterMovie]    Script Date: 2022-04-14 18:25:30 ******/
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

		EXEC dbo.RegisterCassette @MovieID
		
		SET @Count=@Count+1
	END

END

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterStaff]    Script Date: 2022-04-14 18:25:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterStaff](@Name NVARCHAR(50), @SSN NVARCHAR(50)) AS
BEGIN

	INSERT INTO dbo.Staff ([Name], SSN, Active) VALUES (@Name, @SSN, 1)
	SELECT CAST(SCOPE_IDENTITY() AS INT) AS ID

END
GO
/****** Object:  StoredProcedure [dbo].[SetSetting]    Script Date: 2022-04-14 18:25:30 ******/
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
USE [master]
GO
ALTER DATABASE [VHS-rental] SET  READ_WRITE 
GO
