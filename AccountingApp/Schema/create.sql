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
/****** Object:  Table [dbo].[ServiceType]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ServiceType]
GO
/****** Object:  Table [dbo].[ServiceModel]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ServiceModel]
GO
/****** Object:  Table [dbo].[ServiceComponent]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ServiceComponent]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[Service]
GO
/****** Object:  Table [dbo].[NetworkType]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[NetworkType]
GO
/****** Object:  Table [dbo].[NetworkSocket]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[NetworkSocket]
GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[EntityType]
GO
/****** Object:  Table [dbo].[EntityModel]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[EntityModel]
GO
/****** Object:  Table [dbo].[Entity]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[Entity]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[ComponentType]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ComponentType]
GO
/****** Object:  Table [dbo].[ComponentStatus]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ComponentStatus]
GO
/****** Object:  Table [dbo].[ComponentModel]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[ComponentModel]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 17.05.2020 19:26:27 ******/
DROP TABLE [dbo].[Component]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 17.05.2020 19:26:27 ******/
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
/****** Object:  Table [dbo].[ComponentModel]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[ComponentStatus]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[ComponentType]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[Entity]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[EntityModel]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[EntityType]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[NetworkSocket]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[NetworkType]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[Service]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[ServiceComponent]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[ServiceModel]    Script Date: 17.05.2020 19:26:28 ******/
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
/****** Object:  Table [dbo].[ServiceType]    Script Date: 17.05.2020 19:26:28 ******/
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
