import { Restaurant } from './Restaurant';

export interface RestaurantAddress {
    id: number;
    address: string;
    number: number;
    cityId: number;
    street: string;
    restaurantId: number;
    createDate: Date;
    updateDate: Date;
    restaurant: Restaurant;
}
