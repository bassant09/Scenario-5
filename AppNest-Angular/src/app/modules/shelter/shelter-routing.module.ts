import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShelterComponent } from './shelter.component';
import { GetShelterComponent } from './pages/get-shelter/get-shelter.component';
import { ShelterDetailsComponent } from './pages/shelter-details/shelter-details.component';
import { ShelterUserComponent } from './pages/shelter-user/shelter-user.component';

const routes: Routes = [{ path: '', component: ShelterComponent,children:[
  { path: 'get', component: GetShelterComponent},
  { path: 'details/:id', component: ShelterDetailsComponent},
  { path: 'users/:id', component: ShelterUserComponent},
] },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShelterRoutingModule { }
