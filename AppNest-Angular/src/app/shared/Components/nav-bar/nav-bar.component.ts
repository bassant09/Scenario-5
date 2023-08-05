import { Component } from '@angular/core';
import { AuthService } from '../../services/AuthServices/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  constructor(private _auth:AuthService){}
  ngOnInit(){
    this.decode();
  }
  id:any;
    token:any;
    role:any;
    decode(){ 
     this.token= this._auth.getDecodedAccessToken();
     this.id=this.token?.nameid;
    }
  logOut(){
    localStorage.clear();
    this.decode();
  }
}
