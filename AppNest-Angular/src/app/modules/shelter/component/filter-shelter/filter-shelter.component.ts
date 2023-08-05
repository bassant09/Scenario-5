import { Component, EventEmitter, Output } from '@angular/core';
import { ShelterService } from 'src/app/shared/services/ShelterServices/shelter.service';

@Component({
  selector: 'app-filter-shelter',
  templateUrl: './filter-shelter.component.html',
  styleUrls: ['./filter-shelter.component.scss']
})
export class FilterShelterComponent {
   shelters:any[]=[];
   @Output() Out=new EventEmitter();
  filterObject={
    Water:false,
    Clothes:false,
    Toy:false,
    Medicine:false,
    Food:false

  }
  ngOnInit(){
    this.getAllShelter();
  }
   constructor(private _shelter:ShelterService){}
   getAllShelter(){
    this._shelter.getAllShelter(this.filterObject).subscribe((res:any)=>{
      console.log(res);
      this.shelters=res.data;
      this.Out.emit(this.shelters);
      //console.log(this.Out.value)
    })
   }
  filter: any[] = [
    { name: 'Water', isSelected: false },
    { name: 'Food', isSelected: false },
    { name: 'Medicine', isSelected: false },
    { name: 'Clothes', isSelected: false },
    { name: 'Toys', isSelected: false }
  ];
  isSelected(index:any,word:any){
    this.filterObject[word as keyof typeof this.filterObject] = !this.filterObject[word as keyof typeof this.filterObject];
    this.getAllShelter();
    console.log(this.filterObject);
    if (this.filter[index]) {
      this.filter[index].isSelected = !this.filter[index].isSelected;
    }
  }
}
