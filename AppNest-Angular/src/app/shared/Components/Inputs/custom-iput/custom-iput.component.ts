import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-custom-iput',
  templateUrl: './custom-iput.component.html',
  styleUrls: ['./custom-iput.component.scss']
})
export class CustomIputComponent {
  @Input() title: any ={};
  @Input() id: string = '';
  @Input() typeInput: string = 'text';
  @Input() formControlNameInput!: string;
  @Input() formGroupInput!: FormGroup;
  @Input() defaultValue!: any;
  @Input() isRequired=true;
  @Output() onValueChange = new EventEmitter<any>();

}
