import { Deserializable } from "./deserializable.model";

export class PreliminaryCalculation implements Deserializable{
  public DirectMaterialCost: number;
  public MaterialOverhead: number;
  public MaterialCost: number;
  public DirectProductionCost: number;
  public ProductionOverhead: number;
  public ProductionCost: number;
  public AdministrativeOverhead: number
  public SellingExpenses: number;
  public SelfCost: number;
  public ProfitMarkup: number;
  public CashSelfPrice: number;
  public CashDiscount: number;
  public AgentsCommission: number;
  public TargetSalePrice: number
  public CustomerDiscount: number;
  public ListPrice: number;
  public SalesTax: number;
  public OfferPrice: number;


  public deserialize(input: any):this {
    Object.assign(this, input);
    return this;
  }
}

