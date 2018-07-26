import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Ticket } from '../Models/ticket';
 
@Injectable()
export class TicketService {
 
    private url = "http://localhost:52729/api/tickets";
 
    constructor(private http: HttpClient) {
    }
 
    getAll() {
        return this.http.get(this.url);
    }
 
    get(id:number){
        return this.http.get(this.url + '/'+ id);        
    }

    create(ticket:Ticket) {
        return this.http.post(this.url, ticket);
    }
    
    update(ticket:Ticket) { 
        return this.http.put(this.url+'/'+ ticket.id, ticket);
    }

    delete(id:number) {
        return this.http.delete(this.url + '/' + id);
    }
}