USE [master]
GO
/****** Object:  Database [ProjectRooms]    Script Date: 2014-02-13 10:20:45 ******/
CREATE DATABASE [ProjectRooms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectRooms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectRooms.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectRooms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectRooms_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectRooms] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectRooms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectRooms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectRooms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectRooms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectRooms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectRooms] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectRooms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectRooms] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectRooms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectRooms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectRooms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectRooms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectRooms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectRooms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectRooms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectRooms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectRooms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectRooms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectRooms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectRooms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectRooms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectRooms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectRooms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectRooms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectRooms] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectRooms] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectRooms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectRooms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectRooms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectRooms] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectRooms', N'ON'
GO
USE [ProjectRooms]
GO
/****** Object:  Table [dbo].[tbBooking]    Script Date: 2014-02-13 10:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBooking](
	[iBookingID] [int] IDENTITY(1,1) NOT NULL,
	[iUserId] [int] NOT NULL,
	[iRumId] [int] NOT NULL,
	[dtDateDay] [date] NOT NULL,
	[dtTimeStart] [time](0) NOT NULL,
	[dtTimeEnd] [time](0) NOT NULL,
	[iCheckIn] [int] NULL,
 CONSTRAINT [PK_tbBooking] PRIMARY KEY CLUSTERED 
(
	[iBookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbBooking] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[tbRole]    Script Date: 2014-02-13 10:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRole](
	[iRoleID] [int] IDENTITY(1,1) NOT NULL,
	[sRoleType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbRole] PRIMARY KEY CLUSTERED 
(
	[iRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbRole] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[tbRoom]    Script Date: 2014-02-13 10:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRoom](
	[iRoomId] [int] IDENTITY(1,1) NOT NULL,
	[sRoomName] [nvarchar](50) NOT NULL,
	[iRoomChairs] [int] NOT NULL,
	[sRoomDesc] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbRoom] PRIMARY KEY CLUSTERED 
(
	[iRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 2014-02-13 10:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbUser](
	[iUserId] [int] IDENTITY(1,1) NOT NULL,
	[sUserName] [nvarchar](max) NOT NULL,
	[sUserLoginName] [nvarchar](50) NOT NULL,
	[sUserPassword] [nvarchar](50) NOT NULL,
	[iUserRole] [int] NULL,
	[iBlocked] [int] NULL,
	[sClass] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[iUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbRole] ON 

INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (1, N'Admin')
INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (2, N'User')
INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (3, N'Teacher')
SET IDENTITY_INSERT [dbo].[tbRole] OFF
SET IDENTITY_INSERT [dbo].[tbRoom] ON 

INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs], [sRoomDesc]) VALUES (1, N'Projektrum1', 7, N'Whiteboard, eluttag')
INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs], [sRoomDesc]) VALUES (2, N'Projektrum2', 6, N'Whiteboard')
INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs], [sRoomDesc]) VALUES (3, N'Projektrum3', 8, N'Whiteboard')
SET IDENTITY_INSERT [dbo].[tbRoom] OFF
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [sClass], [Email]) VALUES (1, N'Gun', N'Gun', N'123', 1, 0, N'Admin', NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [sClass], [Email]) VALUES (2, N'User', N'User', N'user', 2, 0, N'SHAN13', NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [sClass], [Email]) VALUES (3, N'Teacher', N'teacher', N'teacher', 3, 0, N'Lärare', NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [sClass], [Email]) VALUES (6, N'nyUser', N'nyUser', N'nyUser', 2, 0, NULL, NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [sClass], [Email]) VALUES (7, N'Hannah', N'Hannah', N'hannah', 2, 0, N'SHAN13', N'hannah.sahlberg@gmail.com')
SET IDENTITY_INSERT [dbo].[tbUser] OFF
ALTER TABLE [dbo].[tbBooking]  WITH CHECK ADD FOREIGN KEY([iRumId])
REFERENCES [dbo].[tbRoom] ([iRoomId])
GO
ALTER TABLE [dbo].[tbBooking]  WITH CHECK ADD FOREIGN KEY([iUserId])
REFERENCES [dbo].[tbUser] ([iUserId])
GO
ALTER TABLE [dbo].[tbUser]  WITH CHECK ADD FOREIGN KEY([iUserRole])
REFERENCES [dbo].[tbRole] ([iRoleID])
GO
USE [master]
GO
ALTER DATABASE [ProjectRooms] SET  READ_WRITE 
GO
