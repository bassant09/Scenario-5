import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingRoutingModule } from './booking-routing.module';
import { BookingComponent } from './booking.component';
import { BookingRequestComponent } from './pages/booking-request/booking-request.component';
import { BookingCardComponent } from './components/booking-card/booking-card.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    BookingComponent,
    BookingRequestComponent,
    BookingCardComponent
  ],
  imports: [
    CommonModule,
    BookingRoutingModule,
    SharedModule
  ],
  exports: [
    BookingCardComponent
  ]
})
export class BookingModule { }
