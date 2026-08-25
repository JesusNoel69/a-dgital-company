import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavigationService } from '../../core/services/navigation.service';
import { PersonalSvg } from '../../shared/components/svg/personal-svg/personal-svg';
import { DepartmentSvg } from '../../shared/components/svg/department-svg/department-svg';
import { StationSvg } from '../../shared/components/svg/station-svg/station-svg';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, PersonalSvg, DepartmentSvg, StationSvg],
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
