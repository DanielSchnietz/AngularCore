using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class ForwardCalculation : Calculation
    {


        public override Calculation CalculateCalculation(InputObject input)
        {
            var matDirect = CalculationService.CalcDirectCost(input.Items);
            var prodDirect = CalculationService.CalcDirectCost(input.Steps);
            Calculation calculation = new Calculation();
            calculation.MaterialDirectCost = matDirect;
            calculation.ProductionDirectCost = prodDirect;
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
    }
}
