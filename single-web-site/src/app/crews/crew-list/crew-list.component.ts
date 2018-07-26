import { Component, OnInit } from '@angular/core';
import { FormGroup} from '@angular/forms';
import { CrewService } from '../../Shared/Services/crew.service';
import { Crew } from '../../Shared/Models/crew';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crew-list',
  templateUrl: './crew-list.component.html',
  styleUrls: ['./crew-list.component.css']
})
export class CrewListComponent implements OnInit {

  crew:Crew=new Crew();
  crews:Crew[];
  tableMode: boolean = true;

  constructor(
    private crewService:CrewService,
    private router:Router) { }

  ngOnInit() {
    this.loadCrews();
  }

  loadCrews(){
    this.crewService.getAll()
    .subscribe((data:Crew[])=>this.crews=data);
  }

  onSave() {
    if (this.crew.id == undefined) {
      this.crew.id=0;
      
      this.crewService.create(this.crew)
            .subscribe(data => this.loadCrews());
    } else {
        this.crewService.update(this.crew)
            .subscribe(data => this.loadCrews());
    }
    this.onCancel();
  }

  onEditCrew(c: Crew) {
      this.crew = c;
  }

  onCancel() {
      this.crew = new Crew();
      this.tableMode = true;
  }

  onDelete(c: Crew) {
      this.crewService.delete(c.id)
          .subscribe(data => this.loadCrews());
  }

  onAdd() {
      this.onCancel();
      this.tableMode = false;
  }

  onSelect(selected:Crew){
    this.router.navigate(["crews/",selected.id]);
  }

}
