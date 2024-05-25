-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: qlbh
-- ------------------------------------------------------
-- Server version	8.4.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categorynews`
--

DROP TABLE IF EXISTS `categorynews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorynews` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) NOT NULL,
  `CategoryDecription` text,
  `CategoryOrder` int DEFAULT NULL,
  `MetaTitle` varchar(100) DEFAULT NULL,
  `MetaDescription` varchar(100) DEFAULT NULL,
  `MetaKeywords` varchar(100) DEFAULT NULL,
  `Tags` varchar(150) DEFAULT NULL,
  `IsHot` tinyint(1) NOT NULL,
  `IsHome` tinyint(1) NOT NULL,
  `IsView` tinyint(1) NOT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorynews`
--

LOCK TABLES `categorynews` WRITE;
/*!40000 ALTER TABLE `categorynews` DISABLE KEYS */;
/*!40000 ALTER TABLE `categorynews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `export`
--

DROP TABLE IF EXISTS `export`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `export` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `OrderID` int NOT NULL,
  `ExportedDate` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `export`
--

LOCK TABLES `export` WRITE;
/*!40000 ALTER TABLE `export` DISABLE KEYS */;
/*!40000 ALTER TABLE `export` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedback`
--

DROP TABLE IF EXISTS `feedback`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feedback` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `PhoneNumber` varchar(12) DEFAULT NULL,
  `Subject` varchar(500) DEFAULT NULL,
  `Message` text,
  `Avatar` text,
  `Type` int NOT NULL,
  `CreateDate` datetime NOT NULL,
  `ProductID` int NOT NULL,
  `NewsID` int NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `ShowOnHome` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedback`
--

LOCK TABLES `feedback` WRITE;
/*!40000 ALTER TABLE `feedback` DISABLE KEYS */;
/*!40000 ALTER TABLE `feedback` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `import`
--

DROP TABLE IF EXISTS `import`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `import` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nane` varchar(50) DEFAULT NULL,
  `TotalPrice` decimal(18,2) NOT NULL,
  `ImportedDate` datetime NOT NULL,
  `Note` varchar(4000) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `import`
--

LOCK TABLES `import` WRITE;
/*!40000 ALTER TABLE `import` DISABLE KEYS */;
INSERT INTO `import` VALUES (1,'admin',0.00,'2024-03-15 02:24:38',''),(2,'admin',100000.00,'2024-03-15 02:25:31','');
/*!40000 ALTER TABLE `import` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `importdetail`
--

DROP TABLE IF EXISTS `importdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `importdetail` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ImportID` int NOT NULL,
  `ProductID` int NOT NULL,
  `Quantity` int NOT NULL,
  `Price` decimal(18,2) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `importdetail`
--

LOCK TABLES `importdetail` WRITE;
/*!40000 ALTER TABLE `importdetail` DISABLE KEYS */;
INSERT INTO `importdetail` VALUES (1,2,1,10,10000.00);
/*!40000 ALTER TABLE `importdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `news` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int DEFAULT NULL,
  `MetaUrl` varchar(500) DEFAULT NULL,
  `ThumbImage` varchar(150) DEFAULT NULL,
  `LargeImage` varchar(150) DEFAULT NULL,
  `Title` varchar(150) DEFAULT NULL,
  `SubTitle` varchar(500) DEFAULT NULL,
  `NewsContent` text,
  `Author` varchar(50) DEFAULT NULL,
  `PostedDate` datetime DEFAULT NULL,
  `IsHot` tinyint(1) NOT NULL,
  `IsHome` tinyint(1) NOT NULL,
  `IsView` tinyint(1) NOT NULL,
  `NewsOrder` int DEFAULT NULL,
  `Tags` varchar(150) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OrderCode` varchar(50) DEFAULT NULL,
  `TotalPrice` decimal(18,2) DEFAULT NULL,
  `OrderStatusId` int DEFAULT NULL,
  `CustomerAddress` varchar(250) DEFAULT NULL,
  `CustomerPhone` varchar(15) DEFAULT NULL,
  `CustomerFullName` varchar(50) DEFAULT NULL,
  `CustomerEmail` varchar(50) DEFAULT NULL,
  `CustomerNote` varchar(500) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  `ProductPrice` decimal(18,2) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatus`
--

DROP TABLE IF EXISTS `orderstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatus` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatus`
--

LOCK TABLES `orderstatus` WRITE;
/*!40000 ALTER TABLE `orderstatus` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int DEFAULT NULL,
  `ProductImagesId` int DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `Description` text,
  `Price` decimal(18,2) DEFAULT NULL,
  `PromotionPrice` decimal(18,2) DEFAULT NULL,
  `MainImageThumb` varchar(150) DEFAULT NULL,
  `MainImageLarge` varchar(150) DEFAULT NULL,
  `IsHot` tinyint(1) NOT NULL,
  `IsHome` tinyint(1) NOT NULL,
  `IsPromote` tinyint(1) NOT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `Quantity` int NOT NULL,
  `Branch` varchar(100) DEFAULT NULL,
  `SubDes` text,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,1,NULL,'SP01','SP01',NULL,100000.00,90000.00,'#','#',1,1,1,'2024-03-13 22:43:59','admin',NULL,NULL,10,NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productcategory`
--

DROP TABLE IF EXISTS `productcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productcategory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ParentId` int NOT NULL,
  `CategoryName` varchar(100) DEFAULT NULL,
  `CategoryDecription` text,
  `CategoryOrder` int DEFAULT NULL,
  `IsHot` tinyint(1) NOT NULL,
  `IsHome` tinyint(1) NOT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productcategory`
--

LOCK TABLES `productcategory` WRITE;
/*!40000 ALTER TABLE `productcategory` DISABLE KEYS */;
INSERT INTO `productcategory` VALUES (1,0,'DM1',NULL,1,0,0,'admin','2024-03-09 01:28:52',NULL,NULL);
/*!40000 ALTER TABLE `productcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productimages`
--

DROP TABLE IF EXISTS `productimages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productimages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProductId` int DEFAULT NULL,
  `ProductItemId` int DEFAULT NULL,
  `LargeImage` varchar(500) DEFAULT NULL,
  `ThumbImage` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productimages`
--

LOCK TABLES `productimages` WRITE;
/*!40000 ALTER TABLE `productimages` DISABLE KEYS */;
/*!40000 ALTER TABLE `productimages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscribeemail`
--

DROP TABLE IF EXISTS `subscribeemail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscribeemail` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(50) DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscribeemail`
--

LOCK TABLES `subscribeemail` WRITE;
/*!40000 ALTER TABLE `subscribeemail` DISABLE KEYS */;
/*!40000 ALTER TABLE `subscribeemail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id` char(36) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `Gender` int DEFAULT NULL,
  `Birthday` date DEFAULT NULL,
  `Address` varchar(150) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ModifiedBy` varchar(50) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('3cff168e-dd77-11ee-8667-d067e544dd11','admin','Admin@123','Administrator',1,NULL,'Hà Nội','0397966566','Admin@gmail.com','',NULL,NULL,NULL,1,1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'qlbh'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-25 18:31:42
