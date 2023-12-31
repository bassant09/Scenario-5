import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingRequestComponent } from './booking-request.component';

describe('BookingRequestComponent', () => {
  let component: BookingRequestComponent;
  let fixture: ComponentFixture<BookingRequestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookingRequestComponent]
    });
    fixture = TestBed.createComponent(BookingRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
