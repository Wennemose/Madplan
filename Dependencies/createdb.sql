USE [master]
GO

/****** Object:  Database [Foodplan]    Script Date: 22-06-2015 21:14:34 ******/
CREATE DATABASE [Foodplan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Foodplan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Foodplan.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Foodplan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Foodplan_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Foodplan] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Foodplan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Foodplan] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Foodplan] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Foodplan] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Foodplan] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Foodplan] SET ARITHABORT OFF 
GO

ALTER DATABASE [Foodplan] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Foodplan] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Foodplan] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Foodplan] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Foodplan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Foodplan] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Foodplan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Foodplan] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Foodplan] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Foodplan] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Foodplan] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Foodplan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Foodplan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Foodplan] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Foodplan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Foodplan] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Foodplan] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Foodplan] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Foodplan] SET RECOVERY FULL 
GO

ALTER DATABASE [Foodplan] SET  MULTI_USER 
GO

ALTER DATABASE [Foodplan] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Foodplan] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Foodplan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Foodplan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Foodplan] SET  READ_WRITE 
GO


USE [Foodplan]
GO

/****** Object:  Table [dbo].[FoodProduct]    Script Date: 22-06-2015 21:15:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FoodProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Protein] [decimal](16, 2) NOT NULL,
	[Fat] [decimal](16, 2) NOT NULL,
	[Carbonhydrate] [decimal](16, 2) NOT NULL,
	[Calories] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_FoodProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [Foodplan]
GO

/****** Object:  Table [dbo].[FoodProductNames]    Script Date: 22-06-2015 21:15:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FoodProductNames](
	[FoodId] [int] NOT NULL,
	[da-DK] [nvarchar](255) NOT NULL,
	[en-US] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FoodProductNames]  WITH CHECK ADD  CONSTRAINT [FK_FoodProductNames_FoodProduct] FOREIGN KEY([FoodId])
REFERENCES [dbo].[FoodProduct] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FoodProductNames] CHECK CONSTRAINT [FK_FoodProductNames_FoodProduct]
GO


USE [Foodplan]
GO

USE [Foodplan]
GO

/****** Object:  StoredProcedure [dbo].[AddFoodProduct]    Script Date: 22-06-2015 21:21:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddFoodProduct] 
	-- Add the parameters for the stored procedure here
	@daDK as nvarchar(255),
	@enUS as nvarchar(255),
	@protein as decimal(16,2),
	@carbonhydrate as decimal(16,2),
	@calories as decimal(16,2),
	@fat as decimal(16,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @foodproductid int
    -- Insert statements for procedure here
	INSERT INTO FoodProduct(Protein, Fat, Carbonhydrate,Calories)
	VALUES (@protein,@fat,@carbonhydrate,@calories)

	SET @foodproductid = SCOPE_IDENTITY()

	INSERT INTO FoodProductNames([da-DK], [en-US],FoodId)
	VALUES (@daDK,@enUS, @foodproductid)

	SELECT @foodproductid

END



GO





USE [Foodplan]
GO

/****** Object:  StoredProcedure [dbo].[GetAllFoodProducts]    Script Date: 22-06-2015 21:15:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllFoodProducts] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT fp.Id, fp.Protein, fp.Fat, fp.Carbonhydrate, fp.Calories, fpn.[da-DK], fpn.[en-US]
	FROM FoodProduct fp
	INNER JOIN FoodProductNames fpn ON fp.Id = fpn.FoodId
END

GO

USE [Foodplan]
GO

/****** Object:  StoredProcedure [dbo].[GetFoodProduct]    Script Date: 22-06-2015 21:15:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFoodProduct] 
	-- Add the parameters for the stored procedure here
	@id as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT fp.Id, fp.Protein, fp.Fat, fp.Carbonhydrate, fp.Calories, fpn.[da-DK], fpn.[en-US]
	FROM FoodProduct fp
	INNER JOIN FoodProductNames fpn ON fp.Id = fpn.FoodId
	WHERE fp.Id = @id
END

GO







