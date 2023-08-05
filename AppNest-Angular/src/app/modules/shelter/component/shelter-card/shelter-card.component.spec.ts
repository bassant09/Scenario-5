import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelterCardComponent } from './shelter-card.component';

describe('ShelterCardComponent', () => {
  let component: ShelterCardComponent;
  let fixture: ComponentFixture<ShelterCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShelterCardComponent]
    });
    fixture = TestBed.createComponent(ShelterCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
