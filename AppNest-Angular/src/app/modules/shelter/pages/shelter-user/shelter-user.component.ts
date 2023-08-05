import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShelterService } from 'src/app/shared/services/ShelterServices/shelter.service';

@Component({
  selector: 'app-shelter-user',
  templateUrl: './shelter-user.component.html',
  styleUrls: ['./shelter-user.component.scss']
})
export class ShelterUserComponent {
  constructor(private _shelter:ShelterService,private activatedRoute:ActivatedRoute){}
  id:any;
  users:any;
  shelter:any;
  ngOnInit(){
    this.activatedRoute.params.subscribe(params=>{
      console.log('x'+params["id"])
      this.id=params["id"]
      this.getShelterDetails();
    })
  
  }
  getShelterDetails(){
     this._shelter.getShelterDetails(this.id).subscribe((res:any)=>{
      this.shelter=res.data
      this.users=res.data?.users;
      console.log(this.users);
     })
  } 
}
