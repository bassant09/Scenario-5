import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelterUserComponent } from './shelter-user.component';

describe('ShelterUserComponent', () => {
  let component: ShelterUserComponent;
  let fixture: ComponentFixture<ShelterUserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShelterUserComponent]
    });
    fixture = TestBed.createComponent(ShelterUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
