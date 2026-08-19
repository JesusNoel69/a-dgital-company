import { Component, Input } from '@angular/core';

@Component({
  selector: 'personal-svg',
  imports: [],
  templateUrl: './personal-svg.html',
  styleUrl: './personal-svg.css',
})
export class PersonalSvg {
  @Input() color = '--color-text-inverse';
  @Input() height = '24px';
  @Input() width = '24px';
}
