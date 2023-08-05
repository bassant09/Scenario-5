import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/shared/services/BookingServices/booking.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent {
  @ViewChild('close') close !:ElementRef
  @Output() Output=new EventEmitter();
  constructor(private _book:BookingService,private activatedRoute:ActivatedRoute ){}
  book={
    shelterId:'',
    startDay:'',
    endDay:'',
  }
  id:any
  ngOnInit(){
    this.activatedRoute.params.subscribe(params=>{
      console.log('x'+params["id"])
      this.id=params["id"]
    })
  
  }
  bookShelter(){
    this.book.shelterId=this.id;
    this._book.bookShelter(this.book).subscribe((res:any)=>{
      console.log(res); 
      this.Output.emit(); 
    this.close.nativeElement.click()
    })
  }
}
