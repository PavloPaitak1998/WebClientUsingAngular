import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Flight } from '../Models/flight';
 
@Injectable()
export class FlightService {
 
    private url = "http://localhost:52729/api/flights";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(flight:Flight) {
        return this.http.post(this.url, flight);
    }
    
    update(flight:Flight) { 
        return this.http.put(this.url+'/'+ flight.id, flight);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}