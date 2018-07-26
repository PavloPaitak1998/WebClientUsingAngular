import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { FlightsModule } from './flights/flights.module'
import { TicketsModule } from './tickets/tickets.module'
import { DeparturesModule } from './departures/departures.module'
import { CrewsModule } from './crews/crews.module'
import { PilotsModule } from './pilots/pilots.module'
import { PlanesModule } from './planes/planes.module';
import { StewardessesModule } from './stewardesses/stewardesses.module';
import { PlaneTypesModule } from './plane-types/plane-types.module';

import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FlightsModule,
    TicketsModule,
    DeparturesModule,
    HttpClientModule,
    FormsModule,
    CrewsModule,
    PilotsModule,
    PlanesModule,
    StewardessesModule,
    PlaneTypesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
