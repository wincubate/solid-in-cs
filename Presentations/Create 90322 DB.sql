USE [master]
GO
/****** Object:  Database [90322]    Script Date: 24/10/2020 22.50.00 ******/
CREATE DATABASE [90322]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'90322', FILENAME = N'C:\Users\JesperGulmannHenriks\90322.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'90322_log', FILENAME = N'C:\Users\JesperGulmannHenriks\90322_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [90322] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [90322].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [90322] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [90322] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [90322] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [90322] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [90322] SET ARITHABORT OFF 
GO
ALTER DATABASE [90322] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [90322] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [90322] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [90322] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [90322] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [90322] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [90322] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [90322] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [90322] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [90322] SET  DISABLE_BROKER 
GO
ALTER DATABASE [90322] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [90322] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [90322] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [90322] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [90322] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [90322] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [90322] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [90322] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [90322] SET  MULTI_USER 
GO
ALTER DATABASE [90322] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [90322] SET DB_CHAINING OFF 
GO
ALTER DATABASE [90322] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [90322] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [90322] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [90322] SET QUERY_STORE = OFF
GO
USE [90322]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [90322]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[CouponCode] [nchar](10) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/10/2020 22.50.00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [int] NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 
GO
INSERT [dbo].[Comments] ([Id], [ProductId], [Description]) VALUES (1, 3, N'This book will become a bestseller')
GO
INSERT [dbo].[Comments] ([Id], [ProductId], [Description]) VALUES (2, 4, N'Suspected to be fake news')
GO
INSERT [dbo].[Comments] ([Id], [ProductId], [Description]) VALUES (3, 4, N'Will not be reprinted')
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (1, N'Jesper Gulmann', N'Henriksen', CAST(N'1972-03-17T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (2, N'Ane Kirk', N'Gulmann', CAST(N'1980-07-03T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (3, N'Frederikke Kirk', N'Gulmann', CAST(N'2007-03-24T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (4, N'Noah Kirk', N'Gulmann', CAST(N'2010-07-09T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (5, N'Jørgen Gulmann', N'Henriksen', CAST(N'1946-05-30T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (6, N'Annie Holmer', N'Henriksen', CAST(N'1946-03-30T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [BirthDate], [CouponCode]) VALUES (7, N'Heidi Gulmann', N'Olsen', CAST(N'1975-11-27T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([Id], [Name], [Price]) VALUES (1, N'Milk', 8)
GO
INSERT [dbo].[Items] ([Id], [Name], [Price]) VALUES (2, N'Butter', 16)
GO
INSERT [dbo].[Items] ([Id], [Name], [Price]) VALUES (3, N'Pepsi Max', 15)
GO
INSERT [dbo].[Items] ([Id], [Name], [Price]) VALUES (4, N'Bread', 22)
GO
INSERT [dbo].[Items] ([Id], [Name], [Price]) VALUES (5, N'Lego Friends', 99)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [ItemId], [Quantity]) VALUES (1, 1, 1, 3)
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [ItemId], [Quantity]) VALUES (2, 1, 3, 1)
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [ItemId], [Quantity]) VALUES (4, 2, 2, 4)
GO
INSERT [dbo].[Orders] ([Id], [CustomerId], [ItemId], [Quantity]) VALUES (5, 3, 5, 2)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Participants] ON 
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (1, N'Elon', N'Musk', N'Tesla')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (2, N'Satya', N'Nadella', N'Microsoft')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (3, N'Jeff', N'Bezos', N'Amazon')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (4, N'Cook', N'Tim', N'Apple')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (5, N'Mark', N'Zuckerberg', N'Facebook')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (6, N'Jack', N'Dorsey', N'Twitter')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (7, N'Ash', N'Williams', N'S-Mart')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (8, N'Apu', N'Nahasapeemapetilon', N'Kwik E-Mart')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (9, N'Al', N'McWhiggin', N'Al''s Toy Barn')
GO
INSERT [dbo].[Participants] ([Id], [FirstName], [LastName], [Company]) VALUES (10, N'Nolan', N'Sorrento', N'IOI')
GO
SET IDENTITY_INSERT [dbo].[Participants] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (1, 0, N'Microsoft', N'Something awesome')
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (2, 1, N'Wincubate Games', N'Business Suit Boba Goes Looking for Love in Aldaraan Places')
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (3, 2, N'Gang of One', N'Design Patterns in C#')
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (4, 2, N'Chris MacDonald', N'How to survive without Internet')
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (5, 0, N'Nintendo', N'Switch')
GO
INSERT [dbo].[Products] ([Id], [Category], [Manufacturer], [Name]) VALUES (6, 0, N'Nintendo', N'Switch Controller')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_ProductNotes_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_ProductNotes_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Items]
GO
USE [master]
GO
ALTER DATABASE [90322] SET  READ_WRITE 
GO
