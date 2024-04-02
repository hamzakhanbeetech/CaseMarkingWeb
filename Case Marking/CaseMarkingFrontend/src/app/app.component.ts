import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Case Marking Web';
  showHeader = false
  showFooter = false

  constructor(private router: Router){
    router.events.pipe(
      filter((event: any) => event instanceof NavigationEnd)
    )
      .subscribe(event => {
        if (event instanceof NavigationEnd) {
           // Trick the Router into believing it's last link wasn't previously loaded
           this.router.navigated = false;
        }
        console.log(event.url);
        if (event.url == '/authenctication' || event.url.includes('authentication')) {
          this.showHeader = false
          this.showFooter = false
        } else {
          this.showHeader = true
          this.showFooter = true
        }
      });

  }
  
}
