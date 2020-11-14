using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarSale.Models;
using Microsoft.AspNetCore.Identity;

namespace CarSale.Data
{
    public class CarSaleDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public CarSaleDbContext(DbContextOptions<CarSaleDbContext> options)
            : base(options)
        {
        }


        public DbSet<CarSale.Models.CarModel> CarModel { get; set; }
        public DbSet<CarSale.Models.TestDrive> TestDrive { get; set; }
       
    }
}
