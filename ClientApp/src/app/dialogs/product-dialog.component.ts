import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductModel } from '../models/ProductItem';
import { ProductService } from '../services/product.service';
import { SnackbarService } from '../services/snackbar/snackbar.service';

@Component({
    selector: 'product-dialog',
    templateUrl: 'product-dialog.component.html',
    styleUrls: ['./product-dialog.component.scss'],
})
export class ProductDialog {
    mode: 'Edit' | 'New';
    product: ProductModel;

    constructor(
        public dialogRef: MatDialogRef<ProductDialog>,
        public productService: ProductService,
        public snackbarService: SnackbarService,
        @Inject(MAT_DIALOG_DATA) public productInput: ProductModel | undefined
    ) {
        this.mode = this.productInput ? 'Edit' : 'New';

        this.product = this.productInput
            ? Object.assign({}, this.productInput)
            : {
                  name: '',
                  description: '',
                  imageUrl: '',
                  unit: '',
                  productDeliveryTimes: [],
              };
    }

    save(): void {
        if (this.mode == 'New') {
            this.addProduct(this.product);
        } else {
            this.editProduct(this.product);
        }
    }

    addProduct(product: ProductModel): void {
        this.productService.post(product).subscribe({
            next: (_successResponse) => {
                this.snackbarService.success('Product has been created');
                this.dialogRef.close(this.product);
            },
            error: (errorResponse) => {
                this.snackbarService.error(errorResponse.error);
            },
        });
    }

    editProduct(product: ProductModel): void {
        this.productService.put(product).subscribe({
            next: (_successResponse) => {
                this.snackbarService.success('Product has been updated');
                this.dialogRef.close(this.product);
            },
            error: (errorResponse) => {
                this.snackbarService.error(errorResponse.error);
            },
        });
    }
}
