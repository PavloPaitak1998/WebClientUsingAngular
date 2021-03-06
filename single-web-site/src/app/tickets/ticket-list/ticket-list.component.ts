import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { TicketService } from '../../Shared/Services/ticket.service';
import { Router } from '@angular/router';
import { Ticket } from '../../Shared/Models/ticket';
import {Sort} from '@angular/material';
import { compare } from '../../Shared/Compare/compare';

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.css']
})
export class TicketListComponent implements OnInit {
  
  ticket:Ticket=new Ticket();
  tickets:Ticket[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private ticketService:TicketService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "flightNumber":["",[Validators.required,Validators.maxLength(4),Validators.pattern("[0-9]{4}")]],
        "flightId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "ticketPrice":["",[Validators.required]]
      });
    }

  ngOnInit() {
    this.loadTickets();
  }

  loadTickets(){
    this.ticketService.getAll()
    .subscribe((data:Ticket[])=>this.tickets=data);
  }

  sortData(sort: Sort) {
    const data = this.tickets.slice();
    if (!sort.active || sort.direction === '') {
      this.tickets = data;
      return;
    }

    this.tickets = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'flightNumber': return compare(a.flightNumber, b.flightNumber, isAsc);
        case 'price': return compare(a.price, b.price, isAsc);
        case 'flightId': return compare(a.flightId, b.flightId, isAsc);
        default: return 0;
      }
    });
  }

  onSave() {
    if (this.ticket.id == undefined) {
      this.ticket.id=0;
      
      this.ticket.price=this.myForm.get('ticketPrice').value;
      this.ticket.flightNumber=this.myForm.get('flightNumber').value;
      this.ticket.flightId=this.myForm.get('flightId').value;

      this.ticketService.create(this.ticket)
            .subscribe(data => this.loadTickets());
    } else {
        this.ticketService.update(this.ticket)
            .subscribe(data => this.loadTickets());
    }
    this.onCancel();
  }

  onEditTicket(t: Ticket) {
      this.ticket = t;
  }

  onCancel() {
      this.ticket = new Ticket();
      this.tableMode = true;
  }

  onDelete(t: Ticket) {
      this.ticketService.delete(t.id)
          .subscribe(data => this.loadTickets());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Ticket){
    this.router.navigate(["tickets/",selected.id]);
  }

}
