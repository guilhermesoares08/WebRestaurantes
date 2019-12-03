import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Restaurant } from "../_models/Restaurant";

@Injectable({
  providedIn: "root"
})
export class RestaurantService {
  baseUrl = "http://localhost:5000/api/restaurant";
  constructor(private http: HttpClient) {}

  getAllRestaurant(): Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(this.baseUrl);
  }

  getRestaurantById(id: number): Observable<Restaurant> {
    return this.http.get<Restaurant>(`${this.baseUrl}/${id}`);
  }

  getRestaurantByText(text: string): Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(`${this.baseUrl}/getByText/${text}`);
  }
}
