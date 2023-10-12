import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private router: Router){}

  signOut(): void {
    localStorage.removeItem("userData")

    this.router.navigate(['/anonymous-dashboard']);

  }

  isAuthenticated(){
    var userData = localStorage.getItem("userData")

    if(userData){
      return true
    }
    return false;
  }

}
