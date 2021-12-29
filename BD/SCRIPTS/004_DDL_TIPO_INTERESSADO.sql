USE [SGFD_NEW_DEV]
GO

/****** Object:  Table [dbo].[tab_tipo_interessado]    Script Date: 23/01/2021 20:13:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tab_tipo_interessado](
	[tip_id] [int] NOT NULL,
	[tip_descricao] [nvarchar](50) NULL,
 CONSTRAINT [PK_tab_tipo_interessado] PRIMARY KEY CLUSTERED 
(
	[tip_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


