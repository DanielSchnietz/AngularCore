using AngularWebApp.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public static class CalculationService
    {
        public static async Task<CalculationDetailDTO> CreateForwardCalculation( InputObject input)
        {
            var forward = new ForwardCalculation();
            var calc = forward.CalculateCalculation(input);
            var mappedCalc = MapToDbDTO(calc);
            return await GetDbResponse(mappedCalc);
        }

        public static async Task UpdateCalculation(string id, InputObject input)
        {
            var forward = new ForwardCalculation();
            var calc = MapToDbDTO(forward.CalculateCalculation(input));
            await GetDbResponse(id, calc);
        }

        public static double CalcDirectCost(dynamic obj)
        {
            double res = 0;
            foreach (var item in obj)
            {
                res += Calculate.Multiply(item.Price, item.Amount);
            };
            return res;
        }

        private static async Task<CalculationDetailDTO> GetDbResponse(CalculationDbDTO calc)
        {
            var db = new DatabaseAccess();
            return await db.AddCalculation(calc);
        }

        private static async Task<CalculationDetailDTO> GetDbResponse(string Id, CalculationDbDTO calc)
        {
            var db = new DatabaseAccess();
            return await db.ChangeCalculationById(Id, calc);
        }

        // will be replaced with AutoMapper later
        private static CalculationDbDTO MapToDbDTO(Calculation calculation)
        {
            return new CalculationDbDTO()
            {
                MaterialDirectCost = calculation.MaterialDirectCost,
                MaterialOverheadPercentage = calculation.MaterialOverheadPercentage,
                MaterialOverhead = calculation.MaterialOverhead,
                MaterialCost = calculation.MaterialCost,
                ProductionDirectCost = calculation.ProductionDirectCost,
                ProductionOverheadPercentage = calculation.ProductionOverheadPercentage,
                ProductionOverhead = calculation.ProductionOverhead,
                ProductionCost = calculation.ProductionCost,
                ManufacturingCost = calculation.ManufacturingCost,
                AdministrativeOverheadPercentage = calculation.AdministrativeOverheadPercentage,
                AdministrativeOverhead = calculation.AdministrativeOverhead,
                SellingExpensesPercentage = calculation.SellingExpensesPercentage,
                SellingExpenses = calculation.SellingExpenses,
                SelfCost = calculation.SelfCost,
                ProfitMarkup = calculation.ProfitMarkup,
                Profit = calculation.Profit,
                CashSalePrice = calculation.CashSalePrice,
                CashDiscount = calculation.CashDiscount,
                CashDiscountPercentage = calculation.CashDiscountPercentage,
                AgentsCommission = calculation.AgentsCommission,
                AgentsCommissionPercentage = calculation.AgentsCommissionPercentage,
                TargetSalePrice = calculation.TargetSalePrice,
                CustomerDiscount = calculation.CustomerDiscount,
                CustomerDiscountPercentage = calculation.CustomerDiscountPercentage,
                ListPrice = calculation.ListPrice,
                SalesTax = calculation.SalesTax,
                SalesTaxPercentage = calculation.SalesTaxPercentage,
                OfferPrice = calculation.OfferPrice
            };
        }
    }
}
