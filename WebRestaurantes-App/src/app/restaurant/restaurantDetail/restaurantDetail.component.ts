import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/_models/Restaurant';
import { RestaurantService } from 'src/app/_services/Restaurant.service';
import { BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig, BsDatepickerInlineConfig } from 'ngx-bootstrap/datepicker';



@Component({
  selector: 'app-restaurantdetail',
  templateUrl: './restaurantDetail.component.html',
  styleUrls: ['./restaurantDetail.component.css']
})
export class RestaurantDetailComponent implements OnInit {
 
  bsInlineValue = new Date();
  
  datepickerConfig:Partial<BsDatepickerConfig>;
  
  constructor(private restaurantService: RestaurantService
    , private fb: FormBuilder   
    , private toastr: ToastrService
    , private localService: BsLocaleService
    , private router: ActivatedRoute) {
      this.localService.use('pt-br');
      this.datepickerConfig = Object.assign({}, { dateInputFormat:'DD/MM/YYYY hh:mm a' });
     }

  ngOnInit() {
   
    
  } 

}
