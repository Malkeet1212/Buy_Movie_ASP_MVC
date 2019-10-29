SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [CustomerName], [Email]) VALUES (1, N'Robert Holding', N'robert1234@gmail.com')
INSERT INTO [dbo].[Customer] ([Id], [CustomerName], [Email]) VALUES (2, N'Frank Davidson', N'frank1234@gmail.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (1, N'The Fast and the Furious ', N'Action', CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (2, N'Man Of Steel', N'Thriller /Action ', CAST(150.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (3, N'The Unborn', N'Horror', CAST(100.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Movie] ([Id], [MovieName], [Genre], [Price]) VALUES (4, N'Beautiful Mind ', N'Drama /Thriller ', CAST(150.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Movie] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON
INSERT INTO [dbo].[Comment] ([Id], [CustomerId], [CommentText]) VALUES (1, 1, N'A wonderful range of choices')
INSERT INTO [dbo].[Comment] ([Id], [CustomerId], [CommentText]) VALUES (2, 2, N'Excellent customer care')
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[MovieTransaction] ON
INSERT INTO [dbo].[MovieTransaction] ([Id], [MovieId], [CustomerId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[MovieTransaction] ([Id], [MovieId], [CustomerId]) VALUES (2, 3, 2)
SET IDENTITY_INSERT [dbo].[MovieTransaction] OFF
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'612082f2-afd5-4245-8633-4cd7bcc79625', N'sysadmin@movies.com', N'SYSADMIN@MOVIES.COM', N'sysadmin@movies.com', N'SYSADMIN@MOVIES.COM', 0, N'AQAAAAEAACcQAAAAEH/a7xXSUaUffL7tLhZmuvyNg/CC1M9myp8MMpiRCMXshMI2YRqyQq+W3AlxKfZU/A==', N'CJ5R2SNCGACDAOVX23OTNXGKNA7MBSNX', N'2b8d0217-2e74-4b4f-956f-3642c8400231', NULL, 0, 0, NULL, 1, 0)

