USE [HHH]
GO

/****** Object:  Table [dbo].[Authorize]    Script Date: 9/17/2017 2:24:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Authorize](
	[AuthorizeID] [int] NOT NULL,
	[ClientID] [nvarchar](50) NULL,
	[Permission] [nvarchar](50) NULL
) ON [PRIMARY]

GO


