import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';

@Injectable()
export class BaseApiService {

  baseUrl = 'http://localhost:63907/';
}
