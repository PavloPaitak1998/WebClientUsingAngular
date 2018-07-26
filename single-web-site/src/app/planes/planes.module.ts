import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';

import { PlanesRoutingModule } from './planes-routing.module';
import { PlaneListComponent } from './plane-list/plane-list.component';
import { PlaneDetailsComponent } from './plane-details/plane-details.component';
import { PlaneService } from '../Shared/Services/plane.service';

@NgModule({
  imports: [
    CommonModule,
    PlanesRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers:[PlaneService],
  declarations: [PlaneListComponent, PlaneDetailsComponent]
})
export class PlanesModule { }
