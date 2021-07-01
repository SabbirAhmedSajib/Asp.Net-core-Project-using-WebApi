using ASP.Net_core_WebApi.BAL;
using ASP.Net_core_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASP.Net_core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinksController : ControllerBase
    {
        private IColdDrinkService coldDrinkService;

        public ColdDrinksController(IColdDrinkService coldDrinkService)
        {
            this.coldDrinkService = coldDrinkService;
        }      


        //API 01: Insert Mojo (Quantity 575, Unit Price 15)
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(tblColdDrinks coldDrinks)
        {
            if (ModelState.IsValid)
            {
                coldDrinkService.Create(coldDrinks);
            }
            else
            {
                return BadRequest();
            }

            return Ok(HttpStatusCode.Created);
        }

        //API 02: Update unit price of Futika to 35
        [HttpPut]
        [Route("Update/{Id}")]
        public IActionResult Update(int Id, UpdateModel updateModel)
        {
            if(Id != updateModel.intColdDrinksId)
            {
                return BadRequest();
            }
            
            coldDrinkService.Update(updateModel);           

            return Ok(HttpStatusCode.OK);
        }

        //API 03: Delete Speed from the table
        [Route("Delete/{Id}")]
        [HttpDelete]
        public IActionResult Delete(int Id) 
        { 
            coldDrinkService.Delete(Id);

            return Ok(HttpStatusCode.OK);
        }

        //API 04: Find remaining products name
        [HttpGet]
        [Route("remainingproducts")]
        public List<tblColdDrinks> GetAll()
        {
            List<tblColdDrinks> coldDrinks = new List<tblColdDrinks>();

            coldDrinks = coldDrinkService.GetAllColdDrinks();

            return coldDrinks;
        }

        //API 05: Delete All products if it’s quantity is less than 500
        [HttpDelete]
        [Route("DeleteProductsForLessQuantity")]
        public IActionResult DeleteProductsForLessQuantity()
        {
            coldDrinkService.DeleteProductsForLessQuantity();

            return Ok(HttpStatusCode.OK);
        }

        //API 06: Find total price of all products
        [HttpGet]
        [Route("TotalPrice")]
        public IActionResult TotalPrice()
        {
            decimal totalPrice = 0;

            totalPrice = coldDrinkService.TotalPrice();

            return Ok("Total Price is: "+ totalPrice);
        }
    }
}
