import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {
  userName!: string
  password!: string

  constructor(private authService: AuthService,
    private router: Router
    ){}

  onLogin(){
    if(!this.userName || !this.password){
      alert("fill both fields")
      return
    }

    let request = {
      userName: this.userName,
      password: this.password
    }

    this.authService.login(request).subscribe(resp => {
      localStorage.setItem("userData", JSON.stringify(resp))
      this.router.navigate(['/'])
      
    }, err => {
      alert("Something Went Wrong!!")
    })

  }

}
