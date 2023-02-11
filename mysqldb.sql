CREATE DATABASE `lachagarden`;
USE `lachagarden`;
--
-- Table structure for table `treetype`
--

CREATE TABLE `treetype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameTreeType` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `treetype`
--

/*!40000 ALTER TABLE `treetype` DISABLE KEYS */;
REPLACE INTO `treetype` (`ID`, `NameTreeType`, `Status`) VALUES (1,'Hoa',1);
/*!40000 ALTER TABLE `treetype` ENABLE KEYS */;

--
-- Table structure for table `technical`
--

CREATE TABLE `technical` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameTech` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Phone` int NOT NULL,
  `Image` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Gender` bit(1) NOT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idTechnical_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `technical`
--

/*!40000 ALTER TABLE `technical` DISABLE KEYS */;
/*!40000 ALTER TABLE `technical` ENABLE KEYS */;

--
-- Table structure for table `packagetype`
--

CREATE TABLE `packagetype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NamePackageType` varchar(50) NOT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `packagetype`
--

/*!40000 ALTER TABLE `packagetype` DISABLE KEYS */;
/*!40000 ALTER TABLE `packagetype` ENABLE KEYS */;

--
-- Table structure for table `gardenpackage`
--

CREATE TABLE `gardenpackage` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NamePack` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Image` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Length` int NOT NULL,
  `Width` int NOT NULL,
  `status` int NOT NULL,
  `PackageType_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `GardenPackage_PackageType_idx` (`PackageType_ID`),
  CONSTRAINT `GardenPackage_PackageType` FOREIGN KEY (`PackageType_ID`) REFERENCES `packagetype` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gardenpackage`
--

/*!40000 ALTER TABLE `gardenpackage` DISABLE KEYS */;
/*!40000 ALTER TABLE `gardenpackage` ENABLE KEYS */;

--
-- Table structure for table `tree`
--

CREATE TABLE `tree` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameTree` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Desc` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Image` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Price` int NOT NULL,
  `Status` int NOT NULL,
  `TreeType_ID` int NOT NULL,
  `GardenPackage_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `Tree_idx` (`GardenPackage_ID`),
  KEY `Tree_TreeType_idx` (`TreeType_ID`),
  CONSTRAINT `Tree_GardenPackage` FOREIGN KEY (`GardenPackage_ID`) REFERENCES `gardenpackage` (`ID`),
  CONSTRAINT `Tree_TreeType` FOREIGN KEY (`TreeType_ID`) REFERENCES `treetype` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tree`
--

/*!40000 ALTER TABLE `tree` DISABLE KEYS */;
/*!40000 ALTER TABLE `tree` ENABLE KEYS */;

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `FullName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Phone` decimal(10,0) NOT NULL,
  `Gmail` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Password` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Gender` bit(1) NOT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=ascii;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;


--
-- Table structure for table `blocks`
--
CREATE TABLE `blocks` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameBlocks` varchar(10) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blocks`
--

/*!40000 ALTER TABLE `blocks` DISABLE KEYS */;
REPLACE INTO `blocks` (`ID`, `NameBlocks`) VALUES (1,'ORIGAMI');
REPLACE INTO `blocks` (`ID`, `NameBlocks`) VALUES (2,'RAINBOW');
REPLACE INTO `blocks` (`ID`, `NameBlocks`) VALUES (3,'THE TIME');
/*!40000 ALTER TABLE `blocks` ENABLE KEYS */;

--
-- Table structure for table `building`
--

