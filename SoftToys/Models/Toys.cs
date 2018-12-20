using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace SoftToys.Models
{
    public class Toys
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int UnderAge { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

    }
}
