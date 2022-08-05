using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(250)]
        
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
        /*⦁	ProductId
        ⦁	Name (up to 50 characters, unicode)
        ⦁	Quantity (real number)
        ⦁	Price
        ⦁	Sales
        */
    }
}
