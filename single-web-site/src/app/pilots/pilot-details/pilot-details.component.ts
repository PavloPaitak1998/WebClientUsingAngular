import { Component, OnInit } from '@angular/core';
import { Pilot } from '../../Shared/Models/pilot';
import { ActivatedRoute, Params } from '@angular/router';
import { PilotService } from '../../Shared/Services/pilot.service';

@Component({
  selector: 'app-pilot-details',
  templateUrl: './pilot-details.component.html',
  styleUrls: ['./pilot-details.component.css']
})
export class PilotDetailsComponent implements OnInit {

  pilot:Pilot;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private pilotService:PilotService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.pilotService.get(id).subscribe((data:Pilot)=>this.pilot=data);
    });
  }

}
