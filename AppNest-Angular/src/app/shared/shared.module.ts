import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomIputComponent } from './Components/Inputs/custom-iput/custom-iput.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavBarComponent } from './Components/nav-bar/nav-bar.component';
import { NavBarFirstComponent } from './Components/nav-bar-first/nav-bar-first.component';
import { FooterComponent } from './Components/footer/footer.component';



@NgModule({
  declarations: [
    CustomIputComponent,
    NavBarComponent,
    NavBarFirstComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule
    
  ],
  exports: [
    CustomIputComponent,
    NavBarComponent,
    NavBarFirstComponent,
    FooterComponent
    
  ]
})
export class SharedModule { }
