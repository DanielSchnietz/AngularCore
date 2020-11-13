using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class InputObject
    {
        //more validations will be added
        [Required]
        public string KindOfCalculation { get; set;}
        [Required]
        public Item[] Items { get; set; }
        [Required]
        public int MaterialOverheadPercentage { get; set; }
        [Required]
        public Step[] Steps { get; set; }
        [Required]
        public int ProductionOverheadPercentage { get; set; }
        [Required]
        public int AdministrativeOverheadPercentage { get; set; }
        [Required]
        public int SellingExpensesPercentage { get; set; }
        [Required]
        public int ProfitMarkup { get; set; }
        [Required]
        public int CashDiscountPercentage { get; set; }
        [Required]
        public int AgentsCommissionPercentage { get; set; }
        [Required]
        public int CustomerDiscountPercentage { get; set; }
        [Required]
        public int SalesTaxPercentage { get; set; }
    }
}
