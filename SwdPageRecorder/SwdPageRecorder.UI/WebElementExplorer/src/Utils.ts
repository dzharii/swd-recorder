/// <reference path="_reference.ts" />
module WebElementExplorer {

    export function say (something : any) : void {
        if (typeof console !== "undefined" && console !== null) {
            return console.log(something);
        }
    }

    export function logError(something: any): void {
        if (typeof console !== "undefined" && console !== null) {
            return console.error(something);
        }
    }

    export function dbg (something : any) : void {
        if (typeof console !== "undefined" && console !== null) {
            return console.log("DBG:" + something);
        }
    }

    export function hello (something : any) : void {
        return dbg("(begin): " + something);
    }

    export function bye (something : any) : void {
        return dbg("(end): " + something);
    }

    export function pseudoGuid() : string {
        var result : string;
        hello("pseudoGuid");
        function pseudoPart(mode : boolean) : string {
            var p = (Math.random().toString(16) + "000000000").substr(2, 8);
            return mode ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
        }
        result = pseudoPart(false) + pseudoPart(true) + pseudoPart(true) + pseudoPart(false);
        bye("pseudoGuid");
        return result;
    }


 }
