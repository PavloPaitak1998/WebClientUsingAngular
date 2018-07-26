import { Component, OnInit } from '@angular/core';
import { Departure } from '../../Shared/Models/departure';
import { ActivatedRoute, Params } from '@angular/router';
import { DepartureService } from '../../Shared/Services/departure.service';

@Component({
  selector: 'app-departure-details',
  templateUrl: './departure-details.component.html',
  styleUrls: ['./departure-details.component.css']
})
export class DepartureDetailsComponent implements OnInit {

  departure:Departure;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private departureService:DepartureService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.departureService.get(id).subscribe((data:Departure)=>this.departure=data);
    });
  }

}