CREATE TABLE `building` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameBuilding` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Blocks_ID` int NOT NULL,
  PRIMARY KEY (`ID`,`Blocks_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `blocks_building_idx` (`Blocks_ID`),
  CONSTRAINT `blocks_building` FOREIGN KEY (`Blocks_ID`) REFERENCES `blocks` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `building`
--

/*!40000 ALTER TABLE `building` DISABLE KEYS */;
REPLACE INTO `building` (`ID`, `NameBuilding`, `Blocks_ID`) VALUES (1,'S1.01',2);
REPLACE INTO `building` (`ID`, `NameBuilding`, `Blocks_ID`) VALUES (2,'S1.02',2);
REPLACE INTO `building` (`ID`, `NameBuilding`, `Blocks_ID`) VALUES (3,'S6.01',1);
/*!40000 ALTER TABLE `building` ENABLE KEYS */;


--
-- Table structure for table `area`
--

CREATE TABLE `area` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `RoomNumber` int NOT NULL,
  `Square` int NOT NULL,
  `Status` int NOT NULL,
  `Building_ID` int NOT NULL,
  `Customer_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `Building_Area_idx` (`Building_ID`),
  KEY `Building_Customer_idx` (`Customer_ID`),
  CONSTRAINT `Building_Area` FOREIGN KEY (`Building_ID`) REFERENCES `building` (`ID`),
  CONSTRAINT `Building_Customer` FOREIGN KEY (`Customer_ID`) REFERENCES `customer` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `area`
--

/*!40000 ALTER TABLE `area` DISABLE KEYS */;
/*!40000 ALTER TABLE `area` ENABLE KEYS */;

--
-- Table structure for table `activitytype`
--

CREATE TABLE `activitytype` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameActivityType` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idActivityType_UNIQUE` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activitytype`
--

/*!40000 ALTER TABLE `activitytype` DISABLE KEYS */;
/*!40000 ALTER TABLE `activitytype` ENABLE KEYS */;

--
-- Table structure for table `garden`
--

CREATE TABLE `garden` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Fullname` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Image` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  `GardenPackage_ID` int NOT NULL,
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `GardenPackage_ID_UNIQUE` (`GardenPackage_ID`),
  CONSTRAINT `Garden_Area` FOREIGN KEY (`ID`) REFERENCES `area` (`ID`),
  CONSTRAINT `Garden_GardenPackage` FOREIGN KEY (`GardenPackage_ID`) REFERENCES `gardenpackage` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `garden`
--

/*!40000 ALTER TABLE `garden` DISABLE KEYS */;
/*!40000 ALTER TABLE `garden` ENABLE KEYS */;


--
-- Table structure for table `treecare`
--

CREATE TABLE `treecare` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  `Garden_ID` int NOT NULL,
  `Technical_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `Technical_ID_UNIQUE` (`Technical_ID`),
  UNIQUE KEY `Garden_ID_UNIQUE` (`Garden_ID`),
  CONSTRAINT `TreeCare_Garden` FOREIGN KEY (`Garden_ID`) REFERENCES `garden` (`ID`),
  CONSTRAINT `TreeCare_Technical` FOREIGN KEY (`Technical_ID`) REFERENCES `technical` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `treecare`
--

/*!40000 ALTER TABLE `treecare` DISABLE KEYS */;
/*!40000 ALTER TABLE `treecare` ENABLE KEYS */;


--
-- Table structure for table `activity`
--

CREATE TABLE `activity` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NameActivity` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  `Date` date NOT NULL,
  `ActivityType_ID` int NOT NULL,
  `TreeCare_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idActivityType_UNIQUE` (`ID`),
  UNIQUE KEY `ActivityType_ID_UNIQUE` (`ActivityType_ID`),
  UNIQUE KEY `Tre_UNIQUE` (`TreeCare_ID`),
  CONSTRAINT `Activity_ActivityType` FOREIGN KEY (`ActivityType_ID`) REFERENCES `activitytype` (`ID`),
  CONSTRAINT `Activity_TreeCare` FOREIGN KEY (`TreeCare_ID`) REFERENCES `treecare` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity`
--

/*!40000 ALTER TABLE `activity` DISABLE KEYS */;
/*!40000 ALTER TABLE `activity` ENABLE KEYS */;

--
-- Table structure for table `request`
--

CREATE TABLE `request` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Description` varchar(250) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `RequestType` int NOT NULL,
  `status` int NOT NULL,
  `Garden_ID` int NOT NULL,
  `TreeCare_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idRequest_UNIQUE` (`ID`),
  UNIQUE KEY `TreeCare_ID_UNIQUE` (`TreeCare_ID`),
  UNIQUE KEY `Garden_ID_UNIQUE` (`Garden_ID`),
  CONSTRAINT `Request_Garden` FOREIGN KEY (`Garden_ID`) REFERENCES `garden` (`ID`),
  CONSTRAINT `Request_TreeCare` FOREIGN KEY (`TreeCare_ID`) REFERENCES `treecare` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

/*!40000 ALTER TABLE `request` DISABLE KEYS */;
/*!40000 ALTER TABLE `request` ENABLE KEYS */;

--
-- Table structure for table `result`
--

CREATE TABLE `result` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Image` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Status` int NOT NULL,
  `Activity_ID` int NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `idResult_UNIQUE` (`ID`),
  UNIQUE KEY `Activity_ID_UNIQUE` (`Activity_ID`),
  CONSTRAINT `Result_Activity` FOREIGN KEY (`Activity_ID`) REFERENCES `activity` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `result`
--

/*!40000 ALTER TABLE `result` DISABLE KEYS */;
/*!40000 ALTER TABLE `result` ENABLE KEYS */;