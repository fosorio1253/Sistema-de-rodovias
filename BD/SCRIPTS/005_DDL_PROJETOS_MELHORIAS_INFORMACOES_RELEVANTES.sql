USE [SGFD_NEW_DEV]
GO

/****** Object:  Table [dbo].[tab_projetos_melhorias_informacoes_relevantes]    Script Date: 22/02/2021 22:35:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tab_projetos_melhorias_informacoes_relevantes](
	[info_id] [int] IDENTITY(1,1) NOT NULL,
	[info_pro_id] [int] NULL,
	[info_data_atualizacao] [date] NULL,
	[info_addpor] [nvarchar](50) NULL,
	[info_descricao] [nvarchar](250) NULL,
 CONSTRAINT [PK_tab_projetos_melhorias_informacoes_relevantes] PRIMARY KEY CLUSTERED 
(
	[info_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tab_projetos_melhorias_informacoes_relevantes]  WITH CHECK ADD  CONSTRAINT [FK_tab_projetos_melhorias_informacoes_relevantes_tab_projetos_melhorias] FOREIGN KEY([info_pro_id])
REFERENCES [dbo].[tab_projetos_melhorias] ([pro_id])
GO

ALTER TABLE [dbo].[tab_projetos_melhorias_informacoes_relevantes] CHECK CONSTRAINT [FK_tab_projetos_melhorias_informacoes_relevantes_tab_projetos_melhorias]
GO


