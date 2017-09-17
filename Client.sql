USE [HHH]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 9/17/2017 2:24:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[ClientID] [nvarchar](50) NOT NULL,
	[ClientDescription] [nvarchar](50) NULL,
	[ControlAccess] [nvarchar](50) NULL
) ON [PRIMARY]

GO


