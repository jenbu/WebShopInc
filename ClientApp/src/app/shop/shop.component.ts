import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject, switchMap, tap, filter, map } from 'rxjs';
import { ProductService } from '../services/product.service';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialog } from '../dialogs/product-dialog.component';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  triggerFetch: BehaviorSubject<boolean> = new BehaviorSubject(true);
  products$: Observable<any>;
  loading: boolean = false;

  constructor(
    public productsService: ProductService,
    public dialog: MatDialog
  ) {
    this.products$ = this.triggerFetch.pipe(
      switchMap(() => {
        this.loading = true;
        return this.productsService.get();
      }),
      map((response) => {
        return response.data;
      }),
      tap(() => {
        this.loading = false;
      })
    );
  }

  ngOnInit(): void {}

  addProduct(): void {
    const dialogRef = this.dialog.open(ProductDialog, {
      width: '900px',
      data: null,
    });

    dialogRef
      .afterClosed()
      .pipe(
        filter((product) => product),
        switchMap((product) => {
          return this.productsService.post(product);
        })
      )
      .subscribe((product) => {});
  }
}
