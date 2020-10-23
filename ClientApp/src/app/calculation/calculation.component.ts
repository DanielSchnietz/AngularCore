import { Component, OnInit, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as uuid from 'uuid';
import { CalculationService } from '../services/calculate.service'
import {FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';
import { Observable } from 'rxjs';
import { PreliminaryCalculation } from '../models/preliminary-calculation.model';
import { map } from 'rxjs/operators'




@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})


export class CalculationComponent implements OnInit {
  public apiResponse = null;
  public dataSubmitted = false
  public calculation$: Observable<any>;

  frm = this.fb.group({
    items: this.fb.array([
      this.createItemGroup()
    ]),
    materialOverheadPercentage : [null],
    steps: this.fb.array([
      this.createStepGroup()
    ]),
    
    productionOverheadPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    administrativeOverheadPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    sellingExpensesPercentage: [null, [
      Validators.required,
      Validators.min(0)
    ]],
    profitMarkup : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    cashDiscountPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    agentsCommissionPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    customerDiscountPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    salesTaxPercentage : [null, [
      Validators.required,
      Validators.min(0)
    ]]
  })
  


  constructor( private calculationService: CalculationService, private fb: FormBuilder) {}
 
  get items(): FormArray { return this.frm.get('items') as FormArray; }

  get steps(): FormArray { return this.frm.get('steps') as FormArray; }
  //MaterialOverhead
  get productionOverheadPercentage() { return this.frm.get('productionOverheadPercentage') }
  get administrativeOverheadPercentage() { return this.frm.get('administrativeOverheadPercentage') }
  get sellingExpensesPercentage() { return this.frm.get('sellingExpensesPercentage') }
  get profitMarkup() { return this.frm.get('profitMarkup') }
  get cashDiscountPercentage() { return this.frm.get('cashDiscountPercentage') }
  get agentsCommissionPercentage() { return this.frm.get('agentsCommissionPercentage') }
  get customerDiscountPercentage() { return this.frm.get('customerDiscountPercentage') }
  get salesTaxPercentage() { return this.frm.get('salesTaxPercentage') }

  public addItem() {
    this.items.push(this.createItemGroup());
  };

  public deleteItem(index:number): void {
    this.items.removeAt(index)
  }

  private createItemGroup() {
    return this.fb.group({
      itemNo: ['', [
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      itemDesc: ['', [
        Validators.required,
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      amount: [null, [
        Validators.required,
        Validators.min(0)
      ]],
      price: [null, [
        Validators.required,
        Validators.min(0)
      ]],
    })
  }

  private createStepGroup() {
    return this.fb.group({
      stepNo: ['', [
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      stepDesc: ['', [
        Validators.required,
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      amount: [null, [
        Validators.required,
        Validators.min(0)
      ]],
      price: [null, [
        Validators.required,
        Validators.min(0)
      ]]
    })
  }
  public addStep(): void {
    this.steps.push(this.createStepGroup())  
  }

  public deleteStep(index): void {
    console.log(index)
    this.steps.removeAt(index)
  }

  public submitCalculation(e):void{
    
    e.preventDefault()
  
    this.calculation$ = this.calculationService.getCalculatedData(this.frm.value)
    this.dataSubmitted = true
    console.log(this.calculation$)
    };

  ngOnInit() {
  }

}
