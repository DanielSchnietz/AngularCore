

import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})

export class CalculationService {


   public getCalculatedData(inputData) {
    console.log(inputData)
  }
}
