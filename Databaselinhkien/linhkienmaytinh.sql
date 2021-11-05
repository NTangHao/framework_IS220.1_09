-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: landaulinhkien
-- ------------------------------------------------------
-- Server version	8.0.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `binhluan`
--

DROP TABLE IF EXISTS `binhluan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `binhluan` (
  `MABINHLUAN` int NOT NULL,
  `NOIDUNG` varchar(250) DEFAULT NULL,
  `NGAYTAO` datetime DEFAULT NULL,
  `SOLUOT` int DEFAULT NULL,
  PRIMARY KEY (`MABINHLUAN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `binhluan`
--

LOCK TABLES `binhluan` WRITE;
/*!40000 ALTER TABLE `binhluan` DISABLE KEYS */;
INSERT INTO `binhluan` VALUES (1,'Sản phẩm dùng tốt','2021-02-03 00:00:00',1);
/*!40000 ALTER TABLE `binhluan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact` (
  `MALH` int NOT NULL,
  `HOTEN` varchar(250) DEFAULT NULL,
  `EMAIL` varchar(250) DEFAULT NULL,
  `NOIDUNG` varchar(250) DEFAULT NULL,
  `TINHTRANGDON` varchar(250) DEFAULT NULL,
  `NGAYGUI` datetime DEFAULT NULL,
  PRIMARY KEY (`MALH`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
INSERT INTO `contact` VALUES (1,'Duy','duy123@gmail.com','tôi muốn hợp tác','đã gửi',NULL);
/*!40000 ALTER TABLE `contact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctdh`
--

DROP TABLE IF EXISTS `ctdh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ctdh` (
  `MASP` int NOT NULL AUTO_INCREMENT,
  `MADONHANG` int NOT NULL,
  `SOLUONG` int DEFAULT NULL,
  `DONGIA` double DEFAULT NULL,
  PRIMARY KEY (`MASP`,`MADONHANG`),
  KEY `FK_CTDH2` (`MADONHANG`),
  CONSTRAINT `FK_CTDH` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`),
  CONSTRAINT `FK_CTDH2` FOREIGN KEY (`MADONHANG`) REFERENCES `donhang` (`MADONHANG`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctdh`
--

LOCK TABLES `ctdh` WRITE;
/*!40000 ALTER TABLE `ctdh` DISABLE KEYS */;
INSERT INTO `ctdh` VALUES (1,1,2,1450000),(1,2,2,2190000);
/*!40000 ALTER TABLE `ctdh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danhgia`
--

DROP TABLE IF EXISTS `danhgia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danhgia` (
  `MADANHGIA` int NOT NULL,
  `MANGUOIDUNG` int DEFAULT NULL,
  `SOSAO` int DEFAULT NULL,
  PRIMARY KEY (`MADANHGIA`),
  KEY `FK_DANG` (`MANGUOIDUNG`),
  CONSTRAINT `FK_DANG` FOREIGN KEY (`MANGUOIDUNG`) REFERENCES `nguoidung` (`MANGUOIDUNG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `danhgia`
--

LOCK TABLES `danhgia` WRITE;
/*!40000 ALTER TABLE `danhgia` DISABLE KEYS */;
INSERT INTO `danhgia` VALUES (1,5,4);
/*!40000 ALTER TABLE `danhgia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danhmuc`
--

DROP TABLE IF EXISTS `danhmuc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danhmuc` (
  `MADM` int NOT NULL,
  `TENDM` varchar(250) DEFAULT NULL,
  `_MOTA` varchar(250) DEFAULT NULL,
  `HINHANH` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`MADM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `danhmuc`
--

LOCK TABLES `danhmuc` WRITE;
/*!40000 ALTER TABLE `danhmuc` DISABLE KEYS */;
INSERT INTO `danhmuc` VALUES (1,'Ram-Bộ nhớ trong','danh mục ram',NULL);
/*!40000 ALTER TABLE `danhmuc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donhang`
--

DROP TABLE IF EXISTS `donhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donhang` (
  `MADONHANG` int NOT NULL,
  `MAVOUCHER` int DEFAULT NULL,
  `TENDONHANG` varchar(50) DEFAULT NULL,
  `NGAYDAT` datetime DEFAULT NULL,
  `HOTEN` varchar(250) DEFAULT NULL,
  `SDT` varchar(50) DEFAULT NULL,
  `DIACHI` varchar(250) DEFAULT NULL,
  `GIOITINH` varchar(250) DEFAULT NULL,
  `EMAIL` varchar(250) DEFAULT NULL,
  `GHICHU` varchar(300) DEFAULT NULL,
  `TIENSHIP` double DEFAULT NULL,
  `HINHTHUCTHANHTOAN` varchar(50) DEFAULT NULL,
  `TINHTRANGDON` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MADONHANG`),
  KEY `FK_APDUNG` (`MAVOUCHER`),
  CONSTRAINT `FK_APDUNG` FOREIGN KEY (`MAVOUCHER`) REFERENCES `voucher` (`MAVOUCHER`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donhang`
--

LOCK TABLES `donhang` WRITE;
/*!40000 ALTER TABLE `donhang` DISABLE KEYS */;
INSERT INTO `donhang` VALUES (1,1,'SK1234','2021-01-03 00:00:00','Hải','09123141','21/24 Nguyễn Chí Thanh','Nam',NULL,NULL,0,'Trực tiếp','đã nhận'),(2,1,'SK12345','2021-02-03 00:00:00','Long','0123415254','32/42 Chi phương, phú nhuận','Nữ',NULL,NULL,10000,'Trực tiếp','đã nhận');
/*!40000 ALTER TABLE `donhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `giaohang`
--

DROP TABLE IF EXISTS `giaohang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `giaohang` (
  `MAGIAOHANG` int NOT NULL,
  `MADONHANG` int NOT NULL,
  `TENNGUOIGIAO` varchar(250) DEFAULT NULL,
  `NGAYGIAO` datetime DEFAULT NULL,
  `SDT` varchar(50) DEFAULT NULL,
  `XACNHANGIAO` tinyint(1) DEFAULT NULL,
  `TENCONGTY` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAGIAOHANG`),
  KEY `FK_GIAO` (`MADONHANG`),
  CONSTRAINT `FK_GIAO` FOREIGN KEY (`MADONHANG`) REFERENCES `donhang` (`MADONHANG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `giaohang`
--

LOCK TABLES `giaohang` WRITE;
/*!40000 ALTER TABLE `giaohang` DISABLE KEYS */;
INSERT INTO `giaohang` VALUES (1,1,'Phạm Khanh','2021-02-03 00:00:00','0234151',1,'Giao hàng vui'),(2,2,'Duy Phong','2021-02-03 00:00:00','0923415',0,'Giao hàng vui');
/*!40000 ALTER TABLE `giaohang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hinhanh`
--

DROP TABLE IF EXISTS `hinhanh`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hinhanh` (
  `MAANH` int NOT NULL,
  `LINKANH` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAANH`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hinhanh`
--

LOCK TABLES `hinhanh` WRITE;
/*!40000 ALTER TABLE `hinhanh` DISABLE KEYS */;
INSERT INTO `hinhanh` VALUES (1,NULL),(2,NULL),(3,NULL),(4,NULL),(5,NULL),(6,NULL),(7,NULL),(8,NULL),(9,NULL),(10,NULL),(11,NULL),(12,NULL),(13,NULL);
/*!40000 ALTER TABLE `hinhanh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nguoidung`
--

DROP TABLE IF EXISTS `nguoidung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nguoidung` (
  `MANGUOIDUNG` int NOT NULL,
  `MATINTUC` int DEFAULT NULL,
  `MADONHANG` int DEFAULT NULL,
  `MADANHGIA` int DEFAULT NULL,
  `MABINHLUAN` int DEFAULT NULL,
  `MAQUYEN` int DEFAULT NULL,
  `USERNAME` varchar(250) DEFAULT NULL,
  `PASSWORD` varchar(250) DEFAULT NULL,
  `PASSWORD_RESET` varchar(250) DEFAULT NULL,
  `HOTEN` varchar(250) DEFAULT NULL,
  `NGAYSINH` datetime DEFAULT NULL,
  `EMAIL` varchar(250) DEFAULT NULL,
  `NGAYTAO` datetime DEFAULT NULL,
  `NGAYSUA` datetime DEFAULT NULL,
  `VAITRO` varchar(50) DEFAULT NULL,
  `TRANGTHAI` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`MANGUOIDUNG`),
  KEY `FK_VIET` (`MABINHLUAN`),
  KEY `FK_ASSOCIATION_12` (`MATINTUC`),
  KEY `FK_CO` (`MADONHANG`),
  KEY `FK_DANG2` (`MADANHGIA`),
  KEY `FK_PHANQUYEN` (`MAQUYEN`),
  CONSTRAINT `FK_ASSOCIATION_12` FOREIGN KEY (`MATINTUC`) REFERENCES `tintuc` (`MATINTUC`),
  CONSTRAINT `FK_CO` FOREIGN KEY (`MADONHANG`) REFERENCES `donhang` (`MADONHANG`),
  CONSTRAINT `FK_DANG2` FOREIGN KEY (`MADANHGIA`) REFERENCES `danhgia` (`MADANHGIA`),
  CONSTRAINT `FK_PHANQUYEN` FOREIGN KEY (`MAQUYEN`) REFERENCES `vaitronguoidung` (`MAQUYEN`),
  CONSTRAINT `FK_VIET` FOREIGN KEY (`MABINHLUAN`) REFERENCES `binhluan` (`MABINHLUAN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nguoidung`
--

LOCK TABLES `nguoidung` WRITE;
/*!40000 ALTER TABLE `nguoidung` DISABLE KEYS */;
INSERT INTO `nguoidung` VALUES (1,NULL,NULL,NULL,NULL,1,'haohan2801','123',NULL,'Hảo',NULL,NULL,NULL,NULL,'admin',1),(2,NULL,NULL,NULL,NULL,1,'philong','philong',NULL,'Long',NULL,NULL,NULL,NULL,'admin',1),(3,NULL,NULL,NULL,NULL,1,'anhkhoa','anhkhoa',NULL,'Khoa',NULL,NULL,NULL,NULL,'admin',1),(4,NULL,NULL,NULL,NULL,1,'thanhieu','thanhieu',NULL,'Hiếu',NULL,NULL,NULL,NULL,'admin',1),(5,NULL,NULL,NULL,NULL,3,'khach1','123',NULL,'Giang',NULL,NULL,NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `nguoidung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhacungcap`
--

DROP TABLE IF EXISTS `nhacungcap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhacungcap` (
  `MAKHO` int NOT NULL,
  `MASP` int NOT NULL AUTO_INCREMENT,
  `SLNHAP` int DEFAULT NULL,
  `GIA` double DEFAULT NULL,
  PRIMARY KEY (`MAKHO`),
  KEY `FK_CUNGCAP` (`MASP`),
  CONSTRAINT `FK_CUNGCAP` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhacungcap`
--

LOCK TABLES `nhacungcap` WRITE;
/*!40000 ALTER TABLE `nhacungcap` DISABLE KEYS */;
INSERT INTO `nhacungcap` VALUES (1,1,50,1000000),(2,2,50,1000000);
/*!40000 ALTER TABLE `nhacungcap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phanloaidanhmuc`
--

DROP TABLE IF EXISTS `phanloaidanhmuc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phanloaidanhmuc` (
  `MASP` int NOT NULL AUTO_INCREMENT,
  `MADM` int NOT NULL,
  PRIMARY KEY (`MASP`,`MADM`),
  KEY `FK_PHANLOAIDANHMUC2` (`MADM`),
  CONSTRAINT `FK_PHANLOAIDANHMUC` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`),
  CONSTRAINT `FK_PHANLOAIDANHMUC2` FOREIGN KEY (`MADM`) REFERENCES `danhmuc` (`MADM`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phanloaidanhmuc`
--

LOCK TABLES `phanloaidanhmuc` WRITE;
/*!40000 ALTER TABLE `phanloaidanhmuc` DISABLE KEYS */;
INSERT INTO `phanloaidanhmuc` VALUES (1,1),(2,1);
/*!40000 ALTER TABLE `phanloaidanhmuc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sanpham`
--

DROP TABLE IF EXISTS `sanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sanpham` (
  `MASP` int NOT NULL,
  `MAANH` int DEFAULT NULL,
  `TENSP` varchar(250) DEFAULT NULL,
  `CHITIET` varchar(500) DEFAULT NULL,
  `DONGIA` double DEFAULT NULL,
  `GIAKM` double DEFAULT NULL,
  `BAOHANH` int DEFAULT NULL,
  `LUOTXEM` double DEFAULT NULL,
  `NGAYDANG` datetime DEFAULT NULL,
  `SOLUONGTON` int DEFAULT NULL,
  `BANCHAY` tinyint(1) DEFAULT NULL,
  `HINHANH` varchar(150) DEFAULT NULL,
  `TINHTRANGSP` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`MASP`),
  KEY `FK_GOM` (`MAANH`),
  CONSTRAINT `FK_GOM` FOREIGN KEY (`MAANH`) REFERENCES `hinhanh` (`MAANH`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sanpham`
--

LOCK TABLES `sanpham` WRITE;
/*!40000 ALTER TABLE `sanpham` DISABLE KEYS */;
INSERT INTO `sanpham` VALUES (1,1,'(8GB DDR4 1x8GB 3200) RAM Laptop Samsung 8GB 3200 CL22 SODIMM','Thiết kế cổ điển, hiệu năng ấn tượng\nThiết kế cổ điển với hiệu năng cao và chế tạo bằng các thành phần chất lượng. Ram laptop Samsung mang lại hiệu quả sử dụng cao dành cho công việc hàng ngày của bạn.',1450000,1150000,36,NULL,NULL,50,NULL,NULL,'còn'),(2,2,'(16GB DDR4 1x16GB 3200) RAM Laptop Team Group 16GB 3200 SODIMM','Dễ dàng lắp đặt và nâng cấp\nChỉ với vài bước lắp đặt và cài đặt đơn giản, bạn đã có thể tận hưởng hiệu năng của thanh Ram mang lại cho thiết bị của mình.',2190000,2190000,36,NULL,NULL,50,NULL,NULL,'còn');
/*!40000 ALTER TABLE `sanpham` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `thuonghieu`
--

DROP TABLE IF EXISTS `thuonghieu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `thuonghieu` (
  `MATHUONGHIEU` int NOT NULL,
  `MASP` int NOT NULL AUTO_INCREMENT,
  `TENTHUONGHIEU` varchar(150) DEFAULT NULL,
  `HINHANH` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`MATHUONGHIEU`),
  KEY `FK_TRONG` (`MASP`),
  CONSTRAINT `FK_TRONG` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `thuonghieu`
--

LOCK TABLES `thuonghieu` WRITE;
/*!40000 ALTER TABLE `thuonghieu` DISABLE KEYS */;
INSERT INTO `thuonghieu` VALUES (1,1,'Samsung',NULL),(2,2,'TeamGroup',NULL);
/*!40000 ALTER TABLE `thuonghieu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tintuc`
--

DROP TABLE IF EXISTS `tintuc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tintuc` (
  `MATINTUC` int NOT NULL,
  `TIEUDE` varchar(1000) DEFAULT NULL,
  `NOIDUNG` varchar(1000) DEFAULT NULL,
  `NGAYDANG` datetime DEFAULT NULL,
  `NGAYSUA` datetime DEFAULT NULL,
  PRIMARY KEY (`MATINTUC`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tintuc`
--

LOCK TABLES `tintuc` WRITE;
/*!40000 ALTER TABLE `tintuc` DISABLE KEYS */;
INSERT INTO `tintuc` VALUES (1,'Laptop PC quả thật đang có vấn đề với webcam, nhưng cái \'tai thỏ\' của Apple không phải là giải pháp đúng','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.',NULL,NULL),(2,'RTX 3090 vừa mua đã nóng tới 110 độ C, thử mở ra xem thì thấy điều bất ngờ','Một lý do hết sức ngớ ngẩn và cũng không kém phần hài hước đã khiến cho chiếc RTX 3090 Founder Edition gặp tình trạng quá nhiệt.\nMới đây, thành viên antonyjeweet trên Reddit đã chia sẻ một trải nghiệm hết sức bi hài với chiếc RTX 3090 mà anh này vừa mua. Chiếc RTX 3090 mà anh chàng này đặt mua là phiên bản Founder Edition, được NVIDIA sản xuất và bán trực tiếp mà không thông qua bất kỳ nhà sản xuất nào khác. Theo thông lệ, việc tự ý mở các linh kiện điện tử sẽ khiến cho người dùng mất quyền lợi bảo hành. Đây cũng là điều mà NVIDIA đã nói với chủ nhân của chiếc RTX 3090 này ở thời điểm ban đầu. Nhưng sau khi câu chuyện này được đăng tải lên Reddit và thu hút được sự quan tâm lớn từ cộng đồng, NVIDIA đã đổi ý và sẽ vẫn tiếp tục bảo hành chiếc RTX 3090 này trong tương lai nếu có trục trặc xảy ra.',NULL,NULL);
/*!40000 ALTER TABLE `tintuc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaitronguoidung`
--

DROP TABLE IF EXISTS `vaitronguoidung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaitronguoidung` (
  `MAQUYEN` int NOT NULL,
  `TENQUYEN` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAQUYEN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaitronguoidung`
--

LOCK TABLES `vaitronguoidung` WRITE;
/*!40000 ALTER TABLE `vaitronguoidung` DISABLE KEYS */;
INSERT INTO `vaitronguoidung` VALUES (1,'Quản lý'),(2,'Nhân viên'),(3,'Khách hàng');
/*!40000 ALTER TABLE `vaitronguoidung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `voucher`
--

DROP TABLE IF EXISTS `voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `voucher` (
  `MAVOUCHER` int NOT NULL,
  `TENMA` varchar(50) DEFAULT NULL,
  `NGAYBD` date DEFAULT NULL,
  `NGAYKT` date DEFAULT NULL,
  `TYLE` double DEFAULT NULL,
  `TINHTRANG` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAVOUCHER`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `voucher`
--

LOCK TABLES `voucher` WRITE;
/*!40000 ALTER TABLE `voucher` DISABLE KEYS */;
INSERT INTO `voucher` VALUES (1,'RAM10','2021-11-11','2021-11-30',0.1,NULL),(2,'RAM15','2021-11-11','2021-11-30',0.15,NULL);
/*!40000 ALTER TABLE `voucher` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-11-04 20:44:07
