import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { PlaneTypeService } from '../../Shared/Services/plane-type.service';
import { PlaneType } from '../../Shared/Models/planeType';
import { Router } from '@angular/router';
import {Sort} from '@angular/material';
import { compare } from '../../Shared/Compare/compare';

@Component({
  selector: 'app-plane-type-list',
  templateUrl: './plane-type-list.component.html',
  styleUrls: ['./plane-type-list.component.css']
})
export class PlaneTypeListComponent implements OnInit {

  planeType:PlaneType=new PlaneType();
  planeTypes:PlaneType[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private planeTypeService:PlaneTypeService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "planeTypeModel":["",[Validators.required]],
        "planeTypeSeats":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "planeTypeCarrying":["",[Validators.required,Validators.pattern("[0-9.]+")]],
      });
    }

  ngOnInit() {
    this.loadPlaneTypes();
  }

  loadPlaneTypes(){
    this.planeTypeService.getAll()
    .subscribe((data:PlaneType[])=>this.planeTypes=data);
  }
  
  sortData(sort: Sort) {
    const data = this.planeTypes.slice();
    if (!sort.active || sort.direction === '') {
      this.planeTypes = data;
      return;
    }

    this.planeTypes = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      switch (sort.active) {
        case 'id': return compare(a.id, b.id, isAsc);
        case 'model': return compare(a.model, b.model, isAsc);
        case 'seats': return compare(a.seats, b.seats, isAsc);
        case 'carrying': return compare(a.carrying, b.carrying, isAsc);
        default: return 0;
      }
    });
  }

  onSave() {
    if (this.planeType.id == undefined) {
      this.planeType.id=0;
      
      this.planeType.model=this.myForm.get('planeTypeModel').value;
      this.planeType.seats=this.myForm.get('planeTypeSeats').value;
      this.planeType.carrying=this.myForm.get('planeTypeCarrying').value;

      this.planeTypeService.create(this.planeType)
            .subscribe(data => this.loadPlaneTypes());
    } else {
        this.planeTypeService.update(this.planeType)
            .subscribe(data => this.loadPlaneTypes());
    }
    this.onCancel();
  }

  onEditPlaneType(pt: PlaneType) {
      this.planeType = pt;
  }

  onCancel() {
      this.planeType = new PlaneType();
      this.tableMode = true;
  }

  onDelete(pt: PlaneType) {
      this.planeTypeService.delete(pt.id)
          .subscribe(data => this.loadPlaneTypes());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:PlaneType){
    this.router.navigate(["planetypes/",selected.id]);
  }

}
