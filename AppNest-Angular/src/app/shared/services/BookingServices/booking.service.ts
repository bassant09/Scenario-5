import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  url: any = environment.ApiUrl + 'Booking/';
  constructor(private _http:HttpClient) { }
  getBookingRequests() :Observable<any>{
    return this._http.get(this.url+"BookingRequest");
    
  }
  acceptBookingRequests(id:any) :Observable<any>{
    return this._http.get(this.url+"acceptShelterBooking/"+id); 
  }
  cancelBookingRequests(id:any) :Observable<any>{
    return this._http.get(this.url+"cancelShelterBooking/"+id);
  }
  bookShelter(data:any):Observable<any>{
     return this._http.post(this.url+"BookShelter",data);
  }
}
