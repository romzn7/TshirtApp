using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TshirtApp.Models
{
    public class Brands
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
    }
}