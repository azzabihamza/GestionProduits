using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category: Concept
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //navigation properties
        public virtual ICollection<Product> Products { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine("Category Id: " + CategoryId + ";" + "Name: " + Name);
        }

    }
}
