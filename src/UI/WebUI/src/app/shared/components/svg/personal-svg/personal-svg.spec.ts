import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalSvg } from './personal-svg';

describe('PersonalSvg', () => {
  let component: PersonalSvg;
  let fixture: ComponentFixture<PersonalSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonalSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(PersonalSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
