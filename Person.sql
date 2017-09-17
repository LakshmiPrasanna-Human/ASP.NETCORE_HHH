USE [HHH]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 9/17/2017 2:24:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[AddressId] [int] NOT NULL,
	[HouseholdId] [int] NULL,
	[StudentId] [int] NULL,
	[StateId] [varchar](50) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[DateofBirth] [date] NOT NULL,
	[Email] [varchar](100) NULL,
	[Phone] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


