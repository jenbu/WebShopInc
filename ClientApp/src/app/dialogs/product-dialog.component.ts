import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductItem } from '../ProductItem';

@Component({
  selector: 'product-dialog',
  templateUrl: 'product-dialog.component.html',
})
export class ProductDialog {
  constructor(
    public dialogRef: MatDialogRef<ProductDialog>,
    @Inject(MAT_DIALOG_DATA) public product: ProductItem
  ) {
    this.product = product
      ? product
      : {
          name: '',
          description: '',
          imageUrl: '',
          unit: '',
          productDeliveryTimes: [],
        };
  }

  save(): void {
    this.dialogRef.close(this.product);
  }
}
