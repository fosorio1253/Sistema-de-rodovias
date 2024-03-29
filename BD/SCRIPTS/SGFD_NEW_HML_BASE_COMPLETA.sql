USE [master]
GO
/****** Object:  Database [SGFD_NEW_DEV]    Script Date: 19/05/2021 16:08:48 ******/
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
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_alteraSenha]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_arquivos]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_dadosMestres_col]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_dadosMestres_tbl]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_dadosMestres_val]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_emails]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_empresa]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_empresa_atuacao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado_contato]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado_documento]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado_endereco]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado_observacao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_interessado_tipo_de_concessao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_gestao_ocupacao]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao](
	[ocu_id] [int] IDENTITY(1,1) NOT NULL,
	[int_id] [int] NOT NULL,
	[dmv_idRegional] [int] NULL,
	[ocu_numerospdoc] [varchar](100) NULL,
	[ocu_numeroProcesso] [varchar](100) NULL,
	[ocu_dataDespacho] [datetime] NULL,
	[dmv_idOrigemSolicitacao] [int] NULL,
	[ocu_situacaoSolicitacao] [int] NULL,
	[ocu_dataCadastro] [datetime] NULL,
	[ocu_ativo] [bit] NULL,
	[ocu_residencial_conservacao_id] [int] NULL,
 CONSTRAINT [PK__tab_gest__19BCACC049B74B98] PRIMARY KEY CLUSTERED 
(
	[ocu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_deferimento]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_deferimento](
	[ocu_def_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NULL,
	[ocu_def_data_assinatura] [datetime] NULL,
	[ocu_def_data_publicacao] [datetime] NULL,
	[ocu_def_data_despacho] [datetime] NULL,
	[ocu_def_numero_processo] [varchar](100) NULL,
	[ocu_def_caminho_arquivo] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_def_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_documento]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_documento](
	[ocu_doc_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NULL,
	[ocu_doc_documento] [varchar](100) NOT NULL,
	[ocu_doc_arquivo] [varchar](500) NULL,
	[ocu_doc_data] [datetime] NOT NULL,
	[ocu_doc_addPor] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_ocorrencia]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_ocorrencia](
	[ocu_oco_int] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NOT NULL,
	[ocu_oco_dataOcorrencia] [datetime] NULL,
	[ocu_oco_autor] [varchar](100) NULL,
	[ocu_oco_area] [varchar](100) NULL,
	[ocu_oco_ocorrencia] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_oco_int] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_ocupacao]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_ocupacao](
	[ocu_ocu_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NULL,
	[ocu_ocu_assunto] [varchar](100) NOT NULL,
	[ocu_ocu_observacao] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_ocu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_parecer]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_parecer](
	[ocu_par_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NULL,
	[ocu_par_regional_obeservacao] [varchar](100) NULL,
	[ocu_par_regional_data] [datetime] NULL,
	[ocu_par_regional_id] [int] NULL,
	[ocu_par_engenharia_obeservacao] [varchar](100) NULL,
	[ocu_par_engenharia_data] [datetime] NULL,
	[ocu_par_engenharia_id] [int] NULL,
	[ocu_par_coordenadoria_obeservacao] [varchar](100) NULL,
	[ocu_par_coordenadoria_data] [datetime] NULL,
	[ocu_par_coordenadoria_id] [int] NULL,
	[ocu_par_faixa_obeservacao] [varchar](100) NULL,
	[ocu_par_faixa_data] [datetime] NULL,
	[ocu_par_faixa_id] [int] NULL,
	[ocu_par_data] [datetime] NULL,
	[ocu_par_caminho_arq_coordenadoria] [varchar](200) NULL,
	[ocu_par_caminho_arq_diretoria] [varchar](200) NULL,
	[ocu_par_caminho_arq_faixa_dominio] [varchar](200) NULL,
	[ocu_par_caminho_arq_regional] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_par_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_trecho]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_trecho](
	[ocu_tre_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_id] [int] NOT NULL,
	[ocu_tre_rodovia_id] [int] NULL,
	[ocu_tre_kminicial] [decimal](18, 3) NULL,
	[ocu_tre_kmfinal] [decimal](18, 3) NULL,
	[ocu_tre_extensao] [decimal](18, 3) NULL,
	[ocu_tre_localizacao] [int] NULL,
	[ocu_tre_tipo_implantacao_id] [int] NULL,
	[ocu_tre_tipo_passagem_id] [int] NULL,
	[ocu_tre_lado] [int] NULL,
	[ocu_tre_tipo_ocupacao_id] [int] NULL,
	[ocu_tre_altura] [decimal](18, 3) NULL,
	[ocu_tre_profundidade] [decimal](18, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_tre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_gestao_ocupacao_trecho_interferencia]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_gestao_ocupacao_trecho_interferencia](
	[ocu_tre_int_id] [int] IDENTITY(1,1) NOT NULL,
	[ocu_tre_id] [int] NOT NULL,
	[ocu_tre_int_tipo_id] [int] NOT NULL,
	[ocu_tre_int_volume] [decimal](18, 3) NULL,
	[ocu_tre_int_quantidade] [decimal](18, 3) NULL,
	[ocu_tre_int_volume_total] [decimal](18, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[ocu_tre_int_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_grupos]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_logAlteracao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_perfil_permissao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_perfis]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_permissoes]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_projetos_melhorias]    Script Date: 19/05/2021 16:08:50 ******/
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
	[pro_km_inicial] [float] NULL,
	[pro_km_final] [float] NULL,
	[pro_extensao] [float] NULL,
	[pro_sentido] [nvarchar](50) NULL,
	[pro_lado] [int] NULL,
	[pro_lote] [nvarchar](100) NULL,
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
/****** Object:  Table [dbo].[tab_projetos_melhorias_informacoes_relevantes]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_projetos_melhorias_status]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_projetos_melhorias_status](
	[pro_sta_id] [int] IDENTITY(1,1) NOT NULL,
	[pro_sta_nome] [nvarchar](50) NULL,
	[pro_sta_marcado] [nchar](10) NULL,
	[pro_sta_projetos_melhorias] [int] NOT NULL,
 CONSTRAINT [PK_tab_projetos_melhorias_status] PRIMARY KEY CLUSTERED 
(
	[pro_sta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_status_aprovacao]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_statusSPDOC]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_tipo_documentos]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_tipo_interessado]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_tipo_interessado](
	[tip_id] [int] NOT NULL,
	[tip_descricao] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tab_usuario_empresa]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_usuario_grupo]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Table [dbo].[tab_usuarios]    Script Date: 19/05/2021 16:08:50 ******/
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
/****** Object:  Index [IX_usu_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_alteraSenha]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_dmt_codigo]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_dmt_codigo] ON [dbo].[tab_dadosMestres_col]
(
	[dmt_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_col_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_col_id] ON [dbo].[tab_dadosMestres_val]
(
	[col_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_prf_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_prf_id] ON [dbo].[tab_grupos]
(
	[prf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_per_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_per_id] ON [dbo].[tab_perfil_permissao]
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_prf_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_prf_id] ON [dbo].[tab_perfil_permissao]
(
	[prf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_per_paiId]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_per_paiId] ON [dbo].[tab_permissoes]
(
	[per_paiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_emp_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_emp_id] ON [dbo].[tab_usuario_empresa]
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_usu_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_usuario_empresa]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_grp_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_grp_id] ON [dbo].[tab_usuario_grupo]
(
	[grp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_usu_id]    Script Date: 19/05/2021 16:08:50 ******/
