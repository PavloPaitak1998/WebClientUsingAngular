import { Component, OnInit } from '@angular/core';
import { Crew } from '../../Shared/Models/crew';
import { ActivatedRoute, Params } from '@angular/router';
import { CrewService } from '../../Shared/Services/crew.service';

@Component({
  selector: 'app-crew-details',
  templateUrl: './crew-details.component.html',
  styleUrls: ['./crew-details.component.css']
})
export class CrewDetailsComponent implements OnInit {

  crew:Crew;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private crewService:CrewService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.crewService.get(id).subscribe((data:Crew)=>this.crew=data);
    });
  }

}
