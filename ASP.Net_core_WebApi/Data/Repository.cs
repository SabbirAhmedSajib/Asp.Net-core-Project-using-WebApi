using ASP.Net_core_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_core_WebApi.Data
{
    public class Repository : IRepositoryColdDrinks
    {
        private ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public List<tblColdDrinks> GetAllColdDrinks()
        {
            return _applicationDbContext.tblColdDrink.ToList();
        }

        public void Create(tblColdDrinks coldDrinks)
        {
            _applicationDbContext.tblColdDrink.Add(coldDrinks);
            _applicationDbContext.SaveChanges();
        }

        public void Update(UpdateModel updateModel)
        {
            var result = _applicationDbContext.tblColdDrink.Find(updateModel.intColdDrinksId);
            
            result.numUnitPrice = updateModel.numUnitPrice;

            _applicationDbContext.Entry(result).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int intColdDrinksId)
        {
            var result = _applicationDbContext.tblColdDrink.Find(intColdDrinksId);

            _applicationDbContext.Remove(result);

            _applicationDbContext.SaveChanges();
        }

        public void DeleteProductsForLessQuantity()
        {
            var result = _applicationDbContext.tblColdDrink.Where(x=>x.numQuantity<500);

            _applicationDbContext.RemoveRange(result);
            _applicationDbContext.SaveChanges();
        }

        public decimal TotalPrice()
        {
            decimal totalCalucation = _applicationDbContext.tblColdDrink.Sum(x => x.numUnitPrice * x.numQuantity);

            return totalCalucation;
        }
    }
}
