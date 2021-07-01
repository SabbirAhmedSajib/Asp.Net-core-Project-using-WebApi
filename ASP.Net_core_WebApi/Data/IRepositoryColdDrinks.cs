using ASP.Net_core_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_core_WebApi.Data
{
    public interface IRepositoryColdDrinks
    {
        List<tblColdDrinks> GetAllColdDrinks();
        void Create(tblColdDrinks coldDrinks);

        void Update(UpdateModel updateModel);

        void Delete(int intColdDrinksId);

        void DeleteProductsForLessQuantity();

        decimal TotalPrice();
    }
}
