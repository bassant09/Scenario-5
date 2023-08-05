import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModulesComponent } from './modules.component';
import { LandingComponent } from './shelter/pages/landing/landing.component';

const routes: Routes = [{ path: '', component: ModulesComponent,children:[
  { path: 'shelter', loadChildren: () => import('./shelter/shelter.module').then(m => m.ShelterModule) },
  { path: 'booking', loadChildren: () => import('./booking/booking.module').then(m => m.BookingModule) },
  { path: 'land', loadChildren: () => import('./landing/landing.module').then(m => m.LandingModule) },
  { path: '', redirectTo: 'land', pathMatch: 'full' },
 
] 

},
 

 
 ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModulesRoutingModule { }
