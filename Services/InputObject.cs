using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class InputObject
    {
        public Item[] Items { get; set; }
        public int MaterialOverheadPercentage { get; set; }
        public Step[] Steps { get; set; }
        public int ProductionOverheadPercentage { get; set; }
        public int AdministrativeOverheadPercentage { get; set; }
        public int SellingExpensesPercentage { get; set; }
        public int ProfitMarkup { get; set; }
        public int CashDiscountPercentage { get; set; }
        public int AgentsCommissionPercentage { get; set; }
        public int CustomerDiscountPercentage { get; set; }
        public int SalesTaxPercentage { get; set; }
    }
}
