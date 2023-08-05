import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/AuthServices/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
 constructor(private _auth:AuthService,private router:Router){}
 object={
  email:'',
  password:'',
 }
 formGroup = new FormGroup({
  email: new FormControl('', [Validators.required, Validators.email]),
  password: new FormControl('', [Validators.required]),
});
token:any;
login(){
  console.log(this.formGroup.value)
 this._auth.login(this.formGroup.value).subscribe({
  next: (response) => {
    console.log(response.message)
    this.token=response.data;
    localStorage.setItem("token",this.token);
    console.log('Auth: ', response.data);
    this.router.navigate(['shelter/get']);

  },
  error: (err) => {
    console.log(err)
  }
})
}
}
