using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chemical :Product
    {
        public string LabName { get; set; }
        //public string City { get; set; }
        //public string StreetAddress { get; set; }
        public Adress LabAddress { get; set; }

        #region Partie 4: Polymorphisme
        public override void GetMyType()
        {
            Console.WriteLine("CHEMICAL");
        }
        public override void GetDetails()
        {
            Console.Write("City: " + City); base.GetDetails();

        }
        #endregion
    }
}
