import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { PlaneType } from '../Models/planeType';
 
@Injectable()
export class PlaneTypeService {
 
    private url = "http://localhost:52729/api/planeTypes";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(planeType:PlaneType) {
        return this.http.post(this.url, planeType);
    }
    
    update(planeType:PlaneType) { 
        return this.http.put(this.url+'/'+ planeType.id, planeType);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}