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
    public class Calculate
    {
        private IEnumerable<Item> Items;
        private IEnumerable<Step> Steps;
        private double MaterialDirectCost;
        private double MaterialOverheadPercentage;
        private double MaterialOverhead;
        private double MaterialCost;
        private double ProductionDirectCost;
        private double ProductionOverheadPercentage;
        private double ProductionOverhead;
        private double ProductionCost;
        private double ManufacturingCost;
        private double AdministrativeOverheadPercentage;
        private double AdministrativeOverhead;
        private double SellingExpensesPercentage;
        private double SellingExpenses;
        private double SelfCost;
        private double ProfitMarkup;
        private double Profit;
        private double CashSalePrice;
        private double CashDiscount;
        private double CashDiscountPercentage;
        private double AgentsCommission;
        private double AgentsCommissionPercentage;
        private double TargetSalePrice;
        private double CustomerDiscount;
        private double CustomerDiscountPercentage;
        private double ListPrice;
        private double SalesTax;
        private double SalesTaxPercentage;
        private double OfferPrice;
        private double Time;

        public Calculate(InputObject inputObject)
        {
            Items = inputObject.Items;
            MaterialOverheadPercentage = inputObject.MaterialOverheadPercentage;
            Steps = inputObject.Steps;
            ProductionOverheadPercentage = inputObject.ProductionOverheadPercentage;
            AdministrativeOverheadPercentage = inputObject.AdministrativeOverheadPercentage;
            SellingExpensesPercentage = inputObject.SellingExpensesPercentage;
            ProfitMarkup = inputObject.ProfitMarkup;
            CashDiscountPercentage = inputObject.CustomerDiscountPercentage;
            AgentsCommissionPercentage = inputObject.AgentsCommissionPercentage;
            CustomerDiscountPercentage = inputObject.CustomerDiscountPercentage;
            SalesTaxPercentage = inputObject.SalesTaxPercentage;
        }
        public async Task<CalculationDetailDTO> ForwardCalculation()
        {
            var data = new DatabaseAccess();
            var calcOverhead = new PercentageCalculation();
            var calcCost = new Calculation();
            var matDirect = CalcDirectCost(Items);
            var prodDirect = CalcDirectCost(Steps);
            MaterialDirectCost =  await matDirect;
            ProductionDirectCost =  await prodDirect;
            MaterialOverhead = calcOverhead.Multiply(MaterialDirectCost, MaterialOverheadPercentage);
            ProductionOverhead = calcOverhead.Multiply(ProductionDirectCost, ProductionOverheadPercentage);
            MaterialCost = calcCost.Add(MaterialDirectCost, MaterialOverhead);
            ProductionCost = calcCost.Add(ProductionDirectCost, ProductionOverhead);
            ManufacturingCost = calcCost.Add(MaterialCost, ProductionCost);
            AdministrativeOverhead = calcOverhead.Multiply(ManufacturingCost, AdministrativeOverheadPercentage);
            SellingExpenses = calcOverhead.Multiply(ManufacturingCost, SellingExpensesPercentage);
            SelfCost = calcCost.Add(ManufacturingCost, AdministrativeOverhead, SellingExpenses);
            Profit = calcOverhead.Multiply(SelfCost, ProfitMarkup);
            CashSalePrice = calcCost.Add(SelfCost, Profit);
            CashDiscount = calcOverhead.Multiply(CashSalePrice, CashDiscountPercentage);
            AgentsCommission = calcOverhead.Multiply(CashSalePrice, AdministrativeOverheadPercentage);
            TargetSalePrice = calcCost.Add(CashSalePrice, CashDiscount, AgentsCommission);
            CustomerDiscount = calcOverhead.Multiply(TargetSalePrice, CustomerDiscountPercentage);
            ListPrice = calcCost.Add(TargetSalePrice, CustomerDiscount);
            SalesTax = calcOverhead.Multiply(ListPrice, SalesTaxPercentage);
            OfferPrice = calcCost.Add(ListPrice, SalesTax);

            var calculation = GetCalculationDetailDTO();
            return await data.AddCalculation(calculation);
            //put everything to db
    }
    


        public CalculationDetailDTO GetCalculationDetailDTO()
        {
            return new CalculationDetailDTO
            {
                MaterialDirectCost = Math.Round(MaterialDirectCost, 2),
                MaterialOverheadPercentage = Math.Round(MaterialOverheadPercentage, 2),
                MaterialOverhead = Math.Round(MaterialOverhead, 2),
                MaterialCost = Math.Round(MaterialCost, 2),
                ProductionDirectCost = Math.Round(ProductionDirectCost, 2),
                ProductionOverheadPercentage = Math.Round(ProductionOverheadPercentage, 2),
                ProductionOverhead = Math.Round(ProductionOverhead, 2),
                ProductionCost = Math.Round(ProductionCost, 2),
                ManufacturingCost = Math.Round(ManufacturingCost, 2),
                AdministrativeOverheadPercentage = Math.Round(AdministrativeOverheadPercentage, 2),
                AdministrativeOverhead = Math.Round(AdministrativeOverhead, 2),
                SellingExpensesPercentage = Math.Round(SellingExpensesPercentage, 2),
                SellingExpenses = Math.Round(SellingExpenses, 2),
                SelfCost = Math.Round(SelfCost, 2),
                ProfitMarkup = Math.Round(ProfitMarkup, 2),
                Profit = Math.Round(Profit, 2),
                CashSalePrice = Math.Round(CashSalePrice, 2),
                CashDiscount = Math.Round(CashDiscount, 2),
                CashDiscountPercentage = Math.Round(CashDiscountPercentage, 2),
                AgentsCommission = Math.Round(AgentsCommission, 2),
                AgentsCommissionPercentage = Math.Round(AgentsCommissionPercentage, 2),
                TargetSalePrice = Math.Round(TargetSalePrice, 2),
                CustomerDiscount = Math.Round(CustomerDiscount, 2),
                CustomerDiscountPercentage = Math.Round(CustomerDiscountPercentage, 2),
                ListPrice = Math.Round(ListPrice, 2),
                SalesTax = Math.Round(SalesTax, 2),
                SalesTaxPercentage = Math.Round(SalesTaxPercentage, 2),
                OfferPrice = Math.Round(OfferPrice, 2)
        };  
    }
        private Task<double> CalcDirectCost(dynamic obj)
        {
            //double result;
            var task = Task.Run(() =>
            {
                var calc = new Calculation();
                double res = 0;
                foreach (var item in obj)
                {
                    res += calc.Multiply(item.Price, item.Amount);
                };
                return res;
            });
            return task;
        }
    }
}
