import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DepartureListComponent } from './departure-list/departure-list.component';
import { DepartureDetailsComponent } from './departure-details/departure-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"departures",component: DepartureListComponent },
    {path:"departures/:id",component: DepartureDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class DeparturesRoutingModule { }
