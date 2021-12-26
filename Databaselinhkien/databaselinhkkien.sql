-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: linhkienchinhthuc
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
-- Table structure for table `anhthem`
--

DROP TABLE IF EXISTS `anhthem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anhthem` (
  `MAANH` int NOT NULL AUTO_INCREMENT,
  `MASP` int NOT NULL,
  `LINKANH` varchar(1000) DEFAULT NULL,
  `NGAYTAO` date DEFAULT NULL,
  PRIMARY KEY (`MAANH`),
  KEY `FK_GOM` (`MASP`),
  CONSTRAINT `FK_GOM` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anhthem`
--

LOCK TABLES `anhthem` WRITE;
/*!40000 ALTER TABLE `anhthem` DISABLE KEYS */;
INSERT INTO `anhthem` VALUES (28,10,'hello2.png','2021-11-22'),(29,10,'gearvn.com-products-chuot-gaming-corsair-harpoon-pro-rgb-3_-_copy_7fd87eee70254496b29487d401b15991.png','2021-11-22'),(30,10,'gearvn.com-products-chuot-gaming-corsair-harpoon-pro-rgb-2_-_copy_0dc51dedfb8048b49c0b37a1ada5054f (1).png','2021-11-22');
/*!40000 ALTER TABLE `anhthem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `binhluan`
--

DROP TABLE IF EXISTS `binhluan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `binhluan` (
  `MABINHLUAN` int NOT NULL AUTO_INCREMENT,
  `MANGUOIDUNG` int NOT NULL,
  `NOIDUNG` varchar(250) DEFAULT NULL,
  `NGAYTAO` datetime DEFAULT NULL,
  PRIMARY KEY (`MABINHLUAN`),
  KEY `FK_VIET` (`MANGUOIDUNG`),
  CONSTRAINT `FK_VIET` FOREIGN KEY (`MANGUOIDUNG`) REFERENCES `nguoidung` (`MANGUOIDUNG`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `binhluan`
--

LOCK TABLES `binhluan` WRITE;
/*!40000 ALTER TABLE `binhluan` DISABLE KEYS */;
INSERT INTO `binhluan` VALUES (1,5,'Sản phẩm tốt','2021-05-03 00:00:00'),(2,5,'Sản phẩm tệ','2021-05-04 00:00:00'),(4,1,'sản phẩm chất lượng tốt','2021-12-10 00:08:00');
/*!40000 ALTER TABLE `binhluan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contact` (
  `MALH` int NOT NULL AUTO_INCREMENT,
  `HOTEN` varchar(250) DEFAULT NULL,
  `EMAIL` varchar(250) DEFAULT NULL,
  `NOIDUNG` varchar(250) DEFAULT NULL,
  `TINHTRANGDON` varchar(250) DEFAULT NULL,
  `NGAYGUI` datetime DEFAULT NULL,
  PRIMARY KEY (`MALH`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contact`
--

LOCK TABLES `contact` WRITE;
/*!40000 ALTER TABLE `contact` DISABLE KEYS */;
INSERT INTO `contact` VALUES (1,'Errik','errik123@gmail.com','Hợp tác làm ăn','đã nhận','2021-12-23 00:00:00'),(2,'Perk','Perk123@gmail.com','Hợp tác làm ăn','đã nhận','2021-12-23 00:00:00'),(8,'Hảo','fckmefreeifyouknowmypass@gmail.com','Hợp đồng quảng cáo','đã nhận','2021-12-25 11:54:18');
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
  `DONGIA` double DEFAULT NULL,
  `SOLUONG` int DEFAULT NULL,
  `TONGTIEN` double DEFAULT NULL,
  `NGAYTAO` date DEFAULT NULL,
  PRIMARY KEY (`MASP`,`MADONHANG`),
  KEY `FK_CTDH2` (`MADONHANG`),
  CONSTRAINT `FK_CTDH` FOREIGN KEY (`MASP`) REFERENCES `sanpham` (`MASP`),
  CONSTRAINT `FK_CTDH2` FOREIGN KEY (`MADONHANG`) REFERENCES `donhang` (`MADONHANG`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctdh`
--

LOCK TABLES `ctdh` WRITE;
/*!40000 ALTER TABLE `ctdh` DISABLE KEYS */;
INSERT INTO `ctdh` VALUES (23,13,2392000,3,7176000,'2021-02-16'),(25,12,73500000,3,73500000,'2021-12-16'),(26,7,4311000,1,13302000,'2021-11-15'),(26,17,4311000,3,16893000,'2021-11-18'),(27,7,3960000,1,13302000,'2021-12-15'),(27,17,3960000,1,16893000,'2021-12-18'),(28,19,4401000,1,22236000,'2021-12-21'),(29,9,5271200,1,10302200,'2021-05-15'),(29,10,5271200,1,10302200,'2021-12-15'),(29,16,5271200,1,10302200,'2021-04-18'),(29,18,5271200,3,12650879.9528718,'2021-12-18'),(29,21,5271200,1,8241759.969297051,'2021-12-24'),(30,4,5031000,1,5031000,'2021-12-15'),(30,7,5031000,1,13302000,'2021-12-15'),(30,9,5031000,1,10302200,'2021-12-15'),(30,10,5031000,1,10302200,'2021-12-15'),(30,11,5031000,1,5031000,'2021-12-16'),(30,14,5031000,1,2515500,'2021-12-18'),(30,15,5031000,3,12074399.955019355,'2021-12-18'),(30,16,5031000,1,10302200,'2021-12-18'),(30,19,5031000,1,22236000,'2021-12-21'),(30,21,5031000,1,8241759.969297051,'2021-12-24'),(31,19,4268000,3,22236000,'2021-12-21'),(31,20,4268000,10,42680000,'2021-12-24');
/*!40000 ALTER TABLE `ctdh` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danhgia`
--

DROP TABLE IF EXISTS `danhgia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danhgia` (
  `MADANHGIA` int NOT NULL AUTO_INCREMENT,
  `MANGUOIDUNG` int DEFAULT NULL,
  `SOSAO` int DEFAULT NULL,
  `NGAYDANHGIA` date DEFAULT NULL,
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
INSERT INTO `danhgia` VALUES (1,5,4,'2021-05-11'),(2,5,2,'2021-12-11');
/*!40000 ALTER TABLE `danhgia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `danhmuc`
--

DROP TABLE IF EXISTS `danhmuc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `danhmuc` (
  `MADM` int NOT NULL AUTO_INCREMENT,
  `TENDM` varchar(250) DEFAULT NULL,
  `_MOTA` varchar(250) DEFAULT NULL,
  `HINHANH` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`MADM`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `danhmuc`
--

LOCK TABLES `danhmuc` WRITE;
/*!40000 ALTER TABLE `danhmuc` DISABLE KEYS */;
INSERT INTO `danhmuc` VALUES (1,'Ram-linh kiện máy tính','sd','d'),(2,'Bàn phím','d','gearvn.com-products-ban-phim-leopold-fc660mpd-light-pink-1_9965ef1f8ff5406fbe04d4e811bf5e41.jpg'),(3,'Chuột','d','f'),(4,'Ổ cứng máy tính','d','f'),(5,'Tai nghe','a','s'),(7,'CPU- Bộ vi xử lý','s','s'),(8,'Màn hình máy tính','Màn hình','samsung_lc24f390_gearvn_bd3d2840b8e249ca9f87c43df8eaa053.jpg');
/*!40000 ALTER TABLE `danhmuc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donhang`
--

DROP TABLE IF EXISTS `donhang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donhang` (
  `MADONHANG` int NOT NULL AUTO_INCREMENT,
  `MAVOUCHER` int DEFAULT NULL,
  `MAGIAOHANG` int DEFAULT NULL,
  `MANGUOIDUNG` int DEFAULT NULL,
  `NGAYDAT` datetime DEFAULT NULL,
  `NGAYSHIP` datetime DEFAULT NULL,
  `TONGDON` double DEFAULT NULL,
  `HOTEN` varchar(250) DEFAULT NULL,
  `SDT` varchar(50) DEFAULT NULL,
  `DIACHI` varchar(250) DEFAULT NULL,
  `GIOITINH` varchar(250) DEFAULT NULL,
  `EMAIL` varchar(250) DEFAULT NULL,
  `GHICHU` varchar(300) DEFAULT NULL,
  `SOTHEODOI` varchar(50) DEFAULT NULL,
  `VANCHUYEN` varchar(50) DEFAULT NULL,
  `TINHTRANGTHANHTOAN` varchar(100) DEFAULT NULL,
  `NGAYTHANHTOAN` datetime DEFAULT NULL,
  `NGAYHETHAN` datetime DEFAULT NULL,
  `KHONGDANGKY` tinyint DEFAULT NULL,
  `HOMEFLAG` bit(1) DEFAULT NULL,
  `IDTRANSACTION` int DEFAULT NULL,
  `THANHPHO` varchar(200) DEFAULT NULL,
  `QUAN` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`MADONHANG`),
  KEY `FK_CO` (`MANGUOIDUNG`),
  KEY `FK_GIAO` (`MAGIAOHANG`),
  KEY `FK_APDUNG` (`MAVOUCHER`),
  KEY `FK_TRANSACTION_idx` (`IDTRANSACTION`),
  CONSTRAINT `FK_APDUNG` FOREIGN KEY (`MAVOUCHER`) REFERENCES `voucher` (`MAVOUCHER`),
  CONSTRAINT `FK_CO` FOREIGN KEY (`MANGUOIDUNG`) REFERENCES `nguoidung` (`MANGUOIDUNG`),
  CONSTRAINT `FK_GIAO` FOREIGN KEY (`MAGIAOHANG`) REFERENCES `giaohang` (`MAGIAOHANG`),
  CONSTRAINT `FK_TRANSACTION` FOREIGN KEY (`IDTRANSACTION`) REFERENCES `transaction` (`IDTRANSACTION`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donhang`
--

LOCK TABLES `donhang` WRITE;
/*!40000 ALTER TABLE `donhang` DISABLE KEYS */;
INSERT INTO `donhang` VALUES (4,NULL,NULL,34,'2021-12-15 22:26:47',NULL,5031000,'hảo ','09123141',NULL,NULL,NULL,NULL,NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,4,NULL,NULL),(7,NULL,NULL,34,'2021-12-15 22:52:00',NULL,13302000,'hảo ','09123141',NULL,NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,4,NULL,NULL),(8,NULL,NULL,34,'2021-12-15 22:59:43',NULL,8991000,'hảo ','09123141',NULL,NULL,NULL,NULL,NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,NULL,NULL),(9,NULL,NULL,34,'2021-11-15 23:14:10',NULL,10302200,'hảo ','09123141','bà rịa 28',NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,1,'Đắk Lắk','Thành phố Vũng Tàu'),(10,NULL,NULL,34,'2021-02-15 23:22:28',NULL,10302200,'hảo ','09123141','kiên giang',NULL,NULL,'giao hàng nhanh nhất có thể',NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,'Bến Tre','Huyện Gia Bình'),(11,NULL,NULL,NULL,'2021-12-16 08:57:29',NULL,5031000,'thanh trần','11111','long khánh',NULL,NULL,'giao test',NULL,NULL,'Đã thanh toán',NULL,NULL,1,NULL,1,'Bắc Ninh','Thị xã Long Khánh'),(12,NULL,NULL,34,'2021-10-16 21:49:33',NULL,73500000,'hảo ','09123141','Bình định 28',NULL,NULL,'giao nhanh',NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,1,'Đồng Nai','Huyện An Nhơn'),(13,NULL,NULL,34,'2021-12-16 21:52:51',NULL,7176000,'hảo ','09123141','bà rịa 28',NULL,NULL,NULL,NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,'Bình Định','Huyện An Nhơn'),(14,1,NULL,34,'2021-12-18 15:04:15',NULL,2515500,'hảo ','09123141','bà rịa 28',NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,1,'Gia Lai','Huyện Mang Yang'),(15,3,NULL,34,'2021-12-18 17:34:11',NULL,12074399.955019355,'hảo ','09123141','hẻm 30 , p Bình hưng hòa',NULL,NULL,NULL,NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(16,NULL,NULL,35,'2021-12-18 20:47:27',NULL,10302200,'khoa','0928912812','hẻm 30 , p Bình hưng hòa',NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(17,NULL,NULL,35,'2021-12-18 20:49:29',NULL,16893000,'khoa','0928912812','hẻm 30 , p Bình hưng hòa',NULL,NULL,NULL,NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(18,3,NULL,NULL,'2021-09-18 21:45:27',NULL,12650879.9528718,'Bình','0589952172','hẻm 30 , p Bình hưng hòa',NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,1,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(19,NULL,NULL,35,'2021-12-21 14:52:39',NULL,22236000,'khoa','0928912812','hẻm 30 , p Bình hưng hòa',NULL,NULL,'không có',NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,3,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(20,NULL,NULL,35,'2021-12-24 11:14:01',NULL,42680000,'khoa','0928912812','12/23 Hùng Vương',NULL,NULL,NULL,NULL,NULL,'Đã thanh toán',NULL,NULL,NULL,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân'),(21,3,NULL,34,'2021-12-24 11:40:30',NULL,8241759.969297051,'hảo ','09123141','hẻm 30 , p Bình hưng hòa',NULL,NULL,'có mã giảm giá',NULL,NULL,'Chưa thanh toán',NULL,NULL,NULL,NULL,1,'Thành phố Hồ Chí Minh','Quận Bình Tân');
/*!40000 ALTER TABLE `donhang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `giaohang`
--

DROP TABLE IF EXISTS `giaohang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `giaohang` (
  `MAGIAOHANG` int NOT NULL AUTO_INCREMENT,
  `TENNGUOIGIAO` varchar(250) DEFAULT NULL,
  `NGAYGIAO` datetime DEFAULT NULL,
  `SDT` varchar(50) DEFAULT NULL,
  `XACNHAN` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MAGIAOHANG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `giaohang`
--

LOCK TABLES `giaohang` WRITE;
/*!40000 ALTER TABLE `giaohang` DISABLE KEYS */;
INSERT INTO `giaohang` VALUES (1,'Huy Cận','2021-11-12 00:00:00','092341','đã giao'),(2,'Gia Vân','2021-11-24 00:00:00','0912341','chưa giao');
/*!40000 ALTER TABLE `giaohang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nguoidung`
--

DROP TABLE IF EXISTS `nguoidung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nguoidung` (
  `MANGUOIDUNG` int NOT NULL AUTO_INCREMENT,
  `MADANHGIA` int DEFAULT NULL,
  `MAQUYEN` int NOT NULL,
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
  `DIENTHOAI` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MANGUOIDUNG`),
  KEY `FK_DANG2` (`MADANHGIA`),
  KEY `FK_PHANQUYEN` (`MAQUYEN`),
  CONSTRAINT `FK_DANG2` FOREIGN KEY (`MADANHGIA`) REFERENCES `danhgia` (`MADANHGIA`),
  CONSTRAINT `FK_PHANQUYEN` FOREIGN KEY (`MAQUYEN`) REFERENCES `vaitronguoidung` (`MAQUYEN`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nguoidung`
--

LOCK TABLES `nguoidung` WRITE;
/*!40000 ALTER TABLE `nguoidung` DISABLE KEYS */;
INSERT INTO `nguoidung` VALUES (1,NULL,1,'haohan2801','123',NULL,'Tăng Hảo','2001-01-28 00:00:00','haohan123@gmail.com','2021-11-11 00:00:00',NULL,'admin',1,NULL),(3,1,1,'anhkhoa','anhkhoa',NULL,'Anh Khoa Nguyễn','2001-01-23 00:00:00','haas123@gmail.com','2021-11-20 00:00:00',NULL,'admin',1,NULL),(5,1,3,'khanhthanh','123',NULL,'Thành2',NULL,'haohan123@gmail.com',NULL,NULL,NULL,NULL,NULL),(6,NULL,3,'giahuy','123',NULL,'Gia huy',NULL,'huy123@gnail.com','2021-12-02 00:00:00',NULL,'khách  hàng',1,NULL),(7,1,2,'Peter ','123',NULL,'PeterNguyen','2015-02-03 15:55:00','Peter123@gmail.com','2021-11-04 15:56:00',NULL,'Nhân viên bán hàng',1,NULL),(11,1,3,'VanB','123',NULL,NULL,'2021-11-29 20:24:00',NULL,'2021-11-03 20:24:00',NULL,'khách',1,NULL),(12,1,3,'VanC','123',NULL,'VanC',NULL,NULL,NULL,NULL,'khách',1,NULL),(13,1,3,'VanD','VanD',NULL,'VanD','2021-11-10 20:25:00',NULL,'2021-12-01 20:25:00',NULL,NULL,1,NULL),(15,NULL,3,'daylatest','test123',NULL,'test123','2021-11-08 14:26:00','concac@gmail.com','2021-11-23 14:26:29',NULL,'khách hàng',1,NULL),(16,NULL,3,'asd','sdf',NULL,'asdfasdg','2021-11-23 14:38:00','sadfasd','2021-11-23 14:38:55',NULL,'khách hàng',1,NULL),(17,NULL,3,'toaoi','toaoi',NULL,'toaoi','2021-11-12 14:55:00','toaoidsf','2021-11-23 14:55:59',NULL,'khách hàng',1,'12312415'),(25,NULL,3,'hao','hao',NULL,'Hảozz',NULL,'Hao@gmail.com',NULL,NULL,NULL,NULL,'111'),(34,NULL,3,NULL,'26eaf26d687fec574a1e06d2456bba71',NULL,'hảo ',NULL,'tanghao@gmail.com','2021-12-12 17:15:23',NULL,NULL,1,'09123141'),(35,NULL,3,NULL,'26eaf26d687fec574a1e06d2456bba71',NULL,'khoa đỗ',NULL,'khoale@gmail.com','2021-12-18 20:38:16','2021-12-25 16:07:55',NULL,1,'09123131');
/*!40000 ALTER TABLE `nguoidung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhacungcap`
--

DROP TABLE IF EXISTS `nhacungcap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhacungcap` (
  `MANCC` int NOT NULL AUTO_INCREMENT,
  `TENNCC` varchar(500) DEFAULT NULL,
  `DIACHI` varchar(500) DEFAULT NULL,
  `THANHPHO` varchar(450) DEFAULT NULL,
  `SDT` varchar(50) DEFAULT NULL,
  `TINHTRANGXACNHAN` tinyint DEFAULT NULL,
  PRIMARY KEY (`MANCC`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhacungcap`
--

LOCK TABLES `nhacungcap` WRITE;
/*!40000 ALTER TABLE `nhacungcap` DISABLE KEYS */;
INSERT INTO `nhacungcap` VALUES (1,'GearVn','1000000','Hồ Chí Minh','091231414',1),(2,'PC Long Khánh','87/13 Phú Nhuận','Hồ Chí Minh','0912345154',1),(3,'10','500000',NULL,NULL,NULL);
/*!40000 ALTER TABLE `nhacungcap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sanpham`
--

DROP TABLE IF EXISTS `sanpham`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sanpham` (
  `MASP` int NOT NULL AUTO_INCREMENT,
  `MATHUONGHIEU` int DEFAULT NULL,
  `MADM` int DEFAULT NULL,
  `TENSP` varchar(500) DEFAULT NULL,
  `CHITIET` longtext,
  `DONGIA` double DEFAULT NULL,
  `GIAKM` double DEFAULT NULL,
  `BAOHANH` int DEFAULT NULL,
  `LUOTXEM` double DEFAULT NULL,
  `NGAYDANG` datetime DEFAULT NULL,
  `SOLUONG` int DEFAULT NULL,
  `BANCHAY` tinyint(1) DEFAULT NULL,
  `HINHANH` varchar(1000) DEFAULT NULL,
  `TINHTRANGSP` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`MASP`),
  KEY `FK_PHANLOAIDANHMUC` (`MADM`),
  KEY `FK_TRONG` (`MATHUONGHIEU`),
  CONSTRAINT `FK_PHANLOAIDANHMUC` FOREIGN KEY (`MADM`) REFERENCES `danhmuc` (`MADM`),
  CONSTRAINT `FK_TRONG` FOREIGN KEY (`MATHUONGHIEU`) REFERENCES `thuonghieu` (`MATHUONGHIEU`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sanpham`
--

LOCK TABLES `sanpham` WRITE;
/*!40000 ALTER TABLE `sanpham` DISABLE KEYS */;
INSERT INTO `sanpham` VALUES (1,1,1,'(8GB DDR4 1x8GB 3200) RAM Laptop Samsung 8GB 3200 CL22 SODIMM','Thiết kế cổ điển, hiệu năng ấn tượngThiết kế cổ điển với hiệu năng cao và chế tạo bằng các thành phần chất lượng. Ram laptop Samsung mang lại hiệu quả sử dụng cao dành cho công việc hàng ngày của bạn.Một hệ thống tối ưu là một hệ thống vận hành mượt mà và ổn định. Nhà sản xuất cung cấp một bus ram cao lên đến 3200Mhz đem lại hiệu quả sử dụng rất tốt. Các tác vụ sử dụng một cách mượt mà với độ trễ thấp và tính ổn định lâu dài.',1450000,0.05,36,NULL,NULL,50,NULL,'samsung_sodimm_1_c5019814158b4007acdc1cf4570cdc34.jpg','còn hàng'),(5,5,2,'Bàn phím Leopold FC660MPD Light Pink','Keycap PBT DoubleshotVới chất liệu nhựa keycap PBT Doubleshot dày 1.5mm cao cấp nhất hiện nay góp phần tăng cảm giác thoải mái khi gõ phím cùng với chất lượng không hao mòn bởi thời gian.Độ ổn định cao cấp với khung CHERRY StabilizerVới các phím Shift, Spacebar, Enter và Backspace sẽ luôn luôn ở trạng thái cân bằng cho dù bạn có ấn ở góc độ nào đi chăng nữa. Với khung trục ổn định không hề bị ảnh hưởng bởi thời gian. Chắc chắn sẽ cực kì hữu dụng!',2750000,0.05,24,NULL,NULL,50,NULL,'gearvn.com-products-ban-phim-leopold-fc660mpd-light-pink-1_9965ef1f8ff5406fbe04d4e811bf5e41.jpg','còn hàng'),(10,1,3,'Chuột Harpoon RGB','dfg',870000,0.03,12,3,'2021-11-20 14:46:56',30,1,'gearvn.com-products-chuot-gaming-corsair-harpoon-pro-rgb-1_-_copy_8fd71a20c88e4d5ba2231e87ca404bdf.png','còn hàng'),(11,3,3,'Chuột Corsair Katar Pro Ultra Light','Chuột Corsair Katar Pro Ultra Light siêu nhẹMột trong những dòng chuột gaming giá rẻ với trọng lượng chỉ 69g, chuột Corsair Katar Pro Ultra Light cực kỳ nhẹ và thao tác nhanh nhạy trong nhiều giờ chơi game FPS hoặc MOBA với nhịp độ trận đấu nhanh. Ở hình dạng đối xứng, nhỏ gọn làm cho dòng chuột Katar Pro Ultra Light đến từ Corsair trở nên tuyệt vời cho các kiểu cầm vuốt và đầu ngón tay.Trang bị cảm biến PixArt 12.400 DPIĐược hãng sản xuất hỗ trợ trạng bị cảm biến quang học PixArt 12.400 DPI tùy chỉnh cung cấp khả năng theo dõi với độ chính xác cao mà bạn cần để chiến thắng trò chơi.Điều khiển thông minh, tùy chỉnh không giới hạnSử dụng tùy chỉnh bằng phần mềm CORSAIR iCUE cho phép điều khiển ánh sáng RGB động sống động, lập trình macro tinh vi và đồng bộ hóa ánh sáng toàn hệ thống trên các thiết bị ngoại vi.Đồng thời, đây là một trong những dòng chuột chơi game sẽ mang đến lợi thế trong trò chơi với nút và macro tùy chỉnh.',400000,0.05,12,1,'2021-11-21 21:15:22',50,NULL,'gearvn-chuot-corsair-katar-pro-ultra-light-666_86e8617a50a747fd8e6ab39049b28707.png','còn hàng'),(12,3,3,'Chuột Corsair M55 RGB Pro White','Nhà sản xuất	CorsairModel	CH-9308111-APDPI	12400 DPICảm biến	Quang học PMW3327Đèn nền	2 vùng RGBBộ nhớ Profile	CóSwitch chuột	OmronĐộ bền nút chuột	50 triệu nhấp chuộtSố nút	8Trọng lượng	86gDây cáp	1.8m dây cao su chống rốiPhần mềm CUE	Hỗ trợ iCUETần số phản hồi	Có thể tùy chỉnh:1000Hz /500Hz /250Hz /125HzGame Type	FPS, MOBABảo hành	24 tháng',1150000,0.06,12,NULL,'2021-11-21 21:22:04',50,1,'corsair-m55-rgb-gearvn-1_ae4723703730444899cb2c6c13e8ad1b.jpg','còn hàng'),(13,3,3,'Chuột Corsair Katar Pro Wireless','Corsair Katar Pro Wireless với công nghệ Slipstream CORSAIR\r\nTận hưởng sự nhanh nhạy và tiện lợi với công nghệ không dây Slipstream CORSAIR siêu nhanh, dưới 1ms hoặc kết nối với nhiều loại thiết bị có Bluetooth® độ trễ thấp được cấp nguồn với chỉ một pin AA.\r\nChuột Corsair Katar Pro Ultra Light siêu nhẹ\r\nMột trong những dòng chuột gaming giá rẻ với trọng lượng chỉ 69g, chuột Corsair Katar Pro Ultra Light cực kỳ nhẹ và thao tác nhanh nhạy trong nhiều giờ chơi game FPS hoặc MOBA với nhịp độ trận đấu nhanh. \r\n\r\nỞ hình dạng đối xứng, nhỏ gọn làm cho dòng chuột Katar Pro Ultra Light đến từ Corsair trở nên tuyệt vời cho các kiểu cầm vuốt và đầu ngón tay.\r\nTrang bị cảm biến PixArt 10000DPI\r\nCảm biến PMW3325 của PixArt cung cấp khả năng theo dõi chính xác và độ chính xác cao mà bạn cần để chiến thắng.\r\n\r\nĐiều khiển thông minh, tùy chỉnh không giới hạn',870000,0.2,12,NULL,'2021-11-21 21:34:00',15,1,'gearvn-chuot-corsair-katar-pro-wireless-666_23333dfd6ea64129b9627324097a4955.png','còn hàng'),(14,3,3,'Chuột gaming Corsair Glaive RGB Pro Aluminum','Chuột Corsair Glaive Pro\r\nThiết kế công thái học dành cho người thuận tay phải\r\nMắt cảm biến PMW3391 cho hiệu năng cao\r\nĐộ phân giải : 18000 DPI\r\nSwitch Omron độ bền 50 triệu lần nhấn\r\nLed RGB 16.8 triệu màu\r\nThiết kế Module tiện lời cho việc điều chình kiểu cầm chuột và thẩm mỹ',1739000,0,12,NULL,'2021-11-21 21:36:11',12,NULL,'48441_chuot_corsair_glaive_pro_rgb_black_pmw3391_0001_1.jpg','còn hàng'),(15,3,3,'Chuột Corsair IronClaw RGB Wireless','Yếu tố hình thức\r\nHình dạng đường viền được điêu khắc đặc biệt cho bàn tay lớn hơn, mang lại cho bạn sự thoải mái khi sử dụng.\r\nCảm biến \"xịn xò\" \r\nCảm biến quang học 18.000 DPI gốc Pixart PMW3391 tùy chỉnh cung cấp khả năng theo dõi siêu chính xác, có thể điều chỉnh theo các bước độ phân giải 1 DPI để tùy chỉnh độ nhạy tổng thể.\r\nCông nghệ không dây Slipstream\r\nĐi vào làn đường nhanh với SLIPSTREAM WIRELESS. Trải nghiệm tốc độ không dây cấp độ chơi game siêu nhanh và thiết lập ngoài luồng đơn giản.',2100000,0.1,24,NULL,'2021-11-21 21:38:15',12,1,'gearvn_corsair_ironclawwireless_1_8f3839ce11c64de19a278c31fa2d5c21.png','còn hàng'),(18,6,7,'AMD Athlon 3000G / 5MB / 3.5GHz / 2 nhân 4 luồng / AM4','Về cơ bản chúng ta sẽ có CPU 2 nhân/ 4 luồng hoạt động ở mức độ xung nhịp 3.5GHz (tăng 300MHz so với thế hệ trước), dung lượng L3 Cache là 4MB và được tích hợp kèm iGPU Radeon Vega 3. iGPU Radeon Vega 3 có 3 NGCUs (192 luồng xử lý) và tốc độ xung nhịp hoạt động từ 100MHz tới 1.1GHz. Với iGPU này các bạn có thể chơi tốt được các tựa game E-sport với mức FPS cao.\r\nBộ xử lý AMD Athlon ™ mới, tích hợp công nghệ xử lý đồ họa Radeon ™ Vega tiên tiến cho người dùng hàng ngày. Bộ xử lý cao cấp nhất kết hợp với card đồ họa tích hợp Radeon Vega mà AMD từng tạo ra dành cho người dùng, đã nhận được các đánh giá cao về khả năng phản hồi nhanh chóng, cùng với kiến trúc bộ xử lý tiên tiến thích hợp cho các tác vụ thường ngày của bạn.\r\nVới CPU AMD Athlon 3000G được thiết kế tối ưu cho việc chơi game, người dùng thỏa sức lướt web mượt mà và trải nghiệm khả năng xử lý các video chất lượng cao mà không bị giật lag nhờ Đồ họa Radeon™ tích hợp. Nhờ đó mà người dùng có thể chiêm ngưỡng các tựa game hot hiện nay như Liên Minh Huyền Thoại, Fifa Online,... ở độ phân giải 720p. Đồng thời chất lượng được nâng cao hơn nhờ việc kết hợp với màn hình hỗ trợ FreeSync đem đến khả năng chống xé hình hoàn hảo, yên tâm với các tựa game chuyển động nhanh như game thể thao, game bắn súng,...\r\n',1690000,0.2,36,NULL,'2021-11-29 09:49:06',12,1,'vn-cpu-amd-athlon-3000g-3-5ghz-2-nhan-4-luong-radeon-vega-3-graphics-6_e3613c9098ec457190a48ecf2aeff9f5.jpg','còn hàng'),(19,6,7,'AMD Ryzen 5 3400G / 6MB / 4.2GHz / 4 nhân 8 luồng / AM4','Bạn đang tìm kiếm một con chip có hiệu năng cao / giá thành thì đây là con chip dành cho bạn. AMD Ryzen 5 3400G được thiết kế dựa trên kiến trúc Zen+ và tiến trình 12nm giúp cải thiện xung nhịp và nhiệt độ so với thế hệ cũ. \r\n\r\nAMD Ryzen 5 3400G được mở khóa ép xung ở mức 4.2GHz, cao hơn 8% so với 2400G có mức xung 3.9GHz. Với 4 nhân 8 luồng, ở xung nhịp cơ bản 3.7GHz nó dễ dàng xử lý các tác vụ văn phòng cùng gaming esports nhẹ nhàng.\r\nĐồ họa tích hợp đi kèm mạnh mẽ, xử lý tốt các game esports tại thời điểm hiện tại 2021\r\nAPU tích hợp đi kèm là VGA Radeon™ RX Vega 11 Graphics là một chip đồ họa đủ mạnh mẽ để thoải mái chơi các game Esport như Liên minh huyền thoại với mức FPS khá cao trên 100 FPS với hệ thống có 8GB Ram đi kèm. Lưu ý là hệ thống này chỉ phát huy mạnh mẽ khi Ram của máy bạn từ 8GB cho đến 16GB Ram là đẹp nhất. Thời buổi bão giá VGA mà bạn muốn xây dựng một hệ thống mới đủ sức chơi những game esports như Liên minh huyền thoại, CS:GO hay GTA V ở mức thiết lập hợp lý thì giải pháp này cũng là một ý tưởng không tồi trong lúc chờ giá VGA hạ nhiệt.\r\nHình ảnh test game Liên minh huyền thoại ở mức FullHD với thiết lập đồ họa cao nhất cùng 8GB Ram\r\n\r\nGame rất đẹp và dễ dàng vượt qua mốc 100 FPS, quá chất lượng với APU VGA Radeon™ RX Vega 11 Graphics.\r\nLời kết:\r\nCông nghệ APU của AMD thật sự rất ấn tượng với hiệu năng xử lý đồ họa tiên tiến, giúp bạn thoải mái chơi những tựa game esports yêu thích của mình mà chưa cần gắn card đồ họa.Tất nhiên nếu sau này cần bạn vẫn có thể nâng cấp lên những chiếc card cao cấp để trải nghiệm làm việc cũng như gaming hứng thú hơn. Còn tại thời điểm hiện tại CPU AMD Ryzen 5 3400G /6MB /3.7GHz /4 nhân 8 luồng thực sự rất đáng để đầu tư và trải nghiệm.',4590000,0.2,36,NULL,'2021-11-29 09:52:09',12,1,'ryzen_5_3400g_gearvn__4e97afc81deb458db0731dceac013ff1 (1).png','còn hàng'),(20,7,4,'CPU Intel Xeon Bronze 3106 / 11MB / 1.7GHz / 8 nhân 8 luồng / LGA 3647','CPU Intel Xeon Bronze 3106\r\nCPU Intel Xeon Bronze 3106 là dòng CPU chuyên nghiệp dành cho máy chủ của các doanh nghiệp vừa và nhỏ.\r\n\r\nSản phẩm giúp đảm bảo cho dữ liệu của đối tượng này được bảo vệ tốt hơn với chức năng được nâng cao nhờ phần cứng, cũng như khả năng sử dụng được vào mọi thời điểm.',8990000,0.2,36,NULL,'2021-11-29 09:53:25',12,1,'gearvn-intel-xeon-bronze-3106_a8e42658e15a4d629e12388002200800.jpg','còn hàng'),(21,6,7,'AMD Ryzen Threadripper PRO 3955WX / Socket sWRX80 / 64MB / 4.3Ghz / 16 nhân 32 luồng','Đánh giá AMD Ryzen Threadripper PRO 3955WX\r\nAMD Ryzen Threadripper Pro 3000 là dòng CPU dành cho máy trạm mạnh mẽ nhất hiện nay. Dòng AMD Ryzen Threadripper Pro có mọi thứ cơ bản mà dòng Threadripper trước đó đã có và nâng tầm tất cả lên một đẳng cấp khác bằng cách mở khóa hệ số nhân, hỗ trợ ép xung cho máy trạm, nâng cấp dung lượng bộ nhớ cao hơn và khả năng kết nối thiết bị ngoại vi.\r\nBứt phá mọi giới hạn với AMD, dòng Ryzen Threadripper Pro trực tiếp đọ sức với dòng Xeon-W của Intel trong phân khúc máy trạm với dòng sản phẩm của AMD cung cấp gấp đôi số lõi / luồng, gấp đôi số làn PCIe và hỗ trợ bộ nhớ 8 kênh.\r\n\r\nMáy trạm chuyên nghiệp đầu tiên hỗ trợ PCIe Gen 4\r\n128 làn PCIe Gen4 với băng thông nhanh gấp 2,5 lần so với thế hệ trước\r\nBăng thông bộ nhớ hỗ trợ 8 kênh ECC RDIMM, LRDIMM và UDIMM DDR4-3200\r\nHỗ trợ RAM lên đến 2TB\r\nQua rồi thời chỉ còn vài lựa chọn trong phân khúc xây dựng bộ máy pc cao cấp, AMD hiện tại đã có những option khiến bạn không thể chối từ. Những đại diện của Ryzen Threadripper Pro mang lại hiệu suất đáng kinh ngạc ở mọi phân khúc trong những bài kiểm tra khắc nghiệt nhất.',30000000,0.4,36,NULL,'2021-11-29 09:55:20',12,1,'21728329_threadripper_pro_wof_3d_left_25b0a119dba046b48a288c8a0355b829.png','còn hàng'),(22,7,7,'Intel Core i7 10700 / 16MB / 4.8GHz / 8 Nhân 16 Luồng / LGA 1200','Đánh giá chi tiết Intel Core i7 10700 / 16MB / 2.9GHz / 8 Nhân 16 Luồng / LGA 1200\r\nCPU Intel Core i7-10700 là bộ vi xử lý mới nhất từ nhà Intel thuộc dòng Comet Lake. Sở hữu những thông số ấn tượng cùng khả năng ép xung, i7-10700 xứng đáng là một trong những chiếc CPU Gen 10 tốt nhất.\r\nCPU Intel Core i7-10700 được sản xuất dựa trên tiến trình 14nm đem lại cho bộ vi xử lý sức mạnh ấn tượng. Với 8 nhân 16 luồng đi kèm với tần số cơ bản là 2.90 GHz và turbo boost lên đến 4.80 GHz, i7-10700 đem lại tốc độ xử lý tác vụ vô cùng nhanh và khả năng hoạt động đa nhiệm mượt mà khi học tập, làm việc và giải trí.\r\nntel Core i7-10700 sở hữu nhân đồ họa tích hợp Intel UHD Graphics 630 được thiết kế trên kiến trúc Iris Plus mới nhất. Tần số cơ sở đạt 350 MHz và khi turbo đạt 1.20 GHz đem lại cho Intel Core i7-10700 khả năng xử lý đồ họa thông minh, đỉnh cao cùng tốc độ nhanh hơn.',9600000,0.3,36,2,'2021-11-29 09:57:08',12,1,'intel-core-i7_ce12bc05c12845ceb6e6cd76e14d33a1.jpg','còn hàng'),(23,7,7,'Intel Core i3 10100F / 6MB / 4.3GHZ / 4 nhân 8 luồng / LGA 1200','CPU Intel Core i3-10100F / 6MB / 4.3GHZ / 4 nhân 8 luồng, chiếc CPU 10th Gen mới nhất từ đội xanh Intel. Sở hữ hiệu năng mạnh mẽ cùng mức giá hợp lý từ việc không trang bị GPU tích hợp, i3-10100F trở thành kẻ thách thức với những chiếc CPU giá rẻ cùng phân khúc hiện nay, đặc biệt là CPU AMD Ryzen 3 3100.\r\n\r\nIntel Core i3-10100F sở hữu hiệu năng mạnh mẽ\r\nIntel Core i3-10100F sở hữu mức xung nhịp cơ bản 3.6 GHz, turbo boost đạt 4.3 GHz cùng với 4 nhân 8 luồng. Với sức mạnh vượt trội cùng công nghệ siêu phân luồng (Hyper-Threading), i3-10100F thực sự là cú hit lớn trong làng CPU. Sức mạnh của i3-10100F có thể sánh ngang với người tiền nhiệm i7-7700.\r\nIntel Core i3-10100F - trang bị không thể thiếu trong những chiếc PC Gaming\r\nTrang bị socket LGA 1200 đem lại cho Intel Core i3-10100F khả năng tối ưu trên những chiếc mainboard tốt nhất hiện nay. Từ phân khúc cao cấp cho đến những chiếc bo mạch chủ ở phân khúc bình dân vẫn khai thác được tối đa sức mạnh từ chiếc i3-10100F.',2990000,0.2,36,12,'2021-11-29 10:08:41',12,1,'gearvn-core-i3-10100f-6mb-4-3ghz-4-nhan-8-luong-4-666_b69c321b09f44952a22253dc39df2432.jpg','còn hàng'),(25,7,7,'Intel Core i9 10940X /19.25MB/ 4.6GHz / 14 nhân 28 luồng / LGA 2066','Thương hiệu: Intel\r\nLoại CPU: Dành cho máy bàn\r\n\r\nThế hệ; Core i9 Thế hệ thứ 10\r\n\r\nTên gọi: Core i9-10940X',24500000,0,36,2,'2021-11-29 10:21:30',12,1,'intel_i9_core-x_47c4e30ac637468b8efc1a0bd7d08446.jpg','còn hàng'),(26,1,8,'Màn hình cong Samsung LC24F390 24\" VA','Hiển Thị\r\nTỷ lệ khung hình16:9\r\n \r\nTấm nềnVA\r\n \r\nĐộ sáng250cd/m2\r\n \r\nĐộ sáng (Tối thiểu)200cd/m2\r\n \r\nTỷ lệ Tương phảnMega\r\n \r\nĐộ phân giải1920 x 1080\r\n \r\nThời gian phản hồi4(GTG)\r\n \r\nGóc nhìn (H/V)178°(H)/178°(V)\r\n \r\nHỗ trợ màu sắc16.7M\r\n \r\nĐộ rộng dải màu có thể hiển thị (NTSC 1976)72%\r\nTính năng chung\r\nChế độ chơi GameYes\r\n \r\nWindows CertificationWindows 10\r\nGiao diện\r\nD-Sub1 EA\r\n \r\nDVINo\r\n \r\nDual Link DVINo\r\n \r\nDisplay PortNo\r\n \r\nHDMI1 EA\r\n \r\nTai ngheNo\r\n \r\nTai nghe1 EA\r\n \r\nBộ chia USBNo\r\nHoạt động\r\nNhiệt độ hoạt động10~40 ℃\r\n \r\nĐộ ẩm10~80 (non-condensing)\r\nThiết kế\r\nMàu sắcBlack high Glossy\r\n \r\nDạng chân đếSimple\r\n \r\nĐộ nghiêng-2.0°（±2.0°）~22.0°（±2.0°）\r\n \r\nTreo tường75.0 x 75.0 mm\r\nNguồn điện\r\nNguồn cấp điệnAC 100~240V\r\n \r\nMức tiêu thụ nguồn (DPMS)Less than 0.3 W\r\n \r\nMức tiêu thụ nguồn (Chế độ Tắt)Less than 0.3 W\r\n \r\nLoạiExternal Adaptor\r\nKích thước\r\nCó chân đế (RxCxD)547.8 x 418.2 x 206.5 mm\r\n \r\nKhông có chân đế (RxCxD)547.8 x 326.3 x 87.6 mm\r\n \r\nThùng máy (RxCxD)618.0 x 166.0 x 394.0 mm\r\nTrọng lượng\r\nCó chân đế3.3 kg\r\n \r\nKhông có chân đế2.8 kg\r\n \r\nThùng máy4.7 kg',4790000,0.1,36,NULL,'2021-11-29 16:54:41',12,1,'samsung_lc24f390_gearvn_bd3d2840b8e249ca9f87c43df8eaa053_large.jpg','còn hàng'),(27,8,8,'Màn hình ViewSonic VA2408-H 24\" IPS 75Hz','<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">ViewSonic&reg; VA2408-h l&agrave; m&agrave;n h&igrave;nh 24 inch Full HD kh&ocirc;ng viền, được trang bị tấm nền IPS, với đầu v&agrave;o HDMI v&agrave; VGA để sử dụng cho doanh nghiệp hoặc gia đ&igrave;nh. Sản phẩm n&agrave;y mang lại chất lượng h&igrave;nh ảnh tuyệt đẹp với mức ti&ecirc;u thụ điện năng thấp, m&agrave;n h&igrave;nh n&agrave;y cung cấp 6 chế độ xem được tinh chỉnh trước để tối ưu h&oacute;a cho c&aacute;c mục đ&iacute;ch kh&aacute;c nhau. mang lại hiệu suất được tối ưu h&oacute;a dựa tr&ecirc;n nhu cầu của bạn. B&ecirc;n cạnh đ&oacute;, c&ocirc;ng nghệ Eye-Care gi&uacute;p loại bỏ t&igrave;nh trạng mỏi mắt do thời gian xem d&agrave;i. Với việc hỗ trợ gi&aacute; treo chuẩn VESA, m&agrave;n h&igrave;nh n&agrave;y c&oacute; thể dễ d&agrave;ng lắp đặt tr&ecirc;n tường.</strong></p>\r\n<h2 style=\'box-sizing: border-box; font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-weight: 500; line-height: 1.1; color: rgb(51, 51, 51); margin-top: 20px; margin-bottom: 10px; font-size: 30px; max-width: 100%; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">G&oacute;c nh&igrave;n rộng</strong></h2>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">Tận hưởng m&agrave;u sắc phong ph&uacute;, sống động với mức độ s&aacute;ng ph&ugrave; hợp. Với c&ocirc;ng nghệ SuperClear&reg; IPS, m&agrave;n h&igrave;nh VA2256-H mang lại chất lượng h&igrave;nh ảnh tương tự cho d&ugrave; bạn đang nh&igrave;n v&agrave;o m&agrave;n h&igrave;nh từ tr&ecirc;n xuống dưới, ph&iacute;a trước hay b&ecirc;n cạnh.</strong></p>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">SuperClear&reg; IPS</strong></p>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">178&deg;/178&deg;</strong></p>\r\nFull HD 1080p\r\n\r\nĐộ phân giải Full HD 1920x1080 cho hiệu suất hình ảnh pixel-by-pixel rõ nét không thể tin được. Bạn sẽ trải nghiệm sự rõ ràng và chi tiết tuyệt vời cho dù đang làm việc, chơi game hay giải trí.\r\n\r\nFull HD 1080P',4400000,0.1,36,15,'2021-11-29 16:57:18',12,1,'view_va2408-h_gearvn_dcbe3f304278477ca9e7cb144e9d18c1_large.jpg','còn hàng'),(28,9,8,'Màn hình Lenovo Q24i-1L 24\" IPS 75Hz loa kép 3W','Khả năng hiển thị tuyệt vời cùng trải nghiệm nâng cao\r\nVới kích thước 24 inch tấm nền IPS cùng độ phủ màu đạt 72% NTSC, Lenovo Q24i-1L sẽ mang lại những hình ảnh hiển thị sắc mắt và tươi tắn nhất cho người dùng. Kích thước lớn đi kèm chứng nhận bảo vệ mắt Eyesafe Display và công nghệ Natural Low Blue Light, Lenovo Q24i-1L giúp giảm thiểu tình trạng mỏi mắt và ánh sáng xanh ảnh hưởng đến sức khỏe của cửa sổ tâm hồn. Trải nghiệm được nâng cao với sự kết hợp giữa AMD FreeSync và tần số quét 75Hz, Lenovo Q24i-1L đem lại những hình ảnh mượt mà nhất mà không bị nhấp nháy hay xé màn hình thường gặp ở những màn hình máy tính thường.',4890000,0.1,12,NULL,'2021-11-29 16:58:48',11,1,'lenovo_q24i-1l_6f758891f8e242fda4dd19e134ac9ce0_large.jpg','còn hàng'),(29,10,8,'Màn hình GIGABYTE G24F 24\" IPS 144Hz chuyên game','<h3 style=\'box-sizing: border-box; font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-weight: 500; line-height: 1.1; color: rgb(51, 51, 51); margin-top: 20px; margin-bottom: 10px; font-size: 24px; max-width: 100%; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><span style=\"box-sizing: border-box; max-width: 100%; font-size: 20px;\"><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">Đ&aacute;nh gi&aacute; chi tiết m&agrave;n h&igrave;nh GIGABYTE G24F 24&quot; IPS 144Hz chuy&ecirc;n game</strong></span></h3>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><span style=\"box-sizing: border-box; max-width: 100%; font-size: 18px;\">M&agrave;n h&igrave;nh GIGABYTE G24F 24&quot; IPS 144Hz chuy&ecirc;n game được thiết kế với k&iacute;ch thước 24 inch c&ugrave;ng phần viền mỏng gi&uacute;p n&acirc;ng cao cảm gi&aacute;c đắm ch&igrave;m với khung h&igrave;nh mở rộng. Tấm nền IPS hiện đại mang đến g&oacute;c nh&igrave;n rộng, đồng thời cải thiện hiệu quả độ tương phản m&agrave;n h&igrave;nh.</span></p>\r\nMàn hình GIGABYTE G24F 24\" IPS 144Hz chuyên game được hỗ trợ công nghệ đồng bộ hóa FreeSync cùng thời gian phản hồi cực nhanh 1ms, cho phép bạn trải nghiệm khung hình mượt mà khi đang chơi game. Bên cạnh đó, tốc độ làm mới lên đến 165GHz giúp đảm bảo chất lượng hiển thị vô cùng sắc nét.\r\n\r\n\r\n',5990000,0.12,12,1,'2021-11-29 17:00:37',12,1,'gigabyte_g24f_gearvn_32c459bb9b714c35b32481e53b4d081e_large.jpg','còn hàng'),(30,11,8,'Màn hình LG 27MP60G-B 27\" IPS 75Hz FreeSync chuyên game','Đánh giá chi tiết màn hình LG 27MP60G-B 27\" IPS 75Hz FreeSync chuyên game\r\nMàn hình IPS Full HD\r\nMàu sắc chân thực ở góc rộng. Màn hình LG với công nghệ IPS làm nổi bật hiệu suất của màn hình tinh thể lỏng. Rút ngắn thời gian phản hồi, cải thiện khả năng tái tạo màu sắc và người dùng có thể xem ở các góc rộng.\r\nFlicker Safe - Reader Mode\r\nChế độ xem chăm sóc đôi mắt. Giúp đôi mắt thoải mái hơn khi làm việc cường độ cao và đọc các văn bản dài trên màn hình vi tính. Chế độ đọc sách (Reader Mode) điều chỉnh nhiệt độ màu và độ sáng tương tự như khi đọc trên giấy tạo cảm giác thoải mái khi nhìn lâu. Chế độ chống nháy (Flicker Safe) giảm thiểu hiện tượng nhấp nháy không nhìn thấy trên màn hình, mang lại môi trường làm việc thoải mái, giảm mỏi mắt.\r\n1ms Motion Blur Reduction\r\nGiành chiến thắng với tốc độ đáng kinh ngạc 1ms MBR giúp chơi game mượt mà, không bị nhòe hay bóng mờ. Các vật thể chuyển động nhiều và có tốc độ nhanh trong lúc thao tác có thể mang lại lợi thế cạnh tranh cho game thủ.\r\n',5590000,0.1,12,14,'2021-11-29 17:02:46',22,1,'lg_27mp60g_gearvn_064e4f02ffdf4600b6c223ba2452c538_large.jpg','còn hàng'),(31,12,8,'Màn hình ASUS VA24EHE 24\" IPS 75Hz viền mỏng','<h3 style=\'box-sizing: border-box; font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-weight: 500; line-height: 1.1; color: rgb(51, 51, 51); margin-top: 20px; margin-bottom: 10px; font-size: 24px; max-width: 100%; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\"><span style=\"box-sizing: border-box; max-width: 100%; font-size: 20px;\">Chất lượng h&igrave;nh ảnh vượt trội kết hợp thiết kế thanh lịch cổ điển</span></strong></h3>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><span style=\"box-sizing: border-box; max-width: 100%; font-size: 18px;\"><strong style=\"box-sizing: border-box; font-weight: bold; max-width: 100%;\">ASUS VA24EHE</strong> l&agrave; một trong những d&ograve;ng sản phẩm&nbsp;<a href=\"https://gearvn.com/pages/man-hinh\" style=\"box-sizing: border-box; color: rgb(66, 139, 202); text-decoration: none; background: transparent; max-width: 100%;\" target=\"_blank\">m&agrave;n h&igrave;nh m&aacute;y t&iacute;nh</a> bảo vệ mắt được trang bị tấm nền IPS 23,8 inch với độ ph&acirc;n giải Full HD (1920 x 1080) để tạo n&ecirc;n m&agrave;n h&igrave;nh với g&oacute;c xem rộng l&ecirc;n tới 178&deg; v&agrave; chất lượng h&igrave;nh ảnh tuyệt đỉnh. Tốc độ l&agrave;m mới l&ecirc;n tới 75Hz, trang bị c&ocirc;ng nghệ Adaptive-Sync để hạn chế x&eacute; h&igrave;nh, đảm bảo ph&aacute;t video r&otilde; r&agrave;ng v&agrave; sắc n&eacute;t.&nbsp;</span></p>\r\n<p style=\'box-sizing: border-box; margin: 0px 0px 10px; max-width: 100%; color: rgb(51, 51, 51); font-family: \"Segoe UI\", Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;\'><span style=\"box-sizing: border-box; max-width: 100%; font-size: 18px;\">Ngo&agrave;i ra, d&ograve;ng m&agrave;n h&igrave;nh n&agrave;y c&ograve;n được trang bị c&aacute;c c&ocirc;ng nghệ Flicker-free (Khử nhấp nh&aacute;y) v&agrave; Low Blue Light (Bộ lọc &aacute;nh s&aacute;ng xanh dương) đều đ&atilde; được T&Uuml;V Rheinland chứng nhận để mang lại trải nghiệm xem thoải m&aacute;i hơn.</span></p>\r\n<h3><strong>C&ocirc;ng nghệ GamePlus độc quyền của ASUS</strong></h3>\r\n<p>Khi thiết kế sản phẩm, ASUS lu&ocirc;n đặt kh&aacute;ch h&agrave;ng l&ecirc;n tr&ecirc;n hết - Ph&iacute;m n&oacute;ng GamePlus độc quyền của ASUS với c&aacute;c t&iacute;nh năng như Crosshair (T&acirc;m ngắm), Timer (Bộ đếm thời gian), FPS counter (Bộ đếm số khung h&igrave;nh/ gi&acirc;y) v&agrave; Display Alignment (Hiển thị căn chỉnh) mang lại cho bạn những cải tiến trong game gi&uacute;p bạn tận hưởng game của m&igrave;nh được tối đa. Chức năng n&agrave;y được ph&aacute;t triển theo &yacute; kiến tư vấn từ c&aacute;c game thủ chuy&ecirc;n nghiệp, cho ph&eacute;p họ luyện tập v&agrave; n&acirc;ng cao kỹ năng chơi game.</p>\r\n<h3><strong>C&ocirc;ng nghệ Flicker-free</strong></h3>\r\n<p>Đ&atilde; đến l&uacute;c để n&oacute;i lời tạm biệt với mỏi mắt, căng mắt. C&aacute;c m&agrave;n h&igrave;nh ASUS trang bị c&ocirc;ng nghệ Flicker-free (Khử nhấp nh&aacute;y) của ASUS đ&atilde; được T&Uuml;V Rheinland chứng nhận để giảm hiện tượng nhấp nh&aacute;y tr&ecirc;n m&agrave;n h&igrave;nh nhằm mang lại trải nghiệm xem thoải m&aacute;i hơn. C&ocirc;ng nghệ n&agrave;y gi&uacute;p giảm thiểu c&aacute;c hiện tượng mỏi mắt v&agrave; c&aacute;c bệnh g&acirc;y tổn hại mắt kh&aacute;c đặc biệt l&agrave; khi bạn xem c&aacute;c chương tr&igrave;nh video ưa th&iacute;ch trong thời gian d&agrave;i.</p>\r\n<p><img src=\"https://file.hstatic.net/1000026716/file/gearvn-va24ehe-9_32cbb139c73147c68c73dfb83ee13266_grande.jpg\" /></p>',4850000,0.12,36,28,'2021-11-29 17:24:46',10,1,'asus_vg24dqlb_gearvn_fe66eb8ce8444925b466e93fd886a565_large.jpg','còn hàng');
/*!40000 ALTER TABLE `sanpham` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `thuonghieu`
--

DROP TABLE IF EXISTS `thuonghieu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `thuonghieu` (
  `MATHUONGHIEU` int NOT NULL AUTO_INCREMENT,
  `TENTHUONGHIEU` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`MATHUONGHIEU`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `thuonghieu`
--

LOCK TABLES `thuonghieu` WRITE;
/*!40000 ALTER TABLE `thuonghieu` DISABLE KEYS */;
INSERT INTO `thuonghieu` VALUES (1,'Samsung'),(2,'TeamGroup'),(3,'Corsair'),(4,'Logitech'),(5,'Leopold '),(6,'AMD'),(7,'Intel'),(8,'ViewSonic'),(9,'Lenovo'),(10,'GIGABYTE'),(11,'LG'),(12,'ASUS');
/*!40000 ALTER TABLE `thuonghieu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tintuc`
--

DROP TABLE IF EXISTS `tintuc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tintuc` (
  `MATINTUC` int NOT NULL AUTO_INCREMENT,
  `MANGUOIDUNG` int NOT NULL,
  `TIEUDE` varchar(500) DEFAULT NULL,
  `MOTANGAN` varchar(1000) DEFAULT NULL,
  `NOIDUNG` longtext,
  `NGAYDANG` datetime DEFAULT NULL,
  `NGAYSUA` datetime DEFAULT NULL,
  `HINHANH` varchar(1000) DEFAULT NULL,
  `HOT` tinyint DEFAULT NULL,
  PRIMARY KEY (`MATINTUC`),
  KEY `FK_DANGTIN` (`MANGUOIDUNG`),
  CONSTRAINT `FK_DANGTIN` FOREIGN KEY (`MANGUOIDUNG`) REFERENCES `nguoidung` (`MANGUOIDUNG`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tintuc`
--

LOCK TABLES `tintuc` WRITE;
/*!40000 ALTER TABLE `tintuc` DISABLE KEYS */;
INSERT INTO `tintuc` VALUES (1,1,'Laptop PC quả thật đang có vấn đề với webcam, nhưng cái \'tai thỏ\' của Apple không phải là giải pháp đúng','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','2021-11-20 16:28:00','2021-11-20 16:28:00','14-inch-macbook-pro-hands-on-featured-cke-163518329482281289084.jpg',1),(3,1,'Card đồ hoạ \'cháy hàng\' vì cơn sốt tiền điện tử','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Card đồ hoạ đang khan hàng tại Việt Nam, khiến các đại lý phải bán kèm máy tính để tránh bị giới đào Bitcoin gom hàng.  Hơn một tuần này, Huy Dũng (Hà Nội) tìm mua card đồ hoạ để nâng cấp máy tính nhưng chưa được. Mẫu VGA mà anh định mua của hãng Nvidia giá hơn 20 triệu đồng vốn lúc nào cũng sẵn hàng mà nay trở thành khan hiếm.','2021-11-20 22:04:00','2021-11-20 22:04:00','nvidia-geforce-rtx-3080-32-161-3068-3775-1612531146.jpg',1),(4,1,'Card đồ hoạ \'cháy hàng\' vì cơn sốt tiền điện tử','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Card đồ hoạ đang khan hàng tại Việt Nam, khiến các đại lý phải bán kèm máy tính để tránh bị giới đào Bitcoin gom hàng.  Hơn một tuần này, Huy Dũng (Hà Nội) tìm mua card đồ hoạ để nâng cấp máy tính nhưng chưa được. Mẫu VGA mà anh định mua của hãng Nvidia giá hơn 20 triệu đồng vốn lúc nào cũng sẵn hàng mà nay trở thành khan hiếm.','2021-11-21 15:10:00','2021-11-21 15:10:00','nvidia-geforce-rtx-3080-32-161-3068-3775-1612531146.jpg',1),(5,3,'Card đồ hoạ \'cháy hàng\' vì cơn sốt tiền điện tử','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Card đồ hoạ đang khan hàng tại Việt Nam, khiến các đại lý phải bán kèm máy tính để tránh bị giới đào Bitcoin gom hàng.  Hơn một tuần này, Huy Dũng (Hà Nội) tìm mua card đồ hoạ để nâng cấp máy tính nhưng chưa được. Mẫu VGA mà anh định mua của hãng Nvidia giá hơn 20 triệu đồng vốn lúc nào cũng sẵn hàng mà nay trở thành khan hiếm.','2021-11-20 22:10:58',NULL,'nvidia-geforce-rtx-3080-32-161-3068-3775-1612531146.jpg',1),(6,1,'Card đồ hoạ \'cháy hàng\' vì cơn sốt tiền điện tử','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Card đồ hoạ đang khan hàng tại Việt Nam, khiến các đại lý phải bán kèm máy tính để tránh bị giới đào Bitcoin gom hàng.  Hơn một tuần này, Huy Dũng (Hà Nội) tìm mua card đồ hoạ để nâng cấp máy tính nhưng chưa được. Mẫu VGA mà anh định mua của hãng Nvidia giá hơn 20 triệu đồng vốn lúc nào cũng sẵn hàng mà nay trở thành khan hiếm.','2021-11-21 15:09:54',NULL,'nvidia-geforce-rtx-3080-32-161-3068-3775-1612531146.jpg',NULL),(7,1,'Card đồ hoạ \'cháy hàng\' vì cơn sốt tiền điện tử','Vừa qua, Apple đã công bố laptop MacBook Pro mới, đi kèm với bộ vi xử lý M1 Pro và M1 Max mạnh mẽ, màn hình LED mini 1.000-nit tuyệt đẹp và viền hẹp. Màn hình có một phần bị che khuất bởi notch, thứ mà Apple đã phổ biến với iPhone X và trên MacBook Pro, phần notch đó chứa một webcam Full HD.','Card đồ hoạ đang khan hàng tại Việt Nam, khiến các đại lý phải bán kèm máy tính để tránh bị giới đào Bitcoin gom hàng.  Hơn một tuần này, Huy Dũng (Hà Nội) tìm mua card đồ hoạ để nâng cấp máy tính nhưng chưa được. Mẫu VGA mà anh định mua của hãng Nvidia giá hơn 20 triệu đồng vốn lúc nào cũng sẵn hàng mà nay trở thành khan hiếm.','2021-11-21 15:10:27',NULL,'nvidia-geforce-rtx-3080-32-161-3068-3775-1612531146.jpg',NULL);
/*!40000 ALTER TABLE `tintuc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `IDTRANSACTION` int NOT NULL AUTO_INCREMENT,
  `TINHTRANG` varchar(200) DEFAULT NULL,
  `MOTA` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`IDTRANSACTION`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
INSERT INTO `transaction` VALUES (1,'Chờ lấy hàng','Đã xác nhận và đang lấy hàng'),(2,'Chờ xác nhận','Đang trong quá trình gọi điện xác nhận giữa người bán và người mua'),(3,'Đang giao','Đơn hàng đang được giao tới người mua'),(4,'Đã giao thành công','Đơn hàng giao thành công tới người mua'),(5,'Đã hủy','Đơn hàng đã hủy thành công'),(6,'Trả hàng','Đơn hàng được trả thành công');
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vaitronguoidung`
--

DROP TABLE IF EXISTS `vaitronguoidung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vaitronguoidung` (
  `MAQUYEN` int NOT NULL AUTO_INCREMENT,
  `TENQUYEN` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAQUYEN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vaitronguoidung`
--

LOCK TABLES `vaitronguoidung` WRITE;
/*!40000 ALTER TABLE `vaitronguoidung` DISABLE KEYS */;
INSERT INTO `vaitronguoidung` VALUES (1,'quản lý'),(2,'nhân viên bán hàng'),(3,'khách hàng');
/*!40000 ALTER TABLE `vaitronguoidung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `voucher`
--

DROP TABLE IF EXISTS `voucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `voucher` (
  `MAVOUCHER` int NOT NULL AUTO_INCREMENT,
  `TENMA` varchar(50) DEFAULT NULL,
  `NGAYBD` datetime DEFAULT NULL,
  `NGAYKT` date DEFAULT NULL,
  `TYLE` double DEFAULT NULL,
  `TRANGTHAI` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`MAVOUCHER`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `voucher`
--

LOCK TABLES `voucher` WRITE;
/*!40000 ALTER TABLE `voucher` DISABLE KEYS */;
INSERT INTO `voucher` VALUES (1,'GIAM50','2021-11-11 00:00:00','2022-11-30',50,'còn'),(2,'GIAM10','2021-11-11 00:00:00','2021-11-30',10,'hết'),(3,'GIAM20','2021-11-11 00:00:00','2022-11-30',20,'còn');
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

-- Dump completed on 2021-12-25 20:09:45
