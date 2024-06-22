-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: databaseda
-- ------------------------------------------------------
-- Server version	8.3.0

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
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `ClienteID` int NOT NULL AUTO_INCREMENT,
  `ClienteNome` varchar(45) NOT NULL,
  `ClienteNIF` varchar(45) NOT NULL,
  `ClienteSaldo` varchar(45) NOT NULL,
  `ClienteEmail` varchar(45) DEFAULT NULL,
  `ClienteNumEs` varchar(45) DEFAULT NULL,
  `ClienteTipo` int NOT NULL,
  PRIMARY KEY (`ClienteID`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (3,'EstudanteTeste','111','222',NULL,'333',2),(4,'ProfessorTeste','111','222','333',NULL,1);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `extras`
--

DROP TABLE IF EXISTS `extras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `extras` (
  `ExtrasID` int NOT NULL AUTO_INCREMENT,
  `ExtrasNome` varchar(45) NOT NULL,
  `ExtrasQuan` varchar(45) NOT NULL,
  `ExtrasPreco` varchar(45) NOT NULL,
  `ExtrasDesc` varchar(45) DEFAULT NULL,
  `ExtrasAtivo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ExtrasID`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `extras`
--

LOCK TABLES `extras` WRITE;
/*!40000 ALTER TABLE `extras` DISABLE KEYS */;
INSERT INTO `extras` VALUES (1,'Coca-Cola','100','1','Lata','Sim');
/*!40000 ALTER TABLE `extras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario` (
  `FuncionarioID` int NOT NULL AUTO_INCREMENT,
  `FuncionarioNome` varchar(45) NOT NULL,
  `FuncionarioNIF` varchar(45) NOT NULL,
  `FuncSelect` varchar(45) NOT NULL,
  PRIMARY KEY (`FuncionarioID`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (2,'Tiago','111111','Nao'),(3,'Rodrigo','2222222','Nao'),(4,'Kleyton','333','Sim');
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menus`
--

DROP TABLE IF EXISTS `menus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menus` (
  `MenuData` varchar(45) NOT NULL,
  `MenuPratos` varchar(45) DEFAULT NULL,
  `MenuExtras` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MenuData`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menus`
--

LOCK TABLES `menus` WRITE;
/*!40000 ALTER TABLE `menus` DISABLE KEYS */;
INSERT INTO `menus` VALUES ('14 de junho de 2024','9,2,7,','1,'),('15 de junho de 2024','9,2,7,','1,'),('13 de junho de 2024','-','-'),('16 de junho de 2024','9,1,7,','1,'),('18 de junho de 2024','9,1,','1,'),('19 de junho de 2024','1,10,','1,');
/*!40000 ALTER TABLE `menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `multa`
--

DROP TABLE IF EXISTS `multa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `multa` (
  `MultaID` int NOT NULL AUTO_INCREMENT,
  `MultaNome` varchar(45) NOT NULL,
  `MultaHora` varchar(45) NOT NULL,
  `MultaPreco` varchar(45) NOT NULL,
  PRIMARY KEY (`MultaID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multa`
--

LOCK TABLES `multa` WRITE;
/*!40000 ALTER TABLE `multa` DISABLE KEYS */;
INSERT INTO `multa` VALUES (1,'MultaTeste','10','100');
/*!40000 ALTER TABLE `multa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prato`
--

DROP TABLE IF EXISTS `prato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prato` (
  `IDPrato` int NOT NULL AUTO_INCREMENT,
  `NomePrato` varchar(45) NOT NULL,
  `QuanPrato` varchar(45) NOT NULL,
  `PrecoPrato` varchar(45) NOT NULL,
  `DescPrato` varchar(45) DEFAULT NULL,
  `AtivoPrato` varchar(45) DEFAULT NULL,
  `TipoPrato` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IDPrato`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prato`
--

LOCK TABLES `prato` WRITE;
/*!40000 ALTER TABLE `prato` DISABLE KEYS */;
INSERT INTO `prato` VALUES (1,'Bitoque','1','8','-','Sim','Carne'),(2,'Francesinha','1','10','-','Sim','Carne'),(3,'Esparguete a carbonara','30','30','-','Nao','Carne'),(7,'Salmao Com Arroz','123','9','-','Sim','Peixe'),(9,'Estrogonofe de carne de soja','10','12','Estrogonofe de carne de soja','Sim','Vegetariano'),(10,'Hamburguer de soja','20','14','-','Sim','Vegetariano');
/*!40000 ALTER TABLE `prato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas`
--

DROP TABLE IF EXISTS `reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservas` (
  `ReservaID` int NOT NULL AUTO_INCREMENT,
  `ReservaClienteID` int NOT NULL,
  `ReservaFunc` varchar(45) NOT NULL,
  `ReservaPratos` varchar(45) DEFAULT NULL,
  `ReservaExtras` varchar(45) DEFAULT NULL,
  `ReservaTotal` varchar(45) NOT NULL,
  `ReservaData` varchar(45) NOT NULL,
  `ReservaEstado` varchar(45) NOT NULL,
  PRIMARY KEY (`ReservaID`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas`
--

LOCK TABLES `reservas` WRITE;
/*!40000 ALTER TABLE `reservas` DISABLE KEYS */;
INSERT INTO `reservas` VALUES (1,4,'2','2,','1,1,1,','15.6','15 de junho de 2024','Nao'),(2,3,'2','1,','1,1,1,1,','12','16 de junho de 2024','Sim'),(3,4,'3','7,','1,','12','18 de junho de 2024','Nao'),(4,4,'3','','1,','1.2','19 de junho de 2024','Nao'),(5,4,'3','10,','1,','18.0000019','19 de junho de 2024','Sim'),(6,4,'4','','','0','19 de junho de 2024','Sim');
/*!40000 ALTER TABLE `reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilizador`
--

DROP TABLE IF EXISTS `utilizador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilizador` (
  `ID` int NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `NIF` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilizador`
--

LOCK TABLES `utilizador` WRITE;
/*!40000 ALTER TABLE `utilizador` DISABLE KEYS */;
/*!40000 ALTER TABLE `utilizador` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-19 22:31:04
