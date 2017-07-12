using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TshirtApp.Models
{
    public class TshirtAppDb : DbContext
    {
        public TshirtAppDb() : base("name=DefaultConnection"){

        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Tshirts> Tshirts { get; set; }
    }
}