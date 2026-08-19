import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSvg } from './edit-svg';

describe('EditSvg', () => {
  let component: EditSvg;
  let fixture: ComponentFixture<EditSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(EditSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
