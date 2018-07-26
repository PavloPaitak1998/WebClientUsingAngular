import { Component, OnInit } from '@angular/core';
import { Stewardess } from '../../Shared/Models/stewardess';
import { ActivatedRoute, Params } from '@angular/router';
import { StewardessService } from '../../Shared/Services/stewardess.service';

@Component({
  selector: 'app-stewardess-details',
  templateUrl: './stewardess-details.component.html',
  styleUrls: ['./stewardess-details.component.css']
})
export class StewardessDetailsComponent implements OnInit {

  stewardess:Stewardess;
  
  constructor(
    private activatedRoute:ActivatedRoute,
    private stewardessService:StewardessService) { }

  ngOnInit() {
    this.activatedRoute.params.forEach((params:Params)=>{
      let id=+params["id"];
      this.stewardessService.get(id).subscribe((data:Stewardess)=>this.stewardess=data);
    });
  }

}
