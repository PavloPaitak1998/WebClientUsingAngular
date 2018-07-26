import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrewListComponent } from './crew-list/crew-list.component';
import { CrewDetailsComponent } from './crew-details/crew-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"crews",component: CrewListComponent },
    {path:"crews/:id",component:CrewDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class CrewsRoutingModule { }
