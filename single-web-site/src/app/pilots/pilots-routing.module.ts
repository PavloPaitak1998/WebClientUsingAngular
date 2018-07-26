import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PilotListComponent } from './pilot-list/pilot-list.component';
import { PilotDetailsComponent } from './pilot-details/pilot-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"pilots",component: PilotListComponent },
    {path:"pilots/:id",component: PilotDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class PilotsRoutingModule { }
