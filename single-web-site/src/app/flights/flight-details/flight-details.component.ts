import { Component, OnInit } from '@angular/core';
import { Flight } from '../../Shared/Models/flight';
import { ActivatedRoute, Params } from '@angular/router';
import { FlightService } from '../../Shared/Services/flight.service';

@Component({
  selector: 'app-flight-details',
  templateUrl: './flight-details.component.html',
  styleUrls: ['./flight-details.component.css']
})
export class FlightDetailsComponent implements OnInit {

  flight:Flight;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private flightService:FlightService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.flightService.get(id).subscribe((data:Flight)=>this.flight=data);
    });
  }

  
}
