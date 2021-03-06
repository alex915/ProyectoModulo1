USE [master]
GO
/****** Object:  Database [VideoClub]    Script Date: 10/14/2020 1:02:46 PM ******/
CREATE DATABASE [VideoClub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoClub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VideoClub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideoClub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VideoClub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VideoClub] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoClub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoClub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoClub] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoClub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoClub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoClub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoClub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoClub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoClub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoClub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideoClub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoClub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoClub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoClub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoClub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoClub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoClub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoClub] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VideoClub] SET  MULTI_USER 
GO
ALTER DATABASE [VideoClub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoClub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoClub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoClub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideoClub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VideoClub] SET QUERY_STORE = OFF
GO
USE [VideoClub]
GO
/****** Object:  Table [dbo].[Alquileres]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquileres](
	[idAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NOT NULL,
	[Pelicula] [int] NOT NULL,
	[FechaAlquiler] [datetime] NOT NULL,
	[TiempoReserva] [int] NOT NULL,
	[FechaDevolucion] [datetime] NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[idAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdadesRecomendadas]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdadesRecomendadas](
	[IdEdadRec] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Anios] [int] NOT NULL,
 CONSTRAINT [PK_EdadesRecomendadas] PRIMARY KEY CLUSTERED 
(
	[IdEdadRec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Area] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[IdPelicula] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Sinopsis] [text] NULL,
	[EdadRecomendada] [int] NOT NULL,
	[Genero] [int] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiemposReservas]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiemposReservas](
	[IdTiempo] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Dias] [int] NOT NULL,
 CONSTRAINT [PK_TiemposReservas] PRIMARY KEY CLUSTERED 
(
	[IdTiempo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/14/2020 1:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[FechaNac] [date] NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FechaReg] [date] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alquileres] ON 

INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (1, 1, 9, CAST(N'2020-10-12T01:38:02.793' AS DateTime), 1, CAST(N'2020-10-12T02:02:34.260' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (2, 1, 10, CAST(N'2020-10-12T01:38:17.123' AS DateTime), 1, CAST(N'2020-10-12T02:26:22.833' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (3, 1, 12, CAST(N'2020-10-12T01:38:25.047' AS DateTime), 1, NULL)
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (4, 1, 4, CAST(N'2020-10-12T01:38:35.103' AS DateTime), 1, CAST(N'2020-10-12T02:28:08.780' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (5, 1, 11, CAST(N'2020-10-12T02:03:12.330' AS DateTime), 3, NULL)
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (6, 2, 9, CAST(N'2020-10-12T12:24:22.517' AS DateTime), 3, CAST(N'2020-10-12T12:27:02.783' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (7, 2, 2, CAST(N'2020-10-12T12:27:37.687' AS DateTime), 2, CAST(N'2020-10-12T12:28:27.303' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (8, 2, 8, CAST(N'2020-10-12T12:27:56.980' AS DateTime), 2, CAST(N'2020-10-12T12:28:39.540' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (9, 3, 9, CAST(N'2020-10-13T21:36:40.533' AS DateTime), 1, CAST(N'2020-10-14T12:18:41.710' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (10, 3, 5, CAST(N'2020-10-13T21:52:17.180' AS DateTime), 4, NULL)
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (11, 3, 3, CAST(N'2020-10-13T22:20:39.850' AS DateTime), 4, NULL)
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (12, 3, 4, CAST(N'2020-10-14T02:06:42.933' AS DateTime), 3, CAST(N'2020-10-14T12:21:44.340' AS DateTime))
INSERT [dbo].[Alquileres] ([idAlquiler], [Usuario], [Pelicula], [FechaAlquiler], [TiempoReserva], [FechaDevolucion]) VALUES (13, 3, 1, CAST(N'2020-10-14T12:20:03.740' AS DateTime), 3, NULL)
SET IDENTITY_INSERT [dbo].[Alquileres] OFF
GO
SET IDENTITY_INSERT [dbo].[EdadesRecomendadas] ON 

INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (1, N'Todos los Públicos', 0)
INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (2, N'Mayores de 7 años', 7)
INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (3, N'Mayores de 12 años', 12)
INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (4, N'Mayores de 16 años', 16)
INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (5, N'Mayores de 18 años', 18)
INSERT [dbo].[EdadesRecomendadas] ([IdEdadRec], [Titulo], [Anios]) VALUES (6, N'Contenido X para Adultos', 18)
SET IDENTITY_INSERT [dbo].[EdadesRecomendadas] OFF
GO
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (1, N'Acción')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (2, N'Ciencia Ficción')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (3, N'Comedia')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (4, N'Drama')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (5, N'Fantasía')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (6, N'Melodrama')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (7, N'Musical')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (8, N'Romance')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (9, N'Suspense')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (10, N'Terror')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (11, N'Documental')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (12, N'XXX')
INSERT [dbo].[Generos] ([IdGenero], [Area]) VALUES (13, N'Western')
SET IDENTITY_INSERT [dbo].[Generos] OFF
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (1, N'Explota Explota', N'Cuenta la historia de María (García-Jonsson), una bailarina joven, sensual y con ansias de libertad a principios de los años 70, una época que en España estuvo marcada por la rigidez y la censura, especialmente en televisión. Con ella descubriremos cómo hasta el más difícil de los sueños puede convertirse en realidad. Y todo ello contado a través de los grandes éxitos de Raffaella Carrà.', 1, 7, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (2, N'The Vigil', N'Tras aceptar convertirse en shomer nocturno (una práctica judía en la que una persona vigila el cadáver de un miembro de la comunidad recientemente fallecido), un joven que acaba de perder su fe descubre que la casa donde ejerce de vigía esconde un terrorífico secreto.NULL', 6, 10, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (3, N'Como perros y gatos: La patrulla unida', N'El gato Gwen y el perro Roger son dos agentes secretos que protegen y salvan el mundo sin que los humanos tengan ni ella de ello. Su alianza se debe al Gran Pacto, que ha logrado detener la hostilidad entre perros y gatos durante una década. Sin embargo, la paz se ve ahora amenazada por un loro supervillano que ha descubierto una forma de manipular las frecuencias que sólo los perros y los gatos pueden oír. ¿Podrán estos héroes detener el avance del mal y evitar así una ''gatástrofe'' entre ambas especies?', 1, 3, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (4, N'Deadpool', N'Basado en el anti-héroe menos convencional de la Marvel, Deadpool narra el origen de un ex-operativo de la fuerzas especiales llamado Wade Wilson, reconvertido a mercenario, y que tras ser sometido a un cruel experimento adquiere poderes de curación rápida, adoptando Wade entonces el alter ego de Deadpool. Armado con sus nuevas habilidades y un oscuro y retorcido sentido del humor, Deadpool intentará dar caza al hombre que casi destruye su vida. ', 5, 1, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (5, N'No matarás', N'Dani, un buen chico que durante los últimos años de su vida se ha dedicado exclusivamente a cuidar de su padre enfermo, decide retomar su vida tras la muerte de éste. Justo cuando ha decidido emprender un largo viaje, conoce a Mila, una chica tan inquietante y sensual como inestable, que convertirá esa noche en una auténtica pesadilla. Las consecuencias de este encuentro llevarán a Dani hasta tal extremo que se planteará cosas que jamás habría podido imaginar.', 5, 9, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (6, N'De nuevo otra vez', N'Romina vuelve a la casa familiar, después de haber sido madre. Provisionalmente alejada de su novio, el padre de Ramón, se refugia en la casa de su madre Mónica, incapaz de tomar una decisión respecto de su pareja. Allí se ve sumergida en la temporalidad de su madre, de ella como hija, e intenta dilucidar qué desea. De visita en Buenos Aires, Romina da clases de alemán, intenta retomar su vida de soltera, salir de noche, conectarse con quien era antes de ser madre. Quiere saber cómo era antes de la experiencia del avasallante amor a su hijo. Necesita comprender quién es, retornando a sus orígenes y reconstruyendo algo de la historia familiar.', 5, 4, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (7, N'Nación cautiva', N'En un barrio de Chicago, casi una década después de una ocupación por una fuerza extraterrestre, Nación cautiva explora las vidas de ambos lados del conflicto: los colaboracionistas y los disidentes. Hace 10 años, los aliens arrebataron el planeta a los humanos. Hoy un grupo de rebeldes intentará comenzar a recuperarlo.', 5, 5, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (8, N'El rey del barrio', N'Una comedia dramática semiautobiográfica sobre los años que pasó Pete Davidson en Staten Island, incluyendo la muerte de su padre el 11-S y su introducción en el mundo de la comedia', 4, 3, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (9, N'Ema', N'Ema, una joven bailarina, decide separarse de Gastón luego de entregar a Polo en adopción, el hijo que ambos habían adoptado y que fueron incapaces de criar. Desesperada por las calles del puerto de Valparaíso, Ema busca nuevos amores para aplacar la culpa. Sin embargo, ese no es su único objetivo, también tiene un plan secreto para recuperarlo todo.', 3, 5, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (10, N'Inheritance', N'Cuando el patriarca de una poderosa familia asociada con vínculos políticos muere deja a su hija al frente de la estabilidad económica familiar. Su responsabilidad es doble, dado que su ya desaparecido padre le ha confesado un terrible secreto, así como una herencia maligna que amenaza con destruir tanto su vida como la de todo el mundo que tiene al su alrededor.', 4, 9, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (11, N'Mortal', N'Un hombre descubre que tiene los poderes propios de uno de los dioses que aparecen en la mitología nórdica.', 4, 5, 1)
INSERT [dbo].[Peliculas] ([IdPelicula], [Titulo], [Sinopsis], [EdadRecomendada], [Genero], [Estado]) VALUES (12, N'Under the Skin', N'Una misteriosa mujer (Scarlett Johansson) deambula por las calles de Escocia, arrastrando a hombres solitarios y confiados a un destino fatal... Adaptación surrealista de la novela homónima de Michel Faber.', 5, 5, 1)
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
SET IDENTITY_INSERT [dbo].[TiemposReservas] ON 

INSERT [dbo].[TiemposReservas] ([IdTiempo], [Titulo], [Dias]) VALUES (1, N'24 horas', 1)
INSERT [dbo].[TiemposReservas] ([IdTiempo], [Titulo], [Dias]) VALUES (2, N'48 horas', 2)
INSERT [dbo].[TiemposReservas] ([IdTiempo], [Titulo], [Dias]) VALUES (3, N'72 horas', 3)
INSERT [dbo].[TiemposReservas] ([IdTiempo], [Titulo], [Dias]) VALUES (4, N'5 días', 5)
INSERT [dbo].[TiemposReservas] ([IdTiempo], [Titulo], [Dias]) VALUES (5, N'Una semana', 7)
SET IDENTITY_INSERT [dbo].[TiemposReservas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNac], [Email], [Password], [FechaReg], [Estado]) VALUES (1, N'Paco', N'Alierta', N'Gutierrez', CAST(N'1997-11-14' AS Date), N'paco@gmail.com', N'1234', CAST(N'2020-10-12' AS Date), 1)
INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNac], [Email], [Password], [FechaReg], [Estado]) VALUES (2, N'David', N'Gomez', N'Ruiz', CAST(N'1989-05-02' AS Date), N'david@gmail.com', N'123', CAST(N'2020-10-12' AS Date), 0)
INSERT [dbo].[Usuarios] ([idUsuario], [Nombre], [PrimerApellido], [SegundoApellido], [FechaNac], [Email], [Password], [FechaReg], [Estado]) VALUES (3, N'a', N'a', N'a', CAST(N'1992-04-10' AS Date), N'a', N'12', CAST(N'2020-10-13' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_Pelicula] FOREIGN KEY([Pelicula])
REFERENCES [dbo].[Peliculas] ([IdPelicula])
GO
ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_Pelicula]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD  CONSTRAINT [FK_Alquileres_TiempoRes] FOREIGN KEY([TiempoReserva])
REFERENCES [dbo].[TiemposReservas] ([IdTiempo])
GO
ALTER TABLE [dbo].[Alquileres] CHECK CONSTRAINT [FK_Alquileres_TiempoRes]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_EdadRec] FOREIGN KEY([EdadRecomendada])
REFERENCES [dbo].[EdadesRecomendadas] ([IdEdadRec])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_EdadRec]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Generos] FOREIGN KEY([Genero])
REFERENCES [dbo].[Generos] ([IdGenero])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Generos]
GO
USE [master]
GO
ALTER DATABASE [VideoClub] SET  READ_WRITE 
GO
