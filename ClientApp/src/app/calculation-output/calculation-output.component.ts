import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { PreliminaryCalculation } from '../models/preliminary-calculation.model';

@Component({
  selector: 'app-calculation-output',
  templateUrl: './calculation-output.component.html',
  styleUrls: ['./calculation-output.component.css']
})
export class CalculationOutputComponent  {
  @Input() calculation$ : Observable<any>

  ngOnInit() {
  }

}
