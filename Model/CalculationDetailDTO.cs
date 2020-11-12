using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace AngularWebApp.Services
{
    [FirestoreData]
    public class CalculationDetailDTO
    {
        [FirestoreProperty]
        public string Id { get; set;}
        [FirestoreProperty]
        public double MaterialDirectCost { get; set; }
        [FirestoreProperty]
        public double MaterialOverheadPercentage { get; set; }
        [FirestoreProperty]
        public double MaterialOverhead { get; set; }
        [FirestoreProperty]
        public double MaterialCost { get; set; }
        [FirestoreProperty]
        public double ProductionDirectCost { get; set; }
        [FirestoreProperty]
        public double ProductionOverheadPercentage { get; set; }
        [FirestoreProperty]
        public double ProductionOverhead { get; set; }
        [FirestoreProperty]
        public double ProductionCost { get; set; }
        [FirestoreProperty]
        public double ManufacturingCost { get; set; }
        [FirestoreProperty]
        public double AdministrativeOverheadPercentage { get; set; }
        [FirestoreProperty]
        public double AdministrativeOverhead { get; set; }
        [FirestoreProperty]
        public double SellingExpensesPercentage { get; set; }
        [FirestoreProperty]
        public double SellingExpenses { get; set; }
        [FirestoreProperty]
        public double SelfCost { get; set; }
        [FirestoreProperty]
        public double ProfitMarkup { get; set; }
        [FirestoreProperty]
        public double Profit { get; set; }
        [FirestoreProperty]
        public double CashSalePrice { get; set; }
        [FirestoreProperty]
        public double CashDiscount { get; set; }
        [FirestoreProperty]
        public double CashDiscountPercentage { get; set; }
        [FirestoreProperty]
        public double AgentsCommission { get; set; }
        [FirestoreProperty]
        public double AgentsCommissionPercentage { get; set; }
        [FirestoreProperty]
        public double TargetSalePrice { get; set; }
        [FirestoreProperty]
        public double CustomerDiscount { get; set; }
        [FirestoreProperty]
        public double CustomerDiscountPercentage { get; set; }
        [FirestoreProperty]
        public double ListPrice { get; set; }
        [FirestoreProperty]
        public double SalesTax { get; set; }
        [FirestoreProperty]
        public double SalesTaxPercentage { get; set; }
        [FirestoreProperty]
        public double OfferPrice { get; set; }
    }
}
