USE [master]
GO
/****** Object:  Database [VHS-rental]    Script Date: 2022-03-14 00:01:06 ******/
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
/****** Object:  Table [dbo].[Cassette]    Script Date: 2022-03-14 00:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cassette](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[EAN] [numeric](18, 0) NOT NULL,
	[IsOutNow] [bit] NOT NULL,
	[NumberOfRentals] [int] NOT NULL,
	[LastRentalDate] [datetime] NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK_Cassette] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 2022-03-14 00:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Information] [ntext] NULL,
	[DefaultCommission] [money] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2022-03-14 00:01:06 ******/
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
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 2022-03-14 00:01:06 ******/
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
	[Description] [ntext] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 2022-03-14 00:01:06 ******/
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
/****** Object:  Table [dbo].[Setting]    Script Date: 2022-03-14 00:01:06 ******/
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
/****** Object:  StoredProcedure [dbo].[GetMoneySetting]    Script Date: 2022-03-14 00:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMoneySetting](@SettingName NVARCHAR(50), @Value MONEY OUTPUT) AS
BEGIN
	SET @Value=(SELECT TOP 1 MoneyValue AS [Value] FROM dbo.Setting WHERE SettingName=@SettingName)
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterMovie]    Script Date: 2022-03-14 00:01:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterMovie](@EAN NUMERIC, @Title NVARCHAR(50), @Year SMALLINT, @CompanyID INT) AS
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
END
GO
/****** Object:  StoredProcedure [dbo].[SetSetting]    Script Date: 2022-03-14 00:01:06 ******/
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
