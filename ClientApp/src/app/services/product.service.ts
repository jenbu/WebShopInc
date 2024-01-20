import { Injectable } from '@angular/core';
import { BaseCrudService } from './base-crud.service';
import { HttpClient } from '@angular/common/http';
import { ProductItem } from '../models/ProductItem';

@Injectable({ providedIn: 'root' })
export class ProductService extends BaseCrudService<ProductItem> {
  constructor(httpClient: HttpClient) {
    super(httpClient, 'products');
  }
}
