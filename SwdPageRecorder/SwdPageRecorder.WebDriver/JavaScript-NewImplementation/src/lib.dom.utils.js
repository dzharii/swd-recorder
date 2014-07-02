var mylog = require("./lib.logger.js")

function addEvent(evnt, elem, func) {
    mylog.hello("addEvent");
    
    if (elem.addEventListener) { // W3C implemetation
       elem.addEventListener(evnt,func,false);
    }
    else if (elem.attachEvent) { // IE DOM
       elem.attachEvent("on"+evnt, func);
    }
    else { 
        mylog.error("addEvent: Cannot attach event listener for: " + evnt);
    }

    mylog.bye("addEvent");
}

module.exports.addEvent = addEvent;