USE [master]
GO
/****** Object:  Database [InventoryDB]    Script Date: 7/15/2023 4:12:42 PM ******/
CREATE DATABASE [InventoryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventory.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventory_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InventoryDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventoryDB] SET QUERY_STORE = OFF
GO
USE [InventoryDB]
GO
/****** Object:  Table [dbo].[Alerts]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alerts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[event] [varchar](150) NOT NULL,
	[msg_body] [varchar](max) NOT NULL,
	[rec_email] [varchar](50) NULL,
	[rec_sms] [varchar](50) NOT NULL,
	[del_status] [varchar](50) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code_Tab]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code_Tab](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tab_id] [varchar](50) NOT NULL,
	[tab_name] [varchar](100) NOT NULL,
	[col_id] [int] NOT NULL,
	[col_name] [varchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[dt_created] [datetime] NOT NULL,
 CONSTRAINT [PK_CodeTab] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_Stock]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prod_id] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[targ_inv_level] [int] NOT NULL,
	[SKU] [varchar](50) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Inv_Stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inv_Trans]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inv_Trans](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[inv_stock_id] [int] NOT NULL,
	[lot_id] [int] NOT NULL,
	[dir] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[note] [varchar](500) NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_InventoryTransaction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lot]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lot](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](50) NULL,
	[prod_id] [int] NOT NULL,
	[vend_id] [int] NOT NULL,
	[manf_date] [datetime] NOT NULL,
	[exp_date] [datetime] NOT NULL,
	[qty] [int] NOT NULL,
	[batch_no] [varchar](50) NOT NULL,
	[pur_ord_id] [int] NOT NULL,
	[lotno] [varchar](50) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Lot] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manf]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manf](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meas]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_UnitofMeasure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prod_Cat]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prod_Cat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[prod_form] [varchar](50) NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_ProductCat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prod_Type]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prod_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[prod_cat_id] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[prod_type_id] [int] NOT NULL,
	[manf_id] [int] NOT NULL,
	[uomid] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pur_Ord_Dtl]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pur_Ord_Dtl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pur_ord_id] [int] NOT NULL,
	[prod_id] [int] NOT NULL,
	[qty] [bigint] NOT NULL,
	[unit_cost] [float] NOT NULL,
	[line_total] [float] NOT NULL,
	[note] [varchar](500) NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Pur_Ord_Dtl] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pur_Order]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pur_Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vend_id] [int] NOT NULL,
	[purchase_date] [datetime] NOT NULL,
	[pur_ord_no] [varchar](50) NOT NULL,
	[total_item_no] [bigint] NOT NULL,
	[total_item_cost] [float] NOT NULL,
	[note] [varchar](500) NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vend_Con]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vend_Con](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vend_id] [int] NOT NULL,
	[org_name] [varchar](150) NOT NULL,
	[rcno] [varchar](50) NULL,
	[contact_fst_name] [varchar](50) NULL,
	[contact_lst_name] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_VendorContact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vend_Prod]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vend_Prod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vendorid] [int] NOT NULL,
	[productid] [int] NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_VendorProduct] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 7/15/2023 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descr] [varchar](150) NOT NULL,
	[uniqueid] [uniqueidentifier] NOT NULL,
	[status] [int] NOT NULL,
	[dt_crtd] [datetime] NOT NULL,
	[dt_modf] [datetime] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alerts] ADD  CONSTRAINT [DF_Notifications_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Alerts] ADD  CONSTRAINT [DF_Notifications_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Alerts] ADD  CONSTRAINT [DF_Notifications_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Code_Tab] ADD  CONSTRAINT [DF_Code_Tab_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Code_Tab] ADD  CONSTRAINT [DF_Code_Tab_dt_created]  DEFAULT (getdate()) FOR [dt_created]
GO
ALTER TABLE [dbo].[Inv_Stock] ADD  CONSTRAINT [DF_Inv_Stock_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Inv_Stock] ADD  CONSTRAINT [DF_Inv_Stock_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Inv_Stock] ADD  CONSTRAINT [DF_Inv_Stock_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Inv_Trans] ADD  CONSTRAINT [DF_InventoryTransaction_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Inv_Trans] ADD  CONSTRAINT [DF_InventoryTransaction_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Inv_Trans] ADD  CONSTRAINT [DF_InventoryTransaction_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Lot] ADD  CONSTRAINT [DF_Lot_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Lot] ADD  CONSTRAINT [DF_Lot_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Lot] ADD  CONSTRAINT [DF_Lot_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Manf] ADD  CONSTRAINT [DF_Manufacturer_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Manf] ADD  CONSTRAINT [DF_Manufacturer_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Manf] ADD  CONSTRAINT [DF_Manufacturer_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Meas] ADD  CONSTRAINT [DF_UnitofMeasure_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Meas] ADD  CONSTRAINT [DF_UnitofMeasure_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Meas] ADD  CONSTRAINT [DF_UnitofMeasure_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Prod_Cat] ADD  CONSTRAINT [DF_ProductCat_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Prod_Cat] ADD  CONSTRAINT [DF_ProductCat_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Prod_Cat] ADD  CONSTRAINT [DF_ProductCat_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Prod_Type] ADD  CONSTRAINT [DF_ProductType_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Prod_Type] ADD  CONSTRAINT [DF_ProductType_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Prod_Type] ADD  CONSTRAINT [DF_ProductType_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl] ADD  CONSTRAINT [DF_Pur_Ord_Dtl_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl] ADD  CONSTRAINT [DF_Pur_Ord_Dtl_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl] ADD  CONSTRAINT [DF_Pur_Ord_Dtl_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Pur_Order] ADD  CONSTRAINT [DF_PurchaseOrder_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Pur_Order] ADD  CONSTRAINT [DF_PurchaseOrder_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Pur_Order] ADD  CONSTRAINT [DF_PurchaseOrder_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Vend_Con] ADD  CONSTRAINT [DF_VendorContact_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Vend_Con] ADD  CONSTRAINT [DF_VendorContact_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Vend_Con] ADD  CONSTRAINT [DF_VendorContact_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Vend_Prod] ADD  CONSTRAINT [DF_VendorProduct_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Vend_Prod] ADD  CONSTRAINT [DF_VendorProduct_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Vend_Prod] ADD  CONSTRAINT [DF_VendorProduct_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF_Vendor_uniqueid]  DEFAULT (newid()) FOR [uniqueid]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF_Vendor_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF_Vendor_dt_crtd]  DEFAULT (getdate()) FOR [dt_crtd]
GO
ALTER TABLE [dbo].[Inv_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Inv_Stock_Product] FOREIGN KEY([prod_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Inv_Stock] CHECK CONSTRAINT [FK_Inv_Stock_Product]
GO
ALTER TABLE [dbo].[Inv_Trans]  WITH CHECK ADD  CONSTRAINT [FK_InventoryTransaction_Inv_Stock] FOREIGN KEY([inv_stock_id])
REFERENCES [dbo].[Inv_Stock] ([id])
GO
ALTER TABLE [dbo].[Inv_Trans] CHECK CONSTRAINT [FK_InventoryTransaction_Inv_Stock]
GO
ALTER TABLE [dbo].[Inv_Trans]  WITH CHECK ADD  CONSTRAINT [FK_InventoryTransaction_Lot] FOREIGN KEY([lot_id])
REFERENCES [dbo].[Lot] ([id])
GO
ALTER TABLE [dbo].[Inv_Trans] CHECK CONSTRAINT [FK_InventoryTransaction_Lot]
GO
ALTER TABLE [dbo].[Lot]  WITH CHECK ADD  CONSTRAINT [FK_Lot_Product] FOREIGN KEY([prod_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Lot] CHECK CONSTRAINT [FK_Lot_Product]
GO
ALTER TABLE [dbo].[Lot]  WITH CHECK ADD  CONSTRAINT [FK_Lot_PurchaseOrder] FOREIGN KEY([pur_ord_id])
REFERENCES [dbo].[Pur_Order] ([id])
GO
ALTER TABLE [dbo].[Lot] CHECK CONSTRAINT [FK_Lot_PurchaseOrder]
GO
ALTER TABLE [dbo].[Lot]  WITH CHECK ADD  CONSTRAINT [FK_Lot_Vendor] FOREIGN KEY([vend_id])
REFERENCES [dbo].[Vendor] ([id])
GO
ALTER TABLE [dbo].[Lot] CHECK CONSTRAINT [FK_Lot_Vendor]
GO
ALTER TABLE [dbo].[Prod_Type]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_ProductCat] FOREIGN KEY([prod_cat_id])
REFERENCES [dbo].[Prod_Cat] ([id])
GO
ALTER TABLE [dbo].[Prod_Type] CHECK CONSTRAINT [FK_ProductType_ProductCat]
GO
ALTER TABLE [dbo].[Prod_Type]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_ProductType] FOREIGN KEY([id])
REFERENCES [dbo].[Prod_Type] ([id])
GO
ALTER TABLE [dbo].[Prod_Type] CHECK CONSTRAINT [FK_ProductType_ProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([manf_id])
REFERENCES [dbo].[Manf] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([prod_type_id])
REFERENCES [dbo].[Prod_Type] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_UnitofMeasure] FOREIGN KEY([uomid])
REFERENCES [dbo].[Meas] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_UnitofMeasure]
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl]  WITH CHECK ADD  CONSTRAINT [FK_Pur_Ord_Dtl_Product] FOREIGN KEY([prod_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl] CHECK CONSTRAINT [FK_Pur_Ord_Dtl_Product]
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl]  WITH CHECK ADD  CONSTRAINT [FK_Pur_Ord_Dtl_PurchaseOrder] FOREIGN KEY([pur_ord_id])
REFERENCES [dbo].[Pur_Order] ([id])
GO
ALTER TABLE [dbo].[Pur_Ord_Dtl] CHECK CONSTRAINT [FK_Pur_Ord_Dtl_PurchaseOrder]
GO
ALTER TABLE [dbo].[Vend_Con]  WITH CHECK ADD  CONSTRAINT [FK_VendorContact_Vendor] FOREIGN KEY([vend_id])
REFERENCES [dbo].[Vendor] ([id])
GO
ALTER TABLE [dbo].[Vend_Con] CHECK CONSTRAINT [FK_VendorContact_Vendor]
GO
ALTER TABLE [dbo].[Vend_Prod]  WITH CHECK ADD  CONSTRAINT [FK_VendorProduct_Product] FOREIGN KEY([productid])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Vend_Prod] CHECK CONSTRAINT [FK_VendorProduct_Product]
GO
ALTER TABLE [dbo].[Vend_Prod]  WITH CHECK ADD  CONSTRAINT [FK_VendorProduct_Vendor] FOREIGN KEY([vendorid])
REFERENCES [dbo].[Vendor] ([id])
GO
ALTER TABLE [dbo].[Vend_Prod] CHECK CONSTRAINT [FK_VendorProduct_Vendor]
GO
USE [master]
GO
ALTER DATABASE [InventoryDB] SET  READ_WRITE 
GO
