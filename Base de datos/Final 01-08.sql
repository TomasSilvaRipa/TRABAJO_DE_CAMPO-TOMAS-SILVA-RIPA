USE [master]
GO
/****** Object:  Database [TPGrupal]    Script Date: 1/8/2024 23:32:44 ******/
CREATE DATABASE [TPGrupal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaMerge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\PruebaMerge.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaMerge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\PruebaMerge_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TPGrupal] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPGrupal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPGrupal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPGrupal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPGrupal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPGrupal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPGrupal] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPGrupal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPGrupal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPGrupal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPGrupal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPGrupal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPGrupal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPGrupal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPGrupal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPGrupal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPGrupal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPGrupal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPGrupal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPGrupal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPGrupal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPGrupal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPGrupal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPGrupal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPGrupal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TPGrupal] SET  MULTI_USER 
GO
ALTER DATABASE [TPGrupal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPGrupal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPGrupal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPGrupal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPGrupal] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TPGrupal] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TPGrupal] SET QUERY_STORE = ON
GO
ALTER DATABASE [TPGrupal] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TPGrupal]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Tipo] [int] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Mensaje] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigitoVerificadorVertical]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreDeTabla] [nvarchar](max) NOT NULL,
	[DigitoVerificadorVertical] [nvarchar](max) NULL,
 CONSTRAINT [PK_DigitoVerificadorVertical] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GestorDeCambios]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GestorDeCambios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Sector] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[DigitoVerificador] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_GestorDeCambios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Palabras]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Palabras](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Texto] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Palabras] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[EsPadre] [bit] NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosXGrupo]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosXGrupo](
	[ID_PermisoPadre] [int] NOT NULL,
	[ID_PermisoHijo] [int] NOT NULL,
 CONSTRAINT [PK_PermisosXGrupo] PRIMARY KEY CLUSTERED 
(
	[ID_PermisoPadre] ASC,
	[ID_PermisoHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosXUsuario]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosXUsuario](
	[NombreDeUsuario] [nvarchar](max) NOT NULL,
	[ID_GrupoDePermisos] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traducciones](
	[Idiomas_Codigo] [int] NOT NULL,
	[Palabras_Codigo] [int] NOT NULL,
	[Traduccion] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [nvarchar](max) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Sector] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[DigitoVerificador] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PermisosXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXGrupo_Permisos] FOREIGN KEY([ID_PermisoPadre])
