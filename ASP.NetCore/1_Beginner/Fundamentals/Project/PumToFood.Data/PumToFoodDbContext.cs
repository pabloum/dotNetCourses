using Microsoft.EntityFrameworkCore;
using PumToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PumToFood.Data
{
    public class PumToFoodDbContext : DbContext
    {
        public PumToFoodDbContext(DbContextOptions<PumToFoodDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
