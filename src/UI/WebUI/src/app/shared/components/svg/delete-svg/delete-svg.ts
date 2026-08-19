import { Component, Input } from '@angular/core';

@Component({
  selector: 'delete-svg',
  imports: [],
  templateUrl: './delete-svg.html',
  styleUrl: './delete-svg.css',
})
export class DeleteSvg {
  @Input() color = '--color-danger';
}
