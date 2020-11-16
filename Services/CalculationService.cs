using AngularWebApp.Interfaces;
using AngularWebApp.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public static class CalculationService
    {
        public static async Task<CalculationDetailDTO> CreateCalculation(InputObject input)
        {
            var calc = GetCalculationObject(input, new Calculation());
            var calcDTO = MapToDbDTO(calc);
            return await GetDbResponse(calcDTO);
        }


        public static async Task UpdateCalculation(string id, InputObject input)
        {
            var calc = GetCalculationObject(input, new Calculation());
            var calcDTO = MapToDbDTO(calc);
            await GetDbResponse(id, calcDTO);
        }

        private static double CalcDirectCost(dynamic obj)
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

        private static Calculation GetCalculationObject(InputObject input, Calculation calculation) =>
            input.KindOfCalculation switch
            {
                "Backwards" => CalculateCalculationBackwards(input, calculation),
                "Difference" => CalculateCalculationDifference(input, calculation),
                _ => CalculateCalculationForward(input, calculation)
            };


        private static Calculation CalculateCalculationForward(InputObject input, Calculation calculation)
        {
            calculation.MaterialDirectCost = CalculationService.CalcDirectCost(input.Items);
            calculation.ProductionDirectCost = CalculationService.CalcDirectCost(input.Steps);
            calculation.MaterialOverheadPercentage = input.MaterialOverheadPercentage;
            calculation.ProductionOverheadPercentage = input.ProductionOverheadPercentage;
            calculation.MaterialOverhead = Calculate.Multiply(calculation.MaterialDirectCost, input.MaterialOverheadPercentage) / 100;
            calculation.ProductionOverhead = Calculate.Multiply(calculation.ProductionDirectCost, input.ProductionOverheadPercentage) / 100;
            calculation.MaterialCost = Calculate.Add(calculation.MaterialDirectCost, calculation.MaterialOverhead);
            calculation.ProductionCost = Calculate.Add(calculation.ProductionDirectCost, calculation.ProductionOverhead);
            calculation.ManufacturingCost = Calculate.Add(calculation.MaterialCost, calculation.ProductionCost);
            calculation.AdministrativeOverhead = Calculate.Multiply(calculation.ManufacturingCost, input.AdministrativeOverheadPercentage) / 100;
            calculation.AdministrativeOverheadPercentage = input.AdministrativeOverheadPercentage;
            calculation.SellingExpenses = Calculate.Multiply(calculation.ManufacturingCost, input.SellingExpensesPercentage) / 100;
            calculation.SellingExpensesPercentage = input.SellingExpensesPercentage;
            calculation.SelfCost = Calculate.Add(calculation.ManufacturingCost, calculation.AdministrativeOverhead, calculation.SellingExpenses);
            calculation.Profit = Calculate.Multiply(calculation.SelfCost, input.ProfitMarkup) / 100;
            calculation.ProfitMarkup = input.ProfitMarkup;
            calculation.CashSalePrice = Calculate.Add(calculation.SelfCost, calculation.Profit);
            calculation.CashDiscount = Calculate.Multiply(calculation.CashSalePrice, input.CashDiscountPercentage) / 100;
            calculation.CashDiscountPercentage = input.CashDiscountPercentage;
            calculation.AgentsCommission = Calculate.Multiply(calculation.CashSalePrice, input.AdministrativeOverheadPercentage) / 100;
            calculation.AgentsCommissionPercentage = input.AgentsCommissionPercentage;
            calculation.TargetSalePrice = Calculate.Add(calculation.CashSalePrice, calculation.CashDiscount, calculation.AgentsCommission);
            calculation.CustomerDiscount = Calculate.Multiply(calculation.TargetSalePrice, input.CustomerDiscountPercentage) / 100;
            calculation.CustomerDiscountPercentage = input.CustomerDiscountPercentage;
            calculation.ListPrice = Calculate.Add(calculation.TargetSalePrice, calculation.CustomerDiscount);
            calculation.SalesTax = Calculate.Multiply(calculation.ListPrice, input.SalesTaxPercentage) / 100;
            calculation.SalesTaxPercentage = input.SalesTaxPercentage;
            calculation.OfferPrice = Calculate.Add(calculation.ListPrice, calculation.SalesTax);

            return calculation;
        }

        // the two following methods will be changed to calculate the right way
        // they are just copies of the forward one for now
        private static Calculation CalculateCalculationBackwards(InputObject input, Calculation calculation)
        {
            calculation.MaterialDirectCost = CalculationService.CalcDirectCost(input.Items);
            calculation.ProductionDirectCost = CalculationService.CalcDirectCost(input.Steps);
            calculation.MaterialOverheadPercentage = input.MaterialOverheadPercentage;
            calculation.ProductionOverheadPercentage = input.ProductionOverheadPercentage;
            calculation.MaterialOverhead = Calculate.Multiply(calculation.MaterialDirectCost, input.MaterialOverheadPercentage) / 100;
            calculation.ProductionOverhead = Calculate.Multiply(calculation.ProductionDirectCost, input.ProductionOverheadPercentage) / 100;
            calculation.MaterialCost = Calculate.Add(calculation.MaterialDirectCost, calculation.MaterialOverhead);
            calculation.ProductionCost = Calculate.Add(calculation.ProductionDirectCost, calculation.ProductionOverhead);
            calculation.ManufacturingCost = Calculate.Add(calculation.MaterialCost, calculation.ProductionCost);
            calculation.AdministrativeOverhead = Calculate.Multiply(calculation.ManufacturingCost, input.AdministrativeOverheadPercentage) / 100;
            calculation.AdministrativeOverheadPercentage = input.AdministrativeOverheadPercentage;
            calculation.SellingExpenses = Calculate.Multiply(calculation.ManufacturingCost, input.SellingExpensesPercentage) / 100;
            calculation.SellingExpensesPercentage = input.SellingExpensesPercentage;
            calculation.SelfCost = Calculate.Add(calculation.ManufacturingCost, calculation.AdministrativeOverhead, calculation.SellingExpenses);
            calculation.Profit = Calculate.Multiply(calculation.SelfCost, input.ProfitMarkup) / 100;
            calculation.ProfitMarkup = input.ProfitMarkup;
            calculation.CashSalePrice = Calculate.Add(calculation.SelfCost, calculation.Profit);
            calculation.CashDiscount = Calculate.Multiply(calculation.CashSalePrice, input.CashDiscountPercentage) / 100;
            calculation.CashDiscountPercentage = input.CashDiscountPercentage;
            calculation.AgentsCommission = Calculate.Multiply(calculation.CashSalePrice, input.AdministrativeOverheadPercentage) / 100;
            calculation.AgentsCommissionPercentage = input.AgentsCommissionPercentage;
            calculation.TargetSalePrice = Calculate.Add(calculation.CashSalePrice, calculation.CashDiscount, calculation.AgentsCommission);
            calculation.CustomerDiscount = Calculate.Multiply(calculation.TargetSalePrice, input.CustomerDiscountPercentage) / 100;
            calculation.CustomerDiscountPercentage = input.CustomerDiscountPercentage;
            calculation.ListPrice = Calculate.Add(calculation.TargetSalePrice, calculation.CustomerDiscount);
            calculation.SalesTax = Calculate.Multiply(calculation.ListPrice, input.SalesTaxPercentage) / 100;
            calculation.SalesTaxPercentage = input.SalesTaxPercentage;
            calculation.OfferPrice = Calculate.Add(calculation.ListPrice, calculation.SalesTax);

            return calculation;
        }

        private static Calculation CalculateCalculationDifference(InputObject input, Calculation calculation)
        {
            calculation.MaterialDirectCost = CalculationService.CalcDirectCost(input.Items);
            calculation.ProductionDirectCost = CalculationService.CalcDirectCost(input.Steps);
            calculation.MaterialOverheadPercentage = input.MaterialOverheadPercentage;
            calculation.ProductionOverheadPercentage = input.ProductionOverheadPercentage;
            calculation.MaterialOverhead = Calculate.Multiply(calculation.MaterialDirectCost, input.MaterialOverheadPercentage) / 100;
            calculation.ProductionOverhead = Calculate.Multiply(calculation.ProductionDirectCost, input.ProductionOverheadPercentage) / 100;
            calculation.MaterialCost = Calculate.Add(calculation.MaterialDirectCost, calculation.MaterialOverhead);
            calculation.ProductionCost = Calculate.Add(calculation.ProductionDirectCost, calculation.ProductionOverhead);
            calculation.ManufacturingCost = Calculate.Add(calculation.MaterialCost, calculation.ProductionCost);
            calculation.AdministrativeOverhead = Calculate.Multiply(calculation.ManufacturingCost, input.AdministrativeOverheadPercentage) / 100;
            calculation.AdministrativeOverheadPercentage = input.AdministrativeOverheadPercentage;
            calculation.SellingExpenses = Calculate.Multiply(calculation.ManufacturingCost, input.SellingExpensesPercentage) / 100;
            calculation.SellingExpensesPercentage = input.SellingExpensesPercentage;
            calculation.SelfCost = Calculate.Add(calculation.ManufacturingCost, calculation.AdministrativeOverhead, calculation.SellingExpenses);
            calculation.Profit = Calculate.Multiply(calculation.SelfCost, input.ProfitMarkup) / 100;
            calculation.ProfitMarkup = input.ProfitMarkup;
            calculation.CashSalePrice = Calculate.Add(calculation.SelfCost, calculation.Profit);
            calculation.CashDiscount = Calculate.Multiply(calculation.CashSalePrice, input.CashDiscountPercentage) / 100;
            calculation.CashDiscountPercentage = input.CashDiscountPercentage;
            calculation.AgentsCommission = Calculate.Multiply(calculation.CashSalePrice, input.AdministrativeOverheadPercentage) / 100;
            calculation.AgentsCommissionPercentage = input.AgentsCommissionPercentage;
            calculation.TargetSalePrice = Calculate.Add(calculation.CashSalePrice, calculation.CashDiscount, calculation.AgentsCommission);
            calculation.CustomerDiscount = Calculate.Multiply(calculation.TargetSalePrice, input.CustomerDiscountPercentage) / 100;
            calculation.CustomerDiscountPercentage = input.CustomerDiscountPercentage;
            calculation.ListPrice = Calculate.Add(calculation.TargetSalePrice, calculation.CustomerDiscount);
            calculation.SalesTax = Calculate.Multiply(calculation.ListPrice, input.SalesTaxPercentage) / 100;
            calculation.SalesTaxPercentage = input.SalesTaxPercentage;
            calculation.OfferPrice = Calculate.Add(calculation.ListPrice, calculation.SalesTax);

            return calculation;
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
