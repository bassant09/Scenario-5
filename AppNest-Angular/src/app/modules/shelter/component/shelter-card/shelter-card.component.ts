import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shelter-card',
  templateUrl: './shelter-card.component.html',
  styleUrls: ['./shelter-card.component.scss']
})
export class ShelterCardComponent {
  @Input() data:any={};
  constructor(private router: Router) { }
  showDetails(){
    this.router.navigate(['shelter/details', this.data.id]);
  }
}
