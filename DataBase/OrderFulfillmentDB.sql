USE [master]
GO
/****** Object:  Database [OrderFulfillmentDB]    Script Date: 7/15/2023 5:02:03 PM ******/
CREATE DATABASE [OrderFulfillmentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderFulfillmentDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OrderFulfillmentDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderFulfillmentDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OrderFulfillmentDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OrderFulfillmentDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderFulfillmentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderFulfillmentDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderFulfillmentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderFulfillmentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderFulfillmentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderFulfillmentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderFulfillmentDB] SET  MULTI_USER 
GO
ALTER DATABASE [OrderFulfillmentDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderFulfillmentDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderFulfillmentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderFulfillmentDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderFulfillmentDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderFulfillmentDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OrderFulfillmentDB] SET QUERY_STORE = OFF
GO
USE [OrderFulfillmentDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fir_name] [varchar](50) NULL,
	[mid_name] [varchar](50) NULL,
	[last_name] [varchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Del_Method]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Del_Method](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[status] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Del_Method] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fulfillment]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fulfillment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[payment_id] [int] NOT NULL,
	[remarks] [varchar](250) NULL,
	[ful_status] [int] NOT NULL,
	[status] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
	[dt_crtd] [date] NOT NULL,
	[dt_modf] [date] NULL,
 CONSTRAINT [PK_Fulfillment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NOT NULL,
	[image] [image] NOT NULL,
	[print_status] [int] NOT NULL,
	[trans_date] [date] NOT NULL,
	[status] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[qty] [int] NOT NULL,
	[total_amt] [decimal](18, 2) NOT NULL,
	[cust_id] [int] NULL,
	[remarks] [varchar](250) NULL,
	[del_met_id] [int] NULL,
	[status] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Del]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Del](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[add_line_1] [varchar](200) NULL,
	[add_line_2] [varchar](200) NULL,
	[cont_name] [varchar](150) NULL,
	[cont_mob] [varchar](50) NULL,
	[contact_email] [varchar](50) NULL,
	[post_code] [varchar](50) NULL,
	[del_status] [int] NOT NULL,
	[status] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Order_Del] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Dtl]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Dtl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[unit_price] [decimal](18, 2) NOT NULL,
	[qty] [int] NOT NULL,
	[line_total] [decimal](18, 2) NOT NULL,
	[status] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[user_id] [varchar](50) NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Order_Dtl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pay_Prov]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pay_Prov](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](80) NOT NULL,
	[status] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Pay_Prov] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_ref] [varchar](50) NOT NULL,
	[order_id] [int] NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[pay_date] [date] NOT NULL,
	[pay_status] [int] NOT NULL,
	[prov_id] [int] NOT NULL,
	[status] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
	[dt_crtd] [date] NOT NULL,
	[dt_modf] [date] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prod_Track]    Script Date: 7/15/2023 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prod_Track](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[order_loc] [varchar](250) NULL,
	[order_sta] [int] NOT NULL,
	[cmt] [varchar](150) NULL,
	[status] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Prod_Track] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Del_Method] ADD  CONSTRAINT [DF_Del_Method_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Del_Method] ADD  CONSTRAINT [DF_Del_Method_unique_id]  DEFAULT (newid()) FOR [unique_id]
GO
ALTER TABLE [dbo].[Fulfillment] ADD  CONSTRAINT [DF_Fulfillment_unique_id]  DEFAULT (newid()) FOR [unique_id]
GO
ALTER TABLE [dbo].[Fulfillment] ADD  CONSTRAINT [DF_Fulfillment_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_print_status]  DEFAULT ((0)) FOR [print_status]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Order_Del] ADD  CONSTRAINT [DF_Order_Del_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Order_Del] ADD  CONSTRAINT [DF_Order_Del_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Order_Del] ADD  CONSTRAINT [DF_Order_Del_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Order_Dtl] ADD  CONSTRAINT [DF_Order_Dtl_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Order_Dtl] ADD  CONSTRAINT [DF_Order_Dtl_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Order_Dtl] ADD  CONSTRAINT [DF_Order_Dtl_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_unique_id]  DEFAULT (newid()) FOR [unique_id]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Fulfillment]  WITH CHECK ADD  CONSTRAINT [FK_Fulfillment_Order] FOREIGN KEY([id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Fulfillment] CHECK CONSTRAINT [FK_Fulfillment_Order]
GO
ALTER TABLE [dbo].[Fulfillment]  WITH CHECK ADD  CONSTRAINT [FK_Fulfillment_Payment] FOREIGN KEY([id])
REFERENCES [dbo].[Payment] ([id])
GO
ALTER TABLE [dbo].[Fulfillment] CHECK CONSTRAINT [FK_Fulfillment_Payment]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Order] FOREIGN KEY([orderid])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([cust_id])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Del_Method] FOREIGN KEY([del_met_id])
REFERENCES [dbo].[Del_Method] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Del_Method]
GO
ALTER TABLE [dbo].[Order_Del]  WITH CHECK ADD  CONSTRAINT [FK_Order_Del_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Order_Del] CHECK CONSTRAINT [FK_Order_Del_Order]
GO
ALTER TABLE [dbo].[Order_Dtl]  WITH CHECK ADD  CONSTRAINT [FK_Order_Dtl_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Order_Dtl] CHECK CONSTRAINT [FK_Order_Dtl_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Pay_Prov] FOREIGN KEY([prov_id])
REFERENCES [dbo].[Pay_Prov] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Pay_Prov]
GO
ALTER TABLE [dbo].[Prod_Track]  WITH CHECK ADD  CONSTRAINT [FK_Prod_Track_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Prod_Track] CHECK CONSTRAINT [FK_Prod_Track_Order]
GO
USE [master]
GO
ALTER DATABASE [OrderFulfillmentDB] SET  READ_WRITE 
GO
