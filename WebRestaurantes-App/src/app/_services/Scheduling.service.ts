import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScheduleTime } from '../_models/ScheduleTime';
import { Restaurant } from '../_models/Restaurant';
import { Scheduling } from '../_models/Scheduling';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {

  baseUrl = 'http://localhost:5000/api/scheduling';

  constructor(private http: HttpClient) {

  }

  getScheduleByRestaurant(restaurantId: number){        
    return this.http.get<string[]>(`${this.baseUrl}/${restaurantId}`);
  }  

  postSchedule(rest: Scheduling) {
    return this.http.post(`${this.baseUrl}`, rest);
  }
}