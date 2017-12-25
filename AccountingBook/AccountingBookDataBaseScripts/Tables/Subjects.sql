USE [AccountingBookDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subjects](
	[inventoryNumber] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[idState] [int] NULL,
	[idCategory] [int] NULL,
	[Photo] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[idLocation] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[inventoryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subject_State] FOREIGN KEY([idState])
REFERENCES [dbo].[States] ([idState])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subject_State]
GO

ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Categories] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([idCategory])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Categories]
GO

ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Locations] FOREIGN KEY([idLocation])
REFERENCES [dbo].[Locations] ([idLocation])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Locations]
GO


