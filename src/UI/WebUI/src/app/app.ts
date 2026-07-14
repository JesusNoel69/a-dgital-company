import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Badge } from './shared/components/badge/badge';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Badge],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  //protected readonly title: Signal<string> = signal('WebUI');
}
