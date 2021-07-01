using ASP.Net_core_WebApi.Models;
using ASP.Net_core_WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_core_WebApi.BAL
{
    public class ColdDrinkService : IColdDrinkService
    {
        private IRepositoryColdDrinks _repositoy;

        public ColdDrinkService(IRepositoryColdDrinks repositoy)
        {
            this._repositoy = repositoy;
        }


        public List<tblColdDrinks> GetAllColdDrinks()
        {
            return _repositoy.GetAllColdDrinks();            
        }

        public void Create(tblColdDrinks coldDrinks)
        {
            _repositoy.Create(coldDrinks);
        }

        public void Update(UpdateModel coldDrinks)
        {
            _repositoy.Update(coldDrinks);
        }

       public void Delete(int intColdDrinksId)
        {
            _repositoy.Delete(intColdDrinksId);
        }

        public void DeleteProductsForLessQuantity()
        {
            _repositoy.DeleteProductsForLessQuantity();
        }

        public decimal TotalPrice()
        {
            return _repositoy.TotalPrice();
        }
    }
}
