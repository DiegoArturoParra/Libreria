USE [libreria]
GO
/****** Object:  Schema [libreria]    Script Date: 16/01/2022 11:53:26 p. m. ******/
CREATE SCHEMA [libreria]
GO
/****** Object:  Table [libreria].[autor]    Script Date: 16/01/2022 11:53:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [libreria].[autor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellido] [nvarchar](max) NOT NULL,
	[edad] [smallint] NOT NULL,
 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [libreria].[libro]    Script Date: 16/01/2022 11:53:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [libreria].[libro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isbn] [nvarchar](13) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[autor_id] [int] NOT NULL,
	[numero_paginas] [smallint] NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[fecha_salida] [date] NOT NULL,
 CONSTRAINT [PK_libro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [libreria].[libro]  WITH CHECK ADD  CONSTRAINT [FK_libro_autor_autor_id] FOREIGN KEY([autor_id])
REFERENCES [libreria].[autor] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [libreria].[libro] CHECK CONSTRAINT [FK_libro_autor_autor_id]
GO
