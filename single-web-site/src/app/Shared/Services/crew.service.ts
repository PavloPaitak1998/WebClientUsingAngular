import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Crew } from '../Models/crew';
 
@Injectable()
export class CrewService {
 
    private url = "http://localhost:52729/api/crew";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(crew:Crew) {
        return this.http.post(this.url, crew);
    }
    
    update(crew:Crew) { 
        return this.http.put(this.url+'/'+ crew.id, crew);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}