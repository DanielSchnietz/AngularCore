import { Component, OnInit, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as uuid from 'uuid';
import { CalculationService } from '../services/calculate.service'
import {FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';



@Component({
  selector: 'app-calculation',
  templateUrl: './calculation.component.html',
  styleUrls: ['./calculation.component.css']
})


export class CalculationComponent implements OnInit {
  public apiResponse = null;
  public dataSubmitted = false

  frm = this.fb.group({
    items: this.fb.array([
      this.createItemGroup()
    ]),
    matOverheadFormControl : [null],
    steps: this.fb.array([
      this.createStepGroup()
    ]),
    
    prodOverheadFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    adminOverheadFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    sellExpFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    profMarkFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    cashDiscFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    agentsCommFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    custDiscountFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]],
    salesTaxFormControl : [null, [
      Validators.required,
      Validators.min(0)
    ]]
  })
  


  constructor( private calculationService: CalculationService, private fb: FormBuilder) {}
 
  get items(): FormArray { return this.frm.get('items') as FormArray; }

  get steps(): FormArray { return this.frm.get('steps') as FormArray; }

  get prodOverheadFormControl() { return this.frm.get('prodOverheadFormControl') }
  get adminOverheadFormControl() { return this.frm.get('adminOverheadFormControl') }
  get sellExpFormControl() { return this.frm.get('sellExpFormControl') }
  get profMarkFormControl() { return this.frm.get('profMarkFormControl') }
  get cashDiscFormControl() { return this.frm.get('cashDiscFormControl') }
  get agentsCommFormControl() { return this.frm.get('agentsCommFormControl') }
  get custDiscountFormControl() { return this.frm.get('custDiscountFormControl') }
  get salesTaxFormControl() { return this.frm.get('salesTaxFormControl') }

  public addItem() {
    this.items.push(this.createItemGroup());
  };

  public deleteItem(index:number): void {
    this.items.removeAt(index)
  }

  private createItemGroup() {
    return this.fb.group({
      itemNoFormControl: ['', [
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      itemDescFormControl: ['', [
        Validators.required,
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      itemAmountFormControl: [null, [
        Validators.required,
        Validators.min(0)
      ]],
      itemPriceFormControl: [null, [
        Validators.required,
        Validators.min(0)
      ]],
    })
  }

  private createStepGroup() {
    return this.fb.group({
      stepNoFormControl: ['', [
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      stepDescFormControl: ['', [
        Validators.required,
        Validators.pattern('[a-zA-Z0-9-/]*')
      ]],
      stepTimeFormControl: [null, [
        Validators.required,
        Validators.min(0)
      ]],
      stepPriceFormControl: [null, [
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

  public submitCalculation(): void {
    //this.calculationService.getCalculatedData(this.frm.value)
    this.dataSubmitted = true
console.log(this.frm.value)
    };

  ngOnInit() {
  }

}
