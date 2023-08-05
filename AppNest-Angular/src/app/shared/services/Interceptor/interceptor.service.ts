import { HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { AuthService } from '../AuthServices/auth.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService {

  constructor( private services :AuthService,private router:Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let tokenReq=req.clone({
      setHeaders:{
        Authorization : `Bearer ${this.services.getToken()}`
      }
    })
    return next.handle(tokenReq).pipe(catchError(err=>{
      if (err instanceof HttpErrorResponse && err.status === 401){
         this.router.navigate(["/login"])
      }
      throw 'error in source. Details: ' + err;
    }))
  }
}
