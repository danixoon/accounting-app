USE [AccountingApp]
GO
DELETE FROM [dbo].[Component]
GO
DELETE FROM [dbo].[ComponentModel]
GO
DELETE FROM [dbo].[ComponentStatus]
GO
DELETE FROM [dbo].[ServiceComponent]
GO
DELETE FROM [dbo].[Service]
GO
DELETE FROM [dbo].[Employee]
GO
DELETE FROM [dbo].[Entity]
GO
DELETE FROM [dbo].[NetworkSocket]
GO
DELETE FROM [dbo].[Department]
GO
DELETE FROM [dbo].[NetworkType]
GO
DELETE FROM [dbo].[ServiceModel]
GO
DELETE FROM [dbo].[ComponentType]
GO
DELETE FROM [dbo].[ServiceType]
GO
DELETE FROM [dbo].[EntityModel]
GO
DELETE FROM [dbo].[EntityType]
GO
SET IDENTITY_INSERT [dbo].[EntityType] ON 

INSERT [dbo].[EntityType] ([id], [name]) VALUES (1, N'Компьютер')
INSERT [dbo].[EntityType] ([id], [name]) VALUES (2, N'Принтер')
SET IDENTITY_INSERT [dbo].[EntityType] OFF
SET IDENTITY_INSERT [dbo].[EntityModel] ON 

INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (1, N'Офисный компьютер', N'Модель1', 1)
INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (3, N'Сервер', N'Модель2', 1)
INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (4, N'Офисный принтер', N'Модель1', 2)
SET IDENTITY_INSERT [dbo].[EntityModel] OFF
SET IDENTITY_INSERT [dbo].[ServiceType] ON 

INSERT [dbo].[ServiceType] ([id], [name]) VALUES (1, N'Замена картриджей')
INSERT [dbo].[ServiceType] ([id], [name]) VALUES (2, N'Переналивка картриджа')
INSERT [dbo].[ServiceType] ([id], [name]) VALUES (3, N'Ремонт комплектующих')
SET IDENTITY_INSERT [dbo].[ServiceType] OFF
SET IDENTITY_INSERT [dbo].[ComponentType] ON 

INSERT [dbo].[ComponentType] ([id], [name]) VALUES (1, N' Картридж принтера')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (2, N'ОЗУ')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (3, N'Материнская плата')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (4, N'Процессор')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (5, N'Видеокарта')
SET IDENTITY_INSERT [dbo].[ComponentType] OFF
SET IDENTITY_INSERT [dbo].[ServiceModel] ON 

INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (1, 1, 1000.0000, 2, 1)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (2, 2, 1500.0000, 2, 1)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (3, 3, 4000.0000, 1, 4)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (4, 3, 2000.0000, 1, 3)
SET IDENTITY_INSERT [dbo].[ServiceModel] OFF
SET IDENTITY_INSERT [dbo].[NetworkType] ON 

INSERT [dbo].[NetworkType] ([id], [name]) VALUES (1, N'Локальная')
INSERT [dbo].[NetworkType] ([id], [name]) VALUES (2, N'Интернет')
SET IDENTITY_INSERT [dbo].[NetworkType] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([id], [name]) VALUES (1, N'Отдел1')
INSERT [dbo].[Department] ([id], [name]) VALUES (2, N'Отдел2')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[NetworkSocket] ON 

INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (1, N'2A')
INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (2, N'3A')
INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (3, N'6Г')
SET IDENTITY_INSERT [dbo].[NetworkSocket] OFF
SET IDENTITY_INSERT [dbo].[Entity] ON 

INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (3, N'tester', N'3', 2, 1, 1, N'255.255.255.0', N'127.0.0.1', 2, 1)
INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (6, N'tester-2', N'4', 1, 2, 2, N'255.255.255.0', N'127.0.0.1', 2, 3)
INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (7, N'printer-1', N'3', 2, 1, 1, N'255.255.254.0', N'127.0.1.1', 3, 4)
SET IDENTITY_INSERT [dbo].[Entity] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [name]) VALUES (1, N'Иванов Иван Иванович')
INSERT [dbo].[Employee] ([id], [name]) VALUES (2, N'Андреев Андрей Андреевич')
INSERT [dbo].[Employee] ([id], [name]) VALUES (3, N'Тестин Тест Тестович')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([id], [employee_id], [count], [service_model_id], [entity_id], [date]) VALUES (2, 1, 2, 3, 3, CAST(N'2020-05-20T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[ServiceComponent] ON 

INSERT [dbo].[ServiceComponent] ([id], [component_id], [service_id]) VALUES (1, 3, 2)
SET IDENTITY_INSERT [dbo].[ServiceComponent] OFF
SET IDENTITY_INSERT [dbo].[ComponentStatus] ON 

INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (1, N'Хранение у пользователя')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (2, N'Хранение в отделе 533')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (3, N'Ожидает обслуживания')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (4, N'В работе')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (5, N'Обслуживается')
SET IDENTITY_INSERT [dbo].[ComponentStatus] OFF
SET IDENTITY_INSERT [dbo].[ComponentModel] ON 

INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (1, N'Модель1', N'Картридж красный', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (2, N'Модель2', N'Картридж синий', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (3, N'Модель3', N'Картридж зелёный', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (4, N'Модель4', N'Картридж чёрный', 200.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (5, N'Модель1', N'ОЗУ', 2000.0000, 2)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (9, N'Intel i3', N'Офисный процессор', 5000.0000, 4)
SET IDENTITY_INSERT [dbo].[ComponentModel] OFF
SET IDENTITY_INSERT [dbo].[Component] ON 

INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (1, 1, CAST(N'2020-05-17T00:00:00.000' AS DateTime), CAST(N'2020-06-17T00:00:00.000' AS DateTime), 4, 4, 7)
INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (2, 2, CAST(N'2020-05-10T00:00:00.000' AS DateTime), CAST(N'2020-06-10T00:00:00.000' AS DateTime), 3, 3, 7)
INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (3, 4, CAST(N'2020-05-16T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 5, 9, 3)
SET IDENTITY_INSERT [dbo].[Component] OFF
