import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterShelterComponent } from './filter-shelter.component';

describe('FilterShelterComponent', () => {
  let component: FilterShelterComponent;
  let fixture: ComponentFixture<FilterShelterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FilterShelterComponent]
    });
    fixture = TestBed.createComponent(FilterShelterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
