export class Departure{

    constructor(
        public id?:number,
        public flightNumber?:number,
        public time?: Date,
        public flightId?:number,
        public crewId?:number,
        public planeId?:number) { }
}