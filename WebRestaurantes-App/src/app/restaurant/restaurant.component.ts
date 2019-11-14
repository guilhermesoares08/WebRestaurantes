import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {

  restaurants: any = [
    {
      Id: '1',
      Name: 'Restaurante1',
      Address: 'Address1'
    },
    {
      Id: '2',
      Name: 'Restaurante2',
      Address: 'Address2'
    }
];

  constructor() { }

  ngOnInit() {
  }

}
