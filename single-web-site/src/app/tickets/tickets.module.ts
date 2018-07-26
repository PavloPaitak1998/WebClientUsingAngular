import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';

import { TicketsRoutingModule } from './tickets-routing.module';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { TicketService } from '../Shared/Services/ticket.service';

@NgModule({
  imports: [
    CommonModule,
    TicketsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [TicketService],
  declarations: [
    TicketDetailsComponent,
    TicketListComponent
  ]
})
export class TicketsModule { }
