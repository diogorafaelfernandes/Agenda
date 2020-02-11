Script para criação do banco de dados:


USE [Agenda1]
GO

/****** Object:  Table [dbo].[contato]    Script Date: 11/02/2020 20:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[contato](
	[con_cod] [int] IDENTITY(1,1) NOT NULL,
	[con_nome] [varchar](80) NOT NULL,
	[con_telefone] [varchar](20) NOT NULL,
 CONSTRAINT [PK_contato] PRIMARY KEY CLUSTERED 
(
	[con_cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO
