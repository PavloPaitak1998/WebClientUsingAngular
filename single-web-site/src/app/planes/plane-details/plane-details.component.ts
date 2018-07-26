import { Component, OnInit } from '@angular/core';
import { Plane } from '../../Shared/Models/plane';
import { ActivatedRoute, Params } from '@angular/router';
import { PlaneService } from '../../Shared/Services/plane.service';

@Component({
  selector: 'app-plane-details',
  templateUrl: './plane-details.component.html',
  styleUrls: ['./plane-details.component.css']
})
export class PlaneDetailsComponent implements OnInit {

  plane:Plane;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private planeService:PlaneService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.planeService.get(id).subscribe((data:Plane)=>this.plane=data);
    });
  }

}
