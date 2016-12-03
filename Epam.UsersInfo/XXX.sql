USE [UserInfoDataBase]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 03.12.2016 18:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](25) NOT NULL,
	[ImageID] [int] NOT NULL CONSTRAINT [DF_Award_ImageID]  DEFAULT ((1)),
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 03.12.2016 18:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 03.12.2016 18:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 03.12.2016 18:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Surname] [nvarchar](250) NOT NULL,
	[Patronymic] [nvarchar](250) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](1200) NOT NULL,
	[ImageID] [int] NOT NULL CONSTRAINT [DF_User_ImageID]  DEFAULT ((1)),
	[RoleID] [int] NOT NULL CONSTRAINT [DF_User_RoleID]  DEFAULT ((1)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAwards]    Script Date: 03.12.2016 18:40:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAwards](
	[UserID] [int] NOT NULL,
	[AwardID] [int] NOT NULL,
 CONSTRAINT [PK_UserAwards] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AwardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Award] ON 

INSERT [dbo].[Award] ([ID], [Title], [ImageID]) VALUES (1, N'ASDA', 1)
INSERT [dbo].[Award] ([ID], [Title], [ImageID]) VALUES (2, N'SADASD', 1)
INSERT [dbo].[Award] ([ID], [Title], [ImageID]) VALUES (4, N'asd', 1)
INSERT [dbo].[Award] ([ID], [Title], [ImageID]) VALUES (6, N'asasd', 1)
SET IDENTITY_INSERT [dbo].[Award] OFF
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [Image]) VALUES (1, 0x1234)
SET IDENTITY_INSERT [dbo].[Image] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (2, N'Admin')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (1, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Surname], [Patronymic], [DateOfBirth], [Login], [Password], [ImageID], [RoleID]) VALUES (1, N'Art', N'Kek', NULL, CAST(N'2000-12-21' AS Date), N'item', N'asdsaasd', 1, 1)
INSERT [dbo].[User] ([ID], [Name], [Surname], [Patronymic], [DateOfBirth], [Login], [Password], [ImageID], [RoleID]) VALUES (2, N'Art', N'Kek', NULL, CAST(N'2000-12-21' AS Date), N'item1', N'asdsaasd', 1, 1)
INSERT [dbo].[User] ([ID], [Name], [Surname], [Patronymic], [DateOfBirth], [Login], [Password], [ImageID], [RoleID]) VALUES (3, N'asd', N'Kek', NULL, CAST(N'2000-12-21' AS Date), N'item2', N'asdsaasd', 1, 1)
INSERT [dbo].[User] ([ID], [Name], [Surname], [Patronymic], [DateOfBirth], [Login], [Password], [ImageID], [RoleID]) VALUES (5, N'Art', N'Kek', NULL, CAST(N'2000-12-21' AS Date), N'item3', N'asdsaasd', 1, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserAwards] ([UserID], [AwardID]) VALUES (1, 1)
INSERT [dbo].[UserAwards] ([UserID], [AwardID]) VALUES (1, 2)
INSERT [dbo].[UserAwards] ([UserID], [AwardID]) VALUES (2, 2)
INSERT [dbo].[UserAwards] ([UserID], [AwardID]) VALUES (5, 1)
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_Title]    Script Date: 03.12.2016 18:40:32 ******/
ALTER TABLE [dbo].[Award] ADD  CONSTRAINT [AK_Title] UNIQUE NONCLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_RoleName]    Script Date: 03.12.2016 18:40:32 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [AK_RoleName] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_Login]    Script Date: 03.12.2016 18:40:32 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [AK_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ID])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Image]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Image] FOREIGN KEY([ImageID])
REFERENCES [dbo].[Image] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Image]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserAwards]  WITH CHECK ADD  CONSTRAINT [FK_UserAwards_Award] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Award] ([ID])
GO
ALTER TABLE [dbo].[UserAwards] CHECK CONSTRAINT [FK_UserAwards_Award]
GO
ALTER TABLE [dbo].[UserAwards]  WITH CHECK ADD  CONSTRAINT [FK_UserAwards_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserAwards] CHECK CONSTRAINT [FK_UserAwards_User]
GO
