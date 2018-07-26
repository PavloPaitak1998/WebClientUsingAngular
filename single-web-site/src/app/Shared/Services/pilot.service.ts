import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Pilot } from '../Models/pilot';
 
@Injectable()
export class PilotService {
 
    private url = "http://localhost:52729/api/pilots";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(pilot:Pilot) {
        return this.http.post(this.url, pilot);
    }
    
    update(pilot:Pilot) { 
        return this.http.put(this.url+'/'+ pilot.id, pilot);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}