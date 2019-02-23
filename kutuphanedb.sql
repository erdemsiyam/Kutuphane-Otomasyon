USE [KutuphaneDB]
GO
/****** Object:  Table [dbo].[Kitap]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitap](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Kitap_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
	[SayfaSayisi] [int] NOT NULL,
	[YazarID] [uniqueidentifier] NOT NULL,
	[Dili] [nvarchar](50) NOT NULL,
	[YayinEviID] [uniqueidentifier] NULL,
	[TipID] [uniqueidentifier] NOT NULL,
	[ISBN] [nvarchar](50) NULL,
	[AlimTarihi] [date] NOT NULL,
	[BasimTarihi] [date] NOT NULL,
	[Fiyati] [money] NOT NULL,
	[ResimURL] [nvarchar](50) NULL,
	[Aktif] [bit] NULL CONSTRAINT [DF_Kitap_Aktif]  DEFAULT ((1)),
	[OkunmaSayisi] [int] NULL CONSTRAINT [DF_Kitap_OkunmaSayisi]  DEFAULT ((0)),
 CONSTRAINT [PK_Kitap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KitapTuru]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitapTuru](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_KitapTuru_ID]  DEFAULT (newsequentialid()),
	[KitapID] [uniqueidentifier] NOT NULL,
	[TurID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_KitapTuru] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OduncKitap]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OduncKitap](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_OduncKitap_ID]  DEFAULT (newsequentialid()),
	[KitapID] [uniqueidentifier] NOT NULL,
	[UyeID] [uniqueidentifier] NOT NULL,
	[BaslangicTarih] [date] NOT NULL,
	[BitisTarih] [date] NOT NULL,
	[GeriAlindiMi] [bit] NULL CONSTRAINT [DF_OduncKitap_GeriAlindiMi]  DEFAULT ((0)),
	[GeriAlinmaTarihi] [date] NULL,
 CONSTRAINT [PK_OduncKitap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Rol_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tip]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tip](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Tip_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tur]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tur](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Tur_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tur] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Uye]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uye](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Uye_ID]  DEFAULT (newsequentialid()),
	[Email] [nvarchar](50) NOT NULL,
	[AdSoyad] [nvarchar](50) NOT NULL,
	[DogumYili] [int] NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[Telefon] [nchar](10) NULL,
	[RolID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Uye] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[YayinEvi]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YayinEvi](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_YayinEvi_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_YayinEvi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yazar]    Script Date: 15.01.2019 00:05:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yazar](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Yazar_ID]  DEFAULT (newsequentialid()),
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Yazar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'1665ef5e-a49d-4fba-ab18-092f7e51afd5', N'Tutunamayanlar', 365, N'ae3eb107-fabb-4d0d-a07a-a53d5b18bd03', N'Türkçe', N'db7bf00a-dfdd-41f1-9794-a426dd3c2389', N'3d9f4621-3417-4484-85d9-1293f4311168', N'12345678925', CAST(N'2018-01-05' AS Date), CAST(N'2018-01-01' AS Date), 40.0000, N'157dbb11-afc9-4d17-9add-21f138ea295c.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'0d0b22d5-0c1e-4f75-b9e2-160f13e7e6ce', N'Budala', 260, N'108c6892-0570-47d9-b60c-1944058962a7', N'Türkçe', N'729e3273-283e-4187-b783-77b827f63284', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 40.0000, N'30b9035c-1e45-4fc1-887d-18c55b698936.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'156ce341-c52d-4848-a6a5-66476a3d2a73', N'Savaş Ve Barış', 420, N'569a2d06-83dd-4b5e-b6cb-2df299f50817', N'Türkçe', N'0d09f370-b41d-48f5-b649-0dd68490eb5b', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'9eabee5c-a0b1-4706-ba3c-03bfb87bf50b.jpg', 0, 2)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'24cd3c51-4ece-432c-bfb7-6b07fb4a8aff', N'Suç Ve Ceza', 300, N'108c6892-0570-47d9-b60c-1944058962a7', N'Türkçe', N'729e3273-283e-4187-b783-77b827f63284', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 35.0000, N'834a9bb8-74a3-4fc6-b77a-e22cf8a4fb2e.jpg', 1, 1)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'0e368b59-4f06-4b2a-96bc-7b05d1f699f2', N'İçimizdeki Şeytan', 380, N'0baa295d-5602-4c4e-9395-8c66159c9b18', N'Türkçe', N'1e5ea8da-8829-43c1-9b5c-c274f0cc6b14', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'42474f38-e012-42e2-962e-3575cdf4bfbd.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'2462661f-bd7c-e811-a7ee-80fa5b2d790b', N'Stalin''den Kaçanlar', 324, N'33d13709-309b-4e6e-abbd-01773574a3e3', N'Türkçe', N'729e3273-283e-4187-b783-77b827f63284', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1234567891', CAST(N'2018-03-04' AS Date), CAST(N'2017-05-06' AS Date), 30.0000, N'842fa8ec-bfe6-4755-b46d-c4f07aaf43ab.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'8f023e4c-bd7c-e811-a7ee-80fa5b2d790b', N'Kısa Edebiyat Sözleri', 115, N'3baa0c32-3a87-4b82-b659-ccc6f8d9f660', N'Türkçe', N'db7bf00a-dfdd-41f1-9794-a426dd3c2389', N'b8ce1c18-67a8-4253-a564-df959f6242c2', N'1234567892', CAST(N'2018-04-05' AS Date), CAST(N'2016-05-07' AS Date), 10.0000, N'a8c7c3a0-9f90-4d2b-92da-d1519bc3c8b5.jpg', 1, 1)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'8e21e0de-af7d-e811-bdb2-80fa5b2d790b', N'Kara Cemal', 255, N'33d13709-309b-4e6e-abbd-01773574a3e3', N'Türkçe', N'729e3273-283e-4187-b783-77b827f63284', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1234567893', CAST(N'2016-01-02' AS Date), CAST(N'2015-05-05' AS Date), 20.0000, N'370a1863-0a7f-470f-938a-2751c79e2fb5.jpg', 1, 1)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'b40c60ef-fc6e-430e-91fe-92fef3e2ce2c', N'Kürk Mantolu Madonna', 260, N'0baa295d-5602-4c4e-9395-8c66159c9b18', N'Türkçe', N'729e3273-283e-4187-b783-77b827f63284', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'432f2b7b-4075-4db5-a9ca-a0db78655619.jpg', 0, 1)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'21f6e8bd-94cb-40ba-a636-9b1030077fb0', N'İvan İlyiç''in Ölümü', 450, N'569a2d06-83dd-4b5e-b6cb-2df299f50817', N'Türkçe', N'0d09f370-b41d-48f5-b649-0dd68490eb5b', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'160083b4-949e-4ae7-af18-e968c604405b.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'bf867311-04f5-403c-bcab-b7a620e4d499', N'Dönüşüm', 254, N'd979022e-feb3-42d0-a000-1712b1a6f216', N'Türkçe', N'1e5ea8da-8829-43c1-9b5c-c274f0cc6b14', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 25.0000, N'79c0f89a-c7e8-4a9f-a542-2f07dd44042f.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'063bdd4f-c819-4b30-a0bc-bc6ce38a3a48', N'Anna Karenina', 390, N'569a2d06-83dd-4b5e-b6cb-2df299f50817', N'Türkçe', N'0d09f370-b41d-48f5-b649-0dd68490eb5b', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'2ba88b47-d836-443c-ad71-6caf6b5f88a9.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'fdba7132-1249-42f4-a10c-c990b5acedf4', N'Babaya Mektup', 289, N'd979022e-feb3-42d0-a000-1712b1a6f216', N'Türkçe', N'2756d580-3655-46d3-b0f1-f1471fe8b041', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 30.0000, N'71de69ee-2ef9-4af9-beec-a655c224d41e.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'cdcd7f5f-9c50-4ef7-b1c2-daef31a9f265', N'Diriliş', 460, N'569a2d06-83dd-4b5e-b6cb-2df299f50817', N'Türkçe', N'0d09f370-b41d-48f5-b649-0dd68490eb5b', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 60.0000, N'4a707587-3bfe-4da5-8f68-459e4876fa2c.jpg', 0, 1)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'bd34c97e-19bb-4018-aa0b-e03218b67a83', N'Orta Doğu Ateşi', 300, N'3baa0c32-3a87-4b82-b659-ccc6f8d9f660', N'Türkçe', N'db7bf00a-dfdd-41f1-9794-a426dd3c2389', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-05-06' AS Date), CAST(N'2018-01-01' AS Date), 45.0000, N'ff814532-561b-4109-93b4-0b7e2fe21519.jpg', 1, 0)
INSERT [dbo].[Kitap] ([ID], [Adi], [SayfaSayisi], [YazarID], [Dili], [YayinEviID], [TipID], [ISBN], [AlimTarihi], [BasimTarihi], [Fiyati], [ResimURL], [Aktif], [OkunmaSayisi]) VALUES (N'a9ba6ee3-9052-4657-bd47-ef6d2c4ce58a', N'Kumarbaz', 356, N'108c6892-0570-47d9-b60c-1944058962a7', N'Türkçe', N'db7bf00a-dfdd-41f1-9794-a426dd3c2389', N'3d9f4621-3417-4484-85d9-1293f4311168', N'1231231231', CAST(N'2018-01-01' AS Date), CAST(N'2017-01-01' AS Date), 55.0000, N'1b6d01ac-9c9a-41de-809e-61f0af6bd219.jpg', 1, 0)
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'a624d394-ebbe-40db-8211-00b883992b79', N'a9ba6ee3-9052-4657-bd47-ef6d2c4ce58a', N'bd90e550-b8e1-490f-9ec4-27a86bf7e7c6')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'45232f06-e14a-48c7-b0a7-07914daba35c', N'cdcd7f5f-9c50-4ef7-b1c2-daef31a9f265', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'6cb74628-8937-47f3-899d-169c09be724e', N'2462661f-bd7c-e811-a7ee-80fa5b2d790b', N'20f6c813-1773-49bd-9113-5d4079f59bed')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'3d004455-0178-49b3-a991-2292d3bd1aa7', N'bf867311-04f5-403c-bcab-b7a620e4d499', N'54128f40-59df-43f0-aab8-5b7c33506efa')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'd3ae8a7d-92df-4712-9c86-284edc4b1b66', N'a9ba6ee3-9052-4657-bd47-ef6d2c4ce58a', N'efe8e5d7-51cc-4267-bea5-e07876e6dae8')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'4d14c17f-6c54-4e3a-8b13-2aec81c92c21', N'2462661f-bd7c-e811-a7ee-80fa5b2d790b', N'fb6809cd-021e-49bd-bc7f-9be854ba6433')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'2c7f1371-f72b-4efe-8a1a-366ca0522019', N'8f023e4c-bd7c-e811-a7ee-80fa5b2d790b', N'258adfa2-9a83-4944-9fc9-c8dcd5e7b763')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'6acbb53f-9bb5-46ff-8a54-3682d26baf76', N'24cd3c51-4ece-432c-bfb7-6b07fb4a8aff', N'efe8e5d7-51cc-4267-bea5-e07876e6dae8')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'8c3f423a-bb7e-4bd7-9472-3786ce1c8038', N'21f6e8bd-94cb-40ba-a636-9b1030077fb0', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'40e87d10-5fa8-475f-a1df-461ef3920fb9', N'156ce341-c52d-4848-a6a5-66476a3d2a73', N'1cb395ee-82be-41b0-b810-1256aacfed70')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'71827246-6b8a-4398-991d-47d5e8572bc9', N'cdcd7f5f-9c50-4ef7-b1c2-daef31a9f265', N'20f6c813-1773-49bd-9113-5d4079f59bed')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'aad1f00c-2adc-453e-a8f7-4e81cdb2f4f4', N'8e21e0de-af7d-e811-bdb2-80fa5b2d790b', N'20f6c813-1773-49bd-9113-5d4079f59bed')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'dd39b0b6-1939-4421-a527-55755784facb', N'0d0b22d5-0c1e-4f75-b9e2-160f13e7e6ce', N'1cb395ee-82be-41b0-b810-1256aacfed70')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'd8747c48-c3f5-4cc9-9eb1-608f1353b594', N'24cd3c51-4ece-432c-bfb7-6b07fb4a8aff', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'0df962b3-dac5-412c-9867-619fa5a8f569', N'bf867311-04f5-403c-bcab-b7a620e4d499', N'756d912f-67a1-493c-8019-2fdbe78a77fa')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'950a9de9-a901-452e-a547-692fd689af14', N'b40c60ef-fc6e-430e-91fe-92fef3e2ce2c', N'1cb395ee-82be-41b0-b810-1256aacfed70')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'27713329-465a-4568-a975-7b15e18838de', N'8f023e4c-bd7c-e811-a7ee-80fa5b2d790b', N'ab647a3f-faff-413b-8062-12be8b6ba64b')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'7304fe52-ea5b-4bd8-9361-7fa645cb8387', N'0e368b59-4f06-4b2a-96bc-7b05d1f699f2', N'efe8e5d7-51cc-4267-bea5-e07876e6dae8')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'7dca76ef-eb23-473a-b664-8844e99e1c9c', N'2462661f-bd7c-e811-a7ee-80fa5b2d790b', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'73c890d6-ce3c-4130-a93c-8e83eae82417', N'0d0b22d5-0c1e-4f75-b9e2-160f13e7e6ce', N'fb6809cd-021e-49bd-bc7f-9be854ba6433')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'a8808e7d-89c8-4264-b18f-9d3b692e3604', N'fdba7132-1249-42f4-a10c-c990b5acedf4', N'1cb395ee-82be-41b0-b810-1256aacfed70')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'b01122e7-3415-4694-afb8-a4425a7dfc53', N'b40c60ef-fc6e-430e-91fe-92fef3e2ce2c', N'efe8e5d7-51cc-4267-bea5-e07876e6dae8')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'c0a45439-2871-4bae-8f09-a9b08b4a0127', N'8e21e0de-af7d-e811-bdb2-80fa5b2d790b', N'fb6809cd-021e-49bd-bc7f-9be854ba6433')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'1934f2a7-ad66-48f9-bc34-b1aebbb8265a', N'063bdd4f-c819-4b30-a0bc-bc6ce38a3a48', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'0a27fbdf-bbdf-4e1e-80fe-b5f4e5cf58fa', N'0e368b59-4f06-4b2a-96bc-7b05d1f699f2', N'bd90e550-b8e1-490f-9ec4-27a86bf7e7c6')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'4697e383-266f-4e7a-a8d2-da6e7f3d3a66', N'b40c60ef-fc6e-430e-91fe-92fef3e2ce2c', N'258adfa2-9a83-4944-9fc9-c8dcd5e7b763')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'a645a008-1347-4f97-a166-ddca78560d85', N'156ce341-c52d-4848-a6a5-66476a3d2a73', N'34408ab2-e0cb-436e-98d9-73417f88a589')
INSERT [dbo].[KitapTuru] ([ID], [KitapID], [TurID]) VALUES (N'261ecf6e-0c83-4f5f-bcb0-f243885ae121', N'bd34c97e-19bb-4018-aa0b-e03218b67a83', N'1cb395ee-82be-41b0-b810-1256aacfed70')
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'd2bd0f77-402d-430f-ba80-13fe6a8edf7e', N'24cd3c51-4ece-432c-bfb7-6b07fb4a8aff', N'762521f5-8e7c-e811-a7ee-80fa5b2d790b', CAST(N'2018-07-02' AS Date), CAST(N'2018-07-03' AS Date), 1, CAST(N'2018-07-19' AS Date))
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'e1fef658-3f5b-48df-9fed-35917509b3d2', N'b40c60ef-fc6e-430e-91fe-92fef3e2ce2c', N'fb6ad8ee-8309-4291-9bf0-88eac0b32f36', CAST(N'2018-07-02' AS Date), CAST(N'2018-08-01' AS Date), 0, NULL)
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'd398aacb-94fd-4bab-bbae-4162949f0cb5', N'8e21e0de-af7d-e811-bdb2-80fa5b2d790b', N'762521f5-8e7c-e811-a7ee-80fa5b2d790b', CAST(N'2018-07-05' AS Date), CAST(N'2018-07-09' AS Date), 1, CAST(N'2018-07-19' AS Date))
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'd8a869ba-280f-48f5-b4b9-5edef468752d', N'156ce341-c52d-4848-a6a5-66476a3d2a73', N'762521f5-8e7c-e811-a7ee-80fa5b2d790b', CAST(N'2018-07-05' AS Date), CAST(N'2018-07-07' AS Date), 1, CAST(N'2018-07-05' AS Date))
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'7ca9c018-2e34-448c-83e0-5f4286a100ea', N'8f023e4c-bd7c-e811-a7ee-80fa5b2d790b', N'762521f5-8e7c-e811-a7ee-80fa5b2d790b', CAST(N'2018-07-05' AS Date), CAST(N'2018-07-19' AS Date), 1, CAST(N'2018-07-19' AS Date))
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'9d20c318-a534-4d96-b4bb-b38c65f7f91b', N'156ce341-c52d-4848-a6a5-66476a3d2a73', N'902fa93e-e508-416b-b825-6813d1be265d', CAST(N'2018-07-19' AS Date), CAST(N'2018-08-14' AS Date), 0, NULL)
INSERT [dbo].[OduncKitap] ([ID], [KitapID], [UyeID], [BaslangicTarih], [BitisTarih], [GeriAlindiMi], [GeriAlinmaTarihi]) VALUES (N'debe85f9-6776-4fee-a360-d6ec03d1092a', N'cdcd7f5f-9c50-4ef7-b1c2-daef31a9f265', N'66d0c84b-ed6b-438f-8bd5-ceef1fcac2d2', CAST(N'2018-07-02' AS Date), CAST(N'2018-07-09' AS Date), 0, NULL)
INSERT [dbo].[Rol] ([ID], [Adi]) VALUES (N'3d9f4621-3417-4484-85d9-1293f4314f68', N'Uye')
INSERT [dbo].[Rol] ([ID], [Adi]) VALUES (N'1113935c-8e7c-e811-a7ee-80fa5b2d790b', N'Admin')
INSERT [dbo].[Tip] ([ID], [Adi]) VALUES (N'3d9f4621-3417-4484-85d9-1293f4311168', N'Ciltli')
INSERT [dbo].[Tip] ([ID], [Adi]) VALUES (N'd784f2d1-06d8-4d49-ab2b-50254d25400e', N'İnce Kapak')
INSERT [dbo].[Tip] ([ID], [Adi]) VALUES (N'426b931f-2128-4a67-915e-c27ec7302c81', N'Diğer')
INSERT [dbo].[Tip] ([ID], [Adi]) VALUES (N'b8ce1c18-67a8-4253-a564-df959f6242c2', N'Cep Boy')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'd8eb5fe0-29e2-4d42-aa5a-0a5959f56559', N'İlişkiler')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'1cb395ee-82be-41b0-b810-1256aacfed70', N'Siyaset')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'ab647a3f-faff-413b-8062-12be8b6ba64b', N'Şiir')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'bd90e550-b8e1-490f-9ec4-27a86bf7e7c6', N'Din')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'756d912f-67a1-493c-8019-2fdbe78a77fa', N'Bilim')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'54128f40-59df-43f0-aab8-5b7c33506efa', N'Eğitim')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'20f6c813-1773-49bd-9113-5d4079f59bed', N'Aksiyon')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'34408ab2-e0cb-436e-98d9-73417f88a589', N'Dram')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'fb6809cd-021e-49bd-bc7f-9be854ba6433', N'Polisiye')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'6e6d2def-9eb7-4f3a-b07f-c73416a39ecd', N'Teknoloji')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'258adfa2-9a83-4944-9fc9-c8dcd5e7b763', N'Edebiyat')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'efe8e5d7-51cc-4267-bea5-e07876e6dae8', N'Felsefe')
INSERT [dbo].[Tur] ([ID], [Adi]) VALUES (N'18ff8803-344a-4e99-b5d0-e0e43dd3b950', N'Sağlık')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'902fa93e-e508-416b-b825-6813d1be265d', N'sedatduran@hotmail.com', N'Sedat Duran', 1996, N'sedatduran1996', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'f124b901-d59c-463c-915d-71d402763271', N'hakancevik@gmail.com', N'Hakan Çevik', 1995, N'hakançevik1995', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'762521f5-8e7c-e811-a7ee-80fa5b2d790b', N'erdemsiyam@gmail.com', N'Erdem Siyam', 1996, N'erdemsiyam1996', N'5511327535', N'1113935c-8e7c-e811-a7ee-80fa5b2d790b')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'fb6ad8ee-8309-4291-9bf0-88eac0b32f36', N'onurgudul@hotmail.com', N'Onur Gudul', 1997, N'onurgudul1997', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'a46a5962-0269-46f8-b57f-92deed6fab6f', N'atiforman@gmail.com', N'Atıf Orman', 1999, N'atıforman1999', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'66d0c84b-ed6b-438f-8bd5-ceef1fcac2d2', N'hakandereli@gmail.com', N'Hakan Dereli', 1997, N'hakandereli1997', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'c44bd1d7-2c77-4993-b62a-e97f21ee8d23', N'furkandemir@hotmail.com', N'Furkan Demir', 1997, N'furkandemir1997', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[Uye] ([ID], [Email], [AdSoyad], [DogumYili], [Sifre], [Telefon], [RolID]) VALUES (N'd94e3eb8-5f22-4f3f-9c4f-eb98c151c9d1', N'ersinkaramustafa@gmail.com', N'Ersin Karamustafa', 1997, N'ersinkaramustafa1997', NULL, N'3d9f4621-3417-4484-85d9-1293f4314f68')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'0d09f370-b41d-48f5-b649-0dd68490eb5b', N'Kırlangıç')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'729e3273-283e-4187-b783-77b827f63284', N'Ay')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'db7bf00a-dfdd-41f1-9794-a426dd3c2389', N'Güven')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'26fd61d9-6cab-48a8-b491-c008d4aaf69a', N'Söz')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'1e5ea8da-8829-43c1-9b5c-c274f0cc6b14', N'Çağdaş')
INSERT [dbo].[YayinEvi] ([ID], [Adi]) VALUES (N'2756d580-3655-46d3-b0f1-f1471fe8b041', N'Aydın')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'33d13709-309b-4e6e-abbd-01773574a3e3', N'Hakan Aydın')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'd979022e-feb3-42d0-a000-1712b1a6f216', N'Franz Kafka')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'108c6892-0570-47d9-b60c-1944058962a7', N'Fyodor Dostoyevski')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'569a2d06-83dd-4b5e-b6cb-2df299f50817', N'Lev Tolstoy')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'0baa295d-5602-4c4e-9395-8c66159c9b18', N'Sabahattin Ali')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'ae3eb107-fabb-4d0d-a07a-a53d5b18bd03', N'Oğuz Atay')
INSERT [dbo].[Yazar] ([ID], [Adi]) VALUES (N'3baa0c32-3a87-4b82-b659-ccc6f8d9f660', N'Engin Altan')
ALTER TABLE [dbo].[Kitap]  WITH CHECK ADD  CONSTRAINT [FK_Kitap_Tip] FOREIGN KEY([TipID])
REFERENCES [dbo].[Tip] ([ID])
GO
ALTER TABLE [dbo].[Kitap] CHECK CONSTRAINT [FK_Kitap_Tip]
GO
ALTER TABLE [dbo].[Kitap]  WITH CHECK ADD  CONSTRAINT [FK_Kitap_YayinEvi] FOREIGN KEY([YayinEviID])
REFERENCES [dbo].[YayinEvi] ([ID])
GO
ALTER TABLE [dbo].[Kitap] CHECK CONSTRAINT [FK_Kitap_YayinEvi]
GO
ALTER TABLE [dbo].[Kitap]  WITH CHECK ADD  CONSTRAINT [FK_Kitap_Yazar] FOREIGN KEY([YazarID])
REFERENCES [dbo].[Yazar] ([ID])
GO
ALTER TABLE [dbo].[Kitap] CHECK CONSTRAINT [FK_Kitap_Yazar]
GO
ALTER TABLE [dbo].[KitapTuru]  WITH CHECK ADD  CONSTRAINT [FK_KitapTuru_Kitap] FOREIGN KEY([KitapID])
REFERENCES [dbo].[Kitap] ([ID])
GO
ALTER TABLE [dbo].[KitapTuru] CHECK CONSTRAINT [FK_KitapTuru_Kitap]
GO
ALTER TABLE [dbo].[KitapTuru]  WITH CHECK ADD  CONSTRAINT [FK_KitapTuru_Tur] FOREIGN KEY([TurID])
REFERENCES [dbo].[Tur] ([ID])
GO
ALTER TABLE [dbo].[KitapTuru] CHECK CONSTRAINT [FK_KitapTuru_Tur]
GO
ALTER TABLE [dbo].[OduncKitap]  WITH CHECK ADD  CONSTRAINT [FK_OduncKitap_Kitap] FOREIGN KEY([KitapID])
REFERENCES [dbo].[Kitap] ([ID])
GO
ALTER TABLE [dbo].[OduncKitap] CHECK CONSTRAINT [FK_OduncKitap_Kitap]
GO
ALTER TABLE [dbo].[OduncKitap]  WITH CHECK ADD  CONSTRAINT [FK_OduncKitap_Uye] FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uye] ([ID])
GO
ALTER TABLE [dbo].[OduncKitap] CHECK CONSTRAINT [FK_OduncKitap_Uye]
GO
ALTER TABLE [dbo].[Uye]  WITH CHECK ADD  CONSTRAINT [FK_Uye_Rol] FOREIGN KEY([RolID])
REFERENCES [dbo].[Rol] ([ID])
GO
ALTER TABLE [dbo].[Uye] CHECK CONSTRAINT [FK_Uye_Rol]
GO
