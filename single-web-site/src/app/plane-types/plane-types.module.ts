import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';

import { PlaneTypesRoutingModule } from './plane-types-routing.module';
import { PlaneTypeListComponent } from './plane-type-list/plane-type-list.component';
import { PlaneTypeDetailsComponent } from './plane-type-details/plane-type-details.component';
import { PlaneTypeService } from '../Shared/Services/plane-type.service';

@NgModule({
  imports: [
    CommonModule,
    PlaneTypesRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[PlaneTypeService],
  declarations: [PlaneTypeListComponent, PlaneTypeDetailsComponent]
})
export class PlaneTypesModule { }
