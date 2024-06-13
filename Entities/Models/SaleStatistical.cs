using System;

namespace Entities.Models
{
    public class ProductStatistical
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int TotalQuantity { get; set; }
        public string ProductName { get; set; }
    }
}
// -- qlbh.productstatistical definition

// CREATE TABLE `ProductStatistical` (
//   `Id` int NOT NULL AUTO_INCREMENT,
//   `Year` int NOT NULL,
//   `TotalQuantity` int NOT NULL,
//   `ProductName` varchar(255) NOT NULL,
//   PRIMARY KEY (`Id`)
// ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;