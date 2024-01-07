import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject, switchMap, tap } from 'rxjs';
import { ProductItem } from '../ProductItem';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  triggerFetch: BehaviorSubject<boolean> = new BehaviorSubject(true);
  products$: Observable<ProductItem[]>;
  loading: boolean = false;

  constructor(public productsService: ProductService) {
    this.products$ = this.triggerFetch.pipe(
      switchMap(() => {
        this.loading = true;
        return this.productsService.get();
      }),
      tap(() => {
        this.loading = false;
      })
    );
  }

  ngOnInit(): void {}
}
