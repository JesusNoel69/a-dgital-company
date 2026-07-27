import { NgStyle } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  imports: [NgStyle],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  sidebarVisible: boolean = true;
  selected: string = '';
  toggleSidebar(): void {
    this.sidebarVisible = !this.sidebarVisible;
  }
}
