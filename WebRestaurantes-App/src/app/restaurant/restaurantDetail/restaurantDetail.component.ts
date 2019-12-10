import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/_models/Restaurant';
import { RestaurantService } from 'src/app/_services/Restaurant.service';
import { BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurantdetail',
  templateUrl: './restaurantDetail.component.html',
  styleUrls: ['./restaurantDetail.component.css']
})
export class RestaurantDetailComponent implements OnInit {
  titulo: 'titulo';
  createDate: any;
  restaurant: Restaurant;
  registerForm: FormGroup;
  dataAtual: string;
  constructor(private restaurantService: RestaurantService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    , private toastr: ToastrService
    , private router: ActivatedRoute) { }

  ngOnInit() {
    this.validation();
    this.dataAtual = new Date().getMilliseconds().toString();
  }

  validation() {
    this.registerForm = this.fb.group({
      description: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(100)
        ]
      ],
      email: ['', [Validators.required, Validators.email]],
      addressDescription: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(100)
        ]
      ],
      cityId: [''],
      imageURL: ['']
      // txtScheduleDate: ['', Validators.required],
      // txtScheduleHour: ['', Validators.required]
    });
  }

  

}
