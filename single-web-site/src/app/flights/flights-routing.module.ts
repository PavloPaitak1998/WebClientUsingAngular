import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FlightListComponent } from './flight-list/flight-list.component'
import { FlightDetailsComponent } from './flight-details/flight-details.component'

@NgModule({
  imports: [RouterModule.forChild([
    {path:"flights",component: FlightListComponent },
    {path:"flights/:id",component: FlightDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class FlightsRoutingModule { }
