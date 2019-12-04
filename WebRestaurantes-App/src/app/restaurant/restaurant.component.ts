import { Component, OnInit, TemplateRef } from '@angular/core';
import { RestaurantService } from '../_services/Restaurant.service';
import { Restaurant } from '../_models/Restaurant';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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
  modalRef: BsModalRef;
  registerForm: FormGroup;

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.filteredRestaurants = this.filtroLista
      ? this.filtrarRestaurants(this.filtroLista)
      : this.restaurants;
  }

  constructor(private restaurantService: RestaurantService, private modalService: BsModalService) {}

  ngOnInit() {
    this.getAllRestaurants();
    this.validation();
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  salvarAlteracao() {

  }

  validation() {
    this.registerForm = new FormGroup({
      txtDescription: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]),
      txtEmail: new FormControl('', [Validators.required, Validators.email]),
      imageURL: new FormControl('', Validators.required)
    });
  }
}
