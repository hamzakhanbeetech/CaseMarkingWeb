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

  getMarkedCaseHistory(userId:any, dateFrom: any, dateTo: any): Observable<any> {

    return this.http.get(environment.apiUrl+'Auth/get-marked-case-history/'+userId+'?dateFrom='+dateFrom+'&dateTo='+dateTo).pipe(

      catchError(this.handleError)

    );    

  }

  createCategory(category: any): Observable<any> {
    return this.http.post<any>(environment.apiUrl+'casecategory', category);
  }

  updateCategory(id: number, category: any): Observable<void> {
    return this.http.put<void>(`${environment.apiUrl}casecategory /${id}`, category);
  }

  deleteCategory(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}casecategory/${id}`);
  }
  getCategories(userId:any): Observable<any> {
    const url = `${environment.apiUrl}casecategory/${userId}`;
    return this.http.get(url);
  }
  
  createCourt(court: any): Observable<any> {
    return this.http.post<any>(environment.apiUrl+'courts', court);
  }

  updateCourt(id: number, court: any): Observable<void> {
    return this.http.put<void>(`${environment.apiUrl}courts /${id}`, court);
  }

  deleteCourt(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}courts/${id}`);
  }
  getCourts(userId:any): Observable<any> {
    const url = `${environment.apiUrl}courts/${userId}`;
    return this.http.get(url);
  }

  addEmployee(data: any): Observable<any> {

    return this.http.post(environment.apiUrl+'employeemanagement/add-employee', data).pipe(

      catchError(this.handleError)

    );

  }

  getEmployeeList(): Observable<any> {

    return this.http.get(environment.apiUrl+'employeemanagement/employee-list').pipe(

      catchError(this.handleError)

    );

  }

  getEmployeeDetail(id:any): Observable<any> {

    return this.http.get(environment.apiUrl+'employeemanagement/employee-detail/'+id).pipe(

      catchError(this.handleError)

    );

  }

  transferEmployee(request:any): Observable<any> {

    return this.http.post(environment.apiUrl+'employeemanagement/transfer-employee/'+request.employeeId, request).pipe(

      catchError(this.handleError)

    );

  }

  getEmployeeTransferHistory(id:any): Observable<any> {

    return this.http.get(environment.apiUrl+'employeemanagement/get-transfer-history/'+id).pipe(

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