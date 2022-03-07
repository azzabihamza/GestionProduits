using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service
{
    public class ManageProvider
    {
        

        private List<Provider> Providers;

        public ManageProvider(List<Provider> providers)
        {
            this.Providers = providers;           
        }


        #region Syntaxe de base

        public List<Provider> GetProviderByName(string name)
        {
            var result = (from provider in Providers
                        where provider.UserName.Contains(name)
                        select provider).ToList();
            return result;
        }
        #endregion
        #region Méthode de sélection
        public Provider GetFirstProviderByName(string name)
        {
            var prvd = (from provider in Providers
                        where provider.UserName.Contains(name)
                        select provider).ToList().First();
            return prvd;
            //si la selection est vide, utiliser FirstOrDefault
        }

        public Provider GetProviderById(int id)
        {
            var prvd = (from provider in Providers
                        where provider.Id == id
                        select provider).ToList().Single();
            return prvd;
            //si la selection est vide, utiliser SingleOrDefault
        }


        #endregion

    }

}
