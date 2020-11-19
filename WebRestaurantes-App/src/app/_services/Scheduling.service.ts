import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ScheduleTime } from '../_models/ScheduleTime';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {

  baseUrl = 'http://localhost:5000/api/scheduling';

  constructor(private http: HttpClient) {

  }

  getTimes(restaurantId: number, scheduleDate: Date): Observable<string[]> {
    //const tmpParams = new HttpParams().set('SDate', scheduleDate.toDateString() );
    const tmpParams = JSON.stringify(scheduleDate);
    return this.http.get<string[]>(`${this.baseUrl}/${restaurantId}&scheduleDate=${tmpParams}/times`);
  }
}