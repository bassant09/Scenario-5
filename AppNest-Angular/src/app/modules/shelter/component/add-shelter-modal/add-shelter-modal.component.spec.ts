import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShelterModalComponent } from './add-shelter-modal.component';

describe('AddShelterModalComponent', () => {
  let component: AddShelterModalComponent;
  let fixture: ComponentFixture<AddShelterModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddShelterModalComponent]
    });
    fixture = TestBed.createComponent(AddShelterModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
