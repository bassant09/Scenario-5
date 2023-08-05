import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ResourcesService {
  url: any = environment.ApiUrl + 'Resources/';
  constructor(private _http:HttpClient) { }
  editShelterResources(id:any,data:any):Observable<any>{
    return this._http.put(this.url+"resources/"+id,data)
  }
}
