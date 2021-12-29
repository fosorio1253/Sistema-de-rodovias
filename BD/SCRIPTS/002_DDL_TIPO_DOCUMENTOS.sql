USE [SGFD_NEW_DEV]
GO

/****** Object:  Table [dbo].[tab_tipo_documentos]    Script Date: 23/01/2021 20:13:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tab_tipo_documentos](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_tipo_interessado] [int] NOT NULL,
	[doc_documentos] [nvarchar](200) NOT NULL,
	[doc_data_cadastro] [datetime] NOT NULL,
	[doc_data_atualizacao] [datetime] NOT NULL,
 CONSTRAINT [PK_tab_tipo_documentos] PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tab_tipo_documentos]  WITH CHECK ADD  CONSTRAINT [FK_tab_tipo_documentos_tab_tipo_interessado] FOREIGN KEY([doc_tipo_interessado])
REFERENCES [dbo].[tab_tipo_interessado] ([tip_id])
GO

ALTER TABLE [dbo].[tab_tipo_documentos] CHECK CONSTRAINT [FK_tab_tipo_documentos_tab_tipo_interessado]
GO


