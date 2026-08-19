import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavigationService } from '../../core/services/navigation.service';
import { PersonalSvg } from '../../shared/components/svg/personal-svg/personal-svg';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, PersonalSvg],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  constructor(public navigation: NavigationService) {}
  sidebarVisible: boolean = true;
  selected: string = '';
  toggleSidebar(): void {
    this.sidebarVisible = !this.sidebarVisible;
  }
}
