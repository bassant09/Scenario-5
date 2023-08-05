import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/services/AuthServices/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  constructor(private _auth:AuthService,private router:Router ){}
  formGroup = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    age: new FormControl('', [Validators.required]),
  });
  register(){
    this._auth.register(this.formGroup.value).subscribe((res:any)=>{
      console.log(res);
      if(res.success==true){
        this.router.navigate(['auth/login']);
      }
    })
  
  }
}
