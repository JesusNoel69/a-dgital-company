import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSvg } from './user-svg';

describe('UserSvg', () => {
  let component: UserSvg;
  let fixture: ComponentFixture<UserSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(UserSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
