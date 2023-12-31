﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComMVVM.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public double price { get; set; }
        public string? image { get; set; }  
        
    }
}
