import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { fromEventPattern } from 'rxjs';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { RestaurantService } from './_services/Restaurant.service';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantComponent,
    NavComponent,
    DateTimeFormatPipePipe
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [RestaurantService],
  bootstrap: [AppComponent]
})
export class AppModule {}
