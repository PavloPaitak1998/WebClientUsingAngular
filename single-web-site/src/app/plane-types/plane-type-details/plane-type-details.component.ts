import { Component, OnInit } from '@angular/core';
import { PlaneType } from '../../Shared/Models/planeType';
import { ActivatedRoute, Params } from '@angular/router';
import { PlaneTypeService } from '../../Shared/Services/plane-type.service';

@Component({
  selector: 'app-plane-type-details',
  templateUrl: './plane-type-details.component.html',
  styleUrls: ['./plane-type-details.component.css']
})
export class PlaneTypeDetailsComponent implements OnInit {

  planeType:PlaneType;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private planeTypeService:PlaneTypeService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.planeTypeService.get(id).subscribe((data:PlaneType)=>this.planeType=data);
    });
  }

}
