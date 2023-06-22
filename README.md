AcmeCorp.API
AcmeCorp.API. is a REST API application in Asp.Net Core Web api. It provides APIs for managing customers contacts and orders which has the following functionalities
•	Add Customers
•	Edit Customers
•	Delete Customers
•	List Customers
Folder Structure
 
Getting Started
•	Clone https://github.com/searchanshuman/AcmeCorp.git using git commands or using Visual Studio
•	Open the Solution in Visual Studio (Preferably in 2019)
•	Create DB and Tables in Sql Server 
create database AcmeCorpDB
USE [AcmeCorpDB]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 6/22/2023 10:18:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](500) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [AcmeCorpDB]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 6/22/2023 10:19:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[Order Number] [nvarchar](50) NOT NULL,
	[Order Date] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Total] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO

•	Update ConnectionString in appSettings.json
•	Build the solution
•	Run the solution from Visual Studio
•	To host in IIS/Azure Cloud use publish options

