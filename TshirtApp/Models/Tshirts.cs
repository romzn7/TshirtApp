using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TshirtApp.Models
{
    public class Tshirts
    {
        [Key]
        public int Id { get; set; }
        public string TshirtName { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public enum Gender { Men, Women, Unisex }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brands Brand { get; set; }
    }
}