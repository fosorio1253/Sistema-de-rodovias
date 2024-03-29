USE [master]
GO
/****** Object:  Database [SGFD_NEW_DEV]    Script Date: 01/03/2021 17:40:34 ******/
CREATE DATABASE [SGFD_NEW_DEV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SGFD_NEW_DEV', FILENAME = N'C:\Database\MSSQL11.MSSQLSERVER\MSSQL\DATA\SGFD_NEW_DEV.mdf' , SIZE = 118784KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SGFD_NEW_DEV_log', FILENAME = N'C:\Database\MSSQL11.MSSQLSERVER\MSSQL\DATA\SGFD_NEW_DEV_log.ldf' , SIZE = 265344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SGFD_NEW_DEV] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SGFD_NEW_DEV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ARITHABORT OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET RECOVERY FULL 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET  MULTI_USER 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SGFD_NEW_DEV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SGFD_NEW_DEV] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SGFD_NEW_DEV', N'ON'
GO
USE [SGFD_NEW_DEV]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 01/03/2021 17:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_alteraSenha]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_alteraSenha](
	[als_id] [uniqueidentifier] NOT NULL,
	[als_dataExpiracao] [datetime] NOT NULL,
	[als_jaUtilizado] [bit] NOT NULL,
	[usu_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_alteraSenha] PRIMARY KEY CLUSTERED 
(
	[als_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_arquivos]    Script Date: 01/03/2021 17:40:37 ******/
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
/****** Object:  Table [dbo].[tab_dadosMestres_col]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_dadosMestres_col](
	[dmc_id] [int] IDENTITY(1,1) NOT NULL,
	[dmc_nome] [nvarchar](max) NULL,
	[dmt_codigo] [nvarchar](128) NULL,
	[dmc_tipoDado] [int] NULL,
	[dmc_tamanho] [int] NULL,
	[dmc_obrigatorio] [bit] NULL,
 CONSTRAINT [PK_dbo.tab_dadosMestres_col] PRIMARY KEY CLUSTERED 
(
	[dmc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_dadosMestres_tbl]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_dadosMestres_tbl](
	[dmt_codigo] [nvarchar](128) NOT NULL,
	[dmt_nome] [varchar](100) NOT NULL,
	[dmt_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_dadosMestres_tbl] PRIMARY KEY CLUSTERED 
(
	[dmt_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[dmt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_dadosMestres_val]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_dadosMestres_val](
	[dmv_id] [int] IDENTITY(1,1) NOT NULL,
	[dmv_linha] [int] NOT NULL,
	[dmv_valor] [nvarchar](max) NULL,
	[col_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_dadosMestres_val] PRIMARY KEY CLUSTERED 
(
	[dmv_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_emails]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_emails](
	[eml_id] [int] IDENTITY(1,1) NOT NULL,
	[eml_assunto] [nvarchar](max) NULL,
	[eml_corpoEmail] [nvarchar](max) NULL,
	[eml_codigo] [nvarchar](max) NULL,
	[eml_cc] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tab_emails] PRIMARY KEY CLUSTERED 
(
	[eml_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_empresa]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_empresa](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_nome] [varchar](150) NULL,
	[emp_CNPJ] [char](18) NULL,
	[emp_excluido] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.tab_empresa] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_empresa_atuacao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_empresa_atuacao](
	[atu_id] [int] IDENTITY(1,1) NOT NULL,
	[atu_nome] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[atu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado](
	[int_id] [int] IDENTITY(1,1) NOT NULL,
	[int_numerospdoc] [varchar](100) NULL,
	[dmv_id_natureza_juridica] [int] NULL,
	[dmv_id_tipo_interessado] [int] NULL,
	[int_nome] [varchar](100) NOT NULL,
	[int_documento] [varchar](18) NOT NULL,
	[int_matrizOuFilial] [varchar](100) NOT NULL,
	[int_nomeFantasia] [varchar](100) NOT NULL,
	[int_validoAte] [datetime] NULL,
	[int_statusSPDOC] [varchar](100) NULL,
	[sta_id] [int] NOT NULL,
	[int_ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[int_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado_contato]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado_contato](
	[int_con_id] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NOT NULL,
	[int_con_principal] [bit] NULL,
	[usu_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[int_con_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado_documento]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado_documento](
	[int_doc_id] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NULL,
	[int_doc_documento] [varchar](100) NOT NULL,
	[int_doc_arquivo] [varchar](500) NULL,
	[int_doc_data] [datetime] NOT NULL,
	[int_doc_addPor] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[int_doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado_endereco]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado_endereco](
	[int_end_id] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NOT NULL,
	[dmv_id_municipio] [int] NOT NULL,
	[dmv_id_unidade] [int] NOT NULL,
	[int_end_logradouro] [varchar](100) NOT NULL,
	[int_end_cep] [char](9) NOT NULL,
	[int_end_numero] [varchar](20) NOT NULL,
	[int_end_complemento] [varchar](50) NOT NULL,
	[int_end_bairro] [varchar](100) NOT NULL,
	[int_end_nome_contato] [varchar](100) NOT NULL,
	[int_end_principal] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[int_end_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado_observacao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado_observacao](
	[int_obs_id] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NOT NULL,
	[int_obs_observacao] [varchar](500) NOT NULL,
	[int_obs_data] [datetime] NOT NULL,
	[int_obs_addPor] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[int_obs_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_interessado_tipo_de_concessao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_interessado_tipo_de_concessao](
	[int_tipo_concessao] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NOT NULL,
	[dmv_id_tipo_concessao] [int] NOT NULL,
	[int_tipo_concessao_marcado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[int_tipo_concessao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_grupos]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_grupos](
	[grp_id] [int] IDENTITY(1,1) NOT NULL,
	[grp_nome] [varchar](50) NULL,
	[grp_descricao] [varchar](150) NULL,
	[prf_id] [int] NOT NULL,
	[grp_excluido] [bit] NOT NULL,
	[grp_ativo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.tab_grupos] PRIMARY KEY CLUSTERED 
(
	[grp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_logAlteracao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_logAlteracao](
	[loa_id] [int] IDENTITY(1,1) NOT NULL,
	[loa_NomeEntidade] [nvarchar](max) NULL,
	[loa_idAlterado] [nvarchar](max) NULL,
	[loa_valorAntigo] [nvarchar](max) NULL,
	[loa_novoValor] [nvarchar](max) NULL,
	[loa_usuarioResponsavel] [int] NOT NULL,
	[loa_dataAlteracao] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.tab_logAlteracao] PRIMARY KEY CLUSTERED 
(
	[loa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_perfil_permissao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_perfil_permissao](
	[prf_id] [int] NOT NULL,
	[per_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_perfil_permissao] PRIMARY KEY CLUSTERED 
(
	[prf_id] ASC,
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_perfis]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_perfis](
	[prf_id] [int] IDENTITY(1,1) NOT NULL,
	[prf_nome] [nvarchar](50) NULL,
	[prf_descricao] [nvarchar](255) NULL,
	[prf_excluido] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.tab_perfis] PRIMARY KEY CLUSTERED 
(
	[prf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_permissoes]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_permissoes](
	[per_id] [int] IDENTITY(1,1) NOT NULL,
	[per_nome] [nvarchar](150) NULL,
	[per_excluido] [bit] NOT NULL,
	[per_paiId] [int] NULL,
	[per_codigo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tab_permissoes] PRIMARY KEY CLUSTERED 
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_projetos_melhorias]    Script Date: 01/03/2021 17:40:37 ******/
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
	[pro_unidade_conservacao] [nvarchar](50) NULL,
 CONSTRAINT [PK_tab_projetos_melhorias] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_projetos_melhorias_informacoes_relevantes]    Script Date: 01/03/2021 17:40:37 ******/
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
/****** Object:  Table [dbo].[tab_projetos_melhorias_status]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_projetos_melhorias_status](
	[pro_sta_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_sta_nome] [nvarchar](50) NULL,
	[pro_sta_marcado] [nchar](10) NULL,
	[pro_sta_projetos_melhorias] [int] NULL,
 CONSTRAINT [PK_tab_projetos_melhorias_status] PRIMARY KEY CLUSTERED 
(
	[pro_sta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_status_aprovacao]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_status_aprovacao](
	[sta_id] [int] IDENTITY(1,1) NOT NULL,
	[sta_nome] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.tab_status_aprovacao] PRIMARY KEY CLUSTERED 
(
	[sta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_statusSPDOC]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_statusSPDOC](
	[sta_spdoc_id] [int] IDENTITY(1,1) NOT NULL,
	[sta_spdoc_nome] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sta_spdoc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_tipo_documentos]    Script Date: 01/03/2021 17:40:37 ******/
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
/****** Object:  Table [dbo].[tab_tipo_interessado]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_tipo_interessado](
	[tip_id] [int] NOT NULL,
	[tip_descricao] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_usuario_empresa]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_usuario_empresa](
	[usu_id] [int] NOT NULL,
	[emp_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_usuario_empresa] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC,
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_usuario_grupo]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_usuario_grupo](
	[usu_id] [int] NOT NULL,
	[grp_id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tab_usuario_grupo] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC,
	[grp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_usuarios]    Script Date: 01/03/2021 17:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_usuarios](
	[usu_id] [int] IDENTITY(1,1) NOT NULL,
	[usu_ativo] [bit] NOT NULL,
	[usu_externo] [bit] NOT NULL,
	[usu_nome] [varchar](150) NOT NULL,
	[usu_cargo] [varchar](50) NULL,
	[usu_login] [varchar](10) NOT NULL,
	[usu_senha] [nvarchar](255) NULL,
	[usu_email] [nvarchar](255) NOT NULL,
	[usu_ddd] [nvarchar](2) NULL,
	[usu_telefoneRamal] [nvarchar](max) NULL,
	[usu_dataCriacao] [datetime] NOT NULL,
	[sta_id] [int] NOT NULL,
	[usu_excluido] [bit] NOT NULL,
	[usu_cpf] [nvarchar](15) NULL,
	[usu_token_alteracao] [uniqueidentifier] NOT NULL,
	[dmv_id_regional] [int] NULL,
 CONSTRAINT [PK_dbo.tab_usuarios] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_usu_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_alteraSenha]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dmt_codigo]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_dmt_codigo] ON [dbo].[tab_dadosMestres_col]
(
	[dmt_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_col_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_col_id] ON [dbo].[tab_dadosMestres_val]
(
	[col_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_prf_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_prf_id] ON [dbo].[tab_grupos]
(
	[prf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_per_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_per_id] ON [dbo].[tab_perfil_permissao]
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_prf_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_prf_id] ON [dbo].[tab_perfil_permissao]
(
	[prf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_per_paiId]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_per_paiId] ON [dbo].[tab_permissoes]
(
	[per_paiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_emp_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_emp_id] ON [dbo].[tab_usuario_empresa]
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_usu_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_usuario_empresa]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_grp_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_grp_id] ON [dbo].[tab_usuario_grupo]
(
	[grp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_usu_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_usuario_grupo]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sta_id]    Script Date: 01/03/2021 17:40:37 ******/
CREATE NONCLUSTERED INDEX [IX_sta_id] ON [dbo].[tab_usuarios]
(
	[sta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tab_usuarios] ADD  CONSTRAINT [DF__tab_usuar__usu_t__0FD74C44]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [usu_token_alteracao]
GO
ALTER TABLE [dbo].[tab_alteraSenha]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_alteraSenha_dbo.tab_usuarios_usu_id] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_alteraSenha] CHECK CONSTRAINT [FK_dbo.tab_alteraSenha_dbo.tab_usuarios_usu_id]
GO
ALTER TABLE [dbo].[tab_arquivos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_arquivos_dbo.tab_usuarios_usu_id] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_arquivos] CHECK CONSTRAINT [FK_dbo.tab_arquivos_dbo.tab_usuarios_usu_id]
GO
ALTER TABLE [dbo].[tab_dadosMestres_col]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_dadosMestres_col_dbo.tab_dadosMestres_tbl_dmt_codigo] FOREIGN KEY([dmt_codigo])
REFERENCES [dbo].[tab_dadosMestres_tbl] ([dmt_codigo])
GO
ALTER TABLE [dbo].[tab_dadosMestres_col] CHECK CONSTRAINT [FK_dbo.tab_dadosMestres_col_dbo.tab_dadosMestres_tbl_dmt_codigo]
GO
ALTER TABLE [dbo].[tab_dadosMestres_val]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_dadosMestres_val_dbo.tab_dadosMestres_col_col_id] FOREIGN KEY([col_id])
REFERENCES [dbo].[tab_dadosMestres_col] ([dmc_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_dadosMestres_val] CHECK CONSTRAINT [FK_dbo.tab_dadosMestres_val_dbo.tab_dadosMestres_col_col_id]
GO
ALTER TABLE [dbo].[tab_gestao_interessado]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Int_Natureza_Juridica] FOREIGN KEY([dmv_id_natureza_juridica])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado] CHECK CONSTRAINT [FK_Gestao_Int_Natureza_Juridica]
GO
ALTER TABLE [dbo].[tab_gestao_interessado]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Int_Tipo_Int] FOREIGN KEY([dmv_id_tipo_interessado])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado] CHECK CONSTRAINT [FK_Gestao_Int_Tipo_Int]
GO
ALTER TABLE [dbo].[tab_gestao_interessado]  WITH CHECK ADD  CONSTRAINT [FK_Status_Aprovacao_Gestao] FOREIGN KEY([sta_id])
REFERENCES [dbo].[tab_status_aprovacao] ([sta_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado] CHECK CONSTRAINT [FK_Status_Aprovacao_Gestao]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_contato]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Int_Cont_Gestao_Int] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_contato] CHECK CONSTRAINT [FK_Gestao_Int_Cont_Gestao_Int]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_contato]  WITH CHECK ADD  CONSTRAINT [FK_GestaoInteressado_Contato_Usuario] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_contato] CHECK CONSTRAINT [FK_GestaoInteressado_Contato_Usuario]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_documento]  WITH CHECK ADD  CONSTRAINT [GestaoInteressadoEndereco_GestaoInteressado] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_documento] CHECK CONSTRAINT [GestaoInteressadoEndereco_GestaoInteressado]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco]  WITH CHECK ADD  CONSTRAINT [FK_Gestao__Int_End_Unidade] FOREIGN KEY([dmv_id_unidade])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco] CHECK CONSTRAINT [FK_Gestao__Int_End_Unidade]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Int_End_Gestao_Int] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco] CHECK CONSTRAINT [FK_Gestao_Int_End_Gestao_Int]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Int_End_Municipio] FOREIGN KEY([dmv_id_municipio])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_endereco] CHECK CONSTRAINT [FK_Gestao_Int_End_Municipio]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_observacao]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Observacao_Gestao_Int] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_observacao] CHECK CONSTRAINT [FK_Gestao_Observacao_Gestao_Int]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_tipo_de_concessao]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Tipo_Concessao_Gestao_Int] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_tipo_de_concessao] CHECK CONSTRAINT [FK_Gestao_Tipo_Concessao_Gestao_Int]
GO
ALTER TABLE [dbo].[tab_gestao_interessado_tipo_de_concessao]  WITH CHECK ADD  CONSTRAINT [FK_Gestao_Tipo_Concessao_Mestres_Tipo] FOREIGN KEY([dmv_id_tipo_concessao])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_interessado_tipo_de_concessao] CHECK CONSTRAINT [FK_Gestao_Tipo_Concessao_Mestres_Tipo]
GO
ALTER TABLE [dbo].[tab_grupos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_grupos_dbo.tab_perfis_prf_id] FOREIGN KEY([prf_id])
REFERENCES [dbo].[tab_perfis] ([prf_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_grupos] CHECK CONSTRAINT [FK_dbo.tab_grupos_dbo.tab_perfis_prf_id]
GO
ALTER TABLE [dbo].[tab_perfil_permissao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_perfil_permissao_dbo.tab_perfis_prf_id] FOREIGN KEY([prf_id])
REFERENCES [dbo].[tab_perfis] ([prf_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_perfil_permissao] CHECK CONSTRAINT [FK_dbo.tab_perfil_permissao_dbo.tab_perfis_prf_id]
GO
ALTER TABLE [dbo].[tab_perfil_permissao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_perfil_permissao_dbo.tab_permissoes_per_id] FOREIGN KEY([per_id])
REFERENCES [dbo].[tab_permissoes] ([per_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_perfil_permissao] CHECK CONSTRAINT [FK_dbo.tab_perfil_permissao_dbo.tab_permissoes_per_id]
GO
ALTER TABLE [dbo].[tab_permissoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_permissoes_dbo.tab_permissoes_per_paiId] FOREIGN KEY([per_paiId])
REFERENCES [dbo].[tab_permissoes] ([per_id])
GO
ALTER TABLE [dbo].[tab_permissoes] CHECK CONSTRAINT [FK_dbo.tab_permissoes_dbo.tab_permissoes_per_paiId]
GO
ALTER TABLE [dbo].[tab_projetos_melhorias_informacoes_relevantes]  WITH CHECK ADD  CONSTRAINT [FK_tab_projetos_melhorias_informacoes_relevantes_tab_projetos_melhorias] FOREIGN KEY([info_pro_id])
REFERENCES [dbo].[tab_projetos_melhorias] ([pro_id])
GO
ALTER TABLE [dbo].[tab_projetos_melhorias_informacoes_relevantes] CHECK CONSTRAINT [FK_tab_projetos_melhorias_informacoes_relevantes_tab_projetos_melhorias]
GO
ALTER TABLE [dbo].[tab_projetos_melhorias_status]  WITH CHECK ADD  CONSTRAINT [FK_tab_projetos_melhorias_status_tab_projetos_melhorias] FOREIGN KEY([pro_sta_projetos_melhorias])
REFERENCES [dbo].[tab_projetos_melhorias] ([pro_id])
GO
ALTER TABLE [dbo].[tab_projetos_melhorias_status] CHECK CONSTRAINT [FK_tab_projetos_melhorias_status_tab_projetos_melhorias]
GO
ALTER TABLE [dbo].[tab_usuario_empresa]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_usuario_empresa_dbo.tab_empresa_emp_id] FOREIGN KEY([emp_id])
REFERENCES [dbo].[tab_empresa] ([emp_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_usuario_empresa] CHECK CONSTRAINT [FK_dbo.tab_usuario_empresa_dbo.tab_empresa_emp_id]
GO
ALTER TABLE [dbo].[tab_usuario_empresa]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_usuario_empresa_dbo.tab_usuarios_usu_id] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_usuario_empresa] CHECK CONSTRAINT [FK_dbo.tab_usuario_empresa_dbo.tab_usuarios_usu_id]
GO
ALTER TABLE [dbo].[tab_usuario_grupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_usuario_grupo_dbo.tab_grupos_grp_id] FOREIGN KEY([grp_id])
REFERENCES [dbo].[tab_grupos] ([grp_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_usuario_grupo] CHECK CONSTRAINT [FK_dbo.tab_usuario_grupo_dbo.tab_grupos_grp_id]
GO
ALTER TABLE [dbo].[tab_usuario_grupo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_usuario_grupo_dbo.tab_usuarios_usu_id] FOREIGN KEY([usu_id])
REFERENCES [dbo].[tab_usuarios] ([usu_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_usuario_grupo] CHECK CONSTRAINT [FK_dbo.tab_usuario_grupo_dbo.tab_usuarios_usu_id]
GO
ALTER TABLE [dbo].[tab_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tab_usuarios_dbo.tab_status_aprovacao_sta_id] FOREIGN KEY([sta_id])
REFERENCES [dbo].[tab_status_aprovacao] ([sta_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tab_usuarios] CHECK CONSTRAINT [FK_dbo.tab_usuarios_dbo.tab_status_aprovacao_sta_id]
GO
ALTER TABLE [dbo].[tab_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Regional] FOREIGN KEY([dmv_id_regional])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_usuarios] CHECK CONSTRAINT [FK_Usuario_Regional]
GO
USE [master]
GO
ALTER DATABASE [SGFD_NEW_DEV] SET  READ_WRITE 
GO
