import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ResourcesService } from 'src/app/shared/services/ResourcesServices/resources.service';

@Component({
  selector: 'app-add-resurce-modal',
  templateUrl: './add-resurce-modal.component.html',
  styleUrls: ['./add-resurce-modal.component.scss']
})
export class AddResurceModalComponent {
  @ViewChild('close') close !:ElementRef
  @Output() Output=new EventEmitter();
  constructor(private _resorces:ResourcesService,private activatedRoute:ActivatedRoute){}
  object={
    water:0,
    clothes:0,
    toy:0,
    medicine:0,
    food:0
  }
  id:any;
  ngOnInit(){
    this.activatedRoute.params.subscribe(params=>{
      console.log('x'+params["id"])
      this.id=params["id"]
    })
  
  }
 editResorces(){
  this._resorces.editShelterResources(this.id,this.object).subscribe((res:any)=>{
    console.log(res);
    this.Output.emit(); 
    this.close.nativeElement.click()
  })
 }
}
