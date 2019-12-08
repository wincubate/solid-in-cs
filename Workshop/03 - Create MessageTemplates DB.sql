USE [90322]
GO
/****** Object:  Table [dbo].[MessageTemplates]    Script Date: 16-09-2019 17:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kind] [nvarchar](50) NOT NULL,
	[Culture] [nvarchar](50) NULL,
	[Subject] [nvarchar](max) NULL,
	[BodyTemplate] [nvarchar](max) NULL,
 CONSTRAINT [PK_MessageTemplates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MessageTemplates] ON 

GO
INSERT [dbo].[MessageTemplates] ([Id], [Kind], [Culture], [Subject], [BodyTemplate]) VALUES (1, N'UserIsCreatedOk', N'en', N'Account created', N'Dear {0}. Your account with Cinemas ''R Us was created successfully. :-)')
GO
INSERT [dbo].[MessageTemplates] ([Id], [Kind], [Culture], [Subject], [BodyTemplate]) VALUES (2, N'UserIsCreatedOk', N'da', N'Konto oprettet', N'Kære {0}. Din konto hos Cinemas ''R Us er nu oprettet. :-)')
GO
INSERT [dbo].[MessageTemplates] ([Id], [Kind], [Culture], [Subject], [BodyTemplate]) VALUES (3, N'UserIsDeletedOk', N'en', N'Account deleted', N'Dear {0}. We''re so sad to see you leave... :-(')
GO
INSERT [dbo].[MessageTemplates] ([Id], [Kind], [Culture], [Subject], [BodyTemplate]) VALUES (4, N'UserIsDeletedOk', N'da', N'Konto slettet', N'Kære {0}. Vi er så kede af, at du forlader os... :-(')
GO
SET IDENTITY_INSERT [dbo].[MessageTemplates] OFF
GO
