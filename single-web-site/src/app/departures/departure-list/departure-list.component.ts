import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { DepartureService } from '../../Shared/Services/departure.service';
import { Departure } from '../../Shared/Models/departure';
import { Router } from '@angular/router';

@Component({
  selector: 'app-departure-list',
  templateUrl: './departure-list.component.html',
  styleUrls: ['./departure-list.component.css']
})
export class DepartureListComponent implements OnInit {

  departure:Departure=new Departure();
  departures:Departure[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private departureService:DepartureService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "flightNumber":["",[Validators.required,Validators.maxLength(4),Validators.pattern("[0-9]{4}")]],
        "departureTime":["",[Validators.required]],
        "flightId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "crewId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "planeId":["",[Validators.required,Validators.pattern("[0-9]+")]]
      });
    }

  ngOnInit() {
    this.loadDepartures();
  }

  loadDepartures(){
    this.departureService.getAll()
    .subscribe((data:Departure[])=>this.departures=data);
  }

  onSave() {
    if (this.departure.id == undefined) {
      this.departure.id=0;
      
      this.departure.flightNumber=this.myForm.get('flightNumber').value;
      this.departure.time=this.myForm.get('departureTime').value;
      this.departure.flightId=this.myForm.get('flightId').value;
      this.departure.crewId=this.myForm.get('crewId').value;
      this.departure.planeId=this.myForm.get('planeId').value;

      this.departureService.create(this.departure)
            .subscribe(data =>this.loadDepartures());
    } else {
        this.departureService.update(this.departure)
            .subscribe(data => this.loadDepartures());
    }
    this.onCancel();
  }

  onEditDeparture(d: Departure) {
      this.departure = d;
  }

  onCancel() {
      this.departure = new Departure();
      this.tableMode = true;
  }

  onDelete(d: Departure) {
      this.departureService.delete(d.id)
          .subscribe(data => this.loadDepartures());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Departure){
    this.router.navigate(["departures/",selected.id]);
  }

}
