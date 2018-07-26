import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';

import { CrewsRoutingModule } from './crews-routing.module';
import { CrewListComponent } from './crew-list/crew-list.component';
import { CrewDetailsComponent } from './crew-details/crew-details.component';
import { CrewService } from '../Shared/Services/crew.service';

@NgModule({
  imports: [
    CommonModule,
    CrewsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers:[CrewService],
  declarations: [CrewListComponent, CrewDetailsComponent]
})
export class CrewsModule { }
