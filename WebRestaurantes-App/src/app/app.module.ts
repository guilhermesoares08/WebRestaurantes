import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { TooltipModule, ModalModule, BsDropdownModule, CarouselComponent } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { defineLocale, BsLocaleService, ptBrLocale, BsDatepickerModule } from 'ngx-bootstrap';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
defineLocale('pt-br', ptBrLocale);

import { RestaurantService } from './_services/Restaurant.service';

import { AppComponent } from './app.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { NavComponent } from './nav/nav.component';
import { CarouselTemplateComponent } from './carousel-template/carousel-template.component';

import { fromEventPattern } from 'rxjs';

import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';




@NgModule({
   declarations: [
      AppComponent,
      RestaurantComponent,
      NavComponent,
      DateTimeFormatPipePipe,
      CarouselComponent,
      CarouselTemplateComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      BsDatepickerModule.forRoot(),
      BrowserAnimationsModule,
      TimepickerModule.forRoot()
   ],
   providers: [
      RestaurantService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
