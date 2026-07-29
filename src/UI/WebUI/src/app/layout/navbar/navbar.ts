import { Component, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavigationService } from '../../core/services/navigation.service';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {
  constructor(public navigation: NavigationService) {}
  readonly showMenu = signal(false);

  toggleMenu() {
    this.showMenu.update((v) => !v);
  }
}
