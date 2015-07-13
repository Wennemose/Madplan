USE [Foodplan]
GO

/****** Object:  Table [dbo].[Userdata]    Script Date: 13-07-2015 22:04:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Userdata](
	[UserId] [uniqueidentifier] NULL,
	[Weight] [int] NULL,
	[Height] [int] NULL,
	[Age] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Userdata]  WITH CHECK ADD  CONSTRAINT [FK_Userdata_aspnet_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Userdata] CHECK CONSTRAINT [FK_Userdata_aspnet_Users]
GO


