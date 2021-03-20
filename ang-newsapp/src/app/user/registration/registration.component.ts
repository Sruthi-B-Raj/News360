import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from 'src/app/models/register';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerUser:Register;

  constructor(public service: AuthenticationService, private router:Router) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }
  onSubmit() {
    this.registerUser=new Register();
    this.registerUser.userId=this.service.formModel.get('UserId').value;
    this.registerUser.password=this.service.formModel.get('Passwords.Password').value;
    console.log(this.registerUser);
    this.service.register().subscribe(data=>{
      
      alert("Successfully Registered");
      console.log(data);
      this.service.formModel.reset();
      this.router.navigate(['/user/login']);


    },error=>{
      alert("Registration failed :(")
    });
    
    
  }

}
