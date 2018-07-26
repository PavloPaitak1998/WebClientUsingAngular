import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl} from '@angular/forms';
import { PlaneService } from '../../Shared/Services/plane.service';
import { Plane } from '../../Shared/Models/plane';
import { Router } from '@angular/router';

@Component({
  selector: 'app-plane-list',
  templateUrl: './plane-list.component.html',
  styleUrls: ['./plane-list.component.css']
})
export class PlaneListComponent implements OnInit {

  plane:Plane=new Plane();
  planes:Plane[];
  tableMode: boolean = true;

  myForm : FormGroup;

  constructor(
    private planeService:PlaneService,
    private router:Router,
    private formBuilder:FormBuilder) { 
      this.myForm=formBuilder.group({
        "planeName":["",[Validators.required]],
        "planeTypeId":["",[Validators.required,Validators.pattern("[0-9]+")]],
        "planeReleaseDate":["",[Validators.required]],
        "planeLifetime":["",[Validators.required]],
      });
    }

  ngOnInit() {
    this.loadPlanes();
  }

  loadPlanes(){
    this.planeService.getAll()
    .subscribe((data:Plane[])=>this.planes=data);
  }

  onSave() {
    if (this.plane.id == undefined) {
      this.plane.id=0;
      
      this.plane.name=this.myForm.get('planeName').value;
      this.plane.planeTypeId=this.myForm.get('planeTypeId').value;
      this.plane.releaseDate=this.myForm.get('planeReleaseDate').value;
      this.plane.lifetime=this.myForm.get('planeLifetime').value;

      this.planeService.create(this.plane)
            .subscribe(data => this.loadPlanes());
    } else {
        this.planeService.update(this.plane)
            .subscribe(data => this.loadPlanes());
    }
    this.onCancel();
  }

  onEditPlane(p: Plane) {
      this.plane = p;
  }

  onCancel() {
      this.plane = new Plane();
      this.tableMode = true;
  }

  onDelete(p: Plane) {
      this.planeService.delete(p.id)
          .subscribe(data => this.loadPlanes());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Plane){
    this.router.navigate(["planes/",selected.id]);
  }

}
