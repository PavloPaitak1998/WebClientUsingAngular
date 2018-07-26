import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlaneListComponent } from './plane-list/plane-list.component';
import { PlaneDetailsComponent } from './plane-details/plane-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"planes",component: PlaneListComponent },
    {path:"planes/:id",component: PlaneDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class PlanesRoutingModule { }
