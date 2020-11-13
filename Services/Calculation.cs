﻿using AngularWebApp.Interfaces;
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
    public class Calculation : ICalculation
    {
        public double MaterialDirectCost { get; set; }
        public double MaterialOverheadPercentage { get; set; }
        public double MaterialOverhead { get; set; }
        public double MaterialCost { get; set; }
        public double ProductionDirectCost { get; set; }
        public double ProductionOverheadPercentage { get; set; }
        public double ProductionOverhead { get; set; }
        public double ProductionCost { get; set; }
        public double ManufacturingCost { get; set; }
        public double AdministrativeOverheadPercentage { get; set; }
        public double AdministrativeOverhead { get; set; }
        public double SellingExpensesPercentage { get; set; }
        public double SellingExpenses { get; set; }
        public double SelfCost { get; set; }
        public double ProfitMarkup { get; set; }
        public double Profit { get; set; }
        public double CashSalePrice { get; set; }
        public double CashDiscount { get; set; }
        public double CashDiscountPercentage { get; set; }
        public double AgentsCommission { get; set; }
        public double AgentsCommissionPercentage { get; set; }
        public double TargetSalePrice { get; set; }
        public double CustomerDiscount { get; set; }
        public double CustomerDiscountPercentage { get; set; }
        public double ListPrice { get; set; }
        public double SalesTax { get; set; }
        public double SalesTaxPercentage { get; set; }
        public double OfferPrice { get; set; }

        public virtual Calculation CalculateCalculation(InputObject input)
        {
            Calculation calculation = new Calculation();
            return calculation;
        }

            
    }
}
