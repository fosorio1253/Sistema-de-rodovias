USE [SGFD_NEW_DEV]
GO

ALTER TABLE [dbo].[tab_arquivos] DROP CONSTRAINT [FK_dbo.tab_arquivos_dbo.tab_usuarios_usu_id]
GO

/****** Object:  Table [dbo].[tab_arquivos]    Script Date: 31/01/2021 14:30:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tab_arquivos]') AND type in (N'U'))
DROP TABLE [dbo].[tab_arquivos]
GO

/****** Object:  Table [dbo].[tab_arquivos]    Script Date: 31/01/2021 14:30:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tab_arquivos](
	[usu_id] [int] NOT NULL,
	[arq_id] [int] IDENTITY(1,1) NOT NULL,
	[arq_apagado] [bit] NOT NULL,
	[arq_nome] [nvarchar](100) NULL,
	[arq_extensao] [nvarchar](max) NULL,	
	[arq_tipo] [int] NOT NULL,
	[arq_documento] [nvarchar](200) NULL,
	[arq_tipo_interessado] [int] NULL,
	[arq_data_cadastro] [datetime] NOT NULL,
	[arq_data_atualizacao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tab_arquivos] PRIMARY KEY CLUSTERED 
(
	[arq_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tab_arquivos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_arquivos_dbo.tab_usuarios_usu_id] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tab_arquivos] CHECK CONSTRAINT [FK_dbo.tab_arquivos_dbo.tab_usuarios_usu_id]
GO


