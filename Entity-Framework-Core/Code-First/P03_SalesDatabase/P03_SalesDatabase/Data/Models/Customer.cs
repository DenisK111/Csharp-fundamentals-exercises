using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        /*⦁	CustomerId
        ⦁	Name (up to 100 characters, unicode)
        ⦁	Email (up to 80 characters, not unicode)
        ⦁	CreditCardNumber (string)
        ⦁	Sales
        */

        [MaxLength(50)]
        [Required]

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
