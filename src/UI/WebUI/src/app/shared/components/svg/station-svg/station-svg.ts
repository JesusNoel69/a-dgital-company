import { Component, Input } from '@angular/core';

@Component({
  selector: 'station-svg',
  imports: [],
  templateUrl: './station-svg.html',
  styleUrl: './station-svg.css',
})
export class StationSvg {
  @Input() color = '--color-text-inverse';
  @Input() size = '24px';
}
