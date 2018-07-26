import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';
import {MatSortModule} from '@angular/material/sort';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PilotsRoutingModule } from './pilots-routing.module';
import { PilotListComponent } from './pilot-list/pilot-list.component';
import { PilotDetailsComponent } from './pilot-details/pilot-details.component';
import { PilotService } from '../Shared/Services/pilot.service';

@NgModule({
  imports: [
    CommonModule,
    PilotsRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
    BrowserAnimationsModule
  ],
  providers:[PilotService],
  declarations: [PilotListComponent, PilotDetailsComponent]
})
export class PilotsModule { }
