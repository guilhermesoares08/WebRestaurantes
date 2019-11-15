import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {

  restaurants: any = [];

  constructor(private http: HttpClient) {  }

  ngOnInit() {
    this.getAllRestaurants();
  }

  getAllRestaurants(){
    this.http.get('http://localhost:5000/api/values').subscribe( response => {
          this.restaurants = response;
        }, error => {
          console.log(error);
        });
  }

}
