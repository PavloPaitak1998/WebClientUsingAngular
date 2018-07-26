import { Component, OnInit } from '@angular/core';
import { Ticket } from '../../Shared/Models/ticket';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { TicketService } from '../../Shared/Services/ticket.service';

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.css']
})
export class TicketDetailsComponent implements OnInit {

  ticket:Ticket;
  
  constructor(
    private router:Router,
    private activatedRoute:ActivatedRoute,
    private ticketService:TicketService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.ticketService.get(id).subscribe((data:Ticket)=>this.ticket=data);
    });
  }

}
