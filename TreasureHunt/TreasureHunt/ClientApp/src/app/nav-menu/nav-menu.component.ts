import { Component } from '@angular/core';
import { StorageService } from '../_services/storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(
    private storageService: StorageService,
    private router: Router) {
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logoutUser() {
    this.storageService.token = null;
    this.storageService.currentUser = null;

    this.router.navigate(['/login']);
  }

  getCurrentUser() {

    if (this.storageService.currentUser && this.storageService.currentUser !== null) {
      return this.storageService.currentUser;
    }
  }
}
