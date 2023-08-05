import { Component } from '@angular/core';
import { ShelterService } from 'src/app/shared/services/ShelterServices/shelter.service';

@Component({
  selector: 'app-get-shelter',
  templateUrl: './get-shelter.component.html',
  styleUrls: ['./get-shelter.component.scss']
})
export class GetShelterComponent {
  shelters:any[]=[];
  ngOnInit(){
  //  console.log(this.data)
  }
  hi(event:any){
    this.shelters=event
  console.log(event);
  }
}
