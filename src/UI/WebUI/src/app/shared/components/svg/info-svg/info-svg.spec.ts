import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoSvg } from './info-svg';

describe('InfoSvg', () => {
  let component: InfoSvg;
  let fixture: ComponentFixture<InfoSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InfoSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(InfoSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
