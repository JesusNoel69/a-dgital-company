import { Component, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavigationService } from '../../core/services/navigation.service';
import { UserSvg } from '../../shared/components/svg/user-svg/user-svg';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, UserSvg],
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
