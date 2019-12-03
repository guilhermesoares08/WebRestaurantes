import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../_services/Restaurant.service';
import { Restaurant } from '../_models/Restaurant';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  // tslint:disable-next-line: variable-name
  _filtroLista: string;
  restaurants: Restaurant[];
  filteredRestaurants: Restaurant[];
  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.filteredRestaurants = this.filtroLista
      ? this.filtrarRestaurants(this.filtroLista)
      : this.restaurants;
  }

  constructor(private restaurantService: RestaurantService) {}

  ngOnInit() {
    this.getAllRestaurants();
  }

  getAllRestaurants() {
    this.restaurantService.getAllRestaurant().subscribe(
      // tslint:disable-next-line: variable-name
      (_restaurants: Restaurant[]) => {
        this.restaurants = _restaurants;
        this.filteredRestaurants = this.restaurants;
      },
      error => {
        console.log(error);
      }
    );
  }

  filtrarRestaurants(filterBy: string): Restaurant[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.restaurants.filter(
      rest => rest.description.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
}
