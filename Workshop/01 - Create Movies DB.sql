USE [90322]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 08-09-2019 17:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Plot] [nvarchar](max) NOT NULL,
	[ImdbRating] [float] NULL,
	[TicketPrice] [money] NULL,
	[IsShowing] [bit] NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Movies] ([Id], [Name], [Year], [Plot], [ImdbRating], [TicketPrice], [IsShowing], [LastUpdated]) VALUES (N'225ed6ba-7a85-4fb2-b314-1eb9102f15e1', N'The Shawshank Redemption', 1994, N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 9.3, 80.0000, 1, NULL)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Year], [Plot], [ImdbRating], [TicketPrice], [IsShowing], [LastUpdated]) VALUES (N'7ace9599-2d09-431d-8bdb-4b7ec92e34d1', N'The Matrix', 1999, N'A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', 8.7, 75.0000, 1, NULL)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Year], [Plot], [ImdbRating], [TicketPrice], [IsShowing], [LastUpdated]) VALUES (N'a1c2023f-0526-48ad-ac62-6c39492fc5ab', N'Forgetting Sarah Marshall', 2008, N'Devastated Peter takes a Hawaiian vacation in order to deal with the recent break-up with his TV star girlfriend, Sarah. Little does he know, Sarah''s traveling to the same resort as her ex - and she''s bringing along her new boyfriend.', 7.1, 25.0000, 1, NULL)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Year], [Plot], [ImdbRating], [TicketPrice], [IsShowing], [LastUpdated]) VALUES (N'88805602-70ca-4df4-a3d9-79b4791b52cd', N'El Camino: A Breaking Bad Movie', 2019, N'After escaping Jack and his gang, Jesse Pinkman goes on the run from the police and tries to escape his own inner turmoil.', NULL, 100.0000, 0, NULL)
GO
INSERT [dbo].[Movies] ([Id], [Name], [Year], [Plot], [ImdbRating], [TicketPrice], [IsShowing], [LastUpdated]) VALUES (N'234f1f4a-5b0f-4e79-808f-8632b3efa928', N'Army of Darkness', 1992, N'A man is accidentally transported to 1300 A.D., where he must battle an army of the dead and retrieve the Necronomicon so he can return home.', 7.5, 50.0000, 1, NULL)
GO
