export class Flight{

    constructor(
        public id?:number,
        public number?:number,
        public pointOfDeparture?:string,
        public departureTime?: Date,
        public destination?: string,
        public destinationTime?:Date ) { }
}