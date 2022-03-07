using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Biological : Product
    {
        public string Herbs { get; set; }

        #region Partie 4: Polymorphisme
        public override void GetMyType()
        {
            Console.WriteLine("BIOLOGICAL");
        }
        #endregion
    }
}
