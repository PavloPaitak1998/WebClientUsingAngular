import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Plane } from '../Models/plane';
 
@Injectable()
export class PlaneService {
 
    private url = "http://localhost:52729/api/planes";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(plane:Plane) {
        return this.http.post(this.url, plane);
    }
    
    update(plane:Plane) { 
        return this.http.put(this.url+'/'+ plane.id, plane);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}