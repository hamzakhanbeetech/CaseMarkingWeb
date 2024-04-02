import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, } from 'rxjs';
import { AuthService } from '../auth/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  jwtHelper = new JwtHelperService();
  constructor(private router: Router, private authService: AuthService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      
      const userData = localStorage.getItem('userData')


      if(userData){
        const token = JSON.parse(userData)?.token

        if(token && !this.jwtHelper.isTokenExpired(token)){

          return true

        }
        this.authService.logOutUser()
        return false
      }
      else{

        this.router.navigate(['/authentication/sign-in']);
        return false

      }
  }

}



@Injectable({
  providedIn: 'root'
})
export class OnlyAnonymous implements CanActivate {
  jwtHelper = new JwtHelperService();

  constructor(private router: Router, private _authService: AuthService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      
      let userData: any = localStorage.getItem('userData')


      if(!userData){
        return true
      }
      else{
        userData = JSON.parse(userData) as any
        const token = userData?.token
        if(token && this.jwtHelper.isTokenExpired(token)){

          return true
        }

        this._authService.roleBasedredirection(userData)
        return false

      }

    
  }

}

@Injectable({
  providedIn: 'root'
})
export class OnlyAdmin implements CanActivate {
  jwtHelper = new JwtHelperService();
  constructor(private router: Router, private authService: AuthService){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      
      const userData = localStorage.getItem('userData')


      if(userData){
        const token = JSON.parse(userData)?.token
        const data = JSON.parse(userData)?.userData

        if(token && data && !this.jwtHelper.isTokenExpired(token) && data.roleId == 1){

          return true

        }
        this.authService.logOutUser()
        return false
      }
      else{

        this.router.navigate(['/authenticate']);
        return false

      }
  }

}

@Injectable({
  providedIn: 'root'
})
export class OnlyDistributor implements CanActivate {
  constructor(private router: Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const authenticationToken = localStorage.getItem('authenticatedByLoginToken')
      const userData = localStorage.getItem('userData')
      if(authenticationToken && userData){
        let user = JSON.parse(userData)
        if(user.userRoles.find((x:any) => x.role.roleName == "distributor") != null){
        return true
        }

      this.router.navigate(['/']);
        return false
      }

      this.router.navigate(['/authenticate']);
      return false
  }

}
