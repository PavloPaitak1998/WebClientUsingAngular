import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PlaneTypeListComponent } from './plane-type-list/plane-type-list.component';
import { PlaneTypeDetailsComponent } from './plane-type-details/plane-type-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"planetypes",component: PlaneTypeListComponent },
    {path:"planetypes/:id",component: PlaneTypeDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class PlaneTypesRoutingModule { }
