import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { User } from '../_models/User';
import { StorageService } from '../_services/storage.service';
import { UsersService } from '../_services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private storageService: StorageService,
    private usersService: UsersService) {
  }

  ngOnInit() {
    // reset login status
    this.storageService.token = null;
    this.storageService.currentUser = null;
    this.storageService.userId = null;
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '';
  }
  async login() {

    this.loading = true;
    try {
      const req = new User();
      req.name = this.model.name;
      req.loginName = this.model.loginName;
      const response = await this.usersService.authenticate(req).toPromise();
      if (response && response.token) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        this.storageService.token = response.token;
        this.storageService.currentUser = response.user.name;
        this.storageService.userId = response.user.id;
        this.router.navigate([this.returnUrl]);
      } else {
        alert('User Not Logged in');
      }
      this.loading = false;
    } catch (error) {
      console.error(error);
      this.loading = false;
    }
  }
}

