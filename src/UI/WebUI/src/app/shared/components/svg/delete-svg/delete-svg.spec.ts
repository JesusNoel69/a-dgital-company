import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteSvg } from './delete-svg';

describe('DeleteSvg', () => {
  let component: DeleteSvg;
  let fixture: ComponentFixture<DeleteSvg>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteSvg],
    }).compileComponents();

    fixture = TestBed.createComponent(DeleteSvg);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
