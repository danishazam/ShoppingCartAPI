USE [ShoppingCartAPI]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/03/2024 10:59:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (1, N'Milk', CAST(0.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (2, N'Bread', CAST(1.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (3, N'Sugar', CAST(0.80 AS Decimal(18, 2)))
GO
INSERT [dbo].[Products] ([Id], [Name], [Price]) VALUES (4, N'Butter', CAST(1.87 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
