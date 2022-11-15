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
  /*date: Date = new Date();*/
  url: string = "https://venturebeat.com/product-comparisons?wp-content=uploads/2021/01/color.jpg"


  expressDelivery: boolean = false;
  
  deliveryDate: string;

  constructor() {
  }

  ngOnInit(): void {
    this.deliveryDate = this.estimateDeliveryTime()
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
        console.log(this.count, this.product.deliveryTimeList[it].toDays, this.product.deliveryTimeList[it].days);
        workingDays = this.product.deliveryTimeList[it].days
        break;
      }
    }

    console.log("working days delivery", workingDays)
    console.log("express delivery: ", this.expressDelivery)
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


