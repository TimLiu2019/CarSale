using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSale.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter Model")]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please enter Engine")]
        public string Engine { get; set; }

        public int Price { get; set; }

        public int Mileage { get; set; }

        public bool IsUsed { get; set; }

        [Required(ErrorMessage = "Please choose car image")]
        [Display(Name = "Car Image")]
        public IFormFile CarImage { get; set; }
    }
}
