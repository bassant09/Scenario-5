import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingComponent } from './booking.component';
import { BookingRequestComponent } from './pages/booking-request/booking-request.component';

const routes: Routes = [{ path: '', component: BookingComponent,children:[
  { path: 'requests', component: BookingRequestComponent,}
] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
