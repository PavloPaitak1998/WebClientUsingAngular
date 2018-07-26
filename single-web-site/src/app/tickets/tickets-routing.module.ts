import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TicketListComponent } from './ticket-list/ticket-list.component';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"tickets",component: TicketListComponent },
    {path:"tickets/:id",component: TicketDetailsComponent }
  ] )],
  exports: [RouterModule]
})
export class TicketsRoutingModule { }
