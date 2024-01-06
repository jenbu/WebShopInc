
export interface ProductItem {
  id: number,
  name: string,
  description: string,
  imageUrl: string,
  unit: string,
  productDeliveryTimes: ProductDeliveryTime[]
}

export interface ProductDeliveryTime {
  fromDays: number,
  toDays: number,
  days: number,
}
