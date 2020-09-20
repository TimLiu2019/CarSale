using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarSale.Models;

namespace CarSale.Data
{
    public class CarSaleDbContext : IdentityDbContext
    {
        public CarSaleDbContext(DbContextOptions<CarSaleDbContext> options)
            : base(options)
        {
        }
        public DbSet<CarSale.Models.CarModel> CarModel { get; set; }
    }
}
