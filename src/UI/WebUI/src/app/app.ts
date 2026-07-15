import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Badge } from './shared/components/badge/badge';
import { Login } from './features/auth/pages/login/login';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Badge, Login],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  //protected readonly title: Signal<string> = signal('WebUI');
}
