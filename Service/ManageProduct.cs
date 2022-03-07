using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service
{
    public class ManageProduct
    {
        private List<Product> products;
        public delegate void FindProducts(string c );
        public delegate void ScanProduct(Category category);
        public ManageProduct(List<Product> products)
        {
            this.products=products;
        }


        public void GetProductByChar(string c)
        {
            foreach (Product product in products)
            {
                if (product.Name.ToUpper().StartsWith(c.ToUpper()))
                    product.GetDetails();
            }
            
        }
        #region Méthodes de sélection et d'agrégation
        public List<Product> Get5Chemical(double price)
        {
            var query = from product in products
                        where (product.Price > price)
                        select product;
            return query.Take(5).ToList<Product>();
        }
        public IEnumerable<Product> GetProductPrice(double price)
        {
            var query = from product in products
                        where (product.Price > price)
                        select product;
            return query.Skip(2); //par défaut AsEnumerable()
        }

        public double GetAveragePrice()
        {
            return (from product in products
                    select product.Price)
                    .Average();
        }

        public Product GetMaxPrice()
        {
            double maxprice = (from product in products
                               select product.Price).Max();

            var result = (from product in products
                          where product.Price == maxprice
                          select product).ToList().FirstOrDefault();


            return result;
        }

        public int GetCountProduct(string city)
        {
            var listProductChemical = (from product in products
                        where product is Chemical
                        && ((Chemical)product).City.Equals(city)
                        select product).ToList();

            return listProductChemical.Count();
        }
        public List<Product> GetChemicalCity()
        {
            var listProductChemical = (from product in products
                        where product is Chemical
                        orderby ((Chemical)product).City ascending // ou descending
                        select product).ToList();

            return listProductChemical;
        }

        public void GetChemicalGroupByCity()
        {
            var query = from product in products
                        where product is Chemical
                        orderby ((Chemical)product).City ascending // ou descending
                        group (Chemical)product by ((Chemical)product).City;

            foreach (var productgroup in query)
            {
                Console.WriteLine(productgroup.Key + ":");

                foreach (var prdct in productgroup)
                {
                    Console.WriteLine("\t" + prdct.Name + " " + prdct.Price);
                }
            }
        }

        #endregion

    }
}
