import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';

import { catchError } from 'rxjs/operators';

import { environment } from 'src/environment/environment';




@Injectable({

  providedIn: 'root'

})

export class ApiService {



  constructor(private http: HttpClient) { }



  addMarkedCase(caseData: any): Observable<any> {


    return this.http.post(environment.apiUrl+'Auth/add-marked-case', caseData).pipe(

      catchError(this.handleError)

    );

  }
  getMarkedCaseHistory(dateFrom: any, dateTo: any): Observable<any> {


    return this.http.get(environment.apiUrl+'Auth/get-marked-case-history?dateFrom='+dateFrom+'&dateTo='+dateTo).pipe(

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