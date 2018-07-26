import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Stewardess } from '../Models/stewardess';
 
@Injectable()
export class StewardessService {
 
    private url = "http://localhost:52729/api/stewardesses";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(stewardess:Stewardess) {
        return this.http.post(this.url, stewardess);
    }
    
    update(stewardess:Stewardess) { 
        return this.http.put(this.url+'/'+ stewardess.id, stewardess);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}