using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class Provider : Concept
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [MaxLength(8)]
        [DataType(DataType.Password)]

        #region Partie 3: Encapsulation
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20) password = value;
                else Console.WriteLine("Le password doit avoir une taille dans l'intervalle [5, 20]");
            }
        }
        #endregion

        [Required]
        [Compare("Password", ErrorMessage = "incorrect PSwd")]
        [DataType(DataType.Password)]
        [NotMapped]//on l'enrgistre pas dans BD
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Champs obligatoire")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? DateCreated { get; set; }  // ?  nullable
        //navigation properties
        virtual public ICollection<Product> Products { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine("UserName: " + UserName + " ; Id: " + Id + " ; Email: " + Email + " ; DateCreated: " + DateCreated);

            #region Partie 5: Collections / Itérations / Structures conditionnelles
            if (Products != null) foreach (Product p in Products) p.GetDetails();
            #endregion
        }

        

        #region Partie 2: Type valeur / Type référence
        public static void SetIsApproved(Provider P)
        {
            P.IsApproved = string.Compare(P.Password, P.ConfirmPassword) == 0;
        }
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        {
            isApproved = string.Compare(password, confirmPassword) == 0;
        }
        #endregion


        #region Partie 4: Polymorphisme
        public bool Login(string userName, string password)
        {
            return string.Compare(UserName, userName) == 0 && string.Compare(Password, password) == 0;
        }
        public bool Login(string userName, string password, string email)
        {
            return string.Compare(UserName, userName) == 0 && string.Compare(Password, password) == 0 && string.Compare(Email, email) == 0;
        }
        //public bool Login(string userName, string password, string email = null)
        //{
        //    return string.Compare(UserName, userName) == 0
        //        && string.Compare(Password, password) == 0
        //        && email != null ? string.Compare(Email, email) == 0 : true;
        //}

        #endregion

        #region Partie 5: Collections / Itérations / Structures conditionnelles
        public void GetProducts(string filterType, string filterValue)
        {
            if (Products != null)
            {
                switch (filterType)
                {
                    case "DATEPROD":
                        foreach (Product p in Products) if (DateTime.Equals(p.DateProd, (DateTime.Parse(filterValue)))) p.GetDetails();
                        break;
                    case "NAME":
                        foreach (Product p in Products) if (string.Equals(p.Name, filterValue)) p.GetDetails();
                        break;
                    case "PRICE":
                        foreach (Product p in Products) if (p.Price == double.Parse(filterValue)) p.GetDetails();
                        break;
                        //Ajouter le reste des possibilités
                }
            }
        }
        #endregion

    }
}
