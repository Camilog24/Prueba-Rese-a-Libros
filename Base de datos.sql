USE [master]
GO

/****** Object:  Database [PruebaTecnicaReseña]    Script Date: 27/06/2024 08:53:46 p. m. ******/
CREATE DATABASE [PruebaTecnicaReseña]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaTecnicaReseña', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CAMILO\MSSQL\DATA\PruebaTecnicaReseña.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PruebaTecnicaReseña_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.CAMILO\MSSQL\DATA\PruebaTecnicaReseña_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [PruebaTecnicaReseña] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaTecnicaReseña].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ARITHABORT OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET  ENABLE_BROKER 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET  MULTI_USER 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PruebaTecnicaReseña] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PruebaTecnicaReseña] SET  READ_WRITE 
GO

