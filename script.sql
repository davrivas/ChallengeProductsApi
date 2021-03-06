USE [master]
GO
/****** Object:  Database [ChallengeProducts]    Script Date: 2021-04-18 20:17:18 ******/
CREATE DATABASE [ChallengeProducts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChallengeProducts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChallengeProducts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChallengeProducts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChallengeProducts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChallengeProducts] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChallengeProducts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChallengeProducts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChallengeProducts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChallengeProducts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChallengeProducts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChallengeProducts] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChallengeProducts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChallengeProducts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChallengeProducts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChallengeProducts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChallengeProducts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChallengeProducts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChallengeProducts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChallengeProducts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChallengeProducts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChallengeProducts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChallengeProducts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChallengeProducts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChallengeProducts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChallengeProducts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChallengeProducts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChallengeProducts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChallengeProducts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChallengeProducts] SET RECOVERY FULL 
GO
ALTER DATABASE [ChallengeProducts] SET  MULTI_USER 
GO
ALTER DATABASE [ChallengeProducts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChallengeProducts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChallengeProducts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChallengeProducts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChallengeProducts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChallengeProducts] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChallengeProducts', N'ON'
GO
ALTER DATABASE [ChallengeProducts] SET QUERY_STORE = OFF
GO
USE [ChallengeProducts]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2021-04-18 20:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [money] NULL,
	[SoldDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[ProductTypeId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 2021-04-18 20:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Description], [Price], [SoldDate], [IsActive], [ProductTypeId]) VALUES (1, N'Motorbike', 300.0000, CAST(N'2021-04-17T12:51:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Product] ([Id], [Description], [Price], [SoldDate], [IsActive], [ProductTypeId]) VALUES (2, N'House', 2500.0000, CAST(N'2021-01-01T13:28:54.000' AS DateTime), 1, 1)
INSERT [dbo].[Product] ([Id], [Description], [Price], [SoldDate], [IsActive], [ProductTypeId]) VALUES (4, N'Gamer PC', 1000.0000, CAST(N'2021-04-18T23:35:48.583' AS DateTime), 0, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (1, N'Apartment')
INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (2, N'Vehicle')
INSERT [dbo].[ProductType] ([Id], [Name]) VALUES (3, N'Good')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
USE [master]
GO
ALTER DATABASE [ChallengeProducts] SET  READ_WRITE 
GO
