import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShelterService } from 'src/app/shared/services/ShelterServices/shelter.service';

@Component({
  selector: 'app-shelter-details',
  templateUrl: './shelter-details.component.html',
  styleUrls: ['./shelter-details.component.scss']
})
export class ShelterDetailsComponent {
  constructor(private _shelter:ShelterService,private activatedRoute:ActivatedRoute){}
  id:any;
  shelter:any;
  mainImg:any; 
  Images:any[]=[];
  ngOnInit(){
    this.activatedRoute.params.subscribe(params=>{
      console.log('x'+params["id"])
      this.id=params["id"]
      this.getShelterDetails();
    })
  
  }
  getShelterDetails(){
     this._shelter.getShelterDetails(this.id).subscribe((res:any)=>{
      console.log(res);
      this.shelter=res.data;
      this.mainImg=res.data?.images[0]?.image; 
      for(let i=1;i<res.data.images.length;i++){
        this.Images.push(res.data?.images[i]?.image);
        
      }
     })
     console.log(this.Images);
  } 
  setImage(img:any){
    this.mainImg=img;
  }
}
