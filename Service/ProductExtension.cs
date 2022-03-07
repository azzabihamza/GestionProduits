using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ProductExtension
    {
        public static void UpperName(this ManageProduct ManageProduct, Product product)
        {
            product.Name = product.Name.ToUpper();
        }
        public static bool InCategory(this ManageProduct ManageProduct, Product product, Category category)
        {
            return product.MyCategory.Name == category.Name;
        }
    }
}
