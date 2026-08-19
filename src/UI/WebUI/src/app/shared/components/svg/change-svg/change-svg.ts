import { Component, Input } from '@angular/core';

@Component({
  selector: 'change-svg',
  imports: [],
  templateUrl: './change-svg.html',
  styleUrl: './change-svg.css',
})
export class ChangeSvg {
  @Input() color = '';
  @Input() width = '24px';
  @Input() height = '24px';
}
