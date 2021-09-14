import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/_models/Restaurant';
import { RestaurantService } from 'src/app/_services/Restaurant.service';
import { BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl, FormControlName } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig, BsDatepickerInlineConfig } from 'ngx-bootstrap/datepicker';
import { Constants } from 'src/app/util/Constants';
import { Table } from 'src/app/_models/Table';



@Component({
  selector: 'app-restaurantdetail',
  templateUrl: './restaurantDetail.component.html',
  styleUrls: ['./restaurantDetail.component.css']
})
export class RestaurantDetailComponent implements OnInit {

  bsInlineValue = new Date();
  datepickerConfig: Partial<BsDatepickerConfig>;
  restaurantObj: Restaurant = new Restaurant();
  imagemURL = '';
  registerScheduleForm: FormGroup;
  file: File;
  fileNameToUpdate: string;
  dataAtual = '';
  modoSalvar: string;
  tables: Table[];
  messages: string[] = [];
  message = 'onShown';
  disabledDropTable: string = 'disabled';




  constructor(private restaurantService: RestaurantService
    , private fb: FormBuilder
    , private toastr: ToastrService
    , private localService: BsLocaleService
    , private router: ActivatedRoute) {
    this.localService.use('pt-br');
    this.datepickerConfig = Object.assign({}, { dateInputFormat: 'DD/MM/YYYY hh:mm a', containerClass: 'theme-red' });

  }

  ngOnInit() {
    this.validation();
    this.loadRestaurant();
    this.disabledDropTable = 'disabled';
  }

  getAvailableTables(restaurantId: number) {
    this.restaurantService.getTables(restaurantId).subscribe(
      // tslint:disable-next-line: variable-name
      (_tables: Table[]) => {
        this.tables = _tables;
      },
      error => {
        this.toastr.error(`Erro ao tentar carregar mesas: ${error}`);
      }
    );
  }

  mostraMesas(): void {

    //this.messages.push(`Event ${value} is fired`);

    if (this.registerScheduleForm.value.scheduleDate) {
      this.getAvailableTables(+this.router.snapshot.paramMap.get('id'));
      this.disabledDropTable = "enabled";
    }
    else {
      this.disabledDropTable = "disabled";
    }
    console.log(this.disabledDropTable);

  }

  validation() {
    this.registerScheduleForm = this.fb.group({
      //[valor padrao, atributos(Validators)]
      scheduleDate: ['', Validators.required],
    });
  }

  loadRestaurant() {
    const idRestaurant = +this.router.snapshot.paramMap.get('id');
    this.restaurantService.getRestaurantById(idRestaurant)
      .subscribe(
        (restaurantObj: Restaurant) => {
          this.restaurantObj = Object.assign({}, restaurantObj);
          this.fileNameToUpdate = restaurantObj.imageURL.toString();

          this.imagemURL = `http://localhost:5000/resources/images/${this.restaurantObj.imageURL}?_ts=${this.dataAtual}`;

          this.restaurantObj.imageURL = '';
          //this.registerForm.patchValue(this.restaurantObj);
        }
      );
  }

  selectedStartDate: string;
  updateMyDate(newDate) {
    console.log(newDate);
  }

  salvarReserva(template: any) {
    if (this.registerScheduleForm.valid) {
      if (this.modoSalvar === Constants.HTTPMETHOD_POST) {

      }
    }
  }



}
