import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShelterRoutingModule } from './shelter-routing.module';
import { ShelterComponent } from './shelter.component';
import { GetShelterComponent } from './pages/get-shelter/get-shelter.component';
import { ShelterCardComponent } from './component/shelter-card/shelter-card.component';
import { FilterShelterComponent } from './component/filter-shelter/filter-shelter.component';
import { CheckBoxComponent } from './component/check-box/check-box.component';
import { AddShelterModalComponent } from './component/add-shelter-modal/add-shelter-modal.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ShelterDetailsComponent } from './pages/shelter-details/shelter-details.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AddBookComponent } from './component/add-book/add-book.component';
import { AddResurceModalComponent } from './component/add-resurce-modal/add-resurce-modal.component';
import { ShelterUserComponent } from './pages/shelter-user/shelter-user.component';
import { RouterModule } from '@angular/router';
import { CardComponent } from './pages/shelter-user/card/card.component';
import { LandingComponent } from './pages/landing/landing.component';


@NgModule({
  declarations: [
    ShelterComponent,
    GetShelterComponent,
    ShelterCardComponent,
    FilterShelterComponent,
    CheckBoxComponent,
    AddShelterModalComponent,
    ShelterDetailsComponent,
    AddBookComponent,
    AddResurceModalComponent,
    ShelterUserComponent,
    CardComponent,
    LandingComponent
  ],
  imports: [
    CommonModule,
    ShelterRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    ShelterCardComponent,
    FilterShelterComponent,
    CheckBoxComponent,
    AddShelterModalComponent
  ]
})
export class ShelterModule { }
