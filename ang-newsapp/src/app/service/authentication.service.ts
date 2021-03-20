import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  
//  readonly BaseURI = 'http://localhost:50014/api';
readonly BaseURI = 'http://localhost:50014/api';


  constructor(private formBuilder:FormBuilder, private http: HttpClient) { }
  formModel = this.formBuilder.group({
    UserId: ['', Validators.required],
    Passwords: this.formBuilder.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords})

  });
  comparePasswords(form: FormGroup) {
    let confirmPasswordCtrl = form.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPasswordCtrl.errors == null || 'passwordMismatch' in confirmPasswordCtrl.errors) {
      if (form.get('Password').value != confirmPasswordCtrl.value)
      confirmPasswordCtrl.setErrors({ passwordMismatch: true });
      else
      confirmPasswordCtrl.setErrors(null);
    }
  }
  register() {
    var body = {
      UserId: this.formModel.value.UserId,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/Auth/register', body);
  }
  login(formData) {
    return this.http.post(this.BaseURI + '/Auth/login', formData);
  }


}
