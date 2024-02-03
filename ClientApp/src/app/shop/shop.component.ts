import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject, switchMap, tap, filter, map } from 'rxjs';
import { ProductService } from '../services/product.service';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialog } from '../dialogs/product-dialog.component';
import { ProductModel } from '../models/ProductItem';
import { SnackbarService } from '../services/snackbar/snackbar.service';

@Component({
    selector: 'app-shop',
    templateUrl: './shop.component.html',
    styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
    triggerFetch: BehaviorSubject<boolean> = new BehaviorSubject(true);
    products$: Observable<any>;
    loading: boolean = false;

    products: ProductModel[] | undefined;

    constructor(
        public productsService: ProductService,
        public dialog: MatDialog,
        public snackbarService: SnackbarService
    ) {
        this.getProducts();
    }

    ngOnInit(): void {}

    getProducts() {
        this.productsService.get().subscribe({
            next: (successResponse) => {
                this.products = successResponse.data;
            },
            error: (errorResponse) => {
                this.snackbarService.error(errorResponse.error);
            },
        });
    }

    addProduct(): void {
        const dialogRef = this.dialog.open(ProductDialog, {
            width: '900px',
            data: null,
        });

        dialogRef
            .afterClosed()
            .pipe(
                filter((product) => product),
                switchMap(() => {
                    return this.productsService.get();
                })
            )
            .subscribe({
                next: (successResponse) => {
                    this.products = successResponse.data;
                },
                error: (errorResponse) => {
                    this.snackbarService.error(errorResponse.error);
                },
            });
    }
}
