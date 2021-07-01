using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_core_WebApi.Models
{
    [Table("tblColdDrinks", Schema = "dbo")]
    public class tblColdDrinks
    {
        [Key]
        public int intColdDrinksId { get; set; }

        [Required]
        public string strColdDrinksName { get; set; }

        
        public decimal numQuantity { get; set; }
       
        public decimal numUnitPrice { get; set; }
    }
}
