import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeSvg } from './change-svg';

describe('ChangeSvg', () => {
  let component: ChangeSvg;
  let fixture: ComponentFixture<ChangeSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChangeSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(ChangeSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
