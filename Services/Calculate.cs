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
        public IEnumerable<Step> Steps;
        public double MaterialDirectCost;
        public double MaterialOverheadPercentage;
        public double MaterialOverhead;
        public double MaterialCost;
        //public int steps;
        public double ProductionDirectCost;
        public double ProductionOverheadPercentage;
        public double ProductionOverhead;
        public double ProductionCost;
        public double ManufacturingCost;
        public double AdministrativeOverheadPercentage;
        public double AdministrativeOverhead;
        public double SellingExpensesPercentage;
        public double SellingExpenses;
        public double SelfCost;
        public double ProfitMarkup;
        public double Profit;
        public double CashSalePrice;
        public double CashDiscount;
        public double CashDiscountPercentage;
        public double AgentsCommission;
        public double AgentsCommissionPercentage;
        public double TargetSalePrice;
        public double CustomerDiscount;
        public double CustomerDiscountPercentage;
        public double ListPrice;
        public double SalesTax;
        public double SalesTaxPercentage;
        public double OfferPrice;

        public Calculate(InputObject inputObject)
        {
            //dataset = data;
            Items = inputObject.Items;
            //MaterialDirectCost = 0;
            MaterialOverheadPercentage = inputObject.MaterialOverheadPercentage;
            //MaterialOverhead = 0;
            //MaterialCost = 0;
            Steps = inputObject.Steps;
            //ProductionDirectCost = 0;
            //ManufacturingCost = 0;
            ProductionOverheadPercentage = inputObject.ProductionOverheadPercentage;
            AdministrativeOverheadPercentage = inputObject.AdministrativeOverheadPercentage;
            SellingExpensesPercentage = inputObject.SellingExpensesPercentage;
            //SellingExpenses = 0;
            //SelfCost = 0;
            ProfitMarkup = inputObject.ProfitMarkup;
            //Profit = 0;
            CashDiscountPercentage = inputObject.CustomerDiscountPercentage;
            AgentsCommissionPercentage = inputObject.AgentsCommissionPercentage;
            CustomerDiscountPercentage = inputObject.CustomerDiscountPercentage;
            SalesTaxPercentage = inputObject.SalesTaxPercentage;
            //bvp = 0;    
            //vgkperc = 0;
            //mgkperc = 0;  
        }
        public async Task StartCalculation()
        {
            var calcOverhead = new PercentageCalculation();
            var calcCost = new Calculation();
            var matDirect = calcMaterialDirectCost(ref MaterialDirectCost);
            //var prodDirect = calcProductionDirectCost();
            //await Task.WhenAll(matDirect, prodDirect);
            MaterialOverhead = await Task.Run(() => calcOverhead.Multiply( MaterialDirectCost,  MaterialOverheadPercentage));
            ProductionOverheadPercentage = await Task.Run(() => calcOverhead.Multiply(ProductionDirectCost, ProductionOverheadPercentage));
            MaterialCost = await Task.Run(() => calcCost.Add(MaterialDirectCost, MaterialOverhead));
            ProductionCost = await Task.Run(() => calcCost.Add(ProductionDirectCost, ProductionOverhead));
            AdministrativeOverhead = await Task.Run(() => calcOverhead.Multiply(ManufacturingCost, AdministrativeOverheadPercentage));
            SellingExpenses = await Task.Run(() => calcOverhead.Multiply(ManufacturingCost, SellingExpensesPercentage));
            //add methode überarbeiten
            SelfCost = await Task.Run(() => calcCost.Add(ManufacturingCost, AdministrativeOverhead, SellingExpenses));
            Profit = await Task.Run(() => calcOverhead.Multiply(SelfCost, ProfitMarkup));
            CashSalePrice = await Task.Run(() => calcCost.Add(SelfCost, Profit));
            CashDiscount = await Task.Run(() => calcOverhead.Multiply(CashSalePrice, CashDiscountPercentage));
            AgentsCommission = await Task.Run(() => calcOverhead.Multiply(CashSalePrice, AdministrativeOverheadPercentage));
            TargetSalePrice = await Task.Run(() => calcCost.Add(CashSalePrice, CashDiscount, AgentsCommission));
            CustomerDiscount = await Task.Run(() => calcOverhead.Multiply(TargetSalePrice, CustomerDiscountPercentage));
            ListPrice = await Task.Run(() => calcCost.Add(TargetSalePrice, CustomerDiscount));
            SalesTax = await Task.Run(() => calcOverhead.Multiply(ListPrice, SalesTaxPercentage));
            OfferPrice = await Task.Run(() => calcCost.Add(ListPrice, SalesTax));
    }
    
        private Task calcMaterialDirectCost(ref double i)
        {
            foreach (Item item in Items)
            {
                i += item.Price * item.Amount;
            };
            return Task.CompletedTask;
            //calculateMGK();
        }
        //private void calcOverhead(ref double overhead, double directCost, double percentage )
       // {
        //    var calcOverhead = new PercentageCalculation();
         //   overhead = calcOverhead.Multiply(directCost, percentage);
       // }
        private void calcCost(ref double cost, double directCost, double overhead)
        {
            var addDirectCostAndOverhead = new Calculation();
            cost = addDirectCostAndOverhead.Add(directCost, overhead);
            //calculateFEK();
        }
        private Task calcProductionDirectCost()
        {
            foreach (Step step in Steps)
            {
                if (step.Price < 0)
                {
                    step.Price = 0;
                }


                if (step.Time < 0)
                {
                    step.Time = 0;
                }

                fek += step.Price * step.Time;
            };
            //calculateFGK();
            return Task.CompletedTask;
        }

        private void calculateFGK()
        {
            fgk = fek * fgkperc / 100;
            calculateFK();
        }

        private void calculateFK()
        {
            fk = fek + fgk;
            calculateHK();
        }

        private void calculateHK()
        {
            hk = mk + fek;
            calculateVGK();
        }
        private void calculateVertGK()
        {
            vertGK = hk * vertgkperc / 100;
            calculateVerwGK();
        }

        private void calculateVerwGK()
        {
            verwGK = hk * verwgkperc / 100;
            calculateversK();
        }
        private void calculateSK()
        {
            sk = hk + vertGK + verwGK;
            calculateG();
        }
        private void calculateG()
        {
            if (perc > 20)
            {
                perc = 20;
            }

            g = sk / 100 * perc;
            calculateBVP();
        }
        private void calculateBVP()
        {
            bvp = sk + g;
            createOutput();
        }
        public void createOutput()
        {
          
        }
    }
}
