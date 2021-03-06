

USE [ProjectRooms]
GO
/****** Object:  Table [dbo].[tbBooking]    Script Date: 2014-02-04 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBooking](
	[iBookingID] [int] IDENTITY(1,1) NOT NULL,
	[iUserId] [int] NOT NULL,
	[iRumId] [int] NOT NULL,
	[dtDateDay] [date] NOT NULL,
	[dtTimeStart] [time](7) NOT NULL,
	[dtTimeEnd] [time](7) NOT NULL,
 CONSTRAINT [PK_tbBooking] PRIMARY KEY CLUSTERED 
(
	[iBookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbBooking] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[tbRole]    Script Date: 2014-02-04 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRole](
	[iRoleID] [int] IDENTITY(1,1) NOT NULL,
	[sRoleType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbRole] PRIMARY KEY CLUSTERED 
(
	[iRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tbRole] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[tbRoom]    Script Date: 2014-02-04 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRoom](
	[iRoomId] [int] IDENTITY(1,1) NOT NULL,
	[sRoomName] [nvarchar](50) NOT NULL,
	[iRoomChairs] [int] NOT NULL,
	[sRoomDesc] [nvarchar](150),
 CONSTRAINT [PK_tbRoom] PRIMARY KEY CLUSTERED 
(
	[iRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 2014-02-04 15:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[iUserId] [int] IDENTITY(1,1) NOT NULL,
	[sUserName] [nvarchar](max) NOT NULL,
	[sUserLoginName] [nvarchar](50) NOT NULL,
	[sUserPassword] [nvarchar](50) NOT NULL,
	[iUserRole] [int] NULL,
	[iBlocked] [int] NULL,
	[iActivBooking] [int] NULL,
	[sClass] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[iUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbRole] ON 

INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (1, N'Admin')
INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (2, N'User')
INSERT [dbo].[tbRole] ([iRoleID], [sRoleType]) VALUES (3, N'Teacher')
SET IDENTITY_INSERT [dbo].[tbRole] OFF
SET IDENTITY_INSERT [dbo].[tbRoom] ON 

INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs]) VALUES (1, N'Projektrum1', 4)
INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs]) VALUES (2, N'Projektrum2', 6)
INSERT [dbo].[tbRoom] ([iRoomId], [sRoomName], [iRoomChairs]) VALUES (3, N'Projektrum3', 9)
SET IDENTITY_INSERT [dbo].[tbRoom] OFF
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [iActivBooking], [sClass]) 
	VALUES (1, N'Gun', N'Gun', N'123', 1, NULL, NULL, NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [iActivBooking], [sClass]) 
	VALUES (2, N'user', N'user', N'user', 2, NULL, NULL, NULL)
INSERT [dbo].[tbUser] ([iUserId], [sUserName], [sUserLoginName], [sUserPassword], [iUserRole], [iBlocked], [iActivBooking], [sClass]) 
	VALUES (3, N'techer', N'teacher', N'teacher', 3, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbUser] OFF
ALTER TABLE [dbo].[tbBooking]  WITH CHECK ADD FOREIGN KEY([iRumId])
REFERENCES [dbo].[tbRoom] ([iRoomId])
GO
ALTER TABLE [dbo].[tbUser]  WITH CHECK ADD FOREIGN KEY([iUserRole])
REFERENCES [dbo].[tbRole] ([iRoleID])
GO
ALTER TABLE [dbo].[tbBooking]  WITH CHECK ADD FOREIGN KEY([iUserId])
REFERENCES [dbo].[tbUser] ([iUserId])
GO
USE [master]
GO
ALTER DATABASE [ProjectRooms] SET  READ_WRITE 
GO
