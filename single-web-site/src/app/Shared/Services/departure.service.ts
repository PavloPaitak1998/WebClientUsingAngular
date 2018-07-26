import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Departure } from '../Models/departure';
 
@Injectable()
export class DepartureService {
 
    private url = "http://localhost:52729/api/departures";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(departure:Departure) {
        return this.http.post(this.url, departure);
    }
    
    update(departure:Departure) { 
        return this.http.put(this.url+'/'+ departure.id, departure);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}