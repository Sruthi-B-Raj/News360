import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LogIn } from 'src/app/models/LogIn';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formModel = {
    userId: '',
    Password: ''
  }

  constructor(private service:AuthenticationService,private router:Router) { }

  ngOnInit(): void {
  }
  loginUser:LogIn;
  onSubmit(form:NgForm){
    this.loginUser=new LogIn();
    this.loginUser.userId=this.formModel.userId.valueOf();
    this.loginUser.password=this.formModel.Password.valueOf();
    localStorage.setItem('currentUser',this.loginUser.userId);
    this.service.login(this.loginUser).subscribe(
      (res:any)=>{
        localStorage.setItem('token', res.token);
        alert("Login sucessfull");
        console.log(res);
        this.router.navigate(['/news']);
      },
      err=>{
        if(err.status==400){
          alert("Invalid user or password");
        }
        else
          alert("Unauthorized User");
      }
    )
  
  }
  
}
