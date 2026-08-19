import { Component, Input } from '@angular/core';

@Component({
  selector: 'user-svg',
  imports: [],
  templateUrl: './user-svg.html',
  styleUrl: './user-svg.css',
})
export class UserSvg {
  @Input() color = '--color-text-inverse';
  @Input() width = '24px';
  @Input() height = '24px';
}
