import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observer } from 'firebase';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ShelterService {
  url: any = environment.ApiUrl + 'Shelter/';
  constructor(private _http:HttpClient) { }
  getAllShelter(filter:any) :Observable<any>{
    return this._http.get(this.url+"shelters",
     { params: filter }
     )
  }
  addNewShelter(data:any):Observable<any>{
   return this._http.post(this.url,data);
  }
  getShelterDetails(id:any):Observable<any>{
    return this._http.get(this.url+"details/"+id);
  }
  
}
