import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';
import {MatSortModule} from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DeparturesRoutingModule } from './departures-routing.module';
import { DepartureListComponent } from './departure-list/departure-list.component';
import { DepartureDetailsComponent } from './departure-details/departure-details.component';
import { DepartureService } from '../Shared/Services/departure.service';

@NgModule({
  imports: [
    CommonModule,
    DeparturesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
    BrowserAnimationsModule

  ],
  providers:[DepartureService],
  declarations: [DepartureListComponent, DepartureDetailsComponent]
})
export class DeparturesModule { }
