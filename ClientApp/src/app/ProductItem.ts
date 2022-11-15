
export interface ProductItem {
  id: number,
  name: string,
  description: string,
  imgURL: string,
  unit: string,
  deliveryTimeList: ProductDeliveryTime[]
}

export interface ProductDeliveryTime {
  fromDays: number,
  toDays: number,
  days: number,
}
