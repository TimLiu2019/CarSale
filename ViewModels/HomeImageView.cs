using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSale.ViewModels
{
    public class HomeImageView
    {
        [Display(Name = "Slide 1")]
        public IFormFile Slide1 { get; set; }

        [Display(Name = "Slide 2")]
        public IFormFile Slide2 { get; set; }

        [Display(Name = "Slide 3")]
        public IFormFile Slide3 { get; set; }


       
    }
}
