import { Component, OnInit, TemplateRef } from '@angular/core';
import { RestaurantService } from '../_services/Restaurant.service';
import { Restaurant } from '../_models/Restaurant';
import { BsModalRef, BsModalService, BsLocaleService } from 'ngx-bootstrap';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';

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
  restaurant: Restaurant;
  modalRef: BsModalRef;
  registerForm: FormGroup;
  disabledDates = [
    new Date('2019-12-05'),
    new Date('2019-12-09')
  ];
  bodyDeletarRestaurant = '';

  get filtroLista(): string {
    return this._filtroLista;
  }

  set filtroLista(value: string) {
    this._filtroLista = value;
    this.filteredRestaurants = this.filtroLista
      ? this.filtrarRestaurants(this.filtroLista)
      : this.restaurants;
  }

  constructor(
    private restaurantService: RestaurantService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
  ) {
    this.localeService.use('pt-br');
  }

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

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  salvarAlteracao() {
    if (this.registerForm.valid) {
      this.restaurant = Object.assign({}, this.registerForm.value);
      this.restaurantService.postRestaurant(this.restaurant);
    }
  }

  validation() {
    this.registerForm = this.fb.group({
      txtDescription: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(100)
        ]
      ],
      txtEmail: ['', [Validators.required, Validators.email]],
      imageURL: ['', Validators.required],
      txtScheduleDate: ['', Validators.required],
      txtScheduleHour: ['', Validators.required]
    });
  }

  excluirRestaurante(rest: Restaurant, modal: any) {
    modal.show();
    this.restaurant = rest;
    this.bodyDeletarRestaurant = `Tem certeza que deseja excluir o Restaurante: ${rest.description}, Código: ${rest.id}`;
  }

  confirmDelete(modal: any) {
    this.restaurantService.deleteRestaurant(this.restaurant.id).subscribe(
      () => {
        modal.hide();
        this.getAllRestaurants();
      }, error => {
        console.log(error);
      }
    );
  }
}
