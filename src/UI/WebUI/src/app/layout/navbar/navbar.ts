import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-navbar',
  imports: [],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {
  readonly showMenu = signal(false);

  toggleMenu() {
    this.showMenu.update((v) => !v);
  }
}
