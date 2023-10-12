import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';

import { catchError } from 'rxjs/operators';




@Injectable({

  providedIn: 'root'

})

export class ApiService {

  private baseUrl = 'https://localhost:7196/api/';




  constructor(private http: HttpClient) { }



  addMarkedCase(caseData: any): Observable<any> {


    return this.http.post('https://localhost:7196/api/Auth/add-marked-case', caseData).pipe(

      catchError(this.handleError)

    );

  }
  getMarkedCaseHistory(dateFrom: any, dateTo: any): Observable<any> {


    return this.http.get('https://localhost:7196/api/Auth/get-marked-case-history?dateFrom='+dateFrom+'&dateTo='+dateTo).pipe(

      catchError(this.handleError)

    );
    

  }

  
  private handleError(error: any) {

    if (error instanceof HttpErrorResponse) {

      console.error('Backend returned code ' + error.status + ', body was:', error.error);

      if (error.error && error.error.errors) {

        console.error('Validation errors:', error.error.errors);

      }

    } else {

      console.error('An error occurred:', error);

    }

    return throwError('Something went wrong. Please try again later.');

  }









}