REFERENCES [dbo].[Permisos] ([ID])
GO
ALTER TABLE [dbo].[PermisosXGrupo] CHECK CONSTRAINT [FK_PermisosXGrupo_Permisos]
GO
ALTER TABLE [dbo].[PermisosXGrupo]  WITH CHECK ADD  CONSTRAINT [FK_PermisosXGrupo_Permisos1] FOREIGN KEY([ID_PermisoHijo])
REFERENCES [dbo].[Permisos] ([ID])
GO
ALTER TABLE [dbo].[PermisosXGrupo] CHECK CONSTRAINT [FK_PermisosXGrupo_Permisos1]
GO
ALTER TABLE [dbo].[Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Traducciones_Idiomas] FOREIGN KEY([Idiomas_Codigo])
REFERENCES [dbo].[Idiomas] ([ID])
GO
ALTER TABLE [dbo].[Traducciones] CHECK CONSTRAINT [FK_Traducciones_Idiomas]
GO
ALTER TABLE [dbo].[Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Traducciones_Palabras] FOREIGN KEY([Palabras_Codigo])
REFERENCES [dbo].[Palabras] ([ID])
GO
ALTER TABLE [dbo].[Traducciones] CHECK CONSTRAINT [FK_Traducciones_Palabras]
GO
/****** Object:  StoredProcedure [dbo].[AgregarBitacora]    Script Date: 1/8/2024 23:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarBitacora] 
@Fecha dateTime,
@Tipo int,
@Usuario nvarchar(50),
@Mensaje nvarchar(MAX)

AS
BEGIN
	SET NOCOUNT ON;
	Insert into Bitacora(Fecha,Tipo,Usuario,Mensaje) values(@Fecha,@Tipo,@Usuario,@Mensaje)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarGrupoDePermisosAUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarGrupoDePermisosAUsuario]
@Nombre nvarchar(MAX),
@ID_GrupoDePermisos int
AS
BEGIN
	
	SET NOCOUNT ON;
	Insert into PermisosXUsuario(NombreDeUsuario,ID_GrupoDePermisos) values(@Nombre,@ID_GrupoDePermisos)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarIdioma]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarIdioma]
    @NombreIdioma NVARCHAR(50),
    @Traducciones NVARCHAR(MAX) -- Formato: 'PalabraID1,Traduccion1;PalabraID2,Traduccion2;'
AS
BEGIN
    -- Insertar el nuevo idioma
    DECLARE @IDNuevoIdioma INT;
    INSERT INTO Idiomas(Nombre) VALUES (@NombreIdioma);
    SET @IDNuevoIdioma = SCOPE_IDENTITY(); -- Obtener el ID del nuevo idioma

    -- Preparar la tabla de traducciones
    DECLARE @TablaTraducciones TABLE (PalabraID INT, Traduccion NVARCHAR(50));

    -- Llenar la tabla de traducciones
    DECLARE @PalabraID NVARCHAR(10), @Traduccion NVARCHAR(50), @Pos INT;
    WHILE CHARINDEX(';', @Traducciones) > 0
    BEGIN
        SET @Pos = CHARINDEX(';', @Traducciones);
        SET @PalabraID = SUBSTRING(@Traducciones, 1, CHARINDEX(',', @Traducciones) - 1);
        SET @Traduccion = SUBSTRING(@Traducciones, CHARINDEX(',', @Traducciones) + 1, @Pos - CHARINDEX(',', @Traducciones) - 1);
        INSERT INTO @TablaTraducciones VALUES (@PalabraID, @Traduccion);
        SET @Traducciones = SUBSTRING(@Traducciones, @Pos + 1, LEN(@Traducciones));
    END

    -- Insertar las traducciones
    INSERT INTO TRADUCCIONES (Palabras_Codigo, Idiomas_Codigo, Traduccion)
    SELECT PalabraID, @IDNuevoIdioma, Traduccion FROM @TablaTraducciones;
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BuscarUsuario] @usuario as nvarchar(50)
as begin
select * from Usuarios where Usuario = @usuario
end
GO
/****** Object:  StoredProcedure [dbo].[ComprobarExistenciaUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ComprobarExistenciaUsuario] @nombre as varchar(40)
as
begin
select * from Usuarios where Usuario = @nombre
end
GO
/****** Object:  StoredProcedure [dbo].[CrearGrupoDePermisos]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearGrupoDePermisos]
@Nombre nvarchar(MAX),
@EsPadre int = 1
AS
BEGIN
	SET NOCOUNT ON;

	Insert into Permisos(Nombre,EsPadre) values(@Nombre,@EsPadre)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearOBorrarRelacionesDePermisos]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearOBorrarRelacionesDePermisos] 
@Donde int,
@ID_PermisoHijo int,
@ID_PermisoPadre int
AS
BEGIN
SET NOCOUNT ON;
    if(@Donde = 0)
    insert into PermisosXGrupo(ID_PermisoHijo,ID_PermisoPadre) values(@ID_PermisoHijo,@ID_PermisoPadre)
	else
	Delete from PermisosXGrupo where ID_PermisoPadre = @ID_PermisoPadre and ID_PermisoHijo = @ID_PermisoHijo
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteUsuario] @nombre as varchar(40)
as
begin
Update Usuarios set Activo=0 where Usuario = @nombre
end
GO
/****** Object:  StoredProcedure [dbo].[EliminarIdioma]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[EliminarIdioma] @IdIdioma int
as
begin
delete from Traducciones where Idiomas_Codigo= @IdIdioma
DELETE from Idiomas where ID = @IdIdioma
end
GO
/****** Object:  StoredProcedure [dbo].[FiltrarBitacoraPorFecha]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FiltrarBitacoraPorFecha] 

@Desde datetime,
@Hasta datetime

AS
BEGIN
	SET NOCOUNT ON;
	Select * from Bitacora where Fecha >= @Desde  AND Fecha <= @Hasta 
END
GO
/****** Object:  StoredProcedure [dbo].[FiltrarCombinado]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FiltrarCombinado] 
@Desde datetime,
@Hasta datetime,
@Tipo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Bitacora where (Fecha >= @Desde AND Fecha <= @Hasta) AND Tipo= @Tipo
END
GO
/****** Object:  StoredProcedure [dbo].[FiltrarPorTipo]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FiltrarPorTipo]
@Tipo int	
AS
BEGIN
	SET NOCOUNT ON;

   Select * from Bitacora where Tipo = @Tipo
END
GO
/****** Object:  StoredProcedure [dbo].[GestionarDigitoVerificadorVertical]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GestionarDigitoVerificadorVertical]
@Donde int,
@Nombre nvarchar(MAX),
@DigitoVerificadorVertical nvarchar(MAX)
AS
BEGIN
	
	SET NOCOUNT ON;
	if(@Donde = 0)
	Insert into DigitoVerificadorVertical(NombreDeTabla,DigitoVerificadorVertical) values(@Nombre,@DigitoVerificadorVertical)
	else
	Update DigitoVerificadorVertical SET DigitoVerificadorVertical = @DigitoVerificadorVertical
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarUsuario] @usuario as nvarchar(MAX), @clave as nvarchar(MAX), @sector as nvarchar(MAX), @DigitoVerificador as nvarchar(MAX),@Fecha dateTime 
as
begin
insert into Usuarios(Usuario, Clave, Sector,Activo,DigitoVerificador) values (@usuario, @clave, @sector, 1,@DigitoVerificador)
insert into GestorDeCambios(Nombre,Clave,Sector,Activo,DigitoVerificador,Fecha) values(@usuario,@clave,@sector,1,@DigitoVerificador,@Fecha)
end

GO
/****** Object:  StoredProcedure [dbo].[LeerBitacora]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerBitacora]
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Bitacora
END
GO
/****** Object:  StoredProcedure [dbo].[LeerDigitoVerificadorVertical]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerDigitoVerificadorVertical]
@Nombre nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;

   Select * from DigitoVerificadorVertical where NombreDeTabla = @Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[LeerGestorDeCambios]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerGestorDeCambios]
@Nombre nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	Select * from GestorDeCambios where Nombre = @Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[LeerGruposDePermisos]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerGruposDePermisos]
AS
BEGIN
	SET NOCOUNT ON;

    Select * From Permisos where EsPadre = 1 
END
GO
/****** Object:  StoredProcedure [dbo].[LeerIdiomas]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[LeerIdiomas]
as
begin
select * from Idiomas
end
GO
/****** Object:  StoredProcedure [dbo].[LeerPalabras]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[LeerPalabras]
as
begin
select * from Palabras
end
GO
/****** Object:  StoredProcedure [dbo].[LeerPermisos]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LeerPermisos]
@ID int = 0
AS
BEGIN
	
	SET NOCOUNT ON;
	if(@ID = 0)
	Select * from Permisos
	else
	Select * from Permisos where ID = @ID
    
END
GO
/****** Object:  StoredProcedure [dbo].[LeerPermisosXGrupo]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerPermisosXGrupo]
@IDGrupo int
AS
BEGIN
	SET NOCOUNT ON;

    Select * from PermisosXGrupo where ID_PermisoPadre = @IDGrupo
END
GO
/****** Object:  StoredProcedure [dbo].[LeerPermisosXUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerPermisosXUsuario]
@NombreDeUsuario nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	Select * from PermisosXUsuario where NombreDeUsuario = @NombreDeUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[LeerTraduccion]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[LeerTraduccion] @IdIdioma int
as
begin

select * from Traducciones where  Idiomas_Codigo= @IdIdioma

end
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuarios]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[LeerUsuarios]
as
begin
select * from Usuarios
end
GO
/****** Object:  StoredProcedure [dbo].[QuitarPermisosDeUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[QuitarPermisosDeUsuario]
@NombreDeUsuario nvarchar(MAX),
@ID int
AS
BEGIN
	SET NOCOUNT ON;

    Delete from PermisosXUsuario where NombreDeUsuario = @NombreDeUsuario and ID_GrupoDePermisos = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[RestablecerUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[RestablecerUsuario] @nombre as varchar(40), @clave as varchar(40)
as
begin
update Usuarios 
set Clave = @clave
where Usuario = @nombre 
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateIdioma]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateIdioma]
    @IDIdioma int,
    @Traducciones NVARCHAR(MAX) -- Formato: 'PalabraID1,Traduccion1;PalabraID2,Traduccion2;'
AS
BEGIN

    -- Preparar la tabla de traducciones
    DECLARE @TablaTraducciones TABLE (PalabraID INT, Traduccion NVARCHAR(50));

    -- Llenar la tabla de traducciones
    DECLARE @PalabraID NVARCHAR(10), @Traduccion NVARCHAR(50), @Pos INT;
    WHILE CHARINDEX(';', @Traducciones) > 0
    BEGIN
        SET @Pos = CHARINDEX(';', @Traducciones);
        SET @PalabraID = SUBSTRING(@Traducciones, 1, CHARINDEX(',', @Traducciones) - 1);
        SET @Traduccion = SUBSTRING(@Traducciones, CHARINDEX(',', @Traducciones) + 1, @Pos - CHARINDEX(',', @Traducciones) - 1);
        INSERT INTO @TablaTraducciones VALUES (@PalabraID, @Traduccion);
        SET @Traducciones = SUBSTRING(@Traducciones, @Pos + 1, LEN(@Traducciones));
    END

    -- Actualizar las traducciones
    UPDATE t
    SET t.Traduccion = tt.Traduccion
    FROM Traducciones t
    INNER JOIN @TablaTraducciones tt ON t.Palabras_Codigo = tt.PalabraID
    WHERE t.Idiomas_Codigo = @IDIdioma;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUsuario]    Script Date: 1/8/2024 23:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateUsuario] @nombre as nvarchar(MAX), @sector as nvarchar(MAX), @clave nvarchar(MAX), @DigitoVerificador nvarchar(MAX),@Fecha dateTime
as
begin
update Usuarios set Sector = @sector, Clave = @clave, DigitoVerificador = @DigitoVerificador where Usuario = @nombre
insert into GestorDeCambios(Nombre,Clave,Sector,Activo,DigitoVerificador,Fecha) values(@nombre,@clave,@sector,1,@DigitoVerificador,@Fecha)
end
GO
USE [master]
GO
ALTER DATABASE [TPGrupal] SET  READ_WRITE 
GO
