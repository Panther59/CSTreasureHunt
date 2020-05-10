import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';
import { User } from '../_models/User';
import { AuthenticateResponse } from '../_models/AuthenticateResponse';
import { Observable } from 'rxjs';
import { BaseApiService } from './baseApi.service';

@Injectable()
export class UsersService extends BaseApiService {
  constructor(
    private httpClient: HttpClient) {
    super();
  }

  authenticate(user: User): Observable<AuthenticateResponse> {
    return this.httpClient.post<AuthenticateResponse>(this.baseUrl + 'api/users/auth', user);
  }
}
