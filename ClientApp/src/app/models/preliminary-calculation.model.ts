import { Deserializable } from "./deserializable.model";

export class PreliminaryCalculation implements Deserializable{
  public DirectMaterialCost: number;
  public MaterialOverhead: number;
  public MaterialCost: number;
  public DirectProductionCost: number;
  public ProductionOverhead: number;
  public ProductionCost: number;
  public ManufacturingCost: number;
  public AdministrativeOverhead: number
  public SellingExpenses: number;
  public SelfCost: number;
  public ProfitMarkup: number;
  public Profit: number;
  public CashSalePrice: number;
  public CashDiscount: number;
  public CashDiscountPercentage: number;
  public AgentsCommission: number;
  public AgentsCommissionPercentage: number;
  public TargetSalePrice: number;
  public CustomerDiscount: number;
  public CustomerDiscountPercentage: number;
  public ListPrice: number;
  public SalesTax: number;
  public SalesTaxPercentage: number;
  public OfferPrice: number;
    actions: any;


  public deserialize(input: any):this {
    Object.assign(this, input);
    return this;
  }
}

