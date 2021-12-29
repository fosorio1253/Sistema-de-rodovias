USE [SGFD_NEW_DEV]
GO

/****** Object:  Table [dbo].[tab_projetos_melhorias]    Script Date: 22/02/2021 22:37:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tab_projetos_melhorias](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_regional] [int] NULL,
	[pro_municipio] [int] NULL,
	[pro_rodovia] [int] NULL,
	[pro_nome] [nvarchar](250) NULL,
	[pro_km_inicial] [nvarchar](10) NULL,
	[pro_km_final] [nvarchar](10) NULL,
	[pro_extensao] [nvarchar](10) NULL,
	[pro_sentido] [nvarchar](10) NULL,
	[pro_lado] [nvarchar](10) NULL,
	[pro_lote] [nvarchar](10) NULL,
	[pro_status] [nvarchar](20) NULL,
	[pro_num_contrato] [nvarchar](50) NULL,
	[pro_prazo] [nvarchar](50) NULL,
	[pro_previsao_inicio] [nvarchar](50) NULL,
	[pro_descricao] [nvarchar](500) NULL,
	[pro_ativo] [bit] NULL,
 CONSTRAINT [PK_tab_projetos_melhorias] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


