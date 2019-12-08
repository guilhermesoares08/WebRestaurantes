import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { CarouselTemplateComponent } from './carousel-template/carousel-template.component';


const routes: Routes = [
  { path: 'restaurant', component: RestaurantComponent },
  { path: '',  component: CarouselTemplateComponent },
  { path: '**',  redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
