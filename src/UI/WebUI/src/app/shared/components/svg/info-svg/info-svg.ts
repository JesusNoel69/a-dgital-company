import { Component, Input } from '@angular/core';

@Component({
  selector: 'info-svg',
  imports: [],
  templateUrl: './info-svg.html',
  styleUrl: './info-svg.css',
})
export class InfoSvg {
  @Input() color = '--color-text';
}
