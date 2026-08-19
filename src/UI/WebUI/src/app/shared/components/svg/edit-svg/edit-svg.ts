import { Component, Input } from '@angular/core';

@Component({
  selector: 'edit-svg',
  imports: [],
  templateUrl: './edit-svg.html',
  styleUrl: './edit-svg.css',
})
export class EditSvg {
  @Input() color = '--color-action';
}
