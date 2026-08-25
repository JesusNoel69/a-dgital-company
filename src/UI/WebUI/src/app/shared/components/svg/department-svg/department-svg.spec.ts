import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentSvg } from './department-svg';

describe('DepartmentSvg', () => {
  let component: DepartmentSvg;
  let fixture: ComponentFixture<DepartmentSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DepartmentSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(DepartmentSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
