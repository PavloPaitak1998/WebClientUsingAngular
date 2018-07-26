import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';

import { StewardessesRoutingModule } from './stewardesses-routing.module';
import { StewardessListComponent } from './stewardess-list/stewardess-list.component';
import { StewardessDetailsComponent } from './stewardess-details/stewardess-details.component';
import { StewardessService } from '../Shared/Services/stewardess.service';

@NgModule({
  imports: [
    CommonModule,
    StewardessesRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [StewardessService],
  declarations: [StewardessListComponent, StewardessDetailsComponent]
})
export class StewardessesModule { }
