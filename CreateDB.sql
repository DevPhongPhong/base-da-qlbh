USE [master]
GO
/****** Object:  Database [qlbh_da]    Script Date: 03/01/2022 10:57:07 AM ******/
CREATE DATABASE [qlbh_da]
GO
ALTER DATABASE [qlbh_da] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qlbh_da].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qlbh_da] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qlbh_da] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qlbh_da] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qlbh_da] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qlbh_da] SET ARITHABORT OFF 
GO
ALTER DATABASE [qlbh_da] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [qlbh_da] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qlbh_da] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qlbh_da] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qlbh_da] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qlbh_da] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qlbh_da] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qlbh_da] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qlbh_da] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qlbh_da] SET  ENABLE_BROKER 
GO
ALTER DATABASE [qlbh_da] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qlbh_da] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qlbh_da] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qlbh_da] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qlbh_da] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qlbh_da] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qlbh_da] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qlbh_da] SET RECOVERY FULL 
GO
ALTER DATABASE [qlbh_da] SET  MULTI_USER 
GO
ALTER DATABASE [qlbh_da] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qlbh_da] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qlbh_da] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qlbh_da] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [qlbh_da] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'qlbh_da', N'ON'
GO
ALTER DATABASE [qlbh_da] SET QUERY_STORE = OFF
GO
USE [qlbh_da]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](150) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryNews]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[CategoryDecription] [nvarchar](max) NULL,
	[CategoryOrder] [int] NULL,
	[MetaTitle] [nvarchar](100) NULL,
	[MetaDescription] [nvarchar](100) NULL,
	[MetaKeywords] [nvarchar](100) NULL,
	[Tags] [nvarchar](150) NULL,
	[IsHot] [bit] NULL,
	[IsHome] [bit] NULL,
	[IsView] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_CategoryNews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[MetaUrl] [nvarchar](500) NULL,
	[ThumbImage] [nvarchar](150) NULL,
	[LargeImage] [nvarchar](150) NULL,
	[Title] [nvarchar](150) NULL,
	[SubTitle] [nvarchar](500) NULL,
	[NewsContent] [nvarchar](max) NULL,
	[Author] [nvarchar](50) NULL,
	[PostedDate] [datetime] NULL,
	[IsHot] [bit] NULL,
	[IsHome] [bit] NULL,
	[IsView] [bit] NULL,
	[NewsOrder] [int] NULL,
	[Tags] [nvarchar](150) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [nvarchar](50) NULL,
	[TotalPrice] [decimal](12, 0) NULL,
	[OrderStatusId] [int] NULL,
	[CustomerAddress] [nvarchar](250) NULL,
	[CustomerPhone] [nvarchar](15) NULL,
	[CustomerFullName] [nvarchar](50) NULL,
	[CustomerEmail] [nvarchar](50) NULL,
	[CustomerNote] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[ProductPrice] [decimal](12, 0) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[ProductImagesId] [int] NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](12, 0) NULL,
	[PromotionPrice] [decimal](12, 0) NULL,
	[MainImageThumb] [nvarchar](150) NULL,
	[MainImageLarge] [nvarchar](150) NULL,
	[IsHot] [bit] NULL,
	[IsHome] [bit] NULL,
	[IsPromote] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[CategoryDecription] [nvarchar](max) NULL,
	[CategoryOrder] [int] NULL,
	[IsHot] [bit] NULL,
	[IsHome] [bit] NULL,
	[IsView] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[ProductItemId] [int] NULL,
	[LargeImage] [nvarchar](500) NULL,
	[ThumbImage] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/01/2022 10:57:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](150) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](30) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [CreateBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (N'85ac1e33-1523-4b95-05a3-08d9ebe35824', N'user', N'user', N'Nguyễn Nam Hải', 2, NULL, N'Trieu Khuc, Thanh Xuan, Ha Noi', N'0345060211', N'namhaicloud@gmail.com', N'user', CAST(N'2022-02-09T22:46:31.267' AS DateTime), NULL, NULL, 1)
GO
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [CreateBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (N'af984f15-ec51-4bc2-0511-08d9f2f2c12e', N'phong', N'phong', NULL, 3, NULL, NULL, N'0397966566', N'phongphong24052k2@gmail.com', N'phong', CAST(N'2022-02-18T22:24:22.140' AS DateTime), NULL, NULL, 1)
GO
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [CreateBy], [CreateDate], [ModifiedBy], [ModifiedDate], [IsActive]) VALUES (N'ef552778-74d9-4934-bfec-f03ebdb58b44', N'admin', N'admin', N'Nguyễn Nam Hải', 1, CAST(N'1999-05-13T00:00:00.000' AS DateTime), N'Hưng Yên', N'0346060827', N'hainn.ict@gmail.com', N'admin', CAST(N'2021-01-01T00:00:00.000' AS DateTime), NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[CategoryNews] ON 
GO
INSERT [dbo].[CategoryNews] ([Id], [CategoryName], [CategoryDecription], [CategoryOrder], [MetaTitle], [MetaDescription], [MetaKeywords], [Tags], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Kinh nghiệm - Thủ thuật', N'Kinh nghiệm - Thủ thuật', 3, NULL, NULL, NULL, NULL, 1, 1, 0, N'admin', CAST(N'2021-02-17T00:06:18.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:50:26.260' AS DateTime))
GO
INSERT [dbo].[CategoryNews] ([Id], [CategoryName], [CategoryDecription], [CategoryOrder], [MetaTitle], [MetaDescription], [MetaKeywords], [Tags], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Tin tức công nghệ', N'Tin tức công nghệ', 2, NULL, NULL, NULL, NULL, 1, 1, 0, N'admin', CAST(N'2021-03-02T00:38:05.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:50:12.140' AS DateTime))
GO
INSERT [dbo].[CategoryNews] ([Id], [CategoryName], [CategoryDecription], [CategoryOrder], [MetaTitle], [MetaDescription], [MetaKeywords], [Tags], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Tin sản phẩm', N'Tin sản phẩm', 1, NULL, NULL, NULL, NULL, 1, 1, 0, N'admin', CAST(N'2021-03-02T00:40:18.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:49:57.237' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[CategoryNews] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 
GO
INSERT [dbo].[News] ([Id], [CategoryId], [MetaUrl], [ThumbImage], [LargeImage], [Title], [SubTitle], [NewsContent], [Author], [PostedDate], [IsHot], [IsHome], [IsView], [NewsOrder], [Tags], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, 3, NULL, N'/Upload/Images/4b142635-3b92-46c4-acd4-0c510f98a438.jpg', N'/Upload/Images/4b142635-3b92-46c4-acd4-0c510f98a438.jpg', N'Màn hình máy tính bị ngược, nguyên nhân và cách khắc phục thành công 100%', N'Sau một ngày bình thường, các bạn khởi động máy tính của mình lên và bỗng thấy màn hình máy tính bị ngược hay màn hình máy tính bị xoay ngang, xoay dọc… cực kì khó chịu mà các bạn lại không biết xử lí thế nào? Vậy thì còn chờ đợi gì nữa, cùng mình tìm hiểu nguyên nhân và cách giải quyết lỗi khó chịu này qua bài viết dưới đây ngay thôi nào!', N'<h2><strong>Màn hình máy tính bị ngược, nguyên nhân và cách khắc phục thành công 100%</strong></h2>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-1.jpg" style="height:394px; width:700px" /></p>

<p>Sau một ngày bình thường, các bạn khởi động máy tính của mình lên và bỗng thấy màn hình máy tính bị ngược&nbsp;hay màn hình máy tính bị xoay ngang, xoay dọc… cực kì khó chịu mà các bạn lại không biết xử lí thế nào? Vậy thì còn chờ đợi gì nữa, cùng mình tìm hiểu nguyên nhân và cách&nbsp;giải quyết&nbsp;lỗi khó chịu này qua bài viết dưới đây ngay thôi nào!</p>

<h3><strong>A. Nguyên nhân màn hình máy tính bị ngược</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-22.jpg" style="height:393px; width:700px" /></p>

<p>Màn hình máy tính bị ngược, xoay ngang hay xoay dọc… là một lỗi rất hay thường gặp và không thực sự rắc rối để khiến các bạn phải lo lắng. Lỗi này thường xảy ra khi các bạn nhấn nhầm tổ hợp phím xoay màn hình hoặc chẳng may lỡ nhấn nhầm vào tính năng xoay màn hình trên hệ điều hành. Các bạn hãy yên tâm bởi đây là lỗi mà các bạn có thể tự khắc phục một cách cực kì dễ dàng và nhanh chóng.</p>

<p>&nbsp;</p>

<h3><strong>B. Cách&nbsp;xoay màn hình máy tính bị ngược</strong></h3>

<p><strong>1. Cách xoay màn hình máy tính bị ngược bằng Rotation</strong><br />
Bước 1: Click chuột phải vào màn hình Desktop rồi chọn Display settings</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-32.jpg" style="height:420px; width:700px" /></p>

<p>Bước 2: Trong cửa sổ Display settings vừa hiện lên, chọn mục Display orientation rồi chọn kiểu xoay màn hình mà các bạn muốn.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-42.jpg" style="height:441px; width:700px" /></p>

<p><strong>Chú thích:</strong><br />
- Landscape: Xoay màn hình máy tính theo chiều ngang mặc định<br />
- Landscape (flipped): Xoay ngược màn hình máy tính theo chiều ngang<br />
- Portrait: Xoay màn hình máy tính 90 độ sang trái<br />
- Portrait (flipped): Xoay màn hình máy tính 90 độ sang phải</p>

<p>&nbsp;</p>

<p><strong>2.&nbsp;Cách&nbsp;xoay màn hình máy tính bị ngược với tổ hợp phím</strong><br />
Ngoài cách&nbsp;xoay màn hình máy tính bị ngược bằng tính năng Rotation trong Display settings, các bạn có thể sử dụng tổ hợp phím để xoay màn hình máy tính bị ngược về vị trí bình thường.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-52.jpg" style="height:294px; width:700px" /></p>

<p><strong>Các tổ hợp phím bao gồm:</strong><br />
- Ctrl + Alt + Mũi tên lên: Xoay màn hình máy tính theo chiều ngang mặc định<br />
- Ctrl + Alt + Mũi tên xuống: Xoay ngược màn hình máy tính theo chiều ngang<br />
- Ctrl + Alt + Mũi tên trái: Xoay màn hình máy tính 90 độ sang trái<br />
- Ctrl + Alt + Mũi tên phải: Xoay màn hình máy tính 90 độ sang phải</p>

<p>&nbsp;</p>

<h3><strong>C. Xoay màn hình máy tính để làm gì?</strong></h3>

<p>&nbsp;</p>

<p>Vì lý do gì mà Windows lại được trang bị khả năng xoay màn hình máy tính? Nếu nó không có tác dụng gì ngoài việc gây khó chịu cho người sử dụng và khiến màn hình máy tính bị xoay ngang thì đáng lẽ ra đây phải là một lỗi cần được loại bỏ đúng không các bạn. Vậy, tính năng xoay màn hình này được Windows trang bị với mục đích gì, cùng chúng mình tìm hiểu ngay nhé!</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-62.jpg" style="height:380px; width:700px" /></p>

<p>Khi các bạn sử dụng máy tính cho các nhu cầu như đọc báo, lướt web, soạn thảo văn bản hay coding…, nếu màn hình máy tính của các bạn hiển thị theo chiều ngang thì sẽ có những khoảng trống rất tốn diện tích hiển thị trên màn hình dẫn đến không tối ưu cho nhu cầu sử dụng của các bạn.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-72.jpg" style="height:467px; width:700px" /></p>

<p>Chính bởi vậy, Windows đã mang tới tính năng xoay màn hình để giúp các bạn tối ưu tốt nhất diện tích hiển thị trên màn hình từ đó tăng cường hiệu quả công việc. Đặc biệt nếu các bạn sử dụng hai màn hình, việc setup một màn hình dọc để lướt web, coding hay để đọc bình luận… sẽ chắc chắn cần tính năng xoay màn hình này.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1001_Manhinhmaytinhbinguoc-8.jpg" style="height:394px; width:700px" /></p>

<p>Chế độ xoay màn hình dọc đang cực kì được ưa chuộng vì nó tối ưu cực tốt cho việc đọc, soạn thảo văn bản hay rất nhiều nhu cầu sử dụng thêm khác chính bởi vậy, việc biết cách xoay màn hình máy tính hợp lí sẽ giúp các bạn chủ động hơn rất nhiều để tăng cường hiệu quả công việc. Và cuối cùng, các bạn đừng quên trang bị cho mình một chiếc màn hình với chân để hỗ trợ khả năng xoay hoặc một chiếc giá treo màn hình để giúp các bạn tiết kiệm thời gian làm việc cũng như đạt hiệu quả cao nhất nhé!</p>

<p>Qua bài viết "<strong>Màn hình máy tính bị ngược, nguyên nhân và cách khắc phục thành công 100%</strong>" trên, mình hi vọng các bạn sẽ biết cách khắc phục tình trạng này để có thể bình tĩnh tự giải quyết hiện tượng này nếu gặp phải (chẳng hạn như màn hình máy tính bị xoay ngang). Mình cũng hi vọng các bạn sẽ hiểu nhiều hơn về tính năng xoay màn hình máy tính trên Windows này, từ đó các bạn có thể tự thiết lập góc máy&nbsp;một cách tối ưu hơn, giúp đem lại hiệu quả&nbsp;vượt trội khi các bạn sử dụng&nbsp;<a href="https://www.anphatpc.com.vn/may-tinh-may-chu.html" target="_blank">máy tính</a>!</p>
', N'TN Computer', CAST(N'2021-04-22T17:20:42.000' AS DateTime), 1, 1, 0, 1, NULL, N'admin', CAST(N'2021-04-22T17:20:42.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:56:29.023' AS DateTime))
GO
INSERT [dbo].[News] ([Id], [CategoryId], [MetaUrl], [ThumbImage], [LargeImage], [Title], [SubTitle], [NewsContent], [Author], [PostedDate], [IsHot], [IsHome], [IsView], [NewsOrder], [Tags], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, 6, NULL, N'/Upload/Images/f1111a04-a958-4408-82db-6738815cc112-thumb.jpg', N'/Upload/Images/f1111a04-a958-4408-82db-6738815cc112.jpg', N'Không thể tin nổi, card 8 năm tuổi GTX 750 Ti vẫn chơi được Dying Light 2', N'Với cộng đồng game thủ, card đồ họa GTX 750 Ti thật sự là huyền thoại sống. Mặc dù đã ra mắt cách đây 8 năm, tuy nhiên lão tướng này vẫn có thể cân tốt một số game đời mới hiện tại. Như Dying Light 2 là một ví dụ.', N'<p><strong>GTX 750 Ti xứng đáng là một huyền thoại.</strong></p>

<p>Với cộng đồng game thủ, card đồ họa GTX 750 Ti thật sự là huyền thoại sống. Mặc dù đã ra mắt cách đây 8 năm, tuy nhiên lão tướng này vẫn có thể cân tốt một số game đời mới hiện tại. Như Dying Light 2 là một ví dụ.</p>

<p>&nbsp;</p>

<p>Được xây dựng trên công nghệ đồ họa mới, Dying Light 2 là một tựa game thế giới mở cực đẹp. Nếu bạn sở hữu một PC mạnh, có thể chiêm ngưỡng hết sự lung linh và chân thực của trò chơi này. Tuy nhiên nếu bạn không đủ điều kiện đó thì GTX 750 Ti vẫn có thể giúp bạn trải nghiệm game một cách bình thường.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/1002_photo-1-16443170058711641394452.jpg" style="height:450px; width:800px" /></p>

<p>Như thực nghiệm mà bạn theo dõi trong clip, GTX 750 Ti có thể chạy Dying Light 2 ở thiết lập đồ họa 1080p. Tuy nhiên mức FPS dao động quanh 30 thực sự không phải là một điều kiện tốt. Khi hạ thiết lập xuống 900p và 720p thì FPS sẽ ổn định hơn. Nhất là ở 720p, game có thể chạy tốt ở 50 FPS. Đây là điều kiện đủ để người bình thường có thể trải nghiệm.</p>
', N'TN Computer', CAST(N'2021-07-15T00:14:57.000' AS DateTime), 1, 1, 0, 1, NULL, N'admin', CAST(N'2021-07-15T00:14:57.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:55:16.843' AS DateTime))
GO
INSERT [dbo].[News] ([Id], [CategoryId], [MetaUrl], [ThumbImage], [LargeImage], [Title], [SubTitle], [NewsContent], [Author], [PostedDate], [IsHot], [IsHome], [IsView], [NewsOrder], [Tags], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 7, NULL, N'/Upload/Images/fe588e78-fa15-446f-9346-741a81d6f83a-thumb.jpg', N'/Upload/Images/fe588e78-fa15-446f-9346-741a81d6f83a.jpg', N'MSI Pulse GL66 gaming laptop (i7-11800H - RTX 3050Ti) - Rồng Đỏ nay đầu tư quá!', N'MSI Pulse GL66, một trong những đời gaming laptop có cấu hình và ngoại hình rất đáng chú ý của năm 2021. MSI Pulse GL66 11UDK 255VN được đẩy mạnh về hiệu năng so với giá thành nhằm cạnh tranh thị trường laptop vốn đang trong thời điểm rất sôi động', N'<p>&nbsp;</p>

<p>&nbsp;</p>

<p>TÓM TẮT NỘI DUNG&nbsp;[Ẩn]</p>

<h2>I. Sơ lược về gaming laptop MSI Pulse GL66 11UDK 255VN</h2>

<p>MSI Pulse GL66, một trong những đời gaming laptop có cấu hình và ngoại hình rất đáng chú ý của năm 2021. MSI Pulse GL66 11UDK 255VN được đẩy mạnh về hiệu năng so với giá thành nhằm cạnh tranh thị trường laptop vốn đang trong thời điểm rất sôi động. Khi những gaming desktop vẫn còn đang quá ảo giá, cùng với thời điểm giãn cách xã hội thì gaming laptop kiêm phục vụ đa nhiệm lại có quá nhiều lựa chọn trong khoảng giá tầm trung, và MSI đã có câu trả lời “cứng rắn”.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-13.jpg" style="height:665px; width:1000px" /></p>

<p>&nbsp;</p>

<h2>II. Thông số cơ bản và sức mạnh cấu hình thực tế</h2>

<h3>Thông số cơ bản</h3>

<p>Thuộc dòng GL là dòng cơ bản nhất trong nhóm Performance (cùng nhóm này phân cấp cao hơn là dòng GP và GE), nhưng với 2 chuyên gia “gánh team” là CPU Intel core i7-11800H và GPU NVIDIA Geforce RTX 3050Ti, cùng với 16GB RAM chạy kênh đôi thì khó có thể nghi ngờ sức mạnh gaming của Pulse GL66. Trước hết, chúng ta hãy nhìn tổng quan lại một lần nữa thông số kỹ thuật để có thông tin tiếp tục vào bài đánh giá chi tiết.</p>

<p><strong>Tên sản phẩm: MSI Pulse GL66 11UDK 255VN</strong><br />
<strong>CPU:</strong>&nbsp;Intel Core i7-11800H<br />
<strong>RAM:</strong>&nbsp;2x 8GB DDR4 3200Mhz<br />
<strong>SSD:</strong>&nbsp;512GB NVMe PCIe Gen3x4<br />
<strong>GPU:</strong>&nbsp;NVIDIA Geforce RTX 3050Ti 4GB GDDR6<br />
<strong>Màn hình:</strong><br />
- 15.6” Full HD (1920x1080)<br />
- Tần số quét 144Hz<br />
- Độ bao phủ màu 72% NTSC, ~97% sRGB</p>

<p><strong>Các cổng kết nối thiết bị ngoại vi:</strong><br />
- 1x USB Type-C 3.2 Gen1<br />
- 2x USB Type-A 3.2 Gen1<br />
- 1x USB Type-A 2.0<br />
- 1x HDMI 2.0 (4K @ 60hz)<br />
- 1x 3.5mm (audio &amp; microphone)<br />
- 1x RJ-45 LAN</p>

<h3>Sức mạnh thực tế</h3>

<p><em><strong>&gt;&gt;&gt;&nbsp;</strong>&nbsp;<strong><a href="https://www.anphatpc.com.vn/danh-gia-thuc-te-suc-manh-cau-hinh-msi-pulse-gl66-11udk-255vn-gaming-laptop.html" target="_blank">Thử nghiệm &amp; đánh giá chi tiết sức manh cấu hình MSI Pulse GL66 11UDK 255VN gaming laptop</a></strong></em></p>

<p>&nbsp;</p>

<h2>III. Tổng quan thiết kế vài trải nghiệm sử dụng</h2>

<h3>Mặt A được nâng cấp chất liệu kim loại</h3>

<p>Ngoài việc kim loại cho bộ khung vững chắc còn cho hiệu ứng ánh kim làm cho màu bạc được thể hiện đúng chất hơn. Cho dù người viết không phải là fan nhà rồng đỏ nhưng cũng phải khách quan mà nói rằng MSI Pulse GL66 của 2021 rất có chất riêng nhờ sự đầu tư mới mẻ.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-04.jpg" style="height:665px; width:1000px" /></p>

<p>Cũng chính nhờ không gian kim loại màu bạc này mà các đường cắt hoạ tiết gợi rất nhiều đến tính chất công nghệ viễn tưởng. Đơn giản nhưng không đơn điệu, nhìn vào chúng ta có thể liên tưởng ngay tới thế giới game đầy màu sắc công nghệ mà chúng ta vẫn thường chiến đấu hàng ngày.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-02.jpg" style="height:665px; width:1000px" /></p>

<p>Riêng người viết lần đầu nhìn mặt A của MSI Pulse GL66 2021 hình dung ngay tới Valorant, hay tựa game đã từng chơi rất lâu trước đây là Call Of Duty: Advanced Warfare. Chắc chắn chính bạn cũng sẽ có sự liên tưởng tới những gì quen thuộc trong thế giới ảo của riêng mình từ những đường cắt hoạ tiết này.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-14.jpg" style="height:665px; width:1000px" /></p>

<p>&nbsp;</p>

<h3>Bản lề mở 180 độ</h3>

<p>Cần phải nhắc ngay đến chi tiết này, vì cho tới thời điểm hiện tại vẫn còn dư luận nhắm đến vấn đề chất lượng bản lề kém mà rất lâu trước đây MSI gặp phải. Tất nhiên, một hãng lớn như MSI không thể để những lỗi nghiêm trọng như thế tồn tại đến đời máy tiếp theo chứ chưa kể đến rất nhiều đời.</p>

<p>Để trấn an dư luận và thể hiện sự lắng nghe người dùng cùng hành động khắc phục triệt để, bản lề gaming laptop MSI đã được nâng cấp qua rất nhiều đời. Chạy đua với đối thủ, lần này MSI GL66 đã đầu tư hẳn bản lề 180 độ (chính xác là 178 độ) nhằm khẳng định sự thay đổi tích cực đồng thời phục vụ mục đích chính là hỗ trợ nhu cầu đa nhiệm của người dùng.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-25.jpg" style="height:791px; width:1000px" /></p>

<p>Đối với những ai kỹ tính, bản lề của MSI Pulse GL66 11UDK 255VN khiến màn hình có độ rung nhất định. Tuy nhiên ta cần xét cơ bản ở 2 vấn đề:<br />
- Tầm giá của máy<br />
- Điều kiện sử dụng thực tế</p>

<p>Với bài test đơn giản là đặt máy trên bàn, mở một góc 120 độ và tạo sự rung lắc, MSI Pulse GL66 11UDK 255VN đã vượt qua một cách đơn giản. Mặc dù người viết đã test không chỉ một lần, và ở nhiều môi trường khác nhau như bàn văn phòng, bàn cafe trong nhà cỡ nhỏ, bàn gỗ freestyle ở cafe vườn hay thậm chí là sử dụng trên ô tô.</p>

<p>Nếu các bạn có tâm lý chỉ thoả mãn với sự hoàn hảo, với độ hoàn thiện cao, tốt nhất khi sắm MSI Pulse GL66 không nên để ý vấn đề này. Nhưng nhu cầu chỉ dừng lại ở sử dụng tốt ở thực tế, MSI Pulse GL66 hoàn toàn có thể đáp ứng.</p>

<h3>&nbsp;</h3>

<h3>Hành trình phím bấm 1,8mm</h3>

<p>Là một hành trình nhấn khá sâu so với 1.4mm của các ultrabook, đây là loại hành trình phục vụ tốt cho chơi game do game thủ khi vào trận sẽ có xu hướng bấm với lực mạnh hơn bình thường.</p>

<p>Trên các phím lớn, lực nhấn được phân bổ tương đối đều từ trung tâm tới 4 cạnh. Chúng ta có thể dễ dàng cảm nhận và yên tâm về sự đồng đều của các phím này trong thao tác soạn thảo. Tuy nhiên với nhu cầu này, lực trả về của phím hơi căng hơn hơn một chút so với ultrabook.</p>

<p>Ở các phím nhỏ như ở khu vực numpad lại cho cảm giác bấm hơi khác, lực nhấn yêu cầu dường như nhẹ hơn một chút và khi bấm về phía cạnh phím sẽ có phần không giống với khu vực trung tâm. Vấn đề này vốn không quan trọng và chúng ta cũng không cần phải lo lắng. Trên thực tế đối với các phím nhỏ thì ngón tay thường tiếp xúc phần lớn diện tích bề mặt, rất hiếm khi chúng ta có thể bấm ra cạnh phím.</p>

<p>Việc kích thước phím phần numpad nhỏ hơn các phím khu vực ký tự khiến những công việc liên quan đến thống kê con số cần thời gian làm quen nhất định. Việc cần làm quen này đơn giản chỉ vì trước đây có thể chúng ta đã quen bấm numpad ở bàn phím rời. Riêng phím enter khu vực numpad được đặt ngang như phím enter khu vực ký tự. Có một cảm giác cực kỳ thú vị khi bạn sử dụng numpad thường xuyên và nhấn phím enter này.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-05.jpg" style="height:666px; width:1000px" /></p>

<p>Hy sinh kích thước khu vực numpad để đảm bảo khu vực ký tự được đủ không gian là một sự đánh đổi cần thiết khi mà bố cục bàn phím này như một xu hướng mới cho laptop gaming kiêm phục vụ đa nhiệm. MSI đã rất quyết đoán khi đem phần numpad trở lại để phục vụ tốt hơn đối tượng khách hàng của mình ở phân khúc này (đa phần là sinh viên hay người mới đi làm cần một sự khởi đầu “cụ thể”).</p>

<h3>&nbsp;</h3>

<h3>Trackpad nhạy và mượt</h3>

<p>Không có gì để chê ở trackpad của MSI GL66 1UDK 255VN khi độ nhạy vừa đủ và cho cảm giác di ngón tay rất mịn, chỉ không có ưu điểm về không gian hoạt động vì dù sao đây cũng không phải là loại trackpad lớn. Được thiết kế hoạ tiết hồng tâm cách điệu theo phong cách game FPS hiện đại khiến trackpad của MSI Pulse GL66 chứa đầy cảm hứng gaming.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-10.jpg" style="height:665px; width:1000px" /></p>

<h3>&nbsp;</h3>

<h3>Led RGB nhưng hiển thị đơn sắc</h3>

<p>Không có dạng RGB 4 vùng như phong trào thiết kế gần đây, MSI Pulse GL66 11UDK 255VN chỉ có thể tuỳ chỉnh led đổi màu theo màu đơn, bù lại chúng ta có một bàn phím lên led cho màu rất tươi và sáng. Đối với ánh sáng vừa phải ở môi trường ngoài trời, một số màu led của bàn phím vẫn cóthể sáng rõ.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-23.jpg" style="height:665px; width:1000px" /></p>

<p><br />
Khi ở môi trường yếu sáng như thời điểm chiều tối là đèn nền phím đã có thể lên màu khá đẹp, môi trường tối hoàn toàn thì lại càng rực rỡ. Chúng ta hãy để ý 2 vùng sáng/tối như ảnh chụp dưới đây là có thể so sánh được độ sáng ở 2 điều kiện môi trường này, đồng thời có thể tương quan so sánh được các dải màu đang ở độ sáng tối đa sẽ như thế nào.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-22.jpg" style="height:665px; width:1000px" /><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-17.jpg" style="height:665px; width:1000px" /><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-18.jpg" style="height:665px; width:1000px" /><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-19.jpg" style="height:665px; width:1000px" /><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-21.jpg" style="height:665px; width:1000px" /><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-20.jpg" style="height:665px; width:1000px" /></p>

<h3>&nbsp;</h3>

<h3>Webcam tích hợp 720p 30fps</h3>

<p>Là webcam tích hợp đủ dùng cho nhu cầu học hay họp online, không có gì xuất sắc hay nổi bật. Webcam được kích hoạt bật/tắt thông qua tổ hợp phím FN+F6. Tuy nhiên sẽ yên tâm cho người dùng hơn nếu GL66 được đầu tư thêm lẫy gạt che webcam như một số laptop khác trên thị trường.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-07.jpg" style="height:666px; width:1000px" /></p>

<h3>&nbsp;</h3>

<h3>Phân bổ vị trí cổng kết nối</h3>

<p>Cổng kết nối đặt khá nhiều bên cạnh phải, sẽ có sự rối rắm khi có quá nhiều dây được cắm vào. Cồng kềnh nhất vẫn là cổng LAN RJ-45 và HDMI luôn sử dụng dây thân tròn, tiếp đến là cổng Type-C thường để kết nối ổ cứng di động.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-09.jpg" style="height:665px; width:1000px" /></p>

<p>Đối với nhu cầu chơi game trên thực tế, nếu sử dụng trực tiếp màn hình laptop thì có thể giải quyết vấn đề của cổng HDMI (là dây cồng kềnh nhất), đối với cổng LAN RJ-45 ta có thể sử dụng loại&nbsp;<strong>dây cáp mạng thân dẹt nhỏ gọn</strong>&nbsp;như gợi ý dưới đây. Và cổng cắm chuột có thể chuyển sang lề bên trái vốn sẵn 1 cổng USB Type-A 2.0, thêm 1 cổng USB Type-A 3.2 Gen1 để kết nối các thiết bị khác cần băng thông cao hơn.</p>

<p><strong><em>&gt;&gt;&gt;&nbsp;&nbsp;<a href="https://www.anphatpc.com.vn/cap-mang-orico-pug-c6b-30-bk-3m-32awg-day-det.html" target="_blank">Cáp mạng Orico PUG-C6B-30-BK 3m 32AWG dây dẹt</a>&nbsp;</em></strong><em>(dài 3 mét)</em><br />
<strong><em>&gt;&gt;&gt;&nbsp;&nbsp;<a href="https://www.anphatpc.com.vn/cap-mang-orico-pug-c6b-50-bk-5m-32awg-day-det.html" target="_blank">Cáp mạng Orico PUG-C6B-50-BK 5m 32AWG dây dẹt</a>&nbsp;</em></strong><em>(dài 5 mét)</em></p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-08.jpg" style="height:666px; width:1000px" /></p>

<p>Vẫn là lời khuyên mà người viết luôn nhắc lại ở mỗi bài đánh giá chi tiết gaming laptop, nếu bạn có sử dụng lót chuột hay luôn đảm bảo rằng có khoảng cách ít nhất 5cm với khe tản nhiệt ở cạnh phải. Bởi khí nóng xả ra khi chơi game đủ để làm nóng chảy viền cao su của lót chuột dẫn đến cong viền mất thẩm mỹ, nặng thì bề mặt vải sẽ bị bong khỏi lớp cao su.</p>

<p>Nếu bạn có sử dụng đế tản nhiệt thì có thể không cần lo lắng đến vấn đề này do thân máy đã được nâng lên cao hơn, luồng khí nóng xả ra ở cạnh phải lúc này không ảnh hưởng tới lót chuột.</p>

<p>Cùng với việc tạo thói quen luôn để lót chuột cách máy tối thiểu 5cm, mọi sự vướng víu sinh ra bởi cổng kết nối dày đặc bên cạnh phải MSI Pulse GL66 sẽ dần không còn là vấn đề. Lúc này sẽ chỉ còn vấn đề về thẩm mỹ và tính gọn gàng mà thôi.</p>

<p>&nbsp;</p>

<h3>Hệ thống tản nhiệt cùng thiết kế mặt D đặc biệt</h3>

<p>Khe hút gió bổ sung được thiết kế khá cụ thể đối với cả thị giác lẫn chức năng vận hành. Các khe được đặt vào vị trí chính giữa và tương đối thuận mắt với thiết kế tổng quan mặt C, tổng hoà hoàn hảo với ngôn ngữ thiết kế chung của MSI Pulse GL66 gaming laptop.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-12.jpg" style="height:665px; width:1000px" /></p>

<p>2 khe tản nhiệt lớn phía sau đủ lớn để có thể thấy rõ các lá đồng phía trong. Các đường cắt vát và chi tiết thiết kế xung quanh có gì đó khá quen thuộc, dường như tương đồng với ngôn ngữ thiết kế của các loại máy bay chiến đấu hiện đại thường gặp trong thế giới game.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-03.jpg" style="height:665px; width:1000px" /></p>

<p>Mặt D là điểm thiết kế nổi bật nhất trong hệ thống tản nhiệt khi cho không gian lấy gió khá nhiều và thoáng. Nhìn tổng quan ta đã có thể thấy ngay những ống đồng dẫn nhiệt và măt D hỗ trợ đắc lực cho việc làm mát trực tiếp các ống đồng này.</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-15.jpg" style="height:665px; width:1000px" /></p>

<p>Nhiệt độ CPU và GPU sẽ mát hơn rất cụ thể nhờ thiết kế độc đáo này, tuy nhiên đổi lại sẽ hút bụi khá nhiều. Khi sử dụng máy chúng ta cần chú ý tới bề mặt đặt máy nhiều hơn (nhất là mặt bàn ở các cafe sân vườn vốn rất nhiều bụi từ không gian thiết kế).</p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-16.jpg" style="height:665px; width:1000px" /></p>

<h3>&nbsp;</h3>

<h3>Màn hình hiển thị tốt dải động</h3>

<p>Đối với nhu cầu trải nghiệm hình ảnh thì MSI Pulse GL66 11UDK 255VN đã thể hiện rất tốt ở khoản “nuông chiều thị giác”. Vùng tối (shadow) thể hiển rất tốt khi không bị chìm vào một màu đen “phẳng” (chỗ nào cũng tối như nhau), vẫn phân biệt khá rõ mức độ khi vào hoạt cảnh lễ hội về đêm vốn khá phức tạp về ánh sáng.</p>

<p>&nbsp;<img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-28.jpg" style="height:666px; width:1000px" /></p>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/2701_MSIPulseGL6611UDK255VN-AnPhatComputer-29.jpg" style="height:666px; width:1000px" /></p>

<p>Độ sáng màn hình chỉ dừng lại ở&nbsp;<strong>260 nit</strong>. Với độ sáng khá khiêm tốn này sẽ có chút khó khăn khi dùng ngoài trời hay cửa sổ có ánh sáng mạnh hắt vào. Sử dụng khu vực trong nhà như giảng đường, văn phòng không ảnh hưởng.</p>
', N'TN Computer', CAST(N'2021-07-15T00:22:41.000' AS DateTime), 1, 1, 0, 2, NULL, N'admin', CAST(N'2021-07-15T00:22:41.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:54:22.780' AS DateTime))
GO
INSERT [dbo].[News] ([Id], [CategoryId], [MetaUrl], [ThumbImage], [LargeImage], [Title], [SubTitle], [NewsContent], [Author], [PostedDate], [IsHot], [IsHome], [IsView], [NewsOrder], [Tags], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, 7, NULL, N'/Upload/Images/c7d05ed7-2402-467d-8c1e-c89a8fc82242.jpg', N'/Upload/Images/c7d05ed7-2402-467d-8c1e-c89a8fc82242.jpg', N'Top Những Chiếc Màn Hình Type C Tốt Nhất', N'Trong thời gian trở lại đây, những chiếc màn hình Type C đang được cực kì nhiều khách hàng quan tâm, lựa chọn', N'<p>Trong thời gian trở lại đây, những chiếc&nbsp;<a href="https://www.anphatpc.com.vn/man-hinh-may-tinh.html-1?filter=2805" target="_blank">màn hình Type C</a>&nbsp;đang được cực kì nhiều khách hàng quan tâm, lựa chọn. Cổng kết nối Type C trên màn hình có thể mang đến cho các bạn rất rất nhiều sự tiện lợi trong quá trình sử dụng. Với một chiếc màn hình Type C, các bạn có thể truyền dữ liệu hình ảnh từ các thiết bị tương thích như laptop, máy tính bảng… và cả điện thoại tới màn hình một cách dễ dàng. Đặc biệt, khi truyền dữ liệu hình ảnh, cổng Type C trên&nbsp;<a href="https://www.anphatpc.com.vn/man-hinh-may-tinh.html-1" target="_blank">màn hình máy tính</a>&nbsp;còn có tác dụng giúp sạc thiết bị truyền hình ảnh luôn cho các bạn, cực kì yên tâm khi sử dụng mà không phải kết nối một mớ dây rợ kèm theo. Cũng chính bởi vậy, cổng kết nối Type C dần trở thành một trong những yếu tố thiết yếu khi lựa chọn màn hình và càng quan trọng hơn khi các bạn đang tìm kiếm một chiếc màn hình phụ cho laptop.</p>

<p>Để giúp các bạn có thêm nhiều sự lựa chọn chất lượng cũng như những gợi ý đáng lưu tâm nhất, ngày hôm nay, mình xin gửi tới các bạn bài viết “<strong>Top Những Chiếc Màn Hình Type C Tốt Nhất</strong>”. Các bạn cùng mình đến ngay với những chiếc màn hình Type C đáng chọn bậc nhất trong năm nay ngay thôi nào!</p>

<p>&nbsp;</p>

<h3><strong>1. Màn hình máy tính Dell Ultrasharp U2422H</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/0802_Manhinhtypec-2.jpg" style="height:394px; width:700px" /></p>

<p>Xuất hiện đầu tiên trong danh sách “Top Những Chiếc Màn Hình Type C Tốt Nhất” chính là chiếc màn hình Dell Ultrasharp U2422H, một chiếc màn hình Type C cực kì ấn tượng được Dell ra mắt cho năm 2022. Là một sản phẩm thuộc Ultrasharp Series cực kì danh tiếng đến từ Dell, U2422H sở hữu độ hoàn thiện có thể nói là hoàn hảo kể cả về thiết kế, công nghệ hay chất lượng hiển thị. Trong quá trình sử dụng, đặc biệt với nhu cầu thiết kế và sáng tạo nội dung, các bạn sẽ cần tới sự “Clean” và “Clear” để tăng khả năng tập trung, tạo cảm hứng sáng tạo và tránh bị phân tâm trong quá trình làm việc.</p>

<p>Đáp ứng đúng theo tiêu chí đó, chiếc màn hình Dell Ultrasharp U2422H mang tới cho chúng ta một thiết kế tối giản bậc nhất nhưng vẫn kèm theo đó là một sự sang trọng tinh tế với điểm nhấn là thiết kế tràn viền trên cả 4 cạnh của chiếc màn hình. Phần vỏ ngoài là sự kết hợp của hai tone màu chủ đạo là xám bạc và đen để tôn lên thêm thiết kế sang trọng ấy. Thiết kế công thái học cũng là một điểm cộng cực lớn trên dòng màn hình Ultrasharp và cụ thể ở đây là chiếc màn hình U2422H, vừa giúp mang lại một trải nghiệm sử dụng đặc biệt ấn tượng cho người dùng, vừa giúp bảo vệ sức khỏe của các bạn trong quá trình sử dụng.</p>

<p>Bên cạnh thiết kế, chất lượng hiển thị chính là một yếu tố chủ chốt giúp Ultrasharp Series luôn chiếm được rất nhiều thiện cảm từ phía cộng đồng người sử dụng. Sau khi làm nức lòng cộng đồng người dùng với chiếc màn hình U2419H, Dell chưa muốn dừng lại ở đó và họ đã thực sự cho chúng ta thấy được sự nâng tầm trên chiếc màn hình U2422H. U2422H sở hữu độ phủ màu cực kì ấn tượng lên tới 100% dải màu sRGB, 100% dải màu Rec 709 và 85% trên dải màu điện ảnh DCI-P3. Trước khi được đưa đến tay người dùng, mỗi chiếc U2422H đều được cân chỉnh màu một cách để các bạn có thể yên tâm sử dụng ngay khi rước em nó về nhà.</p>

<p>Đây là một sự nâng cấp cực kì đáng tiền giúp mang đến một trải nghiệm hình ảnh hiển thị có thể làm các bạn đặc biệt hài lòng, dù là các bạn có sử dụng cho nhu cầu cơ bản, học tập, làm việc, xem phim, chơi game hay cả nhu cầu thiết kế đồ họa. Dell cũng không quên trang bị cho chiếc màn hình thêm rất nhiều công nghệ tích hợp có thể kể đến như ComfortView Plus, Low Blue Light, Flicker-Free… giúp hạn chế tối đa hiện tượng nháy màn hình, giảm lượng ánh sáng xanh có hại phát thải từ màn hình trong quá trình sử dụng mà vẫn đảm bảo khả năng hiển thị màu sắc ấn tượng.</p>

<p><strong>Đặc điểm nổi bật</strong><br />
- Thiết kế tràn viền 4 cạnh<br />
- Thiết kế công thái học<br />
- Dải màu rộng<br />
- Dung sai màu thấp do được cân chỉnh trước khi xuất xưởng<br />
- Cổng kết nối đa dạng<br />
- Tích hợp nhiều công nghệ bảo vệ mắt</p>

<p><strong>Thông số kỹ thuật</strong><br />
- Kích thước: 24 inch<br />
- Độ phân giải: FHD 1920x1080<br />
- Tần số quét: 60 Hz<br />
- Tấm nền: IPS<br />
- Độ sáng: 250 nits<br />
- Cổng kết nối: 1x USB 3.2 (Type-C; downstream, 15W), 3x USB 3.2 (Type-A; Gen 2; downstream), 1x USB 3.2 (Type-C; Gen 2; upstream; 90W; DP Alt Mode), 1x HDMI 1.4, 1x DisplayPort 1.4, 1x DisplayPort 1.4 (out with MST), 1x 3.5mm Audio Out</p>

<p><strong>Video intro</strong></p>

<p><strong>Link sản phẩm</strong><br />
<strong><a href="https://www.anphatpc.com.vn/man-hinh-may-tinh-dell-ultrasharp-u2422h-23.8-inch-fhd-usb-typec_id37929.html" target="_blank">Màn hình máy tính Dell Ultrasharp U2422H</a></strong></p>

<p>&nbsp;</p>

<h3><strong>2. Màn hình máy tính LG 29WP60G-B</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/0802_Manhinhtypec-3.jpg" style="height:394px; width:700px" /></p>

<p>Chiếc màn hình Type C tiếp theo mình muốn giới thiệu đến các bạn trong danh sách ngày hôm nay chính là LG 29WP60G-B, một chiếc màn hình Type C cực kì ấn tượng với tỷ lệ màn hình 21:9 cực mới đến từ LG. Để mang đến một trải nghiệm không chỉ mới lạ mà còn cực kì hiệu quả đến cho người dùng, LG cùng đội ngũ kỹ sư chuyên nghiệp của mình đã nghiên cứu, phát triển và cho ra mắt chiếc màn hình 29WP60G-B để có thể mở rộng dải sản phẩm với mục tiêu có thể làm hài lòng mọi nhu cầu sử dụng của khách hàng.</p>

<p>29WP60G-B sở hữu một thiết kế đơn giản, tinh tế nhưng cũng không kém phần nổi bật. Phần vỏ ngoài được làm bằng chất liệu nhựa cứng cao cấp kết hợp với những đường viền đỏ tạo cho chiếc màn hình một vẻ trẻ trung, cá tính. Và chắc chắn rồi, chiếc màn hình LG 29WP60G-B cũng được trang bị thiết kế tràn viền mới nhất trên cả 3 cạnh của chiếc màn hình, vừa đẹp về mặt thẩm mỹ, vừa giúp người dùng có thể dễ dàng tập trung hơn trong quá trình sử dụng cũng như hạn chế cảm giác bị giới hạn, mang tới thêm nhiều cảm hứng sáng tạo cho người dùng.</p>

<p>29WP60G-B sở hữu tấm nền IPS cho góc nhìn siêu rộng cùng khả năng hiển thị màu sắc ấn tượng. Với độ phủ màu lên tới 99% dải màu sRGB, các bạn có thể hoàn toàn yên tâm để giải quyết những công việc đồ họa cơ bản trên chiếc màn hình đến từ LG này. Với điểm nhấn là tỷ lệ màn hình Ultrawide 21:9, chiếc màn hình có cổng Type C 29WP60G-B sẽ mang lại cho bạn những lợi ích gì? Với tỉ lệ màn hình này, các bạn sẽ có thêm nhiều không gian hiển thị hơn, cực kì hữu dụng khi sử dụng đa nhiệm và một số công việc đặc thù như edit nhạc, video hay coding… Các bạn cũng có thể hoàn toàn yên tâm về chất lượng hiển thị khi tỷ lệ màn hình 21:9 của 29WP60G-B sẽ đi kèm với một độ phân giải riêng đó chính là WFHD (2560x1080), đảm bảo mang đến cho các bạn những giờ phút học tập, làm việc hay giải trí với độ sắc nét ấn tượng.</p>

<p>Đặc biệt, đây còn là một chiếc màn hình với chuẩn HDR 10, mang đến khả năng hiển thị chuẩn xác nhất với khung cảnh gốc để các bạn có thể hoàn toàn đắm chìm trong những giờ phút giải trí bất tận. 29WP60G-B cũng được tích hợp thêm công nghệ đồng bộ khung hình AMD FreeSync, giúp hạn chế tối đa hiện tượng giật, xé khung hình trong quá trình sử dụng, mang đến một trải nghiệm mượt mà và ấn tượng bậc nhất. Chiếc màn hình LG 29WP60G cũng có cổng USB Type C hỗ trợ DisplayPort Chế độ mới, các bạn chỉ cần sử dụng một cáp USB Type C, toàn bộ tín hiệu hình ảnh DisplayPort có thể được truyền sang màn hình bên ngoài mà không cần cáp màn hình chuyên dụng hoặc bộ chuyển đổi nào.</p>

<p><strong>Đặc điểm nổi bật</strong><br />
- Tỷ lệ màn hình Ultrawide 21:9<br />
- Cổng kết nối đa dạng<br />
- Tích hợp nhiều công nghệ bảo vệ mắt<br />
- AMD FreeSync<br />
- HDR 10</p>

<p><strong>Thông số kỹ thuật</strong><br />
- Kích thước: 29 inch<br />
- Độ phân giải: WFHD 2560x1080<br />
- Tần số quét: 75 Hz<br />
- Tấm nền: IPS<br />
- Độ sáng: 250 nits</p>

<p><strong>Video intro</strong></p>

<p><strong>Link sản phẩm</strong><br />
<strong><a href="https://www.anphatpc.com.vn/man-hinh-may-tinh-lg-29wp60g-b-29-inch-ultrawide-fhd-hdr-ips_id37397.html" target="_blank">Màn hình máy tính LG 29WP60G-B</a></strong></p>

<p>&nbsp;</p>

<h3><strong>3. Màn hình máy tính MSI Optix MAG251RX</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/0802_Manhinhtypec-4.jpg" style="height:394px; width:700px" /></p>

<p>Trong thời gian trở lại đây, những chiếc màn hình gaming đang thực sự giành được rất nhiều sự quan tâm đến từ cộng đồng người sử dụng và với một thương hiệu gaming đẳng cấp như MSI, một chiếc màn hình siêu xịn, một món bảo khí có thể giúp các bạn chinh phục mọi mức độ xếp hạng trong các tựa game FPS Esport. Chiếc màn hình gaming có cổng Type C MSI Optix MAG251RX.</p>

<p>Các bạn cần gì ở một chiếc màn hình gaming? Tần số quét cao, thời gian phản hồi thấp, góc nhìn rộng, bảo vệ mắt, công nghệ hỗ trợ game tích hợp? Không chỉ sở hữu tất cả những yếu tố cần thiết này, chiếc màn hình còn đặc biệt gây ấn tượng cho mình với khả năng thể hiện màu sắc cực kì ấn tượng, đây chính là một trong những chiếc màn hình gaming màu đẹp nhất mà mình đã được trải nghiệm từ trước đến nay.</p>

<p>Với một chiếc màn hình gaming, chúng ta sẽ có rất rất nhiều điểm nhấn để có thể kể đến và chắc chắn rồi MSI Optix MAG251RX cũng sở hữu một tá những điểm ấn tượng có thể làm các bạn ưng ý ngay với chiếc màn hình gaming này. Chiếc màn hình sở hữu thiết kế công thái học đang cực kì trending ở thời điểm hiện tại, cho phép các bạn có thể dễ dàng điều chỉnh độ cao cũng như góc nhìn của màn hình để phù hợp với góc nhìn, tư thế ngồi cũng như điều kiện ánh sáng, một yếu tố cực kì quan trọng giúp bảo vệ sức khỏe của bạn trong thời gian dài.</p>

<p>Bao phủ toàn bộ chiếc màn hình là một thiết kế gaming cá tính với những đường cắt góc cạnh trẻ trung, tone màu đen chủ đạo cũng giúp các bạn dễ dàng hơn rất nhiều trong quá trình setup góc máy và đặc biệt nhất là một dải LED RGB vô cùng bắt mắt nằm phía sau thân máy, một thiết kế siêu đẹp để các bạn có thể tự tin đặt em nó ở mọi nơi kể cả trong những không gian mở.</p>

<p>MSI Optix MAG251RX được trang bị tấm nền IPS cực xịn với mức tần số quét lên tới 240Hz cùng thời gian đáp ứng chỉ 1ms, hoàn hảo để các bạn có thể chiến tốt mọi tựa game FPS đang có ở thời điểm hiện tại. Ngoài ra MSI cũng không quên trang bị thêm cho chiếc màn hình công nghệ đồng bộ khung hình Nvidia G-Sync, đảm bảo cho các bạn một trải nghiệm hoàn hảo, nói không với hiện tượng giật xé khung hình. Không dừng lại ở đó, chiếc màn hình sẽ làm bất ngờ các bạn thêm một lần nữa với khả năng hiển thị 1,07 tỉ màu cùng với đó là chứng nhận HDR400, mang đến trải nghiệm hình ảnh ấn tượng mà một số mẫu màn hình đồ họa phải kém xa khi so sánh.</p>

<p><strong>Đặc điểm nổi bật</strong><br />
- Thiết kế công thái học<br />
- Dải LED RGB mặt sau màn hình<br />
- Tần số quét 240hz cùng thời gian phản hồi 1ms<br />
- Nvidia G-Sync<br />
- Kích thước 24.5 inch hoàn hảo mới<br />
- Khả năng hiển thị 1,07 tỉ màu<br />
- HDR400<br />
- Cổng kết nối đa dạng<br />
- Công nghệ bảo vệ mắt tích hợp</p>

<p><strong>Thông số kỹ thuật</strong><br />
- Kích thước: 24.5 inch<br />
- Độ phân giải: FHD 1920x1080<br />
- Tần số quét: 240 Hz<br />
- Tấm nền: IPS<br />
- Độ sáng: 400 nits<br />
- Cổng kết nối: 1x DP (1.2a), 2x HDMI (2.0), 1x USB Type C</p>

<p><strong>Video intro</strong></p>

<p><strong>Link sản phẩm</strong><br />
<strong><a href="https://www.anphatpc.com.vn/man-hinh-may-tinh-msi-optix-mag251rx-24.5-inch-fhd-240hz_id36915.html" target="_blank">Màn hình máy tính MSI Optix MAG251RX</a></strong></p>

<p>&nbsp;</p>

<h3><strong>4. Màn hình máy tính Asus ProArt PA278CV</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/0802_Manhinhtypec-5.jpg" style="height:394px; width:700px" /></p>

<p>Còn gì tuyệt vời hơn một chiếc màn hình đồ họa sở hữu cổng kết nối Type C phải không các bạn? Và còn đặc biệt hơn thế khi đây là một chiếc màn hình cực kì ấn tượng thuộc ProArt Series đến từ Asus, một dòng sản phẩm chuyên về đồ họa và được thiết kế để đáp ứng tốt nhất cho công việc thiết kế đồ họa, chiếc màn hình máy tính Asus ProArt PA278CV.</p>

<p>Chiếc màn hình được trang bị thiết kế công thái học với chân đế tiện dụng có thể điều chỉnh độ nghiêng, xoay, quay và chiều cao, chiếc màn hình Asus ProArt PA278CV 27 inch 2K IPS mang đến trải nghiệm xem và sử dụng thoải mái. Khả năng xoay màn hình 90 độ theo chiều kim đồng hồ hoặc ngược chiều kim đồng hồ để sử dụng ở chế độ dọc rất tiện dụng khi làm việc với các tài liệu dài, mã hóa hoặc duyệt web. Ngoài ra, chân đế tháo nhanh giúp dễ dàng gắn màn hình thông qua giá treo tường chuẩn VESA tích hợp, không cần vít để các bạn có thể treo tường chỉ trong vài giây. Thiết kế của chiếc màn hình cũng được Asus cực kì chăm chút, đẹp, sang trọng và tinh tế giúp các bạn có thêm nhiều cảm hứng cũng như hạn chế mất tập trung trong quá trình làm việc.</p>

<p>Với thông số kỹ thuật, Asus ProArt PA278CV cũng chắc chắn sẽ làm hài lòng các bạn đang tìm kiếm một chiếc màn hình thiết kế đồ họa cao cấp. Asus ProArt PA278CV 27 mang tới độ phủ màu đạt 100% sRGB, 100% Rec 709 theo tiêu chuẩn công nghiệp và hỗ trợ gam màu DCI-P3 giúp tái tạo sống động, phong phú đảm bảo mọi chi tiết trong ảnh của bạn đều rõ ràng và sinh động như thật. Mỗi chiếc màn hình ProArt PA278CV trước khi xuất xưởng đều được hiệu chuẩn và đạt chứng nhận Calman Verified để bảo đảm độ chính xác màu vượt trội (∆E &lt; 2). Mỗi màn hình Asus đều trải qua quá trình thử nghiệm nghiêm ngặt, tỉ mỉ để đảm bảo chuyển màu mượt mà hơn. Các chuyên gia về màu sắc có thể yên tâm về trải nghiệm xem và sáng tạo nội dung với độ chính xác màu tuyệt đối.</p>

<p>Với kích thước 27 inch cùng độ phân giải QHD (2560x1440), Asus muốn đảm bảo chiếc màn hình này sẽ có thể mang đến cho các bạn những trải nghiệm hình ảnh rõ ràng và sắc nét bậc nhất. Asus cung cấp nhiều chế độ cũng trang bị cho chiếc màn hình tính năng ProArt Preset độc quyền để điều chỉnh gam màu nhanh chóng. Cho dù đang chỉnh sửa màu sắc, chỉnh sửa video hoặc thao tác với ảnh, bạn đều có thể dễ dàng chuyển đổi cho phù hợp với nhu cầu. Asus cũng trang bị cho chiếc màn hình thêm một tính năng cực kì hấp dẫn đó chính là Asus ProArt Palette, tính năng cho phép bạn tùy chỉnh màn hình thông qua một loạt các thông số, bao gồm độ sắc, nhiệt độ và gam màu - tất cả đều dễ dàng truy cập thông qua các menu trực quan trên màn hình.</p>

<p>Ngoài ra còn có các thanh trượt thang độ xám hai điểm cho cả sáu màu để mang lại cho bạn sự linh hoạt trong điều chỉnh màu sắc hơn so với các màn hình đồ họa khác trên thị trường. ProArt Palette giúp bạn tạo ra các tác phẩm nghệ thuật một cách nhanh chóng và đồng nhất, cũng như dễ dàng kiểm soát màu sắc của mình lựa chọn.</p>

<p><strong>Đặc điểm nổi bật</strong><br />
- Thiết kế công thái học<br />
- Được thiết kế hoàn hảo cho nhu cầu đồ họa<br />
- Độ phủ màu cao<br />
- Được cân chỉnh màu sắc tỉ mỉ trước khi xuất xưởng<br />
- Cổng kết nối đa dạng<br />
- Độ sáng cao<br />
- Tích hợp công nghệ bảo vệ mắt</p>

<p><strong>Thông số kĩ thuật</strong><br />
- Kích thước: 27 inch<br />
- Độ phân giải: QHD 2560x1440<br />
- Tần số quét: 75 Hz<br />
- Tấm nền: IPS<br />
- Độ sáng: 350 nits<br />
- Cổng kết nối: 1x HDMI(v1.4), 2x DisplayPort 1.2, 1x USB-C(65W)</p>

<p><strong>Video intro</strong></p>

<p><strong>Link sản phẩm</strong><br />
<strong><a href="https://www.anphatpc.com.vn/man-hinh-may-tinh-asus-proart-pa278cv-27-inch-2k-ips-chuyen-do-hoa_id37124.html" target="_blank">Màn hình máy tính Asus ProArt PA278CV</a></strong></p>

<p>&nbsp;</p>

<h3><strong>5. Màn hình máy tính Gigabyte M34WQ</strong></h3>

<p><img alt="" src="https://www.anphatpc.com.vn/media/news/0802_Manhinhtypec-6.jpg" style="height:394px; width:700px" /></p>

<p>Xuất hiện cuối cùng trong danh sách những chiếc màn hình Type C tốt nhất ngày hôm nay, mình xin gửi tới các bạn một chiếc màn hình siêu to, siêu dài và cũng siêu chất đến từ Gigabyte, chiếc màn hình gaming Gigabyte M34WQ.</p>

<p>Sở hữu một hệ sinh thái cực kì rộng lớn trải rộng hết gần như tất cả các dải sản phẩm từ linh kiện, phụ kiện, gear và cả màn hình, Gigabyte luôn biết cách làm hài lòng những người khách hàng của mình với những sản phẩm sở hữu thông số kỹ thuật ấn tượng, nhiều công nghệ tích hợp, giá thành hợp lí, thiết kế gaming cá tính kèm theo đó là khả năng tương thích tuyệt vời trong hệ sinh thái sản phẩm. Không nằm ngoài tiêu chuẩn đó, Gigabyte M34WQ sẽ khiến các bạn phải ngay lập tực hài lòng ngay từ cái nhìn đầu tiên và biến các bạn thành một fan trung thành của thương hiệu gaming siêu đỉnh này.</p>

<p>Sở hữu kích thước siêu khủng lên tới 34 inch, việc duy nhất các bạn cần quan tâm là dọn dẹp góc máy để vừa với em nó, còn Gigabyte M34WQ lo việc mang đến cho các bạn một trải nghiệm sử dụng tuyệt vời. Với kích thước siêu khủng của mình, Gigabyte M34WQ sẽ cho các bạn một diện tích hiển thị cực rộng, giúp các bạn nâng tầm trải nghiệm sử dụng đa nhiệm, thoải mái hơn khi xem những bộ phim ưa thích và hoàn toàn đắm chìm trong thế giới của các tựa game. To thôi là chưa đủ, Gigabyte M34WQ còn sở hữu thông số kỹ thuật cực kì ấn tượng với độ phân giải WQHD (3440x1440) cùng tần số quét 144hz.</p>

<p>Chiếc màn hình vừa cho khả năng hiển thị hình ảnh sắc nét, vừa giúp trải nghiệm sử dụng trở nên mượt mà bậc nhất, với thông số phần cứng này, mình khuyên các bạn nên sử dụng những mẫu card đồ họa với hiệu năng tương đương RTX 2060 Series đến từ Nvidia trở lên. Sở hữu kích thước lớn như vậy nhưng Gigabyte vẫn trang bị cho chiếc màn hình một thiết kế công thái học giúp các bạn dễ dàng nâng hạ cũng như điều chỉnh góc nhìn của màn hình để đảm bảo cảm giác thoải mái cũng như bảo vệ tốt nhất cho sức khỏe của các bạn.</p>

<p>Chiếc màn hình cũng đạt chứng chỉ HDR 400 từ VESA để mang tới hình ảnh hiển thị chân thực cũng như công nghệ đồng bộ khung hình AMD FreeSync Premium để hạn chế hiện tượng giật, xé khung hình trong quá trình sử dụng mà vẫn đảm bảo chất lượng hiển thị HDR. Độ phủ màu của chiếc màn hình cũng cực kì đáng nể khi đạt 91% dải màu điện ảnh DCI-P3, hoàn toàn có thể giúp các bạn giải quyết nhu cầu đồ họa cơ bản khi có việc gấp phải sử dụng.</p>

<p><strong>Đặc điểm nổi bật</strong><br />
- Thiết kế công thái học<br />
- Kích thước Ultrawide 34 inch siêu rộng<br />
- HDR400<br />
- FreeSync Premium<br />
- Độ phủ màu cao<br />
- Công nghệ bảo vệ mắt tích hợp</p>

<p><strong>Thông số kĩ thuật</strong><br />
- Kích thước: 27 inch<br />
- Độ phân giải: QHD 2560x1440<br />
- Tần số quét: 75 Hz<br />
- Tấm nền: IPS<br />
- Độ sáng: 350 nits<br />
- Cổng kết nối: 2x HDMI 2.0, 1x DP 1.4 (DSC),1x USB Type-C</p>
', N'TN Computer', CAST(N'2021-07-15T00:29:15.000' AS DateTime), 1, 1, 0, 1, NULL, N'admin', CAST(N'2021-07-15T00:29:15.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:53:05.860' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (22, N'Order00000', CAST(21990000 AS Decimal(12, 0)), 1, N'1111111111111111111', N'11111111111', N'fdfffffffffff', NULL, NULL, CAST(N'2022-02-12T18:12:07.717' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (23, N'Order000023', CAST(21990000 AS Decimal(12, 0)), 4, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'0397966566', N'aaaaaaaaaa', N'phongphong24052k2@gmail.com', NULL, CAST(N'2022-02-13T15:39:05.470' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (24, N'Order000024', CAST(19290000 AS Decimal(12, 0)), 1, N'1111111111111111111', N'0397966566', N'Nguyễn Hải Phong', N'phongphong24052k2@gmail.com', NULL, CAST(N'2022-02-13T21:50:32.063' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (25, N'Order000025', CAST(19290000 AS Decimal(12, 0)), 4, N'1111111111111111111fsdfsdfsdf', N'0397966566', N'Nguyễn Hải Phong', N'phongphong24052k2@gmail.comrdsfgsdfsd', NULL, CAST(N'2022-02-13T21:50:45.137' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (26, N'Order000026', CAST(19290000 AS Decimal(12, 0)), -2, N'1111111111111111111fsdfsdfsdf', N'0397966566', N'Nguyễn Hải Phong2334321342', N'phongphong24052k2@gmail.comrdsfgsdfsd', NULL, CAST(N'2022-02-13T21:50:50.557' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (27, N'Order000027', CAST(49980000 AS Decimal(12, 0)), 4, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'0397966566', N'aaaaaaaaaa', N'phongphong24052k2@gmail.com', NULL, CAST(N'2022-02-13T23:22:30.987' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (28, N'Order000028', CAST(19290000 AS Decimal(12, 0)), -1, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'0397966566', N'Nguyễn Hải Phong', N'phongphong24052k2@gmail.com', NULL, CAST(N'2022-02-16T18:39:24.790' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (49, N'Order000049', CAST(29699000 AS Decimal(12, 0)), 1, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:04:34.643' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (50, N'Order000050', CAST(29699000 AS Decimal(12, 0)), 1, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:05:01.850' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (51, N'Order000051', CAST(29699000 AS Decimal(12, 0)), 1, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:06:39.910' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (52, N'Order000052', CAST(29699000 AS Decimal(12, 0)), 1, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:13:59.733' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (53, N'Order000053', CAST(29699000 AS Decimal(12, 0)), 1, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:14:18.050' AS DateTime))
GO
INSERT [dbo].[Order] ([Id], [OrderCode], [TotalPrice], [OrderStatusId], [CustomerAddress], [CustomerPhone], [CustomerFullName], [CustomerEmail], [CustomerNote], [CreatedDate]) VALUES (54, N'Order000054', CAST(29699000 AS Decimal(12, 0)), 4, N'Hưng Yên', N'0346060827', N'Nguyễn Nam Hải', N'hainn.ict@gmail.com', NULL, CAST(N'2022-03-01T10:21:09.467' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (33, 22, 26, 3, CAST(21990000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (34, 23, 26, 1, CAST(21990000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (35, 24, 27, 3, CAST(19290000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (36, 25, 27, 3, CAST(19290000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (37, 26, 27, 3, CAST(19290000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (38, 27, 1, 2, CAST(27990000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (39, 27, 26, 2, CAST(21990000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (40, 28, 27, 1, CAST(19290000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (61, 49, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (62, 50, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (63, 51, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (64, 52, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (65, 53, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [ProductPrice]) VALUES (66, 54, 45, 1, CAST(29699000 AS Decimal(12, 0)))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (-2, N'Giao thất bại', NULL)
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (-1, N'Đã hủy', NULL)
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (1, N'Chờ xác nhận', NULL)
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (2, N'Đã xác nhận', NULL)
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (3, N'Đang giao', NULL)
GO
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description]) VALUES (4, N'Giao thành công', NULL)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [CategoryId], [ProductImagesId], [Code], [Name], [Description], [Price], [PromotionPrice], [MainImageThumb], [MainImageLarge], [IsHot], [IsHome], [IsPromote], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1, 16, NULL, N'NBAC0310', N'Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004', N'<h2><strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong></h2>

<p>&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_1.jpg" /></p>

<p><br />
<br />
Được biết đến như là một trong những thương hiệu hàng đầu về laptop,&nbsp;<strong>Acer</strong>&nbsp;luôn mang đến cho người dùng những chiếc laptop vô cùng chất lượng. Sở hữu thiết kế bắt mắt, cấu hình mạnh mẽ, khả năng tản nhiệt ấn tượng, chính sách bảo hành cực xịn kèm theo đó là rất nhiều công nghệ tích hợp tân tiến, những chiếc laptop Acer đã chiếm được rất nhiều cảm tình từ phía người dùng. Là sự lựa chọn được cực kì đông đảo khách hàng tin tưởng sử dụng.</p>

<p>Hướng tới nhu cầu chơi game cũng như thiết kế đồ họa đang rất được quan tâm, Acer đã mang tới cho chúng ta thế hệ&nbsp;<strong><a href="https://www.anphatpc.com.vn/laptop-acer-nitro-5_dm1632.html" target="_blank">Laptop Gaming Nitro 5</a></strong>&nbsp;mới nhất trong năm 2021. Sở hữu diện mạo hoàn toàn mới cùng sự thay đổi về hệ thống cấu hình đẩy sức mạnh của máy lên một tầm cao mới.</p>

<p>Cũng thuộc&nbsp;<strong>Acer Gaming Nitro 5 Series</strong>, chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;với bộ vi xử lý&nbsp;<strong>Intel Core i7-11800H</strong>&nbsp;cùng card đồ họa&nbsp;<strong>RTX 3050ti</strong>&nbsp;sẽ là sự lựa chọn hoàn hảo giúp bạn cân trọn những siêu phẩm game AAA bom tấn cũng như hỗ trợ bạn công việc thiết kế đồ họa.</p>

<p>&nbsp;</p>

<h3><br />
<strong>Thiết kế</strong></h3>

<p><strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;được thừa hưởng thiết kế đậm chất gaming của Nitro Series. Sử dụng tone màu Đen chủ đạo, tạo điểm nhấn bằng những đường cắt tinh tế, chiếc laptop mang tới vẻ ngoài mạnh mẽ, cá tính đúng chuẩn của một cỗ máy chiến game cao cấp.</p>

<p>Để chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;thêm bền bỉ, Acer đã trang bị cho chiếc máy tính lớp vỏ ngoài hoàn toàn bằng chất liệu nhựa cứng cao cấp, giúp Acer Nitro 5 chỉ nặng 2.2kg. An toàn khi đồng hành cùng bạn đi tới bất kỳ đâu.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_2.jpg" /></p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><br />
<strong>Màn hình</strong></h3>

<p>Chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;sở hữu màn hình với kích thước&nbsp;<strong>15,6 inch</strong>&nbsp;tiêu chuẩn, không quá nhỏ để làm giảm trải nghiệm sử dụng nhưng cũng không quá to để có thể gây khó khăn trong quá trình di chuyển. Với thiết kế&nbsp;<strong>SlimBezel</strong>, phần viền màn hình được làm tràn ra cực mỏng, trông cực kì tinh tế, hiện đại, giúp chúng ta tập trung hơn trong quá trình sử dụng.</p>

<p>Acer cũng rất chú trọng tới chất lượng hình ảnh khi trang bị cho&nbsp;<strong>Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;tấm nền với độ phân giải&nbsp;<strong>FHD</strong>&nbsp;(1920x1080) cho khả năng hiển thị hình ảnh với độ sắc nét tuyệt đối. Tần số quét cũng được nâng cấp lên&nbsp;<strong>144Hz</strong>, mang tới hình ảnh chuyển động cực kì mượt mà và chi tiết, đem lại lợi thế vượt trội trong các tựa game như CSGO, Valorant hay PUBG.&nbsp;Chiếc Laptop đến từ Acer được sử dụng công nghệ tấm nền&nbsp;<strong>IPS</strong>&nbsp;cho góc nhìn rộng lên tới&nbsp;<strong>178 độ</strong>&nbsp;cùng khả năng tái tạo màu sắc chuẩn xác, giúp các bạn có thể hoàn thành tốt công việc đồ họa cơ bản của mình.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_3.jpg" /></p>

<p>&nbsp;</p>

<h3><br />
<strong>Cấu hình</strong></h3>

<p><strong>Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;được trang bị bộ vi xử lý&nbsp;<strong>Intel Core i7-11800H</strong>, đây là phiên bản&nbsp;<strong>CPU thế hệ thứ</strong>&nbsp;<strong>11</strong>&nbsp;mới nhất đến từ Intel với&nbsp;<strong>8 nhân 16 luồng</strong>, xung nhịp tối đa lên đến&nbsp;<strong>4.6 GHz</strong>&nbsp;mang đến hiệu năng cực kì ấn tượng. Không dừng lại ở đó, mẫu chip này được nâng cấp bộ nhớ đệm lên đến&nbsp;<strong>24MB</strong>, hỗ trợ cực tốt các tác vụ đa nhiệm, thực hiện nhanh chóng, cải thiện tốc độ phản hồi để mang lại hiệu suất tối ưu nhất cho chiếc laptop.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_4.jpg" /></p>

<p>&nbsp;</p>

<p>Một mẫu laptop gaming thì không thể không nhắc tới Card đồ họa, và không làm chúng ta thất vọng khi&nbsp;<strong>Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;được trang bị mẫu Card màn hình cực khủng&nbsp;<strong>NVIDIA GeForce RTX 3050ti 4GB DDR6</strong>. Mang tới công nghệ&nbsp;<strong>Ray Tracing</strong>&nbsp;cho hình ảnh phản chiếu chân thực, tạo cảm giác sống động, nâng tầm hoàn toàn tựa game các trải nghiệm. Bên cạnh đó, công nghệ&nbsp;<strong>NVIDIA DLSS</strong>&nbsp;được sử dụng, giúp tăng tốc độ khung hình lên thấp nhất&nbsp;<strong>1,5 lần</strong>&nbsp;mà vẫn giữ nguyên chất lượng hình ảnh nhờ sử dụng&nbsp;<strong>Tensor Cores</strong>&nbsp;chuyên dụng trên dòng&nbsp;<strong>GPU RTX</strong>.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_5.jpg" /></p>

<p><br />
Không chỉ sở hữu cấu hình mạnh mẽ, mẫu&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;mang tới một bộ lưu trữ cực kì ấn tượng với&nbsp;<strong>512GB PCIe NVMe SSD</strong>. Đây là loại ổ lưu trữ mới sở hữu tốc độ truyền tải dữ liệu cùng độ bền vượt bậc, tối ưu hóa khả năng lưu trữ giữ liệu và giúp chiếc máy tính khởi động cũng như truy xuất giữ liệu với tốc độ cực kì nhanh chóng.</p>

<p>Để hỗ trợ tốt nhu cầu đa dụng, Acer cũng không quên mang tới&nbsp;<strong>8GB RAM DDR4 Bus 3200MHz</strong>. Các bạn hoàn toàn có thể an tâm sử dụng đa nhiệm một cách vô cùng mượt mà, nâng cao đáng kể hiệu năng làm việc của bạn khi sử dụng chiếc laptop. Chiếc laptop có thể nâng cấp lên tối đa&nbsp;<strong>32GB RAM</strong>&nbsp;nên các bạn có thể yên tâm bởi đây là một sự lựa chọn có tiềm năng lớn, có thể bên cạnh hỗ trợ các bạn trong một khoảng thời gian cực dài.</p>

<p>&nbsp;</p>

<h3><strong>Bàn phím</strong></h3>

<p><strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;sử dụng kích thước bàn phím tiêu chuẩn với đầy đủ các phím chức năng và cả cụm phím phụ Numpad. Bàn phím của chiếc laptop có hỗ trợ hệ thống đèn&nbsp;<strong>LED RGB 4 màu</strong>&nbsp;cực kì cá tính, hỗ trợ quá trình gõ phím của các bạn rất tốt khi dùng máy trong không gian thiếu sáng. Đặc biệt, trên bàn phím này còn có phím tắt đưa người dùng vào phần mềm Nitro Sense một cách nhanh chóng. Nhờ vậy, người dùng có thể kiểm soát được nhiệt độ và tốc độ quạt gió đang hoạt động. Từ đó có những điều chỉnh hợp lý để mang tới hiệu suất làm việc cao cho&nbsp;<strong>Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_6.jpg" /></p>

<p>&nbsp;</p>

<h3><strong>Cổng kết nối</strong></h3>

<p>Ở bên cạnh trái, chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;được trang bị 1 cổng Audio 3.5mm, 2 cổng USB 3.2 Gen 1, 1 cổng Ethernet hỗ trợ 1000 Mbps cùng 1 ổ khóa Kensington Lock Slot để đảm bảo an toàn cho chiếc Laptop của bạn.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_7.jpg" /></p>

<p>&nbsp;</p>

<p>Với cạnh phải, chúng ta sẽ có 1 cổng USB Type C, 1 cổng USB Gen 2 cùng 1 cổng xuất hình HDMI. Thực sự đầy đủ tất cả những cổng kết nối thông dụng để các bạn có thể sử dụng thêm thiết bị ngoại vi như chuột, bàn phím hoặc kết nối với máy chiếu cho bài thuyết giảng, trình bày luận án…</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_8.jpg" /></p>

<p>&nbsp;</p>

<p>Còn kết nối không dây thì sao ạ? Chiếc laptop con cưng được Acer trang bị công nghệ Bluetooth 5.1 với cường độ tín hiệu mạnh mẽ cùng khả năng tiết kiệm điện năng. Kèm theo đó là Wifi 6 mới nhất và&nbsp;KillerTM Wi-Fi 6 AX 1650i giúp ổn định đường truyền internet trong suốt quá trình chiến game.</p>

<p>&nbsp;</p>

<h3><strong>Âm thanh</strong></h3>

<p><strong>Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;tích hợp phần mềm âm thanh&nbsp;<strong>DTS:X Ultra</strong>&nbsp;giúp tái tạo âm thanh 3D và&nbsp;<strong>Acer True Harmony</strong>&nbsp;với 6 chế độ tùy chỉnh âm thanh, định lượng âm thanh chuẩn xác, sống động như thật, mang đến cho các bạn những giờ phút giải trí chất lượng, dù là nghe nhạc, xem phim hay đắm chìm trong thế giới của các tựa game yêu thích.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_9.jpg" /></p>

<p>&nbsp;</p>

<h3><strong>Tản nhiệt</strong></h3>

<p>Ảnh hưởng cực lớn tới hiệu năng cũng như tuổi thọ của một chiếc laptop, đặc biệt là một chiếc laptop gaming, cũng chính bởi vậy Acer đã trang bị cho chiếc laptop Nitro 5 của mình một hệ thống tản nhiệt siêu xịn. Chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;được trang bị quạt đôi, ống đồng sơn cách nhiệt cùng 4 cổng thoát khí.</p>

<p>Ngoài ra công nghệ&nbsp;<strong>Acer CoolBoost</strong>&nbsp;còn giúp chiếc laptop có khả năng tăng tốc độ quạt lên 10% và giảm 9% nhiệt độ của CPU/GPU so với chế độ tự động. Các bạn cũng có thể theo dõi và quản lí thông số nhiệt độ cũng như tốc độ vòng quay của quạt theo thời gian thực với&nbsp;<strong>NitroSense</strong>, từ đó chủ động hơn trong việc sử dụng chiếc máy tính thân yêu của mình.</p>

<p>&nbsp;<img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_10.jpg" /></p>

<p>&nbsp;</p>

<h3><strong>Chính sách bảo hành 3S1</strong></h3>

<p>Để khách hàng có thể an tâm hơn trong quá trình sử dụng, Acer đã mang tới cho chiếc&nbsp;<strong>Laptop Acer Gaming Nitro 5 Eagle AN515-57-720A NH.QEQSV.004</strong>&nbsp;chính sách bảo hành siêu vip riêng là&nbsp;<strong>3S1</strong>. Vậy&nbsp;<strong>3S1</strong>&nbsp;là gì?&nbsp;<strong>3S1</strong>&nbsp;là chính sách bảo hành nhanh của Acer dành cho game thủ. Duy nhất tại Việt Nam, những dòng sản phẩm cao cấp sẽ được kiểm tra, bảo hành và gửi lại khách chỉ trong thời gian ngắn:03 ngày (72 giờ) bao gồm cả thứ 7, Chủ nhật. Đặc biệt hơn nữa, khách hàng sẽ được nhận sản phẩm mới cùng loại hoặc tương đương (1 đổi 1) cho các trường hợp không hoàn thành bảo hành trong 03 ngày tính từ lúc nhận sản phẩm.<br />
Cực kì yên tâm sử dụng phải không các bạn! Chẳng may có lỗi cũng không phải xa chiếc máy tính của mình quá lâu, biết đâu lại được nhận một chiếc máy mới tinh từ dịch vụ bảo hành cực xịn này!</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/14-10-2021/nbac0299_11.jpg" /></p>

<p>&nbsp;</p>
', CAST(30490000 AS Decimal(12, 0)), CAST(27990000 AS Decimal(12, 0)), N'/Upload/Images/1ac82ccc-da90-40c7-a7ef-ec8cf744e9e4-thumb.png', N'/Upload/Images/1ac82ccc-da90-40c7-a7ef-ec8cf744e9e4.png', 1, 1, 1, CAST(N'2021-03-28T20:15:28.000' AS DateTime), N'admin', CAST(N'2022-02-21T01:34:37.193' AS DateTime), N'admin')
GO
INSERT [dbo].[Product] ([Id], [CategoryId], [ProductImagesId], [Code], [Name], [Description], [Price], [PromotionPrice], [MainImageThumb], [MainImageLarge], [IsHot], [IsHome], [IsPromote], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (3, 16, NULL, N'NBAC0329', N'Laptop Gaming Acer Predator Helios PH315-54-758S NH.QC5SV.003', N'<h2><strong>Laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong></h2>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snh.jpg" /></strong></p>

<p><strong>Laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong> - chiếc máy dành cho gaming với ngoại hình cá tính, hiệu năng mạnh mẽ nhờ CPU Intel® Core™ i7-11800H và card đồ họa NVIDIA® GeForce RTX™ 3050, màn hình cực nhanh và hệ thống tản nhiệt hiệu quả. Vì vậy không có gì ngạc nhiên khi nó luôn được săn lùng bởi anh em gamer.</p>

<p>Trong bài viết này, An Phát Computer sẽ giới thiệu đến các bạn một siêu phẩm <strong><a href="https://www.anphatpc.com.vn/gaming-laptop.html">laptop gaming</a></strong> cực chiến - cực chơi - cực độc đến từ Acer -<strong> Laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong>. Hãy cùng khám phá xem với giá bán hấp dẫn, chiếc máy tính xách tay này sẽ đem đến những điều bất ngờ nào nhé!</p>

<h2><strong>Thiết kế bên ngoài, bộ khung máy</strong></h2>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv003-1-13.jpg" /></strong></p>

<p>Ngay từ những ánh nhìn đầu tiên, bạn sẽ ngay lập tức bị hút hồn bởi diện mạo độc đáo, cá tính của <strong><a href="https://www.anphatpc.com.vn/laptop-acer_dm1060.html" target="_blank">laptop Acer</a> Predator Helios PH315-54-758S NH.QC5SV.003</strong>. Các đường cắt, góc cạnh, khe tản nhiệt hay cổng kết nối đều được chế tác mang phòng cách gaming, mạnh mẽ, cứng cáp.</p>

<p>Cùng với đó là logo Predator đặt ở chính giữa sử dụng ánh đèn LED xanh tạo điểm nhấn nổi bật trên nền màu đen trẻ trung, năng động.</p>

<p>Em laptop này sử dụng chất liệu kim loại để mang đến sự bền bỉ và chắc chắn tối đa. Bạn hoàn toàn có thể yên tâm khi sử dụng máy hằng ngày hay mang theo máy di chuyển trên đường.</p>

<p>Kích thước ba chiều của máy lần lượt là 363 (W) x 255 (D) x 22.9 (H) mm và khối lượng 2.3 kg, ở mức trung bình với các dòng máy gaming, nó cũng gọn nhẹ hơn khá nhiều so với những phiên bản trước của series Predator.</p>

<h2><strong>Màn hình hiển thị</strong></h2>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv003-1-1.jpg" /></strong></p>

<p><strong><a href="https://www.anphatpc.com.vn/laptop-gaming-acer-predator-helios-ph315-54-758s-nh.qc5sv.003_id40314.html" target="_blank">Laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</a></strong> được trang bị màn hình 15.6 inch với độ phân giải Full HD 1920 x 1080 giúp hiển thị sắc nét, sống động và chi tiết rõ ràng với từng thước phim.</p>

<p>Để tối ưu cho những trải nghiệm gaming, Chiếc máy này mang đến tần số quét màn hình lên đến <strong>144Hz</strong> giúp đáp ứng tốt ngay cả với các game tốc độ cao như: FPS, đua xe,..., loại bỏ tình trạng giật hình, xé hình.</p>

<p>Với sự hỗ trợ của tấm nền IPS, màn hình của em laptop này có được độ sáng, độ tương phản cao và chính xác cùng quá trình tái tạo màu sắc chân thực hơn. IPS còn đem lại góc nhìn rộng xấp xỉ 180 độ - điều này đồng nghĩa với việc bạn có thể quan sát màn hình ở bất kì góc nào bạn muốn mà không gặp phải tình trạng các chi tiết trên màn hình bị biến đổi so với góc nhìn chính diện.</p>

<p>Bên cạnh đó màn hình máy còn được trang bị công nghệ <strong>LED Backlit</strong> mang đến khả năng hiển thị màu sắc tươi sáng, đẹp mắt và độ tương phản cao hơn cho màn hình máy, đồng thời công nghệ này cũng có khả năng tiết kiệm điện năng hiệu quả và vô cùng thân thiện với môi trường.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv003-1-2.jpg" /></p>

<p>Ở chiếc máy này, Acer sử dụng một công nghệ độc quyền do chính hãng phát triển - <strong>Acer ComfyView</strong>, công nghệ này mang đến rất nhiều ưu điểm vượt trội như: chống chói hiệu quả trong những môi trường có cường độ ánh sao cao, giảm thiểu tình trạng mỏi mắt với công nghệ giảm ánh sáng xanh Bluelight Filter và mang lại màu sắc trong trẻo, tươi tắn. Vô cùng ấn tượng phải không nào?</p>

<p>Viền màn hình của <strong><a href="https://www.anphatpc.com.vn/laptop-acer-predator_dm1634.html" target="_blank">laptop Acer Predator</a> Helios PH315-54-758S NH.QC5SV.003</strong> được thiết kế siêu mỏng <strong>(Slim Bezel)</strong> mang đến tỉ lệ màn hình chiếm đến trên 80% diện tích thân máy, giữ kích thước máy được nhỏ gọn tối đa trong khi bạn vẫn được tận hưởng màn hình lớn đến 15.6 inch.</p>

<p>Phía bên trên màn hình được bố trí đầy đủ Webcam, đèn LED và bộ phận thu âm để đáp ứng nhu cầu gọi video, tham gia các lớp học và buổi họp trực tuyến của bạn.</p>

<h2><strong>Bàn phím, touchpad</strong></h2>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv003-1-4.jpg" /></strong></p>

<p>Bàn phím của <strong>laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong> có hành trình phím hợp lý, độ nhạy cao giúp việc soạn thảo văn bản và nhập liệu được tiến hành dễ dàng, nhanh chóng và chính xác.</p>

<p>Đặc biệt, các phím thường được các bạn sử dụng nhiều khi chơi game: W, A, S, D và bốn phím mũi tên được làm nổi bật giúp dễ dàng định vị và thao tác với chúng hơn.</p>

<p>Bàn phím số phụ cũng được trang bị để đáp ứng tốt hơn cho các công việc cần thao tác nhiều đến con số, giúp bạn có được năng suất và chất lượng công việc cao hơn.</p>

<p><strong><a href="https://www.anphatpc.com.vn/laptop-gaming-acer-predator-helios-ph315-54-758s-nh.qc5sv.003_id40314.html" target="_blank">Laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</a></strong> còn hỗ trợ đèn nền bàn phím với 4 vùng tinh chỉnh để bạn không gặp phải bất tiện và khó khăn khi sử dụng máy trong điều kiện ánh sáng yếu. Đồng thời, chúng còn giúp trang trí và mang đến trải nghiệm gaming thú vị, hào hứng hơn.</p>

<p>Touchpad của máy có diện tích khá rộng, được phủ một lớp nhám mịn giúp cho việc thao tác chuột trở nên thuận tiện hơn, thậm chí không thua kém quá nhiều so với khi sử dụng một chiếc chuột rời. Tuy nhiên, để tối ưu hóa cho trải nghiệm gaming của mình, bạn đừng quên sắm cho mình một chiếc chuột phù hợp nhé!</p>

<h2><strong>Kết nối</strong></h2>

<p>Để phục vụ tối đa cho các nhu cầu đa dạng của người sử dụng, em laptop này được trang bị khá đầy đủ các cổng kết nối bao gồm: KillerTM Ethernet E2600; USB Type-C port: USB 3.2 Gen 2 (up to 10 Gbps); 1 x USB 3.2 Gen 2 port featuring power-off USB charging; 2 x USB 3.2 Gen 1 ports; 1 x HDMI®2.1 port with HDCP support; 1 x Mini DisplayPort 1.4; 3.5 mm headphone/speaker jack.</p>

<p>Máy cũng sử dụng <strong>KillerTM Wi-Fi 6 AX 1650i</strong> mang đến mạng không dây có tốc độ siêu nhanh, ổn định và có khả năng bảo mật cao giúp phục vụ cho việc học tập, công việc và các hoạt động giải trí khác của bạn. Ngoài ra còn có Bluetooth 5.1 giúp cho việc kết nối với các thiết bị khác trở nên nhanh chóng và dễ dàng, phục vụ việc truyền dữ liệu và thực hiện vô số tác vụ khác theo ý muốn.</p>

<h2><strong>Hiệu suất sử dụng</strong></h2>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv003-1-3.jpg" /></strong></p>

<p><strong><a href="https://www.anphatpc.com.vn/may-tinh-xach-tay-laptop.html" target="_blank">Laptop</a> Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong> sở hữu bộ vi xử lý <strong>Intel® Core™ i7-11800H</strong> - một con chip mới được Intel cho ra mắt vào quý 2 năm 2021 có sức mạnh vượt trội và thường được trang bị cho các dòng laptop trung và cao cấp.</p>

<p>Intel® Core™ i7-11800H được sản xuất dựa trên tiến trình SuperFin 10nm thế hệ thứ hai, nó tích hợp 8 nhân xử lý Willow Cove và 16 luồng nhờ công nghệ siêu phân luồng, xung nhịp cơ bản 2.3 GHz và xung nhịp tối đa lên đến 4.6 GHz - một con số thực sự ấn tượng!</p>

<p>Với bộ nhớ đệm lên đến 24MB, bộ nhớ trong 8GB DDR4 với tốc độ bus RAM 3200MHz, bạn có thể thực hiện đa nhiệm cực kì mượt mà. Tự do mở đến cả chục ứng dụng/tabs và chuyển đổi liên tục giữa chúng để đáp ứng nhu cầu công việc mà không gặp phải tình trạng giật, lag. Nếu nhu cầu sử dụng cao hơn nữa, bạn còn có thể&nbsp;<strong>nâng cấp RAM tối đa đến 32GB</strong>&nbsp;với hai khe cắm đã được trang bị sẵn. Vô cùng tiện lợi phải không?</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv00314.jpg" /></p>

<p>Không chỉ dừng lại ở đó, <strong><a href="https://www.anphatpc.com.vn/laptop-acer_dm1060.html">laptop Acer</a> Predator Helios PH315-54-758S NH.QC5SV.003</strong> còn sở hữu ổ cứng <strong>512GB PCIe NVMe SSD</strong>, mang lại không gian khổng lồ đáp ứng mọi nhu cầu công việc hay giải trí của bạn. Ổ cứng dung dung lượng lớn còn giúp cho việc khởi động máy hay mở các ứng dụng trở nên nhanh như chớp, rút ngắn thời gian chờ đợi cho bạn.</p>

<p>Máy còn cho phép bạn nâng cấp tối đa đến <strong>2TB SSD PCIe NVMe</strong> và <strong>2TB HDD 2.5-inch 5400 RPM</strong> nữa đó!</p>

<p>Để tạo nên sức mạnh cho chiếc máy này, không thể không kể đến <strong>card đồ họa NVIDIA® GeForce RTX™ 3050Ti 4GB GDDR6</strong>. Nó có khả năng đáp ứng tốt hầu hết các nhu cầu của bạn từ gaming, thiết kế, dựng video,...&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/06-01-2022/acerpredatorheliosph31554758snhqc5sv00312.jpg" /></p>

<p>Với những chiếc laptop gaming, hệ thống làm mát luôn là một trong những ưu tiên hàng đầu. Ở <strong>laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong> sử dụng một cơ chế lấy gió mới, gió được lấy từ phía đáy và thổi ra 4 lỗ gió ở phía trên và hai bên hông, kết hợp công nghệ độc quyền làm mát CPU và GPU - <strong>CoolBoost và công nghệ AeroBlade 3D</strong> thế hệ thứ 4 với những cánh quạt hình răng cưa.</p>

<p>Những thiết kế thông minh, sáng tạo và công nghệ mới được ứng dụng mang lại hệ thống tản nhiệt vô cùng hiệu quả, hoạt động êm ái để tối ưu hiệu suất hoạt động cho máy.</p>

<p>Acer còn cung cấp đến bạn ứng dụng kiểm soát trò chơi PredatorSense, nó cho phép bạn theo dõi hệ thống, tùy chỉnh tùy chọn RGB, ép xung, tùy chỉnh tùy chọn RGB và nhiều tính năng khác nữa để mang lại trải nghiệm gaming đỉnh cao cho bạn.</p>

<p>Một chiếc laptop mang đến hiệu năng vượt trội mạnh mẽ, đáp ứng tốt từ nhu cầu gaming cho các game thủ bên trong một diện mạo cá tính, mạnh mẽ, <strong>laptop Acer Predator Helios PH315-54-758S NH.QC5SV.003</strong> sẽ là sự lựa chọn hoàn hảo để đồng hành cùng bạn chinh phục những niềm đam mê, những thử thách và các vinh quang huy hoàng mà bạn xứng đáng có được.</p>
', CAST(33990000 AS Decimal(12, 0)), CAST(31990000 AS Decimal(12, 0)), N'/Upload/Images/476a85b1-28c1-4d78-a4a6-d178b3c10728-thumb.png', N'/Upload/Images/476a85b1-28c1-4d78-a4a6-d178b3c10728.png', 1, 1, 1, CAST(N'2021-03-28T20:15:28.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:03:59.840' AS DateTime), N'admin')
GO
INSERT [dbo].[Product] ([Id], [CategoryId], [ProductImagesId], [Code], [Name], [Description], [Price], [PromotionPrice], [MainImageThumb], [MainImageLarge], [IsHot], [IsHome], [IsPromote], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (26, 16, NULL, N'NBAC0328', N'Laptop Gaming Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006', N'<h3><strong>Laptop Gaming Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong></h3>

<p><strong>THỦ LĨNH GAMING BẤT DIỆT</strong></p>

<p><strong><img alt="" src="https://anphat.com.vn/media/lib/21-12-2021/laptop.jpg" style="width:700px" /></strong></p>

<p>Năm 2021 chào đón nhiều gương mặt laptop gaming “tuy cũ mà mới”, vì sao lại như vậy?&nbsp;<strong>Nitro 5</strong>&nbsp;– cái tên đã quá quen thuộc với các game thủ và cũng là niềm ao ước của nhiều anh em nhưng trong năm 2021 này &nbsp;Acer đã cho ra mắt phiên bản&nbsp;<strong>Nitro 5</strong>&nbsp;2021 tích hợp bộ vi xử lý&nbsp;<a href="https://www.anphatpc.com.vn/cpu-amd.html" target="_blank">AMD&nbsp;Ryzen</a>&nbsp;5000 series&nbsp;đầu tiên tại Việt Nam.</p>

<p><strong>&nbsp;&nbsp;Laptop Gaming Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;là một trong những chiếc&nbsp;<a href="https://www.anphatpc.com.vn/may-tinh-xach-tay-laptop.html" target="_blank">laptop</a>&nbsp;nổi bật trong loạt Series này, cùng&nbsp;<em><strong>An Phát PC</strong></em>&nbsp;tìm hiểu nha!</p>

<h3><em><strong>Ngoại hình ấn tượng</strong></em></h3>

<p>&nbsp; Phải nói trong nhiều năm qua<strong>,&nbsp;<a href="https://www.anphatpc.com.vn/laptop-acer-nitro-5_dm1632.html" target="_blank">Nitro 5</a></strong>&nbsp;đã ngày càng được chăm chút tỉ mỉ về thiết kế khiến em nó không hề nhàm chán mà ngược lại luôn khiến các anh em bị thu hút bởi ngoại hình ấn tượng, cá tính của mình.</p>

<p>Với các anh em game thủ "sành điệu" thì hình thức&nbsp; là một trong những tiêu chí quan trọng khi chọn lựa mua cho mình 1 chiếc&nbsp;chiếc laptop gaming, với&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;thì các anh em dù khó tính đến mấy cũng luôn hài lòng với ngoại hình "chất ngầu" nhưng trọng lượng lại không quá nặng nề chỉ 2.2kg, thoải mái để bạn&nbsp; mang theo đến bất kì đâu.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/acer-nitro-5-2021-rtx-3080-ryzen-7-5800h-2.jpg" style="height:408px; width:725px" /></p>

<p><strong>&nbsp; Nitro 5</strong>&nbsp;sử dụng chất liệu nhựa cao cấp, bền đẹp đồng thời với chất liệu này cũng góp phần cắt giảm chi phí. Cảm quan ban đầu thì chiếc&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006&nbsp;</strong>này cũng giống như các thế hệ tiền nhiệm trước, không có quá nhiều khác biệt với các đường nét góc cạnh, hầm hố, thiết kế&nbsp;04 hốc tản nhiệt lớn xung quanh và led RGB 04 vùng ở khu vực bàn phím.</p>

<p>&nbsp; Nắp capo chính là sự khác biệt so với thế hệ tiền nhiệm khi&nbsp; không còn sự “hiện diện” của&nbsp;hai đường&nbsp;phây xước như trên phiên bản AN515 2020.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/z2425442597845_fd784355a364b8cf2f7ae7c5c52493ee.jpg" style="height:411px; width:700px" /></p>

<p>&nbsp; Bản lề chắc chắn có thể mở máy lên bằng 1 tay và cho góc mở màn hình lên 160 độ.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/acer-nitro-5-2021-rtx-3080-ryzen-7-5800h-3.jpg" style="height:420px; width:747px" /></p>

<p>&nbsp; Phần viền&nbsp;<a href="https://www.anphatpc.com.vn/man-hinh-may-tinh.html-1" target="_blank">màn hình</a>&nbsp;được tinh chỉnh mỏng hơn chỉ còn 7,02 mm khiến toàn bộ thân máy sẽ nhỏ gọn hơn thế hệ trước nhưng kích thước màn hình không giảm,&nbsp;mang đến khả năng trải nghiệm thị giác vô cùng mãn nhãn khi giải trí, xem phim hoặc chơi game.</p>

<p>&nbsp;&nbsp;<img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/dsc044931.jpg" style="height:467px; width:700px" /></p>

<p>&nbsp; Có thể mở nắp chỉ bằng một tay để lộ&nbsp;<a href="https://www.anphatpc.com.vn/ban-phim-may-tinh_dm1027.html" target="_blank">bàn phím</a>&nbsp;kiểu chiclet kích thước đầy đủ với bàn phím số.&nbsp;Bàn phím full-size với layout sắp xếp hợp lí, hành trính phím khá sâu giúp người chơi gõ phím thoải mái, khá nhạy. Vẫn trang bị đèn nền RGB 4 vùng trên bàn phím như Nitro 5 2020. &nbsp;</p>

<p>Cụm phím W-A-S-D và 04 phím điều hướng đều được thiết kế khá nổi bật trên tổng thể bàn phím, font chữ to giúp người chơi dễ nhận biết khi chơi game.</p>

<p>TouchPad có viền màu đỏ có kích thước 106mm x 78mm và được đặt lệch sang bên trái.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/4-1.jpg" style="height:256px; width:700px" /></p>

<p>&nbsp; Về cổng kết nối,&nbsp;<strong>Laptop Gaming Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006&nbsp;</strong>không quên trang bị đầy đủ và đa dạng nhất các cổng kết nối : cổng USB-C, &nbsp;cổng USB-A, HDMI cho bạn dễ dàng kết nối với TV hoặc màn hình rời bên ngoài, cổng LAN RJ-45 và jack tai nghe 3.5mm.</p>

<p>&nbsp; Tuy máy không còn trang bị khe&nbsp;<a href="https://www.anphatpc.com.vn/the-nho-sd-card_dm1286.html" target="_blank">thẻ nhớ</a>&nbsp;nhưng hãng đã “bù đắp” cho người dùng cổng USB type C&nbsp; giúp truyền dữ liệu và sạc các thiết bị bên ngoài.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/acernitro5202101.jpg" style="height:394px; width:700px" /></p>

<p>&nbsp; Jack cắm dây nguồn điện được chuyển ra phía sau với mục đích để quạt thông gió có vị trí thích hợp hơn.&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/acernitro5202102.jpg" style="height:394px; width:700px" /></p>

<p>&nbsp; Sạc bằng bộ đổi nguồn AC 135W, 19,5V, 6,92A với chân cắm 5,5mm.&nbsp; Bộ sạc này mỏng và nhẹ hơn nhiều bộ sạc khác. Quá trình sạc đầy chỉ mất khoảng 2,5 giờ với đèn LED sạc chuyển từ màu hổ phách sang màu xanh lam</p>

<p><em><strong>Tản nhiệt</strong></em></p>

<p>Nhận biết được tầm quan trọng của tản nhiệt tới hiệu suất chơi game và tuổi thọ của máy tính xách tay, nên ở&nbsp;&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;khá “đầu tư” cho hệ thống tản nhiệt với 2 quạt cỡ lớn, và 3 ống đồng tản nhiệt được sơn cách nhiệt.</p>

<p>Kết hợp công nghệ&nbsp;<strong>CoolBoost</strong>&nbsp;giúp tăng tốc độ quạt lên 10%, đây là công nghệ&nbsp;giúp tối ưu hoá hiệu suất&nbsp;nhờ&nbsp;kết hợp giữa phần cứng và phần mềm. Công nghệ này là độc quyền của Nitro 5 và Nitro 7.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/iyi.png" style="height:525px; width:700px" /></p>

<p>&nbsp; Các tác vụ nào nặng sẽ được ưu tiên&nbsp;<a href="https://www.anphatpc.com.vn/cooling-tan-nhiet_dm397.html" target="_blank">tản nhiệt</a>&nbsp;tốt để không làm giảm hiệu năng, bình thường khi các anh em chạy các tác vụ chơi game bình thường thì máy nóng từ 70 đến 85 độ C nên hệ thống tản nhiệt sẽ không hoạt động hết công suất.</p>

<p><strong>&nbsp;CoolBoost</strong>&nbsp;được kích hoạt khi các anh em sử dụng các phần mềm nặng như render đồ hoạ, chơi game hoặc nhiệt độ của máy trên 85 độ C hay, máy sẽ giảm từ 5 đến 10 độ C một cách nhanh chóng.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/an515-55-des-5.jpg" style="height:363px; width:645px" /></p>

<p>&nbsp; Nghe thì phức tạp nhưng công nghệ tiến tiến<strong>&nbsp;CoolBoost</strong>&nbsp;được điều khiển &nbsp;rất dễ dàng bằng phần mềm Nitro Sense có&nbsp;khả năng bật CoolBoost với điều chỉnh ba chế độ tăng tốc quạt và giúp máy giảm nhiệt độ ngay lập tức.</p>

<p>&nbsp; Chỉ với một nút chạm, anh em đã có thể truy cập nhanh vào vào Phím nóng ngay trên bàn phím. Có thể theo dõi nhiệt độ và tốc độ quạt, có thể điều chỉnh màu bàn phím RGB.</p>

<p>&nbsp; &nbsp;<img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/ff.png" /></p>

<p><em><strong>Chất lượng hình ảnh</strong></em></p>

<p>&nbsp;&nbsp;<a href="https://www.anphatpc.com.vn/man-hinh-may-tinh-ips-pls_dm1697.html" target="_blank">Màn hình IPS</a>&nbsp;có kích thước 15.6 inch với độ phân giải Full HD mang tới hình ảnh hiển thị rõ nét, màu sắc chân thực ở góc nhìn rộng kể cả ở góc nhìn hẹn nhất.</p>

<p>Ngoài ra,&nbsp;&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;sử dụng tấm nền IPS giúp giảm lượng ánh sáng tán xạ, so với tầm nền TN truyền thống, tấm nền IPS có các lớp tinh thể lỏng xếp theo hàng ngang, thay vì vuông góc với hai lớp kính phân cực thì nó được xếp song song. Chính điều này đã tạo ra góc nhìn rộng đến 178°, giúp người dùng trải nghiệm hết chất lượng của hình ảnh mà không nhất thiết phải ngồi trực diện với màn hình.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/hieunangryzenacer_thumb1.jpg" style="height:315px; width:700px" /></p>

<p>&nbsp; Với các anh em mê mẩn các tựa game cần tốc độ nhanh như tựa game bắn súng FPS, đá bóng, đua xe tốc độ cao thì&nbsp;<strong>tần số quét 144Hz</strong>&nbsp;trên&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;chắc chắn là thông số hoàn hảo mà bạn đang mong chờ ở chiếc laptop gaming.</p>

<p>Với các thông số khác là độ sáng cao 300 nits và độ phủ màu sRGB gần 100%&nbsp;thì so với các phiên bản tiền nhiệm trước thì Nitro 5 2021 có&nbsp;dải màu và độ sáng tương tự.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/uty.png" style="height:424px; width:750px" /></p>

<p>&nbsp;</p>

<p>Không thể thiếu công nghệ&nbsp;Acer ComfyView&nbsp;công nghệ được cải tiến từ công nghệ màn CineCrystal LED Backlit&nbsp;của hãng. Được bổ sung khả năng chống chói,&nbsp;sử dụng trong điều kiện ánh sáng mạnh,không gây mỏi mắt giúp hiển thị nội dung cần xem một cách dễ chịu khi bạn thiết kế hình ảnh hoặc giải trí, giúp bạn dễ dàng sử dụng ngay cả khi ở ngoài trời.</p>

<p>Đây có thể đươc coi là một ưu điểm cực lớn khi màu sắc và hiển thị của màn hình máy là vô cùng tuyệt vời!</p>

<p><em><strong>Hiệu năng</strong></em></p>

<p>&nbsp; Điểm “sáng giá” nhất trên chiếc laptop&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;&nbsp;này là cấu hình cực mạnh, với sự góp mặt của chip&nbsp;<strong>AMD Ryzen™ 5-5600H</strong>&nbsp;kết hợp với&nbsp;<strong>8GB DDR4 3200Mhz</strong>&nbsp;và card đồ họa&nbsp;<strong>NVIDIA GTX 1650 4GB</strong>. Nhìn qua thôi cũng đã đủ thu hút các anh em game thủ phải khám phá rồi.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/acer-nitro-5-2021-rtx-3080-ryzen-7-5800h.jpg" style="height:401px; width:713px" /></p>

<p>&nbsp; Sử dụng con chip&nbsp;<strong>AMD Ryzen™ 5000 Series</strong>&nbsp;&nbsp;có xung nhịp&nbsp;3.3GHz upto 4.2GHz,&nbsp;6 nhân&nbsp;12&nbsp;luồng&nbsp;là bộ xử lý laptop tiên tiến nhất trên thế giới để, được chế tạo bằng công nghệ vi xử lý 7nm đột phá mới nhất mang lại hiệu quả vượt trội, hiệu suất cao, chạy mượt mà các ứng dụng nặng. Kết hợp với bộ nhớ RAM&nbsp;8GB DDR4 3200Mhz&nbsp;&nbsp;hỗ trợ đa nhiệm đa tác vụ tốt hơn cho người dùng.</p>

<p>&nbsp; &nbsp;<img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/nitro-5-ksp-2-l.jpg" style="height:441px; width:794px" /></p>

<p>&nbsp; Ngoài ra máy còn được trang bị ổ&nbsp;NVMe SSD&nbsp;dung lượng 512GB khá lớn giúp người dùng có thể tận hưởng tốc độ truyển tải dữ liệu và khởi động siêu nhanh, giúp bạn không bao giờ bị “chậm trễ” với các tác vụ nặng như chơi game..</p>

<p>&nbsp; Không thể không nhắc tới chiếc Card đồ họa rời Geforce GTX 1650 “huyền thoại”, sẽ thật thiếu sót cho Nitro 5 2021 không trang bị cho mình chiếc card đồ họa rời mạnh mẽ đến từ&nbsp;<a href="https://www.anphatpc.com.vn/card-man-hinh-nvidia.html" target="_blank">VGA NVIDIA</a>. Với khả năng chiến mượt mà với mức FPS ổn định ở các tựa game nặng đang rất Hot trên thị trường hiện nay: Shadow of Tomb Raider, Assassin''s Creed Odyssey, Battlefield 5, Far Cry New Dawn, ,…ở mức đồ họa Medium tới High.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/nitro-5-ksp-3-l.jpg" style="height:394px; width:709px" /></p>

<p>&nbsp; &nbsp;Chơi game muốn mượt mà thì đừng quên chú trọng tới đường truyền kết nối mạng, nên bạn có thể hoàn toàn yên tâm với Công nghệ&nbsp;<strong>Wifi 6</strong>&nbsp;và&nbsp;<strong>Killer™ Ethernet</strong>&nbsp;đảm bảo đường truyền luôn ổn định và tốc độ siêu nhanh.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/4.jpg" style="height:394px; width:700px" /></p>

<p>&nbsp; Nếu như nhu cầu của bạn cho giải trí cao hơn thì đừng lo về khả năng nâng cấp của chiếc máy này, bạn hoàn toàn có thể nâng cấp dễ dàng ngay&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>. Ở phần RAM, vẫn cho người dùng dễ tùy biến cấu hình ở mức cao nhất với 02 khe RAM chuẩn DDR4 tối đa lên đến 32GB. Còn ở phần ổ cứng thì thật “hào phóng” khi hãng đã hỗ trợ để người dùng có thể nâng cấp thêm lên tới&nbsp;tối đa 2 TB SSD và 2TB HDD.</p>

<h3><em>Âm thanh sống động, chân thực</em></h3>

<p>&nbsp;Một chiếc laptop "xịn" như&nbsp;<strong>Acer Nitro 5 AN515-45-R6EV NH.QBMSV.006</strong>&nbsp;vậy không thể thiếu những công nghệ âm thanh tốt, trải nghiệm thế giới âm thanh chân thực sống động nhờ được tích hợp phần mềm âm thanh DTS:X® Ultra giúp tái tạo âm thanh 3D và Acer True Harmony với 6 chế độ tùy chỉnh âm thanh.</p>

<p>Với âm thanh chất lượng cao, người chơi sẽ thực sự được hòa mình vào không gian trong game cũng như nhân vật mà bạn hóa thân.</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/23-04-2021/9.jpg" style="height:394px; width:700px" /></p>
', CAST(23990000 AS Decimal(12, 0)), CAST(21990000 AS Decimal(12, 0)), N'/Upload/Images/ef4f6eaf-24b5-4e7a-8da5-b9624b480451-thumb.png', N'/Upload/Images/ef4f6eaf-24b5-4e7a-8da5-b9624b480451.png', 1, 1, 1, CAST(N'2021-05-06T17:54:31.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:06:26.053' AS DateTime), N'admin')
GO
INSERT [dbo].[Product] ([Id], [CategoryId], [ProductImagesId], [Code], [Name], [Description], [Price], [PromotionPrice], [MainImageThumb], [MainImageLarge], [IsHot], [IsHome], [IsPromote], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (27, 16, NULL, N'NBAC0318', N'Laptop Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007', N'<h2><strong>Laptop Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007</strong></h2>

<p><strong><strong>&nbsp;</strong></strong></p>

<p>Vốn là dòng laptop gaming được ưa chuộng của nhà Acer, <strong>Laptop Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007 </strong>nhanh chóng chiếm được cảm tình từ người dùng nhờ thiết kế cũng như hiệu năng cực đỉnh mà em nó mang lại. Nếu bạn đang tìm kiếm cho mình một em laptop gaming chạy cực ổn áp thì không nên bỏ qua em laptop này đâu nhé! Sau đây, hãy cùng <strong>An Phát PC</strong> khám phá chi tiết về chiếc laptop này của Acer nhé!&nbsp;</p>

<p>&nbsp;</p>

<h2><strong>Thiết kế bền đẹp, chắc chắn</strong></h2>

<p>&nbsp;</p>

<p>Mẫu laptop gaming này được Acer hoàn thiện với chất liệu kim loại chắc chắn, bề mặt giả nhôm vân xước thời trang tạo nên sự ấn tượng trong thiết kế của <strong><a href="https://www.anphatpc.com.vn/laptop-acer-gaming-aspire-7-a715-42g-r05g-nh.qaysv.007_id39875.html" target="_blank">laptop </a></strong><strong><a href="https://www.anphatpc.com.vn/laptop-acer-gaming-aspire-7-a715-42g-r05g-nh.qaysv.007_id39875.html" target="_blank">Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007</a></strong>. Bên cạnh đó, màu sắc charcoal black cũng mang đến cho em laptop này vẻ ngoài hiện đại và chắc chắn.</p>

<p>&nbsp;</p>

<p>Bên cạnh đó, chiếc <a href="https://www.anphatpc.com.vn/may-tinh-xach-tay-laptop.html" target="_blank">laptop</a> này có thiết kế kết cấu cứng cáp, bản lề cho góc mở hoàn toàn tới 180 độ. Đặc biệt, với trọng lượng chỉ 2,1kg và kích thước 363.4 x 254.5 x 22.9 mm, <strong>Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007 </strong>thực sự rất nhẹ đối với một chiếc laptop gaming, nhờ vậy mà bạn có thể dễ dàng luôn mang theo đến mọi nơi.&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/25-11-2021/laptopacergamingaspire7a71542gr05gnhqaysv-3.jpg" /></p>

<p>Chiếc laptop này sở hữu bàn phím fullsize, tiện lợi cho người dùng thao tác sử dụng. Hệ thống bàn phím này được thiết kế công thái học, cấu trúc một mảnh chắc chắn và hành trình phím 1,35mm mang lại trải nghiệm đánh máy cực kỳ thoải mái. Bên cạnh đó, bàn phím này còn được trang bị đèn nền giúp cho việc sử dụng máy vào ban đêm được dễ dàng hơn. Cùng với đó, các phím có độ nảy tốt, hành trình phím sâu, kích thước hợp lý cũng giúp mang đến trải nghiệm gõ phím êm ái cho người dùng học tập và làm việc.&nbsp;</p>

<p><strong><strong>&nbsp;</strong></strong></p>

<p>Phần touchpad cảm ứng đa điểm cũng mang đến cho bạn trải nghiệm điều khiển bằng đầu ngón tay mượt mà. Và đây cũng là một trong những phần được đánh giá cao ở chiếc <strong><a href="https://www.anphatpc.com.vn/laptop-acer-gaming_dm1675.html" target="_blank">laptop </a></strong><strong><a href="https://www.anphatpc.com.vn/laptop-acer-gaming_dm1675.html" target="_blank">Acer Gaming</a> Aspire 7 A715-42G-R05G NH.QAYSV.007 </strong>này. Bạn có thể thao tác ngay bằng phần touchpad này mà không cần nhờ tới sự trợ giúp của chuột rời.&nbsp;</p>

<p><strong><strong>&nbsp;</strong></strong></p>

<p>Ngoài ra, chiếc laptop này cũng được trang bị đầy đủ và đa dạng các kết nối phục vụ công việc và hoạt động chơi game của bạn bao gồm:&nbsp; 2 cổng USB 3.2 gen 1; 1 cổng USB Type-C; 1 cổng USB 2.0; 1 jack cắm tai nghe 3.5mm thông dụng; 1 cổng HDMI và cổng mạng Ethernet. Cùng với đó là công nghệ Bluetooth® 5.1 sẽ giúp người dùng thỏa sức kết nối với bất kỳ thiết bị ngoại vi nào.</p>

<p>&nbsp;</p>

<p>Nhờ vào công nghệ Intel® Wireless Wi-Fi 6 AX200 mà bạn có thể kết nối không dây nhanh chóng dù đó là ở nhà, trong một quán cà phê ở trung tâm thành phố, hay ở sân bay, giúp mang lại tốc độ mạng siêu nhanh để truyền tệp lớn nhanh hơn, chơi game trực tuyến nhanh nhạy và trò chuyện video siêu mượt.</p>

<p>&nbsp;</p>

<p>Chưa hết đâu, hệ thống tản nhiệt hai quạt giúp đẩy cao tốc độ gió vào thân máy, tạo những luồng gió mạnh giúp người dùng chơi game thời gian dài ổn định. Chính vì vậy, mà người dùng không cần phải lo lắng về việc chiếc <strong><a href="https://www.anphatpc.com.vn/laptop-acer_dm1060.html" target="_blank">laptop </a></strong><strong><strong><a href="https://www.anphatpc.com.vn/laptop-acer_dm1060.html" target="_blank">Acer</a></strong> Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007 </strong>của mình quá nóng trong quá trình sử dụng nữa nhé!</p>

<p><strong><strong>&nbsp;</strong></strong></p>

<h2><strong>Màn hình 15.6 inch Full HD cho trải nghiệm hình ảnh cực sống động</strong></h2>

<p>Em laptop này ở hữu màn hình lớn 15,6 inch, với phần viền màn hình siêu mỏng, giúp màn hình chiếm tới 81,61% thân máy mang tới trải nghiệm hình ảnh đắm chìm. Với độ phân giải Full HD, tấm nền IPS tuyệt đẹp, công nghệ màu sắc thông minh từ Acer sẽ mang đến hình ảnh game thực sự sống động, mãn nhãn người chơi.</p>

<p>Bên cạnh đó, công nghệ Acer ComfyView LED-backlit cũng đi kèm để giúp điều chỉnh ánh sáng tốt hơn. Từ đó, người dùng sẽ hạn chế bị đau mắt, mỏi mắt khi quan sát quá lâu trước màn hình máy tính. Thêm vào đó, màn hình tốc độ làm tươi cao 144Hz cũng giúp loại bỏ hiện tượng nhòe chuyển động và chỉ để lại trải nghiệm hình ảnh hoàn hảo mượt mà.&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/25-11-2021/laptopacergamingaspire7a71542gr05gnhqaysv2.jpg" /></p>

<p>Em laptop này sử dụng màn hình LCD thông dụng trên các chiếc laptop hiện nay, cho phép màn hình mỏng hơn và tiêu thụ ít điện năng hơn mà vẫn đảm bảo chất lượng hiển thị sắc nét và sống động. Ngoài ra, phía trên màn hình của laptop <strong>Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007 </strong>sở hữu một chiếc camera có độ phân giải 1280 x 720, đem đến hình ảnh sắc nét, chân thực. Từ đó, giúp cho người dùng có thể thoải mái thực hiện video call với bạn bè, người thân hay tham gia các buổi học online, các cuộc họp trực tuyến.&nbsp;</p>

<p>&nbsp;</p>

<h2><strong>Hiệu năng cực đỉnh cho khả năng chiến game mạnh mẽ</strong></h2>

<p>&nbsp;</p>

<p>Không chỉ sở hữu thiết kế đẹp mắt và phần màn hình ấn tượng mà em laptop này còn sở hữu hiệu năng cực đỉnh cho khả năng chiến game mạnh mẽ. Laptop <strong>Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007</strong> sở hữu hiệu năng cực mạnh từ một laptop chơi game với bộ vi xử lý AMD Ryzen™ 5-5500U (2.1GHz upto 4.0GHz, 8MB) cho tốc độ xử lý nhanh chóng ở mọi tác vụ công việc và chơi game. Bên cạnh đó, máy trang bị sẵn 8GB khe rời DDR4 3200Mhz (2 khe, Nâng cấp tối đa 32GB) siêu tốc giúp laptop có tốc độ khởi động máy, mở ứng dụng, tải game, chạy đa nhiệm cực kỳ mượt mà và nhanh chóng.&nbsp;</p>

<p><img alt="" src="https://anphat.com.vn/media/lib/25-11-2021/laptopacergamingaspire7a71542gr05gnh.jpg" /></p>

<p>Ổ cứng&nbsp; 512GB PCIe NVMe SSD cắm sẵn được kết hợp trên chiếc laptop <strong>Acer Gaming Aspire 7 A715-42G-R05G NH.QAYSV.007</strong> cũng giúp cho việc khởi động máy hoặc khởi động các ứng dụng nhanh hơn, nhờ đó công việc của bạn được đáp ứng kịp thời, không trễ kế hoạch. Bộ nhớ 512GB cũng cho bạn thỏa sức lưu trữ dữ liệu học tập công việc dễ dàng và hiệu quả hơn. Đặc biệt, người dùng có thể nâng cấp bộ nhớ nâng cấp lên đến 1TB SSD PCIe NVMe nữa đấy.</p>

<p><strong><strong>&nbsp;</strong></strong></p>

<p>Chưa dừng lại ở đó,em laptop này nhà Acer còn trang bị <a href="https://www.anphatpc.com.vn/vga-card-man-hinh.html" target="_blank">card đồ họa</a> rời NVIDIA® GeForce® GTX 1650 4GB GDDR6 cho bạn tận hưởng sức mạnh đồ họa từ kiến trúc Turing tiên tiến. Nhờ vậy mà bạn có thể chơi tối mọi tựa game eSports một cách mượt mà với hiệu ứng hình ảnh hấp dẫn, chân thực.</p>

<p><strong><strong>&nbsp;</strong></strong></p>

<p>Ngoài ra, em laptop này còn được trang bị hệ điều hành Windows 11 Home được thiết kế cho các PC, laptop, máy tính bảng,... Phiên bản Windows này được nâng cấp đáng kể so với phiên bản Windows 10 Home trước đây, đem đến cho người dùng nhiều trải nghiệm mượt mà và nhanh chóng hơn bao giờ hết. Nó sở hữu những tính năng thiết yếu cho người tiêu dùng phổ thông cá nhân bao gồm Cortana, khả năng chạy các ứng dụng từ Store, kết nối với Xbox,...</p>
', CAST(22290000 AS Decimal(12, 0)), CAST(19290000 AS Decimal(12, 0)), N'/Upload/Images/8f0b8020-4b89-4603-b43f-6d57e3bccf6e-thumb.jpg', N'/Upload/Images/8f0b8020-4b89-4603-b43f-6d57e3bccf6e.jpg', 1, 1, 1, CAST(N'2021-05-06T17:56:44.000' AS DateTime), N'admin', CAST(N'2022-02-10T14:07:40.067' AS DateTime), N'admin')
GO
INSERT [dbo].[Product] ([Id], [CategoryId], [ProductImagesId], [Code], [Name], [Description], [Price], [PromotionPrice], [MainImageThumb], [MainImageLarge], [IsHot], [IsHome], [IsPromote], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (45, 18, NULL, N'GF65', N'Laptop MSI Gaming GF65 10UE 286VN i5 10500H 16GB 512GB 15.6FHD RTX 3060 Max-Q 6Gb Win 10', N'<p>Giới thiệu Laptop MSI GF65 Thin 10UE-286VN (i5-10500H | RTX 3060 6G | 16GB-RAM | 512GB-SSD | 15.6</p>

<p><strong>Laptop MSI GF65 Thin 10UE-286VN</strong> được thiết kế để chơi game hiệu suất cao, máy tính xách tay này có bộ vi xử lý sáu lõi Intel Core i5-10500H thế hệ thứ 10 mạnh mẽ với 16GB DDR4-3200 bộ nhớ và ổ cứng thể rắn M.2 NVMe PCIe 1TB để nhanh chóng tải các trò chơi và ứng dụng đa nhiệm đòi hỏi khắt khe. Đồ họa NVIDIA GeForce RTX 3060 chuyên dụng giúp cung cấp tốc độ khung hình cao cùng với các tính năng nâng cao như theo dõi tia thời gian thực và tăng tốc trí tuệ nhân tạo trong khi tốc độ làm mới 144 Hz của màn hình FHD 1080p giảm thiểu hiện tượng nhòe chuyển động để mang đến đồ họa mượt mà với các trò chơi hành động nhanh. Ngoài ra, hệ thống âm thanh Nahimic 3 giúp bạn đắm chìm trong trải nghiệm chơi game, video trực tuyến và âm nhạc rõ nét. Kết nối với các mạng tương thích với Wi-Fi 802.11ax cho khả năng phát video 4K mượt mà, chơi game trực tuyến và phát trực tiếp. Với thiết kế nhôm chải nhẹ và bàn phím có đèn nền, GF65 Thin nổi bật e để tạo ấn tượng bất cứ nơi nào bạn đến. Windows 10 Home được cài đặt sẵn trên hệ thống.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Tính năng nổi bật</strong></h3>

<p><img src="https://nguyencongpc.vn/photos/17/GF65-Thin-10UE-286VN-Banner.jpg" style="width:100%" /></p>

<p>- Vi xử lí Intel Core i5-10500H thế hệ 10 mới nhất<br />
- Windows 10 Home<br />
- Card đồ họa GeForce RTX™ 3060 Laptop 6GB GDDR6 mới nhất<br />
- Màn hình chuyên game 15.6" Full HD (1920x1080), 144Hz IPS-level<br />
- Viền màn hình siêu mỏng<br />
- Tản nhiệt Cooler Boost 5 độc quyền<br />
- Phần mềm Dragon Center mới với Gaming mode 2.0<br />
- MSI App Player cho trải nghiệm chơi game mobile mượt mà trên PC<br />
- Hỗ trợ âm thanh High-Resolution.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Hiệu năng đỉnh cao</strong></h3>

<p><img src="https://nguyencongpc.vn/photos/17/MSI-GF65-Thin-10UE-286VN-14.jpg" style="width:100%" /></p>

<p>Laptop MSI GF65 Thin 10UE 286VN được trang bị vi xử lí Intel Core i5-10500H thế hệ 10 mới nhất cho hiệu năng cao hơn tới 15% so với thế hệ trước. Xung nhịp đơn nhân cao hơn cho trải nghiệm chơi game tuyệt hảo.</p>

<p><br />
NVIDIA GeForce RTX 3060 Laptop 6GB GDDR6 có mặt trên những mẫu laptop mạnh nhất thế giới cho game thủ và người sáng tạo nội dung. Sử dụng kiến trúc Ampere danh giá đã đạt nhiều giải thưởng uy tín cũng là kiến trúc RTX thế hệ thứ 2 của NVIDIA với nhân RT và nhân Tensor mới, cùng với đa nhân xử lí streaming giúp đem lại đồ họa ray-tracing siêu chân thực và các tính năng AI tân tiến nhất.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Màn hình 144HZ IPS viền siêu mỏng</strong></h3>

<p><img alt="Màn hình 144HZ IPS-LEVEL THIN-BEZEL" src="https://nguyencongpc.vn/photos/17/Laptop-MSI-GF65-Thin-144Hz.jpg" style="width:100%" /><br />
Máy tính xách tay MSI GF65 Thin 10UE 286VN có màn hình chơi game 144Hz cực nhanh, mang đến cho bạn hình ảnh rực rỡ hơn để bạn luôn bắt kịp mọi chuyển động.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Chất lượng âm thanh cao cấp</strong></h3>

<p><img src="https://nguyencongpc.vn/photos/17/MSI-GF65-Thin-10UE-286VN-8.jpg" style="width:100%" /><br />
Chìm đắm trong những bản nhạc lossless và tận hưởng âm thanh cao cấp với Hi-Resolution Audio. Trải nghiệm và lắng nghe âm thanh đúng chất. Tăng cường chất lượng âm thanh vòm 3D trong game, tùy chỉnh âm thanh theo nhu cầu nghe nhạc, xem phim và họp trực tuyến của bạn.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Thiết kế tản nhiệt đột phá</strong></h3>

<p><img alt="giải pháp tản nhiệt chuyên dụng" src="https://nguyencongpc.vn/photos/17/Laptop-MSI-GF65-Thin-Cooling.gif" style="width:100%" /><br />
Cụm tản nhiệt riêng cho cả CPU lẫn GPU với tổng cộng 6 ống dẫn nhiệt, kết hợp hoàn hảo để giảm thiểu hơi nóng, tối ưu luồng gió để đảm bảo mang lại hiệu năng game cao trong một thân máy nhỏ gọn.</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<h3><strong>Pin lên đến 7 giờ</strong></h3>

<table border="1" cellpadding="1" cellspacing="1" style="width:100%">
	<tbody>
		<tr>
			<td>Thời lượng Pin của Laptop MSI GF65 Thin 10UE có thể hoạt động liên tục lên đến 7 giờ. Đáp ứng hoàn hảo nhu cầu làm việc và giải trí di động.</td>
			<td style="background-color:#000000; vertical-align:middle; width:60%"><img src="https://nguyencongpc.vn/photos/17/MSI-GF65-Thin-battery.jpg" style="width:100%" /></td>
		</tr>
	</tbody>
</table>

<p>*Test bằng phần mềm MobileMark® 2014. Thời lượng pin có thể thay đổi tùy theo cấu hình và thiết lập hệ thống.</p>

<p><a href="javascript:;" onclick="toggleDes(this)">Thu gọn </a></p>
', CAST(30000000 AS Decimal(12, 0)), CAST(29699000 AS Decimal(12, 0)), N'/Upload/Images/a5c772aa-d100-4f97-b01b-e88990f5c092-thumb.jpg', N'/Upload/Images/a5c772aa-d100-4f97-b01b-e88990f5c092.jpg', 1, 1, 1, CAST(N'2022-02-21T01:51:07.000' AS DateTime), N'admin', CAST(N'2022-02-21T11:49:41.597' AS DateTime), N'admin')
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, -1, N'PC - Máy bộ', N'PC - Máy bộ', 1, 1, 1, 0, N'admin', CAST(N'2021-04-19T14:53:36.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:43:17.333' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, -1, N'Laptop văn phòng', N'Laptop văn phòng', 2, 1, 1, 0, N'admin', CAST(N'2021-04-19T14:53:53.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:43:42.140' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, 9, N'Gaming siêu cao cấp', N'Gaming siêu cao cấp', 5, 1, 1, 0, N'admin', CAST(N'2021-04-19T15:04:40.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:49:27.643' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (13, -1, N'Laptop Gaming', N'Laptop Gaming', 3, 1, 1, 0, N'admin', CAST(N'2021-09-14T19:47:07.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:44:01.850' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (14, -1, N'Màn hình', N'Màn hình', 4, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:19:33.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:44:37.193' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (15, -1, N'Bàn phím - Chuột', N'Bàn phím - Chuột', 5, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:20:06.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:45:00.693' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (16, 13, N'Laptop Acer', N'Laptop Acer', 1, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:21:20.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:45:44.563' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (17, 13, N'Laptop Asus', N'Laptop Asus', 2, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:22:12.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:45:58.500' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (18, 13, N'Laptop MSI', N'Laptop MSI', 3, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:23:16.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:46:11.243' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (19, 13, N'Laptop Terminator', NULL, 4, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:25:03.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:46:49.220' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (20, 9, N'Homework Intel', N'Homework Intel', 1, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:26:07.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:48:05.330' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (21, 9, N'Homework Razor', N'Homework Razor', 2, 1, 0, 0, N'admin', CAST(N'2021-09-14T23:26:43.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:48:18.473' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (22, 9, N'Gaming tầm trung', N'Gaming tầm trung', 3, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:27:20.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:48:58.480' AS DateTime))
GO
INSERT [dbo].[ProductCategory] ([Id], [ParentId], [CategoryName], [CategoryDecription], [CategoryOrder], [IsHot], [IsHome], [IsView], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (23, 14, N'Gaming cao cấp', N'Gaming cao cấp', 4, 1, 1, 0, N'admin', CAST(N'2021-09-14T23:27:46.000' AS DateTime), N'admin', CAST(N'2022-02-10T13:49:09.667' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (6, 1, NULL, N'/Upload/Images/69239098-dd57-4cb2-a3cc-d394b19dcbd4.png', N'/Upload/Images/69239098-dd57-4cb2-a3cc-d394b19dcbd4-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (7, 1, NULL, N'/Upload/Images/97afd1bc-9ca2-4f4f-bed2-83fe4f5fdbcc.png', N'/Upload/Images/97afd1bc-9ca2-4f4f-bed2-83fe4f5fdbcc-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (8, 1, NULL, N'/Upload/Images/c0d8a418-e670-42f0-85f9-9c667908c3c5.png', N'/Upload/Images/c0d8a418-e670-42f0-85f9-9c667908c3c5-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (9, 1, NULL, N'/Upload/Images/9e894aed-ab48-4644-8d5e-6b9dff13c0fd.png', N'/Upload/Images/9e894aed-ab48-4644-8d5e-6b9dff13c0fd-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (11, 3, NULL, N'/Upload/Images/01521186-ccf0-42c2-ac31-231b0027fb80.png', N'/Upload/Images/01521186-ccf0-42c2-ac31-231b0027fb80-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (12, 3, NULL, N'/Upload/Images/57fa00bc-c1aa-476f-99c3-8d7b7c7b78f5.png', N'/Upload/Images/57fa00bc-c1aa-476f-99c3-8d7b7c7b78f5-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (13, 3, NULL, N'/Upload/Images/0124870d-5974-4b0f-bf70-192a838f41c7.png', N'/Upload/Images/0124870d-5974-4b0f-bf70-192a838f41c7-thumb.png')
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ProductItemId], [LargeImage], [ThumbImage]) VALUES (14, 3, NULL, N'/Upload/Images/d83163db-909d-4556-8480-97f369ee6db0.png', N'/Upload/Images/d83163db-909d-4556-8480-97f369ee6db0-thumb.png')
GO
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Giám đốc')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (3, N'Nhân viên bán hàng')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsActive], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [RoleId]) VALUES (N'59c42d85-fa64-4bb8-1602-08d9fa9a0cd8', N'giamdoc', N'123456', 1, CAST(N'2022-02-28T16:09:39.690' AS DateTime), N'admin', NULL, NULL, N'Giám đốc', 1, CAST(N'1987-05-13' AS Date), N'Trieu Khuc, Thanh Xuan, Ha Noi', N'0346060828', N'giamdoc@gmail.com', 2)
GO
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsActive], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [RoleId]) VALUES (N'18f84993-4497-418b-9c0e-08d9fadc64e4', N'nhanvien', N'123456', 1, CAST(N'2022-03-01T00:04:34.197' AS DateTime), N'admin', NULL, NULL, N'Nhân viên', 2, CAST(N'1998-06-13' AS Date), N'Hà Nội', N'0346060811', N'nhanvien@gmail.com', 3)
GO
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsActive], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [FullName], [Gender], [Birthday], [Address], [Phone], [Email], [RoleId]) VALUES (N'ef552778-74d9-4934-bfec-f03ebdb58b44', N'admin', N'admin', 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'admin', CAST(N'2021-01-01T00:00:00.000' AS DateTime), N'admin', N'Admin', 2, CAST(N'1999-05-13' AS Date), N'Hà Nội', N'0346060827', N'hainn@pcs.vn', 1)
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Account_Id]  DEFAULT (newid()) FOR [Id]
GO
USE [master]
GO
ALTER DATABASE [qlbh_da] SET  READ_WRITE 
GO
