import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductModel } from '../models/ProductItem';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialog } from '../dialogs/product-dialog.component';
import { ProductService } from '../services/product.service';
import { filter } from 'rxjs';
import { SnackbarService } from '../services/snackbar/snackbar.service';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
})
export class ProductComponent implements OnInit {
    @Input() product: ProductModel;
    @Output() delete = new EventEmitter<void>();

    count: number = 1;

    expressDelivery: boolean = false;
    unit: string = '';
    deliveryDate: string;
    maxQuantity: number = 0;

    constructor(
        public dialog: MatDialog,
        public productService: ProductService,
        public snackbarService: SnackbarService
    ) {}

    ngOnInit(): void {
        this.deliveryDate = this.estimateDeliveryTime();
        this.unit = this.product.unit != '-' ? this.product.unit : '';

        // Get the highest defined quantity in ProductDeliveryTime
        for (let it = 0; it < this.product.productDeliveryTimes.length; it++) {
            if (
                this.maxQuantity < this.product.productDeliveryTimes[it].toDays
            ) {
                this.maxQuantity = this.product.productDeliveryTimes[it].toDays;
            }
        }
    }

    changeProductCount(increment: number) {
        this.count += increment;
        this.deliveryDate = this.estimateDeliveryTime();
    }

    setExpressDelivery(event: any) {
        this.expressDelivery = event.checked;
        this.deliveryDate = this.estimateDeliveryTime();
    }

    // Limitation: ProductDeliveryTime items related to Product must be in an increasing order.
    estimateDeliveryTime() {
        let workingDays = 0;
        let maxDeliveryDays = 0;

        for (let it = 0; it < this.product.productDeliveryTimes.length; it++) {
            if (this.count <= this.product.productDeliveryTimes[it].toDays) {
                workingDays = this.product.productDeliveryTimes[it].days;
                break;
            }
        }

        // Work-around
        if (this.count > this.maxQuantity) {
            workingDays = maxDeliveryDays;
        }

        return this.calculateDelivery(workingDays);
    }

    // Calculate the forward date based on given working days. Does not take into account holidays.
    // Saturday and sunday is not counted as working day.
    // I assume that the current day is not part of delivery period.
    calculateDelivery(working_days: number) {
        let date = new Date('2022-11-01');
        let counter = this.expressDelivery ? working_days - 1 : working_days;

        // minimum of 1 day delivery
        if (counter < 1) {
            counter = 1;
        }

        while (counter > 0) {
            date.setDate(date.getDate() + 1);

            const dayOfWeek = date.getDay();

            if (dayOfWeek != 6 && dayOfWeek != 0) {
                counter -= 1;
            }
        }
        return date.getDate() + '.' + (date.getMonth() + 1);
    }

    editProduct() {
        const dialogRef = this.dialog.open(ProductDialog, {
            width: '900px',
            data: this.product,
        });

        dialogRef
            .afterClosed()
            .pipe(filter((product) => product))
            .subscribe((product) => {
                this.product = product;
            });
    }

    deleteProduct() {
        this.productService.delete(this.product.id).subscribe({
            next: (_successResponse) => {
                this.delete.next();
                this.snackbarService.success(
                    `Deleted product ${this.product.name}`
                );
            },
            error: (errorResponse) => {
                this.snackbarService.error(errorResponse.error);
            },
        });
    }
}
