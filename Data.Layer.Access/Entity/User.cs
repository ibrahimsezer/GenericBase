using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Information { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>(); 
    }

    public class Product :BaseEntity
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
    }

    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
