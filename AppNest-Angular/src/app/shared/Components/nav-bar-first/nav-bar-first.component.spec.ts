import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarFirstComponent } from './nav-bar-first.component';

describe('NavBarFirstComponent', () => {
  let component: NavBarFirstComponent;
  let fixture: ComponentFixture<NavBarFirstComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NavBarFirstComponent]
    });
    fixture = TestBed.createComponent(NavBarFirstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
