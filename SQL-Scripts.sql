USE [ShelterProject]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ShelterId] [int] NOT NULL,
	[StartDay] [nvarchar](max) NOT NULL,
	[EndDay] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShelterId] [int] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Water] [int] NOT NULL,
	[Clothes] [int] NOT NULL,
	[Toy] [int] NOT NULL,
	[Medicine] [int] NOT NULL,
	[Food] [int] NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shelters]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shelters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Owner] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NULL,
	[MaxNum] [int] NOT NULL,
	[Availability] [int] NOT NULL,
	[ResourcesId] [int] NULL,
 CONSTRAINT [PK_Shelters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/5/2023 10:51:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[PersonalImage] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[ShelterId] [int] NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230731200125_intial', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230731220032_second', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230801125749_shelter-resourse', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230801135128_shelter-resourse-second', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230802014914_book-date', N'6.0.20')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230802015508_book-date-second', N'6.0.20')
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [UserId], [ShelterId], [StartDay], [EndDay], [Status]) VALUES (1, 1, 1, N'2023-08-02 01:33:02.2920000', N'2023-08-02 01:33:02.2920000', 2)
INSERT [dbo].[Books] ([Id], [UserId], [ShelterId], [StartDay], [EndDay], [Status]) VALUES (1003, 1, 1004, N'1-4-2023', N'26-5-2023', 0)
INSERT [dbo].[Books] ([Id], [UserId], [ShelterId], [StartDay], [EndDay], [Status]) VALUES (1004, 2, 1, N'1-1-2023', N'1-7-2023', 2)
INSERT [dbo].[Books] ([Id], [UserId], [ShelterId], [StartDay], [EndDay], [Status]) VALUES (1006, 2, 1, N'1-1-2023', N'1-7-2023', 0)
INSERT [dbo].[Books] ([Id], [UserId], [ShelterId], [StartDay], [EndDay], [Status]) VALUES (1007, 1, 1004, N'string', N'string', 2)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (1, 1006, N'9e637013-5949-4764-af35-faffadb10cb0.jfif')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (2, 1006, N'ebada895-2b02-445a-b6bf-537b89a266d9.png')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (3, 1007, N'd7c53e10-09f4-4c1c-9cf7-423b93bb7c4c.jfif')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (4, 1007, N'76b7c897-dd69-46a7-a44e-bc063013fc48.png')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (5, 1008, N'0207d483-29c7-4ef0-a4f1-09c90f23e811.jpg')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (6, 1011, N'ecbfe589-abb2-4882-a73e-b84ec99ce286.jpeg')
INSERT [dbo].[Images] ([Id], [ShelterId], [Image]) VALUES (7, 1012, N'dd2f24aa-648e-45f8-8eb0-6a3b8f0c709d.png')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (2, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (3, 2, 2, 2, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (4, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (5, 1, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1002, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1003, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1004, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1005, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1006, 3, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1007, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1008, 0, 0, 0, 1, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1009, 0, 0, 0, 2, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1010, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1011, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1012, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1013, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1014, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1015, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1016, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1017, 0, 0, 0, 0, 0)
INSERT [dbo].[Resources] ([Id], [Water], [Clothes], [Toy], [Medicine], [Food]) VALUES (1018, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Resources] OFF
GO
SET IDENTITY_INSERT [dbo].[Shelters] ON 

INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1, 1, N'Surian', N'yemen', 100, 0, NULL)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (2, 1, N'Sudan', N'string', 200, 0, 3)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (3, 1, N'test', N'Egypt', 50, 0, 5)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1002, 1, N'homless', N'Yemen', 300, 0, 1002)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1003, 1, N'Haven House', N'Alex', 10, 0, 1010)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1004, 2, N'Hopeful Home', N'Saudi Arabia', 2, 0, 1004)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1005, 1, N's', N's', 12, 0, 1011)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1006, 1, N'New Beginnings Shelter', N'Jordan', 2, 0, 1012)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1007, 1, N'Light and Day', N'syria', 2, 0, 1013)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1008, 1, N'Helping Hands Shelter', NULL, 4, 0, 1014)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1009, 1, N'You''re Always Welcome Here', N'Dahab', 0, 0, 1015)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1010, 1, N'You''re Always Welcome Here', N'dahab', 0, 0, 1016)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1011, 1, N'You''re Always Welcome Here', N'dahab', 0, 0, 1017)
INSERT [dbo].[Shelters] ([Id], [Owner], [Name], [Location], [MaxNum], [Availability], [ResourcesId]) VALUES (1012, 1, N'test', N'ddd', 0, 0, 1018)
SET IDENTITY_INSERT [dbo].[Shelters] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Email], [Age], [PersonalImage], [Location], [ShelterId], [PasswordHash], [PasswordSalt], [PhoneNumber]) VALUES (1, N'bassant khattab', N'bassant@email.com', 21, NULL, NULL, 1004, 0x6B0B73FD14FC9A87F21BEBA1717126E7D1662B79A118FF3F2A288C3633C163633A25751DE0071FC9AE43C76C6F82A596BB5B69FE999182C09DDFDFB0C82C545D, 0xE6468271107AB379F94E5AE0E5A946B6244B55FD2D8C12E19341FE78760B070925620C61EA3E5D1B7C5988B3ED8E265601A7CD26892018EFF7CB7F56417B2EAA6D1F4950BD62D43DC4FCFBFA967289142F184D4718AB14BD4D87CCA8C5D40ABE75A11480765E84DC214E356CD2815F991B306EA39119CD4AEA434D092550019C, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [Email], [Age], [PersonalImage], [Location], [ShelterId], [PasswordHash], [PasswordSalt], [PhoneNumber]) VALUES (2, N'Muhammad Hassan', N'muhammad@email.com', 23, NULL, NULL, NULL, 0x902168981B84CB635653CE5B35A5220D70CD836C83A55EEDC7E15DCF8070A67589D29CC630B4A2F38D52F892AAC9AB35039CCE25EDBC91B6334C20F0B364A03C, 0xAF868F9F638D601D5B84B2A135A259AE493747BF49F73C78652B05537BC5C1DAE0286C37E8F92CED168A7C749615B5CC6590A1CE66D337623BFDA2240F782C5177ACDC281A434AEBC32E4FD57BE26FAE376A544E0813752A30E2614677D4D48BF529356ECDA1D8778E18105E1A41B4B1C786468DF3289C4D2C89542401975A0D, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [Email], [Age], [PersonalImage], [Location], [ShelterId], [PasswordHash], [PasswordSalt], [PhoneNumber]) VALUES (3, N'Abdelrahma Muhammad', N'abdo@email.com', 22, NULL, NULL, NULL, 0x1B4B7D8A65A3F31F8313FF93897F0F75F58EFCE1829B9D716FDF38FC3D9ECF758A5501FE7B0CB67B808E7562AFA0E87DD7011CF7DCA3BCC399F7A20E7822CA5E, 0x39E31F5E934E7E9970F25DBBE643182D0DDC4DB9AC082DB986F04A18478FDE36E77D6B51F60B2B3981260007D1CB94938BF105952B58F28C3F49CB53445FF1D3E8645B2AAF512503505FA68B8B69D94DC3A82925BC98ED82A6182F53DB9959FB57FA9A37E389ADCB7319992CB0369D377FA1FCEF9CAB1C0FD1BFE08D2ECC57FB, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (0x) FOR [PasswordHash]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (0x) FOR [PasswordSalt]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Shelters_ShelterId] FOREIGN KEY([ShelterId])
REFERENCES [dbo].[Shelters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Shelters_ShelterId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Users_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Shelters_ShelterId] FOREIGN KEY([ShelterId])
REFERENCES [dbo].[Shelters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Shelters_ShelterId]
GO
ALTER TABLE [dbo].[Shelters]  WITH CHECK ADD  CONSTRAINT [FK_Shelters_Resources_ResourcesId] FOREIGN KEY([ResourcesId])
REFERENCES [dbo].[Resources] ([Id])
GO
ALTER TABLE [dbo].[Shelters] CHECK CONSTRAINT [FK_Shelters_Resources_ResourcesId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Shelters_ShelterId] FOREIGN KEY([ShelterId])
REFERENCES [dbo].[Shelters] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Shelters_ShelterId]
GO
