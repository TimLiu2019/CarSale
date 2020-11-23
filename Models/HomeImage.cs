using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSale.Models
{
    public class HomeImage
    {

        [Key]
        public int Id { get; set; }

        public string Slide1 { get; set; }


        public string Slide2 { get; set; }


        public string Slide3 { get; set; }
    }
}
