import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { StewardessService } from '../../Shared/Services/stewardess.service';
import { Stewardess } from '../../Shared/Models/stewardess';
import { Router } from '@angular/router';
import {Sort} from '@angular/material';
import { compare } from '../../Shared/Compare/compare';

@Component({
  selector: 'app-stewardess-list',
  templateUrl: './stewardess-list.component.html',
  styleUrls: ['./stewardess-list.component.css']
})
export class StewardessListComponent implements OnInit {

  stewardess:Stewardess=new Stewardess();
  stewardesses:Stewardess[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private stewardessService:StewardessService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "stewardessFirstName":["",[Validators.required]],
        "stewardessLastName":["",[Validators.required]],
        "crewId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "stewardessBirthDate":["",[Validators.required]],
      });
    }

  ngOnInit() {
    this.loadStewardesses();
  }

  loadStewardesses(){
    this.stewardessService.getAll()
    .subscribe((data:Stewardess[])=>this.stewardesses=data);
  }

  sortData(sort: Sort) {
    const data = this.stewardesses.slice();
    if (!sort.active || sort.direction === '') {
      this.stewardesses = data;
      return;
    }

    this.stewardesses = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'firstName': return compare(a.firstName, b.firstName, isAsc);
        case 'lastName': return compare(a.lastName, b.lastName, isAsc);
        case 'crewId': return compare(a.crewId, b.crewId, isAsc);
        case 'birthDate': return compare(a.birthDate, b.birthDate, isAsc);
        default: return 0;
      }
    });
  }

  onSave() {
    if (this.stewardess.id == undefined) {
      this.stewardess.id=0;
      
      this.stewardess.firstName=this.myForm.get('stewardessFirstName').value;
      this.stewardess.lastName=this.myForm.get('stewardessLastName').value;
      this.stewardess.crewId=this.myForm.get('crewId').value;
      this.stewardess.birthDate=this.myForm.get('stewardessBirthDate').value;

      this.stewardessService.create(this.stewardess)
            .subscribe(data => this.loadStewardesses());
    } else {
        this.stewardessService.update(this.stewardess)
            .subscribe(data => this.loadStewardesses());
    }
    this.onCancel();
  }

  onEditStewardess(s: Stewardess) {
      this.stewardess = s;
  }

  onCancel() {
      this.stewardess = new Stewardess();
      this.tableMode = true;
  }

  onDelete(s: Stewardess) {
      this.stewardessService.delete(s.id)
          .subscribe(data => this.loadStewardesses());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Stewardess){
    this.router.navigate(["stewardesses/",selected.id]);
  }

}
