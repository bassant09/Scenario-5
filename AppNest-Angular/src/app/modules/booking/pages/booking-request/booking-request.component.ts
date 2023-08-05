import { Component } from '@angular/core';
import { BookingService } from 'src/app/shared/services/BookingServices/booking.service';

@Component({
  selector: 'app-booking-request',
  templateUrl: './booking-request.component.html',
  styleUrls: ['./booking-request.component.scss']
})
export class BookingRequestComponent {
  requests:any[]=[];
  constructor(private _booking:BookingService){
     this.getBookingRequest();
  }
  getBookingRequest(){
     this._booking.getBookingRequests().subscribe((res:any)=>{
      console.log(res);
      this.requests=res.data;
     })
  }
   AcceptBookingRequest(){
    
  }
   CancelBookingRequest(){
    
  }
}
