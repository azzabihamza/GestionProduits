using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product : Concept
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "champs obligatoire")]//message d'ereur
        [StringLength(25, ErrorMessage = "taille max=25")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]//  plusieurs lignes
        public string Description { get; set; }
        [DataType(DataType.Currency)] //pour indiquer qu'il est monnaie
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Display(Name = "Date de production")] //affichage
        [DataType(DataType.Date)] //DATE valide
        public DateTime DateProd { get; set; }

        public string ImageName { get; set; }  
        //foreign Key properties
        public int? CategoryId { get; set; }
        //navigation properties

        [ForeignKey("CategoryId")]
        public virtual Category MyCategory { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine("ProductId: " + ProductId + " ; Name : " + Name + "DateProd: " + DateProd + " ; Description: " + Description + " ; Price : " + Price + " ; Quantity:" + Quantity);
        }

        #region Partie 4: Polymorphisme
        public virtual void GetMyType()
        {
            Console.WriteLine("UNKNOWN");
        }
        #endregion
    }
}
