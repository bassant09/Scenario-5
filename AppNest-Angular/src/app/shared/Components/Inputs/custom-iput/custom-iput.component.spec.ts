import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomIputComponent } from './custom-iput.component';

describe('CustomIputComponent', () => {
  let component: CustomIputComponent;
  let fixture: ComponentFixture<CustomIputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CustomIputComponent]
    });
    fixture = TestBed.createComponent(CustomIputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
