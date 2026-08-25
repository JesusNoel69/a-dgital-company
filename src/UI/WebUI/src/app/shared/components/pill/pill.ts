import { Component, input } from '@angular/core';

@Component({
  selector: 'app-pill',
  imports: [],
  templateUrl: './pill.html',
  styleUrl: './pill.css',
})
export class Pill {
  name = input<string>('no role');
}
