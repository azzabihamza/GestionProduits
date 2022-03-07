using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Facture
    {
        //[Key(),Column(Order =0)]
        //[DataType(DataType.Date)]
        

        //[Key(), Column(Order = 1)]
        public int ProductId { get; set; }

        //[ForeignKey("Productid")]
        public Product Product { get; set; }
        //[Key, Column(Order = 2)]
               
        public int ClientId { get; set; }
        //[ForeignKey("ClientId")]
        public Client Client { get; set; }

        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

    }
}
