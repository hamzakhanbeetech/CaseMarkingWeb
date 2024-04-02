import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router, private http: HttpClient) { }

  login(request:any){
    return this.http.post(environment.apiUrl+'authentication/login', request).pipe(

      catchError(this.handleError)

    );

  }

  logOutUser() {
    const userData = localStorage.getItem("userData")
    if (!userData) {
      return
    }
    localStorage.removeItem("userData")
    this.router.navigate(['/authentication/sign-in'])
  }


  roleBasedredirection(resp: any) {
    let role = resp.userData.roleId
    let userId = resp.userData.customerId ?? 0
    if (role == 1) { // 2 = distributor
      this.router.navigate(['/'])
      return

    }
    if (role == 2) {
      this.router.navigate(['customers'], { queryParams: { id: resp.distributorId, distributorName: resp.distributerName } })
      return

    }

    if (role == 3) { // 3 = customer
      this.router.navigate(['/projects'], { queryParams: { custId: userId } })
      return

    }

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
