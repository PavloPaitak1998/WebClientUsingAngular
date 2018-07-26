import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { PilotService } from '../../Shared/Services/pilot.service';
import { Pilot } from '../../Shared/Models/pilot';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pilot-list',
  templateUrl: './pilot-list.component.html',
  styleUrls: ['./pilot-list.component.css']
})
export class PilotListComponent implements OnInit {

  pilot:Pilot=new Pilot();
  pilots:Pilot[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private pilotService:PilotService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "pilotFirstName":["",[Validators.required]],
        "pilotLastName":["",[Validators.required]],
        "crewId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "pilotBirthDate":["",[Validators.required]],
        "pilotExperience":["",[Validators.required]]
      });
    }

  ngOnInit() {
    this.loadPilots();
  }

  loadPilots(){
    this.pilotService.getAll()
    .subscribe((data:Pilot[])=>this.pilots=data);
  }

  onSave() {
    if (this.pilot.id == undefined) {
      this.pilot.id=0;
      
      this.pilot.firstName=this.myForm.get('pilotFirstName').value;
      this.pilot.lastName=this.myForm.get('pilotLastName').value;
      this.pilot.crewId=this.myForm.get('crewId').value;
      this.pilot.birthDate=this.myForm.get('pilotBirthDate').value;
      this.pilot.experience=this.myForm.get('pilotExperience').value;

      this.pilotService.create(this.pilot)
            .subscribe(data => this.loadPilots());
    } else {
        this.pilotService.update(this.pilot)
            .subscribe(data => this.loadPilots());
    }
    this.onCancel();
  }

  onEditPilot(p: Pilot) {
      this.pilot = p;
  }

  onCancel() {
      this.pilot = new Pilot();
      this.tableMode = true;
  }

  onDelete(p: Pilot) {
      this.pilotService.delete(p.id)
          .subscribe(data => this.loadPilots());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Pilot){
    this.router.navigate(["pilots/",selected.id]);
  }
}
