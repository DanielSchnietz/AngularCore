

import { Injectable } from '@angular/core';
import { PreliminaryCalculation } from '../models/preliminary-calculation.model';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class CalculationService {
  constructor(private http: HttpClient) { }

  public getPreliminaryCalculation(): Observable<PreliminaryCalculation> {
    return this.http.post<PreliminaryCalculation>("http://localhost:3000/api/calculation/").pipe(
      map(data => new PreliminaryCalculation().deserialize(data)),
      catchError(() => throwError('User not found'))
    );
  }
}
