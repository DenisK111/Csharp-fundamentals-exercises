using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        private decimal price;
        private int quantity;
        private string label;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label {

            get { return label; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                label = value;
            }
        }

        public decimal Price
        {
            get
            { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be positive number");
                }

                price = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }

                quantity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (this.Price > other.Price)
            {
                return 1;
            }

            else if (this.Price == other.Price)
            {
                return 0;
            }

            else
            {
                return -1;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Label == product.Label;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Label);
        }
    }
}
