import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { FlightService } from '../../Shared/Services/flight.service';
import { Flight } from '../../Shared/Models/flight';
import { Router } from '@angular/router';
import {Sort} from '@angular/material';
import { compare } from '../../Shared/Compare/compare';

@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.css']
})
export class FlightListComponent implements OnInit {

  flight:Flight=new Flight();
  flights:Flight[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private flightService:FlightService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "flightNumber":["",[Validators.required,Validators.maxLength(4),Validators.pattern("[0-9]{4}")]],
        "flightPointOfDeparture":["",[Validators.required]],
        "flightDepartureTime":["",[Validators.required]],
        "flightDestination":["",[Validators.required]],
        "flightDestinationTime":["",[Validators.required]]
      });
    }

  ngOnInit() {
    this.loadFlights();
  }

  loadFlights(){
    this.flightService.getAll()
    .subscribe((data:Flight[])=>this.flights=data);
  }

  sortData(sort: Sort) {
    const data = this.flights.slice();
    if (!sort.active || sort.direction === '') {
      this.flights = data;
      return;
    }

    this.flights = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'number': return compare(a.number, b.number, isAsc);
        case 'pointOfDeparture': return compare(a.pointOfDeparture, b.pointOfDeparture, isAsc);
        case 'departureTime': return compare(a.departureTime, b.departureTime, isAsc);
        case 'destination': return compare(a.destination, b.destination, isAsc);
        case 'destinationTime': return compare(a.destinationTime, b.destinationTime, isAsc);
        default: return 0;
      }
    });
  }

  onSave() {
    if (this.flight.id == undefined) {
      this.flight.id=0;
      
      this.flight.number=this.myForm.get('flightNumber').value;
      this.flight.pointOfDeparture=this.myForm.get('flightPointOfDeparture').value;
      this.flight.departureTime=this.myForm.get('flightDepartureTime').value;
      this.flight.destination=this.myForm.get('flightDestination').value;
      this.flight.destinationTime=this.myForm.get('flightDestinationTime').value;

      this.flightService.create(this.flight)
            .subscribe(data => this.loadFlights());
    } else {
        this.flightService.update(this.flight)
            .subscribe(data => this.loadFlights());
    }
    this.onCancel();
  }

  onEditFlight(f: Flight) {
      this.flight = f;
  }

  onCancel() {
      this.flight = new Flight();
      this.tableMode = true;
  }

  onDelete(f: Flight) {
      this.flightService.delete(f.id)
          .subscribe(data => this.loadFlights());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Flight){
    this.router.navigate(["flights/",selected.id]);
  }
}
