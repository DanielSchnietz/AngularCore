using Google.Cloud.Firestore;
using System;


namespace AngularWebApp.Services
{
    [FirestoreData]
    public class CalculationDbDTO
    {
        private double _materialDirectCost;
        private double _materialOverheadPercentage;
        private double _materialOverhead;
        private double _materialCost;
        private double _productionDirectCost;
        private double _productionOverheadPercentage;
        private double _productionOverhead;
        private double _productionCost;
        private double _manufacturingCost;
        private double _administrativeOverheadPercentage;
        private double _administrativeOverhead;
        private double _sellingExpensesPercentage;
        private double _sellingExpenses;
        private double _selfCost;
        private double _profitMarkup;
        private double _profit;
        private double _cashSalePrice;
        private double _cashDiscount;
        private double _cashDiscountPercentage;
        private double _agentsCommission;
        private double _agentsCommissionPercentage;
        private double _targetSalePrice;
        private double _customerDiscount;
        private double _customerDiscountPercentage;
        private double _listPrice;
        private double _salesTax;
        private double _salesTaxPercentage;
        private double _offerPrice;

        [FirestoreProperty]
        public double MaterialDirectCost
        {
            get { return _materialDirectCost; }
            set { _materialDirectCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double MaterialOverheadPercentage
        {
            get { return _materialOverheadPercentage; }
            set { _materialOverheadPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double MaterialOverhead
        {
            get { return _materialOverhead; }
            set { _materialOverhead = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double MaterialCost 
        {
            get { return _materialCost; }
            set { _materialCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ProductionDirectCost 
        {
            get { return _productionDirectCost; }
            set { _productionDirectCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ProductionOverheadPercentage 
        {
            get { return _productionOverheadPercentage; }
            set { _productionOverheadPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ProductionOverhead 
        {
            get { return _productionOverhead; }
            set { _productionOverhead = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ProductionCost 
        {
            get { return _productionCost; }
            set { _productionCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ManufacturingCost 
        {
            get { return _manufacturingCost; }
            set { _manufacturingCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double AdministrativeOverheadPercentage 
        {
            get { return _administrativeOverheadPercentage; }
            set { _administrativeOverheadPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double AdministrativeOverhead 
        {
            get { return _administrativeOverhead; }
            set { _administrativeOverhead = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double SellingExpensesPercentage 
        {
            get { return _sellingExpensesPercentage; }
            set { _sellingExpensesPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double SellingExpenses 
        {
            get { return _sellingExpenses; }
            set { _sellingExpenses = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double SelfCost 
        {
            get { return _selfCost; }
            set { _selfCost = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ProfitMarkup 
        {
            get { return _profitMarkup; }
            set { _profitMarkup = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double Profit 
        {
            get { return _profit; }
            set { _profit = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double CashSalePrice 
        {
            get { return _cashSalePrice; }
            set { _cashSalePrice = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double CashDiscount 
        {
            get { return _cashDiscount; }
            set { _cashDiscount = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double CashDiscountPercentage
        {
            get { return _cashDiscountPercentage; }
            set { _cashDiscountPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double AgentsCommission
        {
            get { return _agentsCommission; }
            set { _agentsCommission = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double AgentsCommissionPercentage 
        {
            get { return _agentsCommissionPercentage; }
            set { _agentsCommissionPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double TargetSalePrice 
        {
            get { return _targetSalePrice; }
            set { _targetSalePrice = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double CustomerDiscount 
        {
            get { return _customerDiscount; }
            set { _customerDiscount = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double CustomerDiscountPercentage 
        {
            get { return _customerDiscountPercentage; }
            set { _customerDiscountPercentage = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double ListPrice 
        {
            get { return _listPrice; }
            set { _listPrice = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double SalesTax 
        {
            get { return _salesTax; }
            set { _salesTax = Math.Round(value, 2); }
        }
        [FirestoreProperty]
        public double SalesTaxPercentage 
        {
            get { return _salesTaxPercentage; }
            set { _salesTaxPercentage = Math.Round(value, 2); }

        }
        [FirestoreProperty]
        public double OfferPrice 
        {
            get { return _offerPrice; }
            set { _offerPrice = Math.Round(value, 2); }
        }

    }
}
