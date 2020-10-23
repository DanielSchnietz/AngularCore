

import { Injectable } from '@angular/core';
import { PreliminaryCalculation } from '../models/preliminary-calculation.model';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';




@Injectable({
  providedIn: 'root'
})

export class CalculationService {
  constructor(private http: HttpClient) { }

  public getCalculatedData(inputData): Observable<any> {
    const headers = { 'Content-Type': 'application/json' }
    console.log(JSON.stringify(inputData))
    //hardcoded url is just a placeholder. interceptors will be added
    return this.http.post<PreliminaryCalculation>("https://localhost:44384/api/calculate", JSON.stringify(inputData), { headers })
   
   
    
  }
}
