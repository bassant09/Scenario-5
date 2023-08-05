import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddResurceModalComponent } from './add-resurce-modal.component';

describe('AddResurceModalComponent', () => {
  let component: AddResurceModalComponent;
  let fixture: ComponentFixture<AddResurceModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddResurceModalComponent]
    });
    fixture = TestBed.createComponent(AddResurceModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
