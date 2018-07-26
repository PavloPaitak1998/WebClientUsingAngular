import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StewardessListComponent } from './stewardess-list/stewardess-list.component';
import { StewardessDetailsComponent } from './stewardess-details/stewardess-details.component';

@NgModule({
  imports: [RouterModule.forChild([
    {path:"stewardesses",component: StewardessListComponent },
    {path:"stewardesses/:id",component: StewardessDetailsComponent }  
  ])],
  exports: [RouterModule]
})
export class StewardessesRoutingModule { }
