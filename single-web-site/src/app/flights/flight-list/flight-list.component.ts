import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { FlightService } from '../../Shared/Services/flight.service';
import { Flight } from '../../Shared/Models/flight';
import { Router } from '@angular/router';

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
