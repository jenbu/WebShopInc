import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { ProductItem } from '../ProductItem';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input() product: ProductItem;
  count: number = 1;
  url: string = "https://venturebeat.com/product-comparisons?wp-content=uploads/2021/01/color.jpg"


  expressDelivery: boolean = false;
  unit: string = ''
  deliveryDate: string;

  constructor() {
  }

  ngOnInit(): void {
    console.log(this.product)
    this.deliveryDate = this.estimateDeliveryTime()
    this.unit = this.product.unit != '-' ? this.product.unit : ''
  }

  changeProductCount(increment: number) {
    this.count += increment;
    this.deliveryDate = this.estimateDeliveryTime();
  }

  setExpressDelivery(event: any) {
    this.expressDelivery = event.checked
    this.deliveryDate = this.estimateDeliveryTime();
  }

  estimateDeliveryTime() {

    let workingDays = 0
    for (let it = 0; it < this.product.deliveryTimeList.length; it++) {
      if (this.count <= this.product.deliveryTimeList[it].toDays) {
        workingDays = this.product.deliveryTimeList[it].days
        break;
      }
    }
    return this.calculateDelivery(workingDays)

  }

  // Calculate the forward date based on given working days. Does not take into account holidays.
  // Saturday and sunday is not counted as working day.
  // I assume that the current day is not part of delivery period. 
  calculateDelivery(working_days: number) {
    let date = new Date()
    let counter = this.expressDelivery ? working_days - 1 : working_days
    console.log("working days: ", counter)

    // minimum of 1 day delivery
    if (counter < 1) {
      counter = 1
    }

    while (counter > 0)
    {
      date.setDate(date.getDate() + 1)

      const dayOfWeek = date.getDay();

      if (dayOfWeek != 5 && dayOfWeek != 6) {
        counter -= 1;
      }
    }
    return date.getDate() + "." + (date.getMonth() + 1);
  }



}


