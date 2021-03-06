USE [master]
GO
/****** Object:  Database [mil_fragancias]    Script Date: 11/5/2018 9:26:47 PM ******/
CREATE DATABASE [mil_fragancias]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mil_fragancias', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\mil_fragancias.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mil_fragancias_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\mil_fragancias_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [mil_fragancias] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mil_fragancias].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mil_fragancias] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mil_fragancias] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mil_fragancias] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mil_fragancias] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mil_fragancias] SET ARITHABORT OFF 
GO
ALTER DATABASE [mil_fragancias] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mil_fragancias] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mil_fragancias] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mil_fragancias] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mil_fragancias] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mil_fragancias] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mil_fragancias] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mil_fragancias] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mil_fragancias] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mil_fragancias] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mil_fragancias] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mil_fragancias] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mil_fragancias] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mil_fragancias] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mil_fragancias] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mil_fragancias] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mil_fragancias] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mil_fragancias] SET RECOVERY FULL 
GO
ALTER DATABASE [mil_fragancias] SET  MULTI_USER 
GO
ALTER DATABASE [mil_fragancias] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mil_fragancias] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mil_fragancias] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mil_fragancias] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mil_fragancias] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'mil_fragancias', N'ON'
GO
ALTER DATABASE [mil_fragancias] SET QUERY_STORE = OFF
GO
USE [mil_fragancias]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 11/5/2018 9:26:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Carrito] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 11/5/2018 9:26:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagen](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imagen] [image] NOT NULL,
	[activo] [char](1) NOT NULL,
 CONSTRAINT [PK_Imagen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/5/2018 9:26:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[producto] [nvarchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[idTipoProd] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[idImagen] [int] NOT NULL,
	[descripcion] [nvarchar](500) NULL,
	[activo] [char](1) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 11/5/2018 9:26:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
	[activo] [char](1) NOT NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/5/2018 9:26:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[contrasenna] [nvarchar](50) NOT NULL,
	[correo] [nvarchar](50) NOT NULL,
	[activo] [char](1) NOT NULL,
	[admin] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Correo] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNQ_Usuario] UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((2)) FOR [admin]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Producto]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Usuario]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Imagen] FOREIGN KEY([idImagen])
REFERENCES [dbo].[Imagen] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Imagen]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([idTipoProd])
REFERENCES [dbo].[TipoProducto] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
USE [master]
GO
ALTER DATABASE [mil_fragancias] SET  READ_WRITE 
GO
