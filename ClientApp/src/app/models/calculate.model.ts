export class CalculatedOffer {
  public Items: IItems;
  public Steps: ISteps;
  public MaterialOverhead: number;
  public ProductionOverhead: number;
  public AdministrativeOverhead: number
  public SellingExpenses: number;
  public ProfitMarkup: number;
  public CashDiscount: number;
  public AgentsCommission: number;
  public CustomerDiscount: number;
  public SalesTax: number;

}

interface IItems {
  itemno: string,
  itemdesc: string,
  amount: number,
  price:number
}

interface ISteps {
  stepno: string,
  stepdesc: string,
  time: number,
  price: number
}
