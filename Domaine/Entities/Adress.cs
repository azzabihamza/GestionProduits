using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Domain.Entities
{
    [Owned]
    public class Adress
    {   
        public string City { get; set; }
        public string StreetAdress { get; set; }
    }
}
