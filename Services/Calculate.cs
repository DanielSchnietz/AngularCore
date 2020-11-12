using AngularWebApp.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AngularWebApp.Services
{
    public static class Calculate
    {
        public static async Task<CalculationDetailDTO> CreateCalculation(InputObject input)
        {
            
            var db = new DatabaseAccess();
            var calc = ForwardCalculation(input);
            return await db.AddCalculation(calc);
        }

        public static async Task UpdateCalculation(string Id, InputObject input)
        {
            var db = new DatabaseAccess();
         var calculation =  ForwardCalculation(input);
            await db.ChangeCalculationById(Id, calculation );
        }
    
        private static CalculationDbDTO ForwardCalculation(InputObject input)
        {
            //var calcOverhead = new PercentageCalculation();
            var matDirect = CalcDirectCost(input.Items);
            var prodDirect = CalcDirectCost(input.Steps);
            var calculation = new CalculationDbDTO();
            //change calculation object to input object to calculate %
            calculation.MaterialDirectCost =  matDirect;
            calculation.ProductionDirectCost = prodDirect;
            calculation.MaterialOverheadPercentage = input.MaterialOverheadPercentage;
            calculation.ProductionOverheadPercentage = input.ProductionOverheadPercentage;
            calculation.MaterialOverhead = Calculation.Multiply(calculation.MaterialDirectCost, input.MaterialOverheadPercentage) / 100;
            calculation.ProductionOverhead = Calculation.Multiply(calculation.ProductionDirectCost, input.ProductionOverheadPercentage) / 100;
            calculation.MaterialCost = Calculation.Add(calculation.MaterialDirectCost, calculation.MaterialOverhead);
            calculation.ProductionCost = Calculation.Add (calculation.ProductionDirectCost, calculation.ProductionOverhead);
            calculation.ManufacturingCost = Calculation.Add(calculation.MaterialCost, calculation.ProductionCost);
            calculation.AdministrativeOverhead = Calculation.Multiply(calculation.ManufacturingCost, input.AdministrativeOverheadPercentage)/100;
            calculation.AdministrativeOverheadPercentage = input.AdministrativeOverheadPercentage;
            calculation.SellingExpenses = Calculation.Multiply(calculation.ManufacturingCost, input.SellingExpensesPercentage)/100;
            calculation.SellingExpensesPercentage = input.SellingExpensesPercentage;
            calculation.SelfCost = Calculation.Add(calculation.ManufacturingCost, calculation.AdministrativeOverhead, calculation.SellingExpenses);
            calculation.Profit = Calculation.Multiply(calculation.SelfCost, input.ProfitMarkup)/100;
            calculation.ProfitMarkup = input.ProfitMarkup;
            calculation.CashSalePrice = Calculation.Add(calculation.SelfCost, calculation.Profit);
            calculation.CashDiscount = Calculation.Multiply(calculation.CashSalePrice, input.CashDiscountPercentage)/100;
            calculation.CashDiscountPercentage = input.CashDiscountPercentage;
            calculation.AgentsCommission = Calculation.Multiply(calculation.CashSalePrice, input.AdministrativeOverheadPercentage)/100;
            calculation.AgentsCommissionPercentage = input.AgentsCommissionPercentage;
            calculation.TargetSalePrice = Calculation.Add(calculation.CashSalePrice, calculation.CashDiscount, calculation.AgentsCommission);
            calculation.CustomerDiscount = Calculation.Multiply(calculation.TargetSalePrice, input.CustomerDiscountPercentage)/100;
            calculation.CustomerDiscountPercentage = input.CustomerDiscountPercentage;
            calculation.ListPrice = Calculation.Add(calculation.TargetSalePrice, calculation.CustomerDiscount);
            calculation.SalesTax = Calculation.Multiply(calculation.ListPrice, input.SalesTaxPercentage)/100;
            calculation.SalesTaxPercentage = input.SalesTaxPercentage;
            calculation.OfferPrice = Calculation.Add(calculation.ListPrice, calculation.SalesTax);



            return calculation;
        }
            
            //put everything to db
    
    




        private static double CalcDirectCost(dynamic obj)
        {
                double res = 0;
                foreach (var item in obj)
                {
                    res += Calculation.Multiply(item.Price, item.Amount);
                };
                return res;
        }
    }
}
