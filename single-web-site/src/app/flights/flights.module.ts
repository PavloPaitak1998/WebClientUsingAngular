import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';
import {MatSortModule} from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FlightsRoutingModule } from './flights-routing.module';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightDetailsComponent } from './flight-details/flight-details.component';
import { FlightService } from '../Shared/Services/flight.service';

@NgModule({
  imports: [
    CommonModule,
    FlightsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
    BrowserAnimationsModule
  ],
  providers:[FlightService],
  declarations: [
    FlightListComponent,
    FlightDetailsComponent   
  ]
})
export class FlightsModule { }
