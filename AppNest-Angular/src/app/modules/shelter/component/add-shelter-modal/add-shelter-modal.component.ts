import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ShelterService } from 'src/app/shared/services/ShelterServices/shelter.service';

@Component({
  selector: 'app-add-shelter-modal',
  templateUrl: './add-shelter-modal.component.html',
  styleUrls: ['./add-shelter-modal.component.scss']
})
export class AddShelterModalComponent {
  @Output() add=new EventEmitter();
  @ViewChild('close') close !:ElementRef
  newShelter={
    name:'',
    location:'',
    maxNum:'',

  }
  
  formGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
    maxNum: new FormControl(0, [Validators.required]),
    imagefile: new FormArray([], [Validators.required]),
  });
  constructor(private _shelter:ShelterService){}
  addNewShelter(){
    const formData = new FormData();
    formData.append('name', this.formGroup.get('name')?.value ??'');
    formData.append('location', this.formGroup.get('location')?.value ??'');
    const maxNumValue = this.formGroup.get('maxNum')?.value;
    formData.append('maxNum', maxNumValue !== null && maxNumValue !== undefined ? maxNumValue.toString() : '');
    const imageFiles = this.formGroup.get('imagefile')?.value ?? '';
    for (const file of imageFiles) {
      formData.append('imagefile', file);
    }

    console.log(formData)
    
    this._shelter.addNewShelter(formData).subscribe((res:any)=>{
      console.log(res);
      this.close.nativeElement.click()
      this.add.emit();
    })
  }
  onFileInputChange(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement.files) {
      const files = Array.from(inputElement.files);
      const imageFileFormArray = this.formGroup.get('imagefile') as FormArray;
      imageFileFormArray.clear();
      for (const file of files) {
        imageFileFormArray.push(new FormControl(file));
      }
    }
  }

}

