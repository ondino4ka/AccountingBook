USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([pid])
REFERENCES [dbo].[Categories] ([idCategory])
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO

ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [PidNotEqualId] CHECK  (([Categories].[pid]<>[Categories].[idCategory]))
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [PidNotEqualId]
GO


