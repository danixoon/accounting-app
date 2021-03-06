USE [AccountingApp]
GO
ALTER TABLE [dbo].[ServiceModel] DROP CONSTRAINT [FK_ServiceModel_ServiceType]
GO
ALTER TABLE [dbo].[ServiceModel] DROP CONSTRAINT [FK_ServiceModel_EntityType]
GO
ALTER TABLE [dbo].[ServiceModel] DROP CONSTRAINT [FK_ServiceModel_ComponentType]
GO
ALTER TABLE [dbo].[ServiceComponent] DROP CONSTRAINT [FK_ServiceComponent_Service]
GO
ALTER TABLE [dbo].[Service] DROP CONSTRAINT [FK_Service_ServiceModel]
GO
ALTER TABLE [dbo].[Service] DROP CONSTRAINT [FK_Service_Employee]
GO
ALTER TABLE [dbo].[EntityModel] DROP CONSTRAINT [FK_Entity_EntityType]
GO
ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_Entity_NetworkType]
GO
ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_Entity_NetworkSocket]
GO
ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_Entity_EntityModel]
GO
ALTER TABLE [dbo].[Entity] DROP CONSTRAINT [FK_Entity_Department]
GO
ALTER TABLE [dbo].[ComponentModel] DROP CONSTRAINT [FK_Component_ComponentType]
GO
ALTER TABLE [dbo].[Component] DROP CONSTRAINT [FK_Component_Entity]
GO
ALTER TABLE [dbo].[Component] DROP CONSTRAINT [FK_Component_ComponentStatus]
GO
ALTER TABLE [dbo].[Component] DROP CONSTRAINT [FK_Component_ComponentModel]
GO
ALTER TABLE [dbo].[Service] DROP CONSTRAINT [DF_ServiceHistory_count]
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ServiceType]
GO
/****** Object:  Table [dbo].[ServiceModel]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ServiceModel]
GO
/****** Object:  Table [dbo].[ServiceComponent]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ServiceComponent]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[Service]
GO
/****** Object:  Table [dbo].[NetworkType]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[NetworkType]
GO
/****** Object:  Table [dbo].[NetworkSocket]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[NetworkSocket]
GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[EntityType]
GO
/****** Object:  Table [dbo].[EntityModel]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[EntityModel]
GO
/****** Object:  Table [dbo].[Entity]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[Entity]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[ComponentType]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ComponentType]
GO
/****** Object:  Table [dbo].[ComponentStatus]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ComponentStatus]
GO
/****** Object:  Table [dbo].[ComponentModel]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[ComponentModel]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 17.05.2020 20:02:22 ******/
DROP TABLE [dbo].[Component]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key] [int] NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NULL,
	[component_status_id] [int] NOT NULL,
	[component_model_id] [int] NOT NULL,
	[entity_id] [int] NULL,
 CONSTRAINT [PK_ComponentHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentModel]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentModel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [varchar](30) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[price] [money] NOT NULL,
	[component_type_id] [int] NOT NULL,
 CONSTRAINT [PK_Cartridge] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentStatus]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_CartridgeStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentType]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ComponentType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entity]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[housing] [varchar](10) NOT NULL,
	[floor] [int] NOT NULL,
	[department_id] [int] NOT NULL,
	[network_type_id] [int] NOT NULL,
	[mac_address] [varchar](50) NOT NULL,
	[ip_address] [varchar](50) NOT NULL,
	[network_socket_id] [int] NULL,
	[entity_model_id] [int] NOT NULL,
 CONSTRAINT [PK_EntityHistory_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityModel]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityModel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[entity_type_id] [int] NOT NULL,
 CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NetworkSocket]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NetworkSocket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_NetworkSocket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NetworkType]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NetworkType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ConnectionType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NOT NULL,
	[count] [int] NOT NULL,
	[service_model_id] [int] NOT NULL,
	[entity_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_ServiceHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceComponent]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceComponent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[component_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
 CONSTRAINT [PK_ServiceComponent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceModel]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceModel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_type_id] [int] NOT NULL,
	[price] [money] NOT NULL,
	[entity_type_id] [int] NOT NULL,
	[component_type_id] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 17.05.2020 20:02:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Component] ON 

INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (1, 1, CAST(N'2020-05-17T00:00:00.000' AS DateTime), CAST(N'2020-06-17T00:00:00.000' AS DateTime), 4, 4, 7)
INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (2, 2, CAST(N'2020-05-10T00:00:00.000' AS DateTime), CAST(N'2020-06-10T00:00:00.000' AS DateTime), 3, 3, 7)
INSERT [dbo].[Component] ([id], [key], [start_date], [end_date], [component_status_id], [component_model_id], [entity_id]) VALUES (3, 4, CAST(N'2020-05-16T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 5, 9, 3)
SET IDENTITY_INSERT [dbo].[Component] OFF
SET IDENTITY_INSERT [dbo].[ComponentModel] ON 

INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (1, N'Модель1', N'Картридж красный', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (2, N'Модель2', N'Картридж синий', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (3, N'Модель3', N'Картридж зелёный', 500.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (4, N'Модель4', N'Картридж чёрный', 200.0000, 1)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (5, N'Модель1', N'ОЗУ', 2000.0000, 2)
INSERT [dbo].[ComponentModel] ([id], [model], [name], [price], [component_type_id]) VALUES (9, N'Intel i3', N'Офисный процессор', 5000.0000, 4)
SET IDENTITY_INSERT [dbo].[ComponentModel] OFF
SET IDENTITY_INSERT [dbo].[ComponentStatus] ON 

INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (1, N'Хранение у пользователя')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (2, N'Хранение в отделе 533')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (3, N'Ожидает обслуживания')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (4, N'В работе')
INSERT [dbo].[ComponentStatus] ([id], [name]) VALUES (5, N'Обслуживается')
SET IDENTITY_INSERT [dbo].[ComponentStatus] OFF
SET IDENTITY_INSERT [dbo].[ComponentType] ON 

INSERT [dbo].[ComponentType] ([id], [name]) VALUES (1, N' Картридж принтера')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (2, N'ОЗУ')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (3, N'Материнская плата')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (4, N'Процессор')
INSERT [dbo].[ComponentType] ([id], [name]) VALUES (5, N'Видеокарта')
SET IDENTITY_INSERT [dbo].[ComponentType] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([id], [name]) VALUES (1, N'Отдел1')
INSERT [dbo].[Department] ([id], [name]) VALUES (2, N'Отдел2')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id], [name]) VALUES (1, N'Иванов Иван Иванович')
INSERT [dbo].[Employee] ([id], [name]) VALUES (2, N'Андреев Андрей Андреевич')
INSERT [dbo].[Employee] ([id], [name]) VALUES (3, N'Тестин Тест Тестович')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Entity] ON 

INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (3, N'tester', N'3', 2, 1, 1, N'255.255.255.0', N'127.0.0.1', 2, 1)
INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (6, N'tester-2', N'4', 1, 2, 2, N'255.255.255.0', N'127.0.0.1', 2, 3)
INSERT [dbo].[Entity] ([id], [username], [housing], [floor], [department_id], [network_type_id], [mac_address], [ip_address], [network_socket_id], [entity_model_id]) VALUES (7, N'printer-1', N'3', 2, 1, 1, N'255.255.254.0', N'127.0.1.1', 3, 4)
SET IDENTITY_INSERT [dbo].[Entity] OFF
SET IDENTITY_INSERT [dbo].[EntityModel] ON 

INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (1, N'Офисный компьютер', N'Модель1', 1)
INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (3, N'Сервер', N'Модель2', 1)
INSERT [dbo].[EntityModel] ([id], [name], [model], [entity_type_id]) VALUES (4, N'Офисный принтер', N'Модель1', 2)
SET IDENTITY_INSERT [dbo].[EntityModel] OFF
SET IDENTITY_INSERT [dbo].[EntityType] ON 

INSERT [dbo].[EntityType] ([id], [name]) VALUES (1, N'Компьютер')
INSERT [dbo].[EntityType] ([id], [name]) VALUES (2, N'Принтер')
SET IDENTITY_INSERT [dbo].[EntityType] OFF
SET IDENTITY_INSERT [dbo].[NetworkSocket] ON 

INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (1, N'2A')
INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (2, N'3A')
INSERT [dbo].[NetworkSocket] ([id], [name]) VALUES (3, N'6Г')
SET IDENTITY_INSERT [dbo].[NetworkSocket] OFF
SET IDENTITY_INSERT [dbo].[NetworkType] ON 

INSERT [dbo].[NetworkType] ([id], [name]) VALUES (1, N'Локальная')
INSERT [dbo].[NetworkType] ([id], [name]) VALUES (2, N'Интернет')
SET IDENTITY_INSERT [dbo].[NetworkType] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([id], [employee_id], [count], [service_model_id], [entity_id], [date]) VALUES (2, 1, 2, 3, 3, CAST(N'2020-05-20T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[ServiceComponent] ON 

INSERT [dbo].[ServiceComponent] ([id], [component_id], [service_id]) VALUES (1, 3, 2)
SET IDENTITY_INSERT [dbo].[ServiceComponent] OFF
SET IDENTITY_INSERT [dbo].[ServiceModel] ON 

INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (1, 1, 1000.0000, 2, 1)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (2, 2, 1500.0000, 2, 1)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (3, 3, 4000.0000, 1, 4)
INSERT [dbo].[ServiceModel] ([id], [service_type_id], [price], [entity_type_id], [component_type_id]) VALUES (4, 3, 2000.0000, 1, 3)
SET IDENTITY_INSERT [dbo].[ServiceModel] OFF
SET IDENTITY_INSERT [dbo].[ServiceType] ON 

INSERT [dbo].[ServiceType] ([id], [name]) VALUES (1, N'Замена картриджей')
INSERT [dbo].[ServiceType] ([id], [name]) VALUES (2, N'Переналивка картриджа')
INSERT [dbo].[ServiceType] ([id], [name]) VALUES (3, N'Ремонт комплектующих')
SET IDENTITY_INSERT [dbo].[ServiceType] OFF
ALTER TABLE [dbo].[Service] ADD  CONSTRAINT [DF_ServiceHistory_count]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_ComponentModel] FOREIGN KEY([component_model_id])
REFERENCES [dbo].[ComponentModel] ([id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_ComponentModel]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_ComponentStatus] FOREIGN KEY([component_status_id])
REFERENCES [dbo].[ComponentStatus] ([id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_ComponentStatus]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_Entity] FOREIGN KEY([entity_id])
REFERENCES [dbo].[Entity] ([id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_Entity]
GO
ALTER TABLE [dbo].[ComponentModel]  WITH CHECK ADD  CONSTRAINT [FK_Component_ComponentType] FOREIGN KEY([component_type_id])
REFERENCES [dbo].[ComponentType] ([id])
GO
ALTER TABLE [dbo].[ComponentModel] CHECK CONSTRAINT [FK_Component_ComponentType]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_Department] FOREIGN KEY([department_id])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_Department]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_EntityModel] FOREIGN KEY([entity_model_id])
REFERENCES [dbo].[EntityModel] ([id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_EntityModel]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_NetworkSocket] FOREIGN KEY([network_socket_id])
REFERENCES [dbo].[NetworkSocket] ([id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_NetworkSocket]
GO
ALTER TABLE [dbo].[Entity]  WITH CHECK ADD  CONSTRAINT [FK_Entity_NetworkType] FOREIGN KEY([network_type_id])
REFERENCES [dbo].[NetworkType] ([id])
GO
ALTER TABLE [dbo].[Entity] CHECK CONSTRAINT [FK_Entity_NetworkType]
GO
ALTER TABLE [dbo].[EntityModel]  WITH CHECK ADD  CONSTRAINT [FK_Entity_EntityType] FOREIGN KEY([entity_type_id])
REFERENCES [dbo].[EntityType] ([id])
GO
ALTER TABLE [dbo].[EntityModel] CHECK CONSTRAINT [FK_Entity_EntityType]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Employee]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_ServiceModel] FOREIGN KEY([service_model_id])
REFERENCES [dbo].[ServiceModel] ([id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_ServiceModel]
GO
ALTER TABLE [dbo].[ServiceComponent]  WITH CHECK ADD  CONSTRAINT [FK_ServiceComponent_Service] FOREIGN KEY([service_id])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[ServiceComponent] CHECK CONSTRAINT [FK_ServiceComponent_Service]
GO
ALTER TABLE [dbo].[ServiceModel]  WITH CHECK ADD  CONSTRAINT [FK_ServiceModel_ComponentType] FOREIGN KEY([component_type_id])
REFERENCES [dbo].[ComponentType] ([id])
GO
ALTER TABLE [dbo].[ServiceModel] CHECK CONSTRAINT [FK_ServiceModel_ComponentType]
GO
ALTER TABLE [dbo].[ServiceModel]  WITH CHECK ADD  CONSTRAINT [FK_ServiceModel_EntityType] FOREIGN KEY([entity_type_id])
REFERENCES [dbo].[EntityType] ([id])
GO
ALTER TABLE [dbo].[ServiceModel] CHECK CONSTRAINT [FK_ServiceModel_EntityType]
GO
ALTER TABLE [dbo].[ServiceModel]  WITH CHECK ADD  CONSTRAINT [FK_ServiceModel_ServiceType] FOREIGN KEY([service_type_id])
REFERENCES [dbo].[ServiceType] ([id])
GO
ALTER TABLE [dbo].[ServiceModel] CHECK CONSTRAINT [FK_ServiceModel_ServiceType]
GO
