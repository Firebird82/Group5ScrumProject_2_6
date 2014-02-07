USE [master]
GO

/****** Object:  Database [ProjectRooms]    Script Date: 2014-02-07 09:44:47 ******/
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

ALTER DATABASE [ProjectRooms] SET  READ_WRITE 
GO

