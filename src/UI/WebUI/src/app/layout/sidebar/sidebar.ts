import { NgStyle } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NavigationService } from '../../core/services/navigation.service';

@Component({
  selector: 'app-sidebar',
  imports: [NgStyle, RouterLink],
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
