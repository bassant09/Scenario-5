import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-check-box',
  templateUrl: './check-box.component.html',
  styleUrls: ['./check-box.component.scss']
})
export class CheckBoxComponent {
  @Input() title:any={};
  @Output() out= new EventEmitter<any>();
  onCheckboxChange(){
    console.log('lo');
    this.out.emit();
  }
}
