import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, switchMap, tap } from 'rxjs';
import { ProductItem } from '../ProductItem';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  triggerFetch: BehaviorSubject<boolean> = new BehaviorSubject(true);
  products$: Observable<ProductItem[]>;
  loading: boolean = false;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.products$ = this.triggerFetch.pipe(
      switchMap((val) => {
        console.log("calling http get", val)
        this.loading = true;
        return http.get<ProductItem[]>(baseUrl + 'products');
      }),
      tap((vals) => { console.log(vals); this.loading = false } )
    );

    this.triggerFetch.next(true)
}

  ngOnInit(): void {
  }

}
