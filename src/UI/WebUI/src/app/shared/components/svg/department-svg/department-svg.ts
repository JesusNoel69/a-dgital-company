import { Component, Input } from '@angular/core';

@Component({
  selector: 'department-svg',
  imports: [],
  templateUrl: './department-svg.html',
  styleUrl: './department-svg.css',
})
export class DepartmentSvg {
  @Input() color = 'var(--color-text-inverse)';
  @Input() size = '24px';
}
