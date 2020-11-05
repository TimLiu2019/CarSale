using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CarSale.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Engine { get; set; }

        public int Price { get; set; }

        public int Mileage { get; set; }

        public bool IsUsed { get; set; }

        [Required]
        public string CarImage { get; set; }
 
        public TestDrive TestDrive { get; set; }
    }
}
