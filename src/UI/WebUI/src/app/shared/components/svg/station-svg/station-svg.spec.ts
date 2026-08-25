import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StationSvg } from './station-svg';

describe('StationSvg', () => {
  let component: StationSvg;
  let fixture: ComponentFixture<StationSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StationSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(StationSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
