import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class RestaurantService {
  baseUrl = "http://localhost:5000/api/restaurant";
  constructor(private http: HttpClient) {}

  getRestaurant() {
    return this.http.get(this.baseUrl);
  }
}
