import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookingService } from 'src/app/shared/services/BookingServices/booking.service';

@Component({
  selector: 'app-booking-card',
  templateUrl: './booking-card.component.html',
  styleUrls: ['./booking-card.component.scss']
})
export class BookingCardComponent {
 @Input() data:any={};
 @Output() output=new EventEmitter(); 
 constructor(private _booking:BookingService){}
 acceptBookingRequest(){
    this._booking.acceptBookingRequests(this.data.id).subscribe((res:any)=>{
      console.log(res);
      this.output.emit();
    })
 }
  cancelBookingRequest(){
    this._booking.cancelBookingRequests(this.data.id).subscribe((res:any)=>{
      console.log(res);
      this.output.emit();
    })
 }
}
