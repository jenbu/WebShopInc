import { Injectable } from '@angular/core';
import { BaseCrudService } from './base-crud.service';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ProductService extends BaseCrudService {
  constructor(httpClient: HttpClient) {
    super(httpClient, 'products');
  }
}