CREATE NONCLUSTERED INDEX [IX_usu_id] ON [dbo].[tab_usuario_grupo]
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_sta_id]    Script Date: 19/05/2021 16:08:50 ******/
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
ALTER TABLE [dbo].[tab_gestao_ocupacao]  WITH CHECK ADD  CONSTRAINT [FK_tab_gestao_ocupacao_tab_gestao_interessado] FOREIGN KEY([int_id])
REFERENCES [dbo].[tab_gestao_interessado] ([int_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao] CHECK CONSTRAINT [FK_tab_gestao_ocupacao_tab_gestao_interessado]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_deferimento]  WITH CHECK ADD  CONSTRAINT [GestaoOcupacaoDeferimento_GestaoOcupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_deferimento] CHECK CONSTRAINT [GestaoOcupacaoDeferimento_GestaoOcupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_documento]  WITH CHECK ADD  CONSTRAINT [GestaoOcupacaoDocumento_GestaoOcupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_documento] CHECK CONSTRAINT [GestaoOcupacaoDocumento_GestaoOcupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_ocorrencia]  WITH CHECK ADD  CONSTRAINT [FK_tab_gestao_ocupacao_ocorrencia_tab_gestao_ocupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_ocorrencia] CHECK CONSTRAINT [FK_tab_gestao_ocupacao_ocorrencia_tab_gestao_ocupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_ocupacao]  WITH CHECK ADD  CONSTRAINT [GestaoOcupacaoOcupacao_GestaoOcupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_ocupacao] CHECK CONSTRAINT [GestaoOcupacaoOcupacao_GestaoOcupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_parecer]  WITH CHECK ADD  CONSTRAINT [GestaoOcupacaoParecer_GestaoOcupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_parecer] CHECK CONSTRAINT [GestaoOcupacaoParecer_GestaoOcupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho]  WITH CHECK ADD  CONSTRAINT [FK_tab_gestao_ocupacao_trecho_tab_gestao_ocupacao] FOREIGN KEY([ocu_id])
REFERENCES [dbo].[tab_gestao_ocupacao] ([ocu_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho] CHECK CONSTRAINT [FK_tab_gestao_ocupacao_trecho_tab_gestao_ocupacao]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho_interferencia]  WITH CHECK ADD  CONSTRAINT [FK_tab_gestao_ocupacao_trecho_interferencia_tipo] FOREIGN KEY([ocu_tre_int_tipo_id])
REFERENCES [dbo].[tab_dadosMestres_val] ([dmv_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho_interferencia] CHECK CONSTRAINT [FK_tab_gestao_ocupacao_trecho_interferencia_tipo]
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho_interferencia]  WITH CHECK ADD  CONSTRAINT [FK_tab_gestao_ocupacao_trecho_interferencia_trecho] FOREIGN KEY([ocu_tre_id])
REFERENCES [dbo].[tab_gestao_ocupacao_trecho] ([ocu_tre_id])
GO
ALTER TABLE [dbo].[tab_gestao_ocupacao_trecho_interferencia] CHECK CONSTRAINT [FK_tab_gestao_ocupacao_trecho_interferencia_trecho]
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
/****** Object:  StoredProcedure [dbo].[STP_DEL_ARQUIVOS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Deleta um item específico da Tabela de Arquivos
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_ARQUIVOS]
	@id INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		UPDATE TAB_ARQUIVOS SET ARQ_APAGADO = 1 WHERE ARQ_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_INTERESSADO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Deleta um Interessado
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_INTERESSADO]
	@id INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		UPDATE TAB_GESTAO_INTERESSADO SET INT_ATIVO = 1 WHERE INT_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_INTERESSADO_ENDERECO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um ENDERECO em Gestão de Interessado.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_INTERESSADO_ENDERECO]
	
	@idGestao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_interessado_endereco
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_INTERESSADO_OBSERVACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta uma observação em Gestão de Interessado.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_INTERESSADO_OBSERVACAO]
	
	@idGestao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_interessado_observacao
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um Tipo de Concessão em Gestão de Interessado.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]
	
	@idGestao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_interessado_tipo_de_concessao
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-ABR-06
-- Description:	Deleta um item da Gestão de Ocupações
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO]
	@id INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		UPDATE TAB_GESTAO_OCUPACAO SET OCU_ATIVO = 0 WHERE OCU_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_DEFERIMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um item No menu Deferimento.
-- ===============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_DEFERIMENTO]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_deferimento
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_DOCUMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um item No menu Documento.
-- ===============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_DOCUMENTO]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_documento
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_OCORRENCIA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um item No menu Ocorrência.
-- ===============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_OCORRENCIA]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_ocorrencia
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_OCUPACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um item No menu Ocupação.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_OCUPACAO]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_ocupacao
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_PARECER]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um Parecer da Ocupação.
-- ===========================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_PARECER]

	@idOcupacao INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM TAB_GESTAO_OCUPACAO_PARECER WHERE OCU_ID = @idOcupacao
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_TRECHO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta um Trecho da Ocupação.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_TRECHO]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_trecho
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_GESTAO_OCUPACAO_TRECHO_INTERFERENCIA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Deleta uma Interferência de um determinado Trecho.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_GESTAO_OCUPACAO_TRECHO_INTERFERENCIA]
	
	@idOcupacao INT	

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM tab_gestao_ocupacao_trecho_interferencia
		WHERE  EXISTS(SELECT ocu_tre_id
					  FROM   tab_gestao_ocupacao_trecho
					  WHERE  ocu_id = @idOcupacao) 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_PROJETOS_MELHORIAS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Deleta um Projeto de Melhoria logicamente.
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_PROJETOS_MELHORIAS]
	@id INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		UPDATE TAB_PROJETOS_MELHORIAS SET PRO_ATIVO = 0 WHERE PRO_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_DEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Deleta uma informação relevante de um Projeto de Melhoria.
-- =======================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_DEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]
	@idProjetos INT	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		DELETE FROM TAB_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES WHERE INFO_PRO_ID = @idProjetos
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_ARQUIVOS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-ABR-07
-- Description:	Insere um item novo na Gestão de Ocupações
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_ARQUIVOS]
	@usuId INT, 
	@apagado BIT, 
	@arquivoNome VARCHAR(100), 
	@arquivoExtensao VARCHAR(100), 
	@tipoArquivo INT,
	@documento VARCHAR(200), 
	@tipoInteressado INT, 
	@dataCadastro DATETIME, 
	@dataAtualizacao DATETIME
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_arquivos
		--OUTPUT INSERTED.arq_id
		  VALUES (@usuId, 
				  @apagado, 
				  ISNULL(@arquivoNome, ''), 
				  ISNULL(@arquivoExtensao, ''), 
				  @tipoArquivo, 
				  ISNULL(@documento, ''), 
				  @tipoInteressado, 
				  @dataCadastro, 
				  @dataAtualizacao);
		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_INTERESSADO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Insere um novo Interessado.
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_INTERESSADO]
	@numeroSPDOC VARCHAR(100), 
	@naturezaJuridicaId INT, 
	@tipoDeInteressadoId INT, 
	@nome VARCHAR(100), 
	@documento VARCHAR(18),
	@matrizOuFilial VARCHAR(100), 
	@nomeFantasia VARCHAR(100), 
	@validoAte DATETIME, 
	@statusSPDOC VARCHAR(100), 
	@statusAprovacaoId INT,
	@ativo BIT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_interessado
		--OUTPUT INSERTED.int_id
		  VALUES (ISNULL(@numeroSPDOC,  ''),
				  @naturezaJuridicaId, 
				  @tipoDeInteressadoId,
				  @nome, 
				  @documento, 
				  @matrizOuFilial, 
				  @nomeFantasia, 
				  @validoAte, 
				  ISNULL(@statusSPDOC, ''), 
				  @statusAprovacaoId,
				  @ativo);
		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_INTERESSADO_DOCUMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo documento em Gestão de Interessados.
-- ========================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_INTERESSADO_DOCUMENTO]

	@GestaoInteressadoId INT, 
	@documento VARCHAR(100), 
	@arquivo VARCHAR(500),
	@data DATETIME,
	@addPor VARCHAR(50)
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
	
		INSERT INTO tab_gestao_interessado_documento
		VALUES     ( ISNULL(@GestaoInteressadoId, NULL),
					 @documento,
					 @arquivo,
					 @data,
					 @addPor) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_INTERESSADO_ENDERECO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo endereço em Gestão de Interessados.
-- ========================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_INTERESSADO_ENDERECO]

	@gestaoInteressadoId INT, 
	@municipioId INT, 
	@unidadeId INT,
	@logradouro VARCHAR(100),
	@cep CHAR(9),
	@numero VARCHAR(20),
	@complemento VARCHAR(50),
	@bairro VARCHAR(100),
	@nomeDoContato VARCHAR(100),
	@principal BIT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_interessado_endereco
		VALUES     ( @gestaoInteressadoId,
					 @municipioId,
					 @unidadeId,
					 @logradouro,
					 @cep,
					 @numero,
					 @complemento,
					 @bairro,
					 @nomeDoContato,
					 @principal) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_INTERESSADO_OBSERVACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere uma nova Observação em Gestão de Interessados.
-- ========================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_INTERESSADO_OBSERVACAO]

	@gestaoInteressadoId INT, 
	@observacao VARCHAR(500), 
	@data DATETIME,
	@addPor VARCHAR(10)
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_interessado_observacao
		VALUES     ( @gestaoInteressadoId,
					 @observacao,
					 @data,
					 @addPor) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo Tipo de Concessão em Gestão de Interessados.
-- ========================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO]

	@gestaoInteressadoId INT, 
	@tipoDeConcessaoId INT, 
	@marcado BIT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_interessado_tipo_de_concessao
		VALUES     ( @gestaoInteressadoId,
					 @tipoDeConcessaoId,
					 @marcado) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-ABR-07
-- Description:	Insere um item novo na Gestão de Ocupações
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO]
	@interessadoId INT, 
	@regionalId INT, 
	@numeroSPDOC VARCHAR(100), 
	@numeroProcesso VARCHAR(100), 
	@dataDespachoAutorizativo DATETIME,
	@origemSolicitacaolId INT, 
	@situacaoSolicitacaoId INT, 
	@dataCadastro DATETIME, 
	@ocu_ativo BIT, 
	@residencialId INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao
		OUTPUT INSERTED.ocu_id
		  VALUES (@interessadoId, 
				  @regionalId, 
				  @numeroSPDOC, 
				  ISNULL(@numeroProcesso, ''), 
				  ISNULL(@dataDespachoAutorizativo, ''), 
				  @origemSolicitacaolId, 
				  @situacaoSolicitacaoId, 
				  @dataCadastro, 
				  1, 
				  @residencialId);
		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO_DEFERIMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo Deferimento no Menu de Deferimento.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO_DEFERIMENTO]

	@gestaoOcupacaoId INT, 
	@dataAssinatura DATETIME, 
	@dataPublicacao DATETIME,
	@dataDespachoAutorizativo DATETIME,
	@numeroProcesso VARCHAR(100),
	@termoAnexadoArquivo VARCHAR(200)
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao_deferimento
		VALUES     ( @gestaoOcupacaoId,
					 @dataAssinatura,
					 @dataPublicacao,
					 @dataDespachoAutorizativo,
					 @numeroProcesso,
					 @termoAnexadoArquivo) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO_DOCUMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo Documento no Menu de Documentos.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO_DOCUMENTO]

	@gestaoOcupacaoId INT, 
	@documento VARCHAR(100), 
	@arquivo VARCHAR(500),
	@dataAdicionado DATETIME,
	@adicionadoPor VARCHAR(50)
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao_documento
		VALUES     ( @gestaoOcupacaoId,
					 @documento,
					 @arquivo,
					 @dataAdicionado,
					 @adicionadoPor) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO_OCORRENCIA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere uma nova Ocorrência no Menu de Ocorrências.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO_OCORRENCIA]

	@gestaoOcupacaoId INT, 
	@dataOcorrencia DATETIME, 
	@autor VARCHAR(100),
	@area VARCHAR(100),
	@ocorrencia VARCHAR(100)
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao_ocorrencia
		VALUES     ( @gestaoOcupacaoId,
					 @dataOcorrencia,
					 @autor,
					 @area,
					 @ocorrencia) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO_PARECER]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um novo PARECER na Gestão de Ocupações
-- ==========================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO_PARECER]
	
	@gestaoOcupacaoId INT,
	@parecerRegionalObservacao VARCHAR(100),
	@arecerRegionalData DATETIME,
	@parecerRegionalId INT,
	@parecerDiretoriaEngenhariaObservacao VARCHAR(100),
	@parecerDiretoriaEngenhariaData DATETIME,
	@parecerDiretoriaEngenhariaId INT,
	@parecerCoordenadoriaOperacoesObservacao VARCHAR(100),
	@parecerCoordenadoriaOperacoesData DATETIME,
	@parecerCoordenadoriaOperacoesId INT,
	@parecerFaixaDominioObservacao VARCHAR(100),
	@parecerFaixaDominioData DATETIME,
	@parecerFaixaDominioId INT,
	@data DATETIME,
	@parecerCoordenadoriaDocumentoArquivo VARCHAR(200),
	@parecerDiretoriaDocumentoArquivo VARCHAR(200),
	@parecerFaixaDominioDocumentoArquivo VARCHAR(200),
	@parecerRegionalDocumentoArquivo VARCHAR(200)

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao_parecer
		VALUES     ( @gestaoOcupacaoId,
					 @parecerRegionalObservacao,
					 @arecerRegionalData,
					 @parecerRegionalId,
					 @parecerDiretoriaEngenhariaObservacao,
					 @parecerDiretoriaEngenhariaData,
					 @parecerDiretoriaEngenhariaId,
					 @parecerCoordenadoriaOperacoesObservacao,
					 @parecerCoordenadoriaOperacoesData,
					 @parecerCoordenadoriaOperacoesId,
					 @parecerFaixaDominioObservacao,
					 @parecerFaixaDominioData,
					 @parecerFaixaDominioId,
					 @data,
					 @parecerCoordenadoriaDocumentoArquivo,
					 @parecerDiretoriaDocumentoArquivo,
					 @parecerFaixaDominioDocumentoArquivo,
					 @parecerRegionalDocumentoArquivo) 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_GESTAO_OCUPACAO_TRECHO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Insere um Trecho novo na Ocupação.
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_GESTAO_OCUPACAO_TRECHO]

	@gestaoOcupacaoId INT, 
	@rodoviaId INT, 
	@kmInicial DECIMAL(18,3), 
	@kmFinal DECIMAL(18,3), 
	@extensao DECIMAL(18,3),
	@localizacao INT, 
	@tipoImplantacaoId INT, 
	@tipoPassagemId INT, 
	@ladoId INT, 
	@tipoOcupacaoId INT,
	@altura DECIMAL(18,3),
	@profundidade DECIMAL(18,3)

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_gestao_ocupacao_trecho
		output      inserted.ocu_tre_id
		VALUES     ( @gestaoOcupacaoId,
					 @rodoviaId,
					 @kmInicial,
					 @kmFinal,
					 @extensao,
					 @localizacao,
					 @tipoImplantacaoId,
					 @tipoPassagemId,
					 @ladoId,
					 @tipoOcupacaoId,
					 @altura,
					 @profundidade); 

		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_PROJETOS_MELHORIAS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Insere um novo Projeto de Melhoria.
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_PROJETOS_MELHORIAS]
	
	 @pro_regional INT,
	 @pro_municipio INT,
	 @pro_rodovia INT,
	 @pro_nome NVARCHAR(250),
	 @pro_km_inicial FLOAT,
	 @pro_km_final FLOAT,
	 @pro_extensao FLOAT,
	 @pro_sentido NVARCHAR(50),
	 @pro_lado INT,
	 @pro_lote NVARCHAR(100),               
	 @pro_status NVARCHAR(20),
	 @pro_num_contrato NVARCHAR(50),
	 @pro_prazo NVARCHAR(50),
	 @pro_previsao_inicio NVARCHAR(50),
	 @pro_descricao NVARCHAR(500),	 
	 @pro_ativo BIT,
	 @pro_unidade_conservacao NVARCHAR(50)

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_projetos_melhorias
		--OUTPUT INSERTED.pro_id
		  VALUES (@pro_regional,
				  @pro_municipio, 
				  @pro_rodovia,
				  @pro_nome, 
				  @pro_km_inicial, 
				  @pro_km_final, 
				  @pro_extensao, 
				  @pro_sentido, 
				  @pro_lado, 
				  @pro_lote,
				  @pro_status,
				  @pro_num_contrato,
				  @pro_prazo,
				  @pro_previsao_inicio,
				  @pro_descricao,
				  @pro_ativo,
				  @pro_unidade_conservacao);
		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_INS_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Insere uma nova informação relevante em um Projeto de Melhoria.
-- ============================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_INS_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES]
	
	 @info_pro_id INT,
	 @info_data_atualizacao DATETIME,
	 @info_addpor NVARCHAR(50),
	 @info_descricao NVARCHAR(250)

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		INSERT INTO tab_projetos_melhorias_informacoes_relevantes
                                VALUES( @info_pro_id,
                                        @info_data_atualizacao,
                                        @info_addpor,
                                        @info_descricao)
		SELECT SCOPE_IDENTITY()
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_ARQUIVO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-13
-- Description:	Busca todos os arquivos de um usuário (Tela de Usuário).
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_ARQUIVO_ID]
	
	@usu_id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT
	        usu_id AS USU_ID,
	        arq_id AS ARQ_ID,
			arq_apagado AS ARQ_APAGADO,
	        arq_nome AS ARQ_NOME,
	        arq_extensao AS ARQ_EXTENSAO,
	        arq_tipo AS ARQ_TIPO,
	        arq_documento AS ARQ_DOCUMENTO,
	        arq_tipo_interessado AS ARQ_TIPO_INTERESSADO,
	        arq_data_cadastro AS ARQ_DATA_CADASTRO,
	        arq_data_atualizacao AS ARQ_DATA_ATUALIZACAO	        
        FROM TAB_ARQUIVOS 
			WHERE usu_id = @usu_id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_CONTATO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um contato em Gestão de Interessados.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_CONTATO_ID]
	
	@idGestao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT usu.usu_id            AS UsuarioId,
			   usu.usu_login         AS Login,
			   usu.usu_cargo         AS Cargo,
			   usu.usu_email         AS Email,
			   usu.usu_nome          AS Nome,
			   usu.usu_telefoneramal AS Telefone,
			   usu.usu_ddd           AS DDD
		FROM   tab_gestao_interessado_contato cont
			   INNER JOIN tab_usuarios usu
					   ON ( cont.usu_id = usu.usu_id )
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_CONTATO_PARAMS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Busca uma lista específica de Contatos na Gestão de Interessados
-- =============================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_CONTATO_PARAMS]

	@nome VARCHAR(50),
	@login VARCHAR(10),
	@cargo VARCHAR(50),
	@email VARCHAR(255),
	@estado INT,
	@empresa INT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT usu.usu_id    AS UsuarioId,
			   usu.usu_nome  AS Nome,
			   usu.usu_cargo AS Cargo,
			   usu.usu_email AS Email
		FROM   tab_usuarios usu
			   LEFT JOIN tab_usuario_empresa emp
					  ON ( emp.usu_id = usu.usu_id )
		WHERE  usu.usu_excluido = 0
			   AND ( @nome IS NULL
					  OR ( @nome IS NOT NULL
						   AND usu.usu_nome = @nome ) )
			   AND ( @login IS NULL
					  OR ( @login IS NOT NULL
						   AND usu.usu_login = @login ) )
			   AND ( @cargo IS NULL
					  OR ( @cargo IS NOT NULL
						   AND usu.usu_cargo = @cargo ) )
			   AND ( @email IS NULL
					  OR ( @email IS NOT NULL
						   AND usu.usu_email = @email ) )
			   AND ( @estado = 0
					  OR ( @estado > 0
						   AND usu.dmv_id_regional = @estado ) )
			   AND ( @empresa = 0
					  OR ( @empresa > 0
						   AND emp.emp_id = @empresa ) ) 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um Documento em Gestão de Interessados.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_ID]
	
	@idGestao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT int_doc_documento AS Documento,
			   int_doc_arquivo   AS Arquivo,
			   int_doc_data      AS Data,
			   int_doc_addpor    AS AdicionadoPor
		FROM   tab_gestao_interessado_documento
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Busca todos os interessados.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_ID]
	
	@id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT
	         int_id as Id,
			 int_numerospdoc as NumeroSPDOC,
			 dmv_id_natureza_juridica as NaturezaJuridicaId,
			 sta_id as StatusId,
			 dmv_id_tipo_interessado as TipoInteressadoId, 
			 int_nome as Nome,
			 int_documento as Documento,
			 CASE(int_matrizOuFilial)
			WHEN 'Matriz' THEN 44 ELSE 45 END as TipoEmpresaId,
			 int_nomeFantasia as NomeFantasia,
			 ISNULL(int_validoAte, '') as Validade,
			 int_statusSPDOC as StatusSPDOC	
        FROM TAB_GESTAO_INTERESSADO
			WHERE int_id = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_LISTA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Busca uma lista de Gestão de Interessados
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_LISTA]
	--@ocu_id INT,
	--@int_id INT,
	--@dmv_idRegional INT,
	--@ocu_numerospdoc VARCHAR(100),
	--@ocu_numeroProcesso VARCHAR(100),
	--@ocu_dataDespacho DATETIME,
	--@dmv_idOrigemSolicitacao INT,	
	--@ocu_situacaoSolicitacao INT,
	--@ocu_dataCadastro DATETIME,	
	--@ocu_ativo BIT,
	--@ocu_residencial_conservacao_id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT
			INTER.int_id AS Id,
			INTER.int_nome AS Nome,
			INTER.int_documento AS Documento,
			TIPO.dmv_valor AS Valor,
			STAPR.sta_nome AS Nome,
			INTER.int_validoAte AS ValidoAte
			--UNIDADE = UNIDADE,
			--MUNICIPIO = MUNICIPIO
		FROM TAB_GESTAO_INTERESSADO INTER
		INNER JOIN tab_status_aprovacao STAPR						ON INTER.sta_id = STAPR.sta_id		
		INNER JOIN TAB_DADOSMESTRES_VAL NATUR						ON INTER.dmv_id_natureza_juridica = NATUR.dmv_id
		INNER JOIN TAB_DADOSMESTRES_VAL TIPO						ON INTER.dmv_id_tipo_interessado = TIPO.dmv_id
		LEFT OUTER JOIN TAB_GESTAO_INTERESSADO_ENDERECO INTEND 		ON INTEND.int_id = INTER.int_id
		LEFT OUTER JOIN TAB_DADOSMESTRES_VAL MUNICI					ON MUNICI.[dmv_id] = INTEND.[dmv_id_municipio]
		LEFT OUTER JOIN TAB_DADOSMESTRES_VAL ESTADO 				ON ESTADO.[dmv_id] = INTEND.[dmv_id_unidade]
    		
		WHERE INTER.int_ativo = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_OBSERVACAO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca uma Observação em Gestão de Interessados.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_OBSERVACAO_ID]
	
	@idGestao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT int_obs_observacao AS Observacao,
			   int_obs_data       AS Data,
			   int_obs_addpor     AS AdicionadoPor
		FROM   tab_gestao_interessado_observacao
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_PARAMS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Busca uma lista de Gestão de Interessados
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_PARAMS]
	@interessado INT,
	@documento VARCHAR(18),
	@idMunicipio INT,
	@idEstado INT,
	@idTipo INT,
	@idNatureza INT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT 
            INTER.INT_ID AS IDINTERESSADO,
	        INTER.INT_NOME AS INTERESSADO,
	        INTER.INT_DOCUMENTO AS DOCUMENTO,
	        TIPO.DMV_VALOR AS TIPO,
	        NATUREZA.DMV_VALOR AS NATUREZA
        FROM TAB_GESTAO_INTERESSADO INTER
        LEFT JOIN TAB_GESTAO_INTERESSADO_ENDERECO ENDE ON (ENDE.INT_ID = INTER.INT_ID)
        LEFT JOIN TAB_DADOSMESTRES_VAL TIPO ON (TIPO.COL_ID = 14 AND TIPO.DMV_ID = INTER.DMV_ID_TIPO_INTERESSADO)
        LEFT JOIN TAB_DADOSMESTRES_VAL NATUREZA ON (NATUREZA.COL_ID = 26 AND NATUREZA.DMV_ID = INTER.DMV_ID_NATUREZA_JURIDICA)
        WHERE INTER.INT_ATIVO = 1
            AND (@interessado IS NULL OR (@interessado IS NOT NULL AND inter.int_nome = @interessado))
	        AND (@documento IS NULL OR (@documento IS NOT NULL AND inter.int_documento = @documento))
            AND (@idMunicipio = 0 OR (@idMunicipio > 0 AND ende.dmv_id_municipio = @idMunicipio))
            AND (@idEstado = 0 OR (@idEstado > 0 AND ende.dmv_id_unidade = @idEstado))
            AND (@idTipo = 0 OR (@idTipo > 0 AND inter.dmv_id_tipo_interessado = @idTipo))
            AND (@idNatureza = 0 OR (@idNatureza > 0 AND inter.dmv_id_natureza_juridica = @idNatureza))
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um Tipo de Concessão em Gestão de Interessados.
-- ==================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_INTERESSADO_TIPO_DE_CONCESSAO_ID]
	
	@idGestao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT int_id                     AS IdGestao,
			   dmv_id_tipo_concessao      AS TipoConcessaoId,
			   int_tipo_concessao_marcado AS Marcado
		FROM   tab_gestao_interessado_tipo_de_concessao
		WHERE  int_id = @idGestao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_DEFERIMENTO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um Deferimento no menu Deferimento pelo ID.
-- ==============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_DEFERIMENTO_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT ocu_def_id              AS Id,
			   ocu_def_data_assinatura AS DataAssinatura,
			   ocu_def_data_publicacao AS DataPublicacao,
			   ocu_def_data_despacho   AS DataDespachoAutorizativo,
			   ocu_def_numero_processo AS NumeroProcesso,
			   ocu_def_caminho_arquivo AS CaminhoArquivo
		FROM   tab_gestao_ocupacao_deferimento
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_DOCUMENTO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca os Documentos no menu Documentos pelo ID.
-- ==============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_DOCUMENTO_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT ocu_doc_id        AS Id,
			   ocu_doc_documento AS Documento,
			   ocu_doc_arquivo   AS Arquivo,
			   ocu_doc_data      AS DataAdicionado,
			   ocu_doc_addpor    AS AdicionadoPor,
			   ocu_doc_arquivo   AS CaminhoArquivo
		FROM   tab_gestao_ocupacao_documento
		WHERE  ocu_id = @idOcupacao  
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-13
-- Description:	Busca um ID de Gestão de Ocupações
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_ID]
	
	@id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT
	        OCU.OCU_ID AS ID,
	        INTE.INT_ID AS INTERESSADOID,
			INTE.INT_NOME AS INTERESSADO,
	        OCU.DMV_IDREGIONAL AS REGIONALID,
	        OCU.OCU_NUMEROSPDOC AS NUMEROSPDOC,
	        OCU.OCU_NUMEROPROCESSO AS NUMEROPROCESSO,
	        DEF.OCU_DEF_DATA_DESPACHO AS DATADESPACHOAUTORIZATIVO,
	        OCU.DMV_IDORIGEMSOLICITACAO AS ORIGEMSOLICITACAOID,
	        OCU.OCU_SITUACAOSOLICITACAO AS SITUACAOSOLICITACAOID,
	        OCU.OCU_DATACADASTRO AS DATACADASTRO,
	        OCU.OCU_ATIVO AS ATIVO,
            OCU.OCU_RESIDENCIAL_CONSERVACAO_ID AS RESIDENCIACONSERVACAOID
        FROM TAB_GESTAO_OCUPACAO OCU
		INNER JOIN TAB_GESTAO_INTERESSADO INTE ON OCU.INT_ID = INTE.INT_ID
        LEFT JOIN TAB_GESTAO_OCUPACAO_DEFERIMENTO DEF ON OCU.OCU_ID = DEF.OCU_ID
        WHERE OCU.OCU_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_LISTA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-ABR-06
-- Description:	Busca uma lista de Gestão de Ocupações
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_LISTA]
	--@ocu_id INT,
	--@int_id INT,
	--@dmv_idRegional INT,
	--@ocu_numerospdoc VARCHAR(100),
	--@ocu_numeroProcesso VARCHAR(100),
	--@ocu_dataDespacho DATETIME,
	--@dmv_idOrigemSolicitacao INT,	
	--@ocu_situacaoSolicitacao INT,
	--@ocu_dataCadastro DATETIME,	
	--@ocu_ativo BIT,
	--@ocu_residencial_conservacao_id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT
			OCUPA.OCU_ID AS Id,
			OCUPA.OCU_NUMEROPROCESSO AS NumeroProcesso,
			DEF.OCU_DEF_DATA_DESPACHO AS DataDespachoAutorizativo,
			OCUPA.OCU_NUMEROSPDOC AS NumeroSPDOC,
			OCUPA.OCU_DATACADASTRO AS DataSolicitacao,
			INTER.INT_NOME AS Interessado,
			OCUPA.DMV_IDREGIONAL AS IdRegional,
			REGION.DMV_VALOR AS Regional,
			OCUPA.DMV_IDORIGEMSOLICITACAO AS IdOrigem,
			ORIGEM.DMV_VALOR AS OrigemSolicitacao,
			SITUACAO.DMV_VALOR AS SituacaoSolicitacao
		FROM TAB_GESTAO_OCUPACAO OCUPA
		INNER JOIN TAB_GESTAO_INTERESSADO INTER
			ON OCUPA.INT_ID = INTER.INT_ID
		LEFT JOIN TAB_GESTAO_OCUPACAO_DEFERIMENTO DEF
			ON OCUPA.OCU_ID = DEF.OCU_ID
		LEFT JOIN TAB_DADOSMESTRES_VAL SITUACAO
			ON (SITUACAO.COL_ID = 34
			AND SITUACAO.DMV_ID = OCUPA.OCU_SITUACAOSOLICITACAO)
		LEFT JOIN TAB_DADOSMESTRES_VAL REGION
			ON (REGION.COL_ID = 3
			AND REGION.DMV_ID = OCUPA.DMV_IDREGIONAL)
		LEFT JOIN TAB_DADOSMESTRES_VAL ORIGEM
			ON (ORIGEM.COL_ID = 33
			AND ORIGEM.DMV_ID = OCUPA.DMV_IDORIGEMSOLICITACAO)
		WHERE OCUPA.OCU_ATIVO = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_OCORRENCIA_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca as Ocorrências do menu Ocorrências pelo ID.
-- ==========================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_OCORRENCIA_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT ocu_oco_int            AS Id,
			   ocu_oco_dataocorrencia AS DataOcorrencia,
			   ocu_oco_autor          AS Autor,
			   ocu_oco_area           AS Area,
			   ocu_oco_ocorrencia     AS Ocorrencia
		FROM   tab_gestao_ocupacao_ocorrencia
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_OCUPACAO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca as Ocupacões do menu Ocupacões pelo ID.
-- ==========================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_OCUPACAO_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT 
		        ocu_ocu_id as Id,
                ocu_ocu_assunto as Assunto,
	            ocu_ocu_observacao as Observacao
        FROM tab_gestao_ocupacao_ocupacao
        WHERE ocu_id = @idOcupacao
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_PARECER_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um Parecer em Ocupações.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_PARECER_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT ocu_par_id                        AS Id,
			   ocu_par_regional_obeservacao      AS ParecerRegionalObservacao,
			   ocu_par_regional_data             AS ParecerRegionalData,
			   ocu_par_regional_id               AS ParecerRegionalId,
			   ocu_par_engenharia_obeservacao    AS ParecerDiretoriaEngenhariaObservacao,
			   ocu_par_engenharia_data           AS ParecerDiretoriaEngenhariaData,
			   ocu_par_engenharia_id             AS ParecerDiretoriaEngenhariaId,
			   ocu_par_coordenadoria_obeservacao AS ParecerCoordenadoriaOperacoesObservacao,
			   ocu_par_coordenadoria_data        AS ParecerCoordenadoriaOperacoesData,
			   ocu_par_coordenadoria_id          AS ParecerCoordenadoriaOperacoesId,
			   ocu_par_faixa_obeservacao         AS ParecerFaixaDominioObservacao,
			   ocu_par_faixa_data                AS ParecerFaixaDominioData,
			   ocu_par_faixa_id                  AS ParecerFaixaDominioId,
			   ocu_par_data                      AS Data,
			   ocu_par_caminho_arq_coordenadoria AS CaminhoArquivoCoordenadoria,
			   ocu_par_caminho_arq_diretoria     AS CaminhoArquivoDiretoria,
			   ocu_par_caminho_arq_faixa_dominio AS CaminhoArquivoFaixaDominio,
			   ocu_par_caminho_arq_regional      AS CaminhoArquivoRegional
		FROM   tab_gestao_ocupacao_parecer
		WHERE  ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_TIPO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-13
-- Description:	Busca um Tipo de Ocupação.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_TIPO_ID]
	
	@idInteressado INT

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT val.dmv_id    AS TipoOcupacaoId,
			   val.dmv_valor AS Nome
		FROM   tab_gestao_interessado_tipo_de_concessao conc
			   INNER JOIN tab_dadosmestres_val val
					   ON conc.dmv_id_tipo_concessao = val.dmv_id
		WHERE  conc.int_id = @idInteressado 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_GESTAO_OCUPACAO_TRECHO_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-19
-- Description:	Busca um Trecho da Ocupação.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_GESTAO_OCUPACAO_TRECHO_ID]
	
	@idOcupacao INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT  trecho.ocu_tre_id                  AS Id,
				trecho.ocu_tre_kminicial           AS KmInicial,
				trecho.ocu_tre_kmfinal             AS KmFinal,
				trecho.ocu_tre_extensao            AS Extensao,
				trecho.ocu_tre_lado                AS LadoId,
				lado.dmv_valor                     AS LadoNome,
				trecho.ocu_tre_altura              AS Altura,
				trecho.ocu_tre_profundidade        AS Profundidade,
				trecho.ocu_tre_rodovia_id          AS IdRodovia,
				rodovia.dmv_valor                  AS NomeRodovia,
				trecho.ocu_tre_tipo_ocupacao_id    AS IdTipoOcupacao,
				tipoocupacao.dmv_valor             AS NomeTipoOcupacao,
				trecho.ocu_tre_tipo_implantacao_id AS IdTipoImplantacao,
				tipoimplantacao.dmv_valor          AS NomeTipoImplantacao,
				trecho.ocu_tre_localizacao         AS IdLocalizacao,
				trecho.ocu_tre_tipo_passagem_id    AS IdTipoPassagem,
				tipopassagem.dmv_valor             AS NomeTipoPassagem
		FROM   tab_gestao_ocupacao_trecho trecho
				LEFT JOIN tab_dadosmestres_val rodovia ON ( rodovia.col_id = 13 AND rodovia.dmv_id = trecho.ocu_tre_rodovia_id )
				LEFT JOIN tab_dadosmestres_val tipoocupacao ON ( tipoocupacao.col_id = 32 AND tipoocupacao.dmv_id = trecho.ocu_tre_tipo_ocupacao_id )
				LEFT JOIN tab_dadosmestres_val tipoimplantacao ON ( tipoimplantacao.col_id = 39 AND tipoimplantacao.dmv_id = trecho.ocu_tre_tipo_implantacao_id )
				LEFT JOIN tab_dadosmestres_val tipopassagem ON ( tipopassagem.col_id = 38 AND tipopassagem.dmv_id = trecho.ocu_tre_tipo_passagem_id )
				LEFT JOIN tab_dadosmestres_val lado ON ( lado.col_id = 41 AND lado.dmv_id = trecho.ocu_tre_lado )
		WHERE  trecho.ocu_id = @idOcupacao 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_PERFIS_NOME_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ====================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Busca um Perfil pelo Nome ou Nome e ID.
-- ====================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_PERFIS_NOME_ID]
	@idPerfil INT,
	@prf_nome NVARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT TOP (1) 
			prf_id ,
			prf_nome , 
			prf_descricao ,
			prf_excluido 
		FROM [dbo].[tab_perfis] 
		WHERE (prf_nome = @prf_nome) 
			OR ((prf_nome = @prf_nome) 
			AND (prf_id != @idPerfil))
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_PROJETOS_MELHORIAS_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Busca um Projeto de Melhoria pelo ID.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_PROJETOS_MELHORIAS_ID]
	
	@id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT 
            PRO.PRO_ID AS ID,
            PRO.PRO_REGIONAL AS REGIONALID,
            PRO.PRO_MUNICIPIO AS MUNICIPIOID,
            PRO.PRO_RODOVIA AS RODOVIAID,
            PRO.PRO_NOME AS NOME,                              
            PRO.PRO_KM_INICIAL AS KMINICIAL,
            PRO.PRO_KM_FINAL AS KMFINAL,
            PRO.PRO_EXTENSAO AS EXTENSAO,
            PRO.PRO_SENTIDO AS SENTIDO,
            PRO.PRO_LADO AS LADOID,
            LADO.DMV_VALOR AS LADO,
            PRO.PRO_LOTE AS LOTE,                                    
            PRO.PRO_STATUS AS STATUS,
            PRO.PRO_NUM_CONTRATO AS NUMEROCONTRATO,
            PRO.PRO_PRAZO AS PRAZO,
            PRO.PRO_PREVISAO_INICIO AS PREVISAOINICIO,
            PRO.PRO_DESCRICAO AS DESCRICAO, 
            PRO.PRO_UNIDADE_CONSERVACAO AS UNIDADECONSERVACAO
        FROM TAB_PROJETOS_MELHORIAS PRO
        LEFT JOIN TAB_DADOSMESTRES_VAL LADO ON (LADO.COL_ID = 41 AND LADO.DMV_ID = PRO.PRO_LADO)
        WHERE PRO_ID = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES_ID]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =================================================================================
-- Author:		Gomes
-- Create date: 2021-MAY-13
-- Description:	Busca um ID de Informações Relevantes dentro de Projeto de Melhorias
-- =================================================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES_ID]

	@projetosMelhoriasId INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT                                    
            INFO_DATA_ATUALIZACAO AS DATAATUALIZACAO,
            INFO_ADDPOR AS ADICIONADOPOR,
            INFO_DESCRICAO AS DESCRICAO
        FROM TAB_PROJETOS_MELHORIAS_INFORMACOES_RELEVANTES
        WHERE INFO_PRO_ID = @projetosMelhoriasId
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_PROJETOS_MELHORIAS_LISTA]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =====================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Retorna a lista de Projetos de Melhorias
-- =====================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_PROJETOS_MELHORIAS_LISTA]
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT 
			PROMEL.PRO_ID AS PRO_ID, 
			REGIONAL.DMV_VALOR AS REGIONAL, 
			MUNICIPIO.DMV_VALOR AS MUNICIPIO, 
			RODOVIA.DMV_VALOR AS RODOVIA, 
			PROMEL.PRO_NOME AS PRO_NOME, 
			PROMEL.PRO_KM_INICIAL AS PRO_KM_INICIAL, 
			PROMEL.PRO_KM_FINAL AS PRO_KM_FINAL, 
			PROMEL.PRO_EXTENSAO AS PRO_EXTENSAO, 
			PROMEL.PRO_SENTIDO AS PRO_SENTIDO, 
			PROMEL.PRO_LADO AS PRO_LADO, 
			PROMEL.PRO_LOTE AS PRO_LOTE, 
			PROMEL.PRO_STATUS AS PRO_STATUS, 
			PROMEL.PRO_NUM_CONTRATO AS PRO_NUM_CONTRATO, 
			PROMEL.PRO_PRAZO AS PRO_PRAZO, 
			PROMEL.PRO_PREVISAO_INICIO AS PRO_PREVISAO_INICIO, 
			PROMEL.PRO_DESCRICAO AS PRO_DESCRICAO, 
			PROMEL.PRO_ATIVO AS PRO_ATIVO, 
			PROMEL.PRO_UNIDADE_CONSERVACAO AS PRO_UNIDADE_CONSERVACAO
		FROM    TAB_PROJETOS_MELHORIAS AS PROMEL
			INNER JOIN TAB_DADOSMESTRES_VAL AS REGIONAL ON PROMEL.PRO_REGIONAL = REGIONAL.DMV_ID
			INNER JOIN TAB_DADOSMESTRES_VAL AS RODOVIA ON PROMEL.PRO_RODOVIA = RODOVIA.DMV_ID
			INNER JOIN TAB_DADOSMESTRES_VAL AS MUNICIPIO ON PROMEL.PRO_MUNICIPIO = MUNICIPIO.DMV_ID
		WHERE PROMEL.[PRO_ATIVO] = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_PROJETOS_MELHORIAS_VALIDA_TRECHO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =====================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Retorna a lista de Trechos existentes antes de cadastrar um Projeto de Melhoria.
-- =====================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_PROJETOS_MELHORIAS_VALIDA_TRECHO]
	
	@lado INT,
	@rodoviaId INT,
	@kmInicial FLOAT,
	@kmFinal FLOAT

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT pro_id   AS PROJETO_MELHORIA_ID,
			   pro_nome AS PROJETO_MELHORIA_NOME
		FROM   tab_projetos_melhorias
		WHERE  pro_lado = @lado
			   AND pro_rodovia = @rodoviaId
			   AND ( ( @kmInicial >= pro_km_inicial
					   AND @kmInicial <= pro_km_final )
					  OR ( @kmFinal <= pro_km_final
						   AND @kmFinal >= pro_km_inicial ) ) 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_SEL_USUARIO_VALIDA_LOGIN]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Busca um usuário pelo LOGIN.
-- =============================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_SEL_USUARIO_VALIDA_LOGIN]
	
	@usu_login VARCHAR(10)
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN
		SELECT TOP (1) 
			USU_ID AS USU_ID, 
			USU_ATIVO AS USU_ATIVO, 
			USU_EXTERNO AS USU_EXTERNO, 
			USU_NOME AS USU_NOME, 
			USU_CARGO AS USU_CARGO, 
			USU_LOGIN AS USU_LOGIN, 
			USU_SENHA AS USU_SENHA, 
			USU_EMAIL AS USU_EMAIL, 
			DMV_ID_REGIONAL AS DMV_ID_REGIONAL, 
			USU_DDD AS USU_DDD, 
			USU_TELEFONERAMAL AS USU_TELEFONERAMAL, 
			USU_DATACRIACAO AS USU_DATACRIACAO, 
			STA_ID AS STA_ID, 
			USU_EXCLUIDO AS USU_EXCLUIDO, 
			USU_CPF AS USU_CPF, 
			USU_TOKEN_ALTERACAO AS USU_TOKEN_ALTERACAO
		FROM DBO.TAB_USUARIOS AS USU
		WHERE (USU.usu_login = @usu_login) 
			AND (8 = USU.sta_id) AND (1 = USU.usu_ativo) 
			AND (0 = USU.usu_excluido)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UPD_GESTAO_INTERESSADO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Atualiza um Interessado na Gestão de Interessados.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_UPD_GESTAO_INTERESSADO]
	
	@numeroSPDOC VARCHAR(100), 
	@statusSPDOC VARCHAR(100), 	 
	@nome VARCHAR(100), 
	@naturezaJuridicaId VARCHAR(100),
	@documento VARCHAR(18),
	@matrizOuFilial VARCHAR(100), 
	@validoAte DATETIME, 
	@nomeFantasia VARCHAR(100),
	@statusAprovacaoId INT,
	@tipoDeInteressadoId INT,
	@id INT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		UPDATE TAB_GESTAO_INTERESSADO SET
		
			int_numerospdoc = CASE WHEN @numeroSPDOC != NULL THEN @numeroSPDOC ELSE NULL END,
		    dmv_id_natureza_juridica = CASE WHEN @naturezaJuridicaId != NULL THEN @naturezaJuridicaId ELSE NULL END,
			dmv_id_tipo_interessado = CASE WHEN @tipoDeInteressadoId != NULL THEN @tipoDeInteressadoId ELSE NULL END,
			int_nome = CASE WHEN @nome != NULL THEN @nome ELSE NULL END,
			int_documento = CASE WHEN @documento != NULL THEN @documento ELSE NULL END,
			int_matrizOuFilial = CASE WHEN @matrizOuFilial != NULL THEN @matrizOuFilial ELSE NULL END,
			int_nomeFantasia = CASE WHEN @nomeFantasia != NULL THEN @nomeFantasia ELSE NULL END,
			int_validoAte = CASE WHEN @validoAte != NULL THEN @validoAte ELSE NULL END,
			int_statusSPDOC = CASE WHEN @statusSPDOC != NULL THEN @statusSPDOC ELSE NULL END,
			sta_id = @StatusAprovacaoId

		WHERE int_id = @id

	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UPD_GESTAO_INTERESSADO_DOCUMENTO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================
-- Author:		Gomes
-- Create date: 2021-MAY-14
-- Description:	Atualiza um Documento na Gestão de Interessados.
-- ===============================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_UPD_GESTAO_INTERESSADO_DOCUMENTO]
	
	@idGestao INT,
	@id INT
	
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		UPDATE tab_gestao_interessado_documento
		SET    int_id = @idGestao
		WHERE  int_doc_id = @id 

	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UPD_GESTAO_OCUPACAO]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-13
-- Description:	Atualiza um item novo na Gestão de Ocupações
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_UPD_GESTAO_OCUPACAO]
	@interessadoId INT, 
	@regionalId INT, 
	@numeroSPDOC VARCHAR(100), 
	@numeroProcesso VARCHAR(100), 
	@dataDespachoAutorizativo DATETIME,
	@origemSolicitacaolId INT, 
	@situacaoSolicitacaoId INT, 
	@dataCadastro DATETIME,
	@residenciaConservacaoId INT,
	@id INT
AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		UPDATE TAB_GESTAO_OCUPACAO SET

			int_id = @interessadoId,
			dmv_idRegional = CASE WHEN @regionalId != NULL THEN @regionalId ELSE NULL END,
		    ocu_numerospdoc = CASE WHEN @numeroSPDOC != NULL THEN @numeroSPDOC ELSE NULL END,
			ocu_numeroProcesso = CASE WHEN @numeroProcesso != NULL THEN @numeroProcesso ELSE NULL END,
			ocu_dataDespacho = CASE WHEN @dataDespachoAutorizativo != NULL THEN @dataDespachoAutorizativo ELSE NULL END,
			dmv_idOrigemSolicitacao = CASE WHEN @origemSolicitacaolId != NULL THEN @origemSolicitacaolId ELSE NULL END,
			ocu_situacaoSolicitacao = CASE WHEN @situacaoSolicitacaoId != NULL THEN @situacaoSolicitacaoId ELSE NULL END,
			ocu_dataCadastro = CASE WHEN @dataCadastro != NULL THEN @dataCadastro ELSE NULL END,
			ocu_residencial_conservacao_id = CASE WHEN @residenciaConservacaoId != NULL THEN @residenciaConservacaoId ELSE NULL END
			
		WHERE ocu_id = @id

	END
END
GO
/****** Object:  StoredProcedure [dbo].[STP_UPD_PROJETOS_MELHORIAS]    Script Date: 19/05/2021 16:08:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =======================================================
-- Author:		Gomes
-- Create date: 2021-MAY-18
-- Description:	Atualiza um Projeto de Melhoria.
-- =======================================================
-- Alterado por: 
-- Data: 
-- Descrição: 
-- Onde se lia: 
-- é na verdade: 

CREATE PROCEDURE [dbo].[STP_UPD_PROJETOS_MELHORIAS]
	
	@RegionalId INT,
	@MunicipioId INT,
	@RodoviaId INT,
	@Nome NVARCHAR(250),
	@KmInicial FLOAT,
	@KmFinal FLOAT,
	@Extensao FLOAT,
	@Sentido NVARCHAR(50),
	@LadoId INT,
	@Lote NVARCHAR(100),             
	@Status NVARCHAR(20),
	@NumeroContrato NVARCHAR(50),
	@Prazo NVARCHAR(50),
	@PrevisaoInicio NVARCHAR(50),
	@Descricao NVARCHAR(500),	 
	@id INT,
	@UnidadeConservacao NVARCHAR(50)

AS
BEGIN

	SET NOCOUNT ON;
   
	BEGIN

		UPDATE TAB_PROJETOS_MELHORIAS SET
			  
            pro_regional = @RegionalId, 
            pro_municipio = @MunicipioId,
            pro_rodovia = @RodoviaId,
            pro_nome = @Nome,                     
            pro_km_inicial = @KmInicial,
            pro_km_final = @KmFinal,
            pro_extensao = @Extensao,
            pro_sentido = @Sentido,
            pro_lado = @LadoId,
            pro_lote = @Lote,                                             
            pro_status = @Status,
            pro_num_contrato = @NumeroContrato,
            pro_prazo = @Prazo, 
            pro_previsao_inicio = @PrevisaoInicio, 
            pro_descricao = @Descricao,
            pro_ativo = 1,
            pro_unidade_conservacao = @UnidadeConservacao

        WHERE pro_id = @id

	END
END
GO
USE [master]
GO
ALTER DATABASE [SGFD_NEW_DEV] SET  READ_WRITE 
GO
