import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetShelterComponent } from './get-shelter.component';

describe('GetShelterComponent', () => {
  let component: GetShelterComponent;
  let fixture: ComponentFixture<GetShelterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetShelterComponent]
    });
    fixture = TestBed.createComponent(GetShelterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
