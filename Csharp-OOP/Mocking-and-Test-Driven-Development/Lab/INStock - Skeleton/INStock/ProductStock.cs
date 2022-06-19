using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    class ProductStock : IProductStock
    {
        private List<IProduct> productsCatalogue;

        public ProductStock()
        {
            productsCatalogue = new List<IProduct>();
        }
        public IProduct this[int index]
        {
            get => productsCatalogue[index];
            set => productsCatalogue[index] = value;
        }


        public int Count => productsCatalogue.Count;

        public void Add(IProduct product)
        {
            if (productsCatalogue.Contains(product))
            {
                throw new ArgumentException();
            }

            productsCatalogue.Add(product);


        }

        public bool Contains(IProduct product) => productsCatalogue.Contains(product);

        public IProduct Find(int index)
        {
            if (index >= productsCatalogue.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return productsCatalogue[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)=> productsCatalogue.Where(x => x.Price == price).ToList();
      
        public IEnumerable<IProduct> FindAllByQuantity(int quantity) => productsCatalogue.Where(x => x.Quantity == quantity).ToList();

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi) => productsCatalogue.Where(x => x.Price >= lo && x.Price <= hi).OrderByDescending(x => x.Price).ToList();
      

        public IProduct FindByLabel(string label)
        {
            var result = productsCatalogue.FirstOrDefault(x => x.Label == label);

            if (result==null)
            {
                throw new ArgumentException();
            }

            return result;


        }

        public IProduct FindMostExpensiveProduct() => productsCatalogue.Max();
      

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var item in productsCatalogue)
            {
                yield return item;
            }
        }

        public bool Remove(IProduct product) => productsCatalogue.Remove(product);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
