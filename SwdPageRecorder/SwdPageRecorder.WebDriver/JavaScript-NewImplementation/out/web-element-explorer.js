(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);throw new Error("Cannot find module '"+o+"'")}var f=n[o]={exports:{}};t[o][0].call(f.exports,function(e){var n=t[o][1][e];return s(n?n:e)},f,f.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
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
},{"./lib.logger.js":2}],2:[function(require,module,exports){
function say (something) {
    if (console) {
        console.log(something);
    }
};

function error(something) {
    say("ERROR:" + something);
};


function dbg(something) {
    say("DBG:" + something);
};

hello = function(something) {
    dbg("(begin): " + something);
};

bye = function(something) {
    dbg("(end): " + something);
};

module.exports.say   = say;
module.exports.error   = error;
module.exports.dbg   = dbg;
module.exports.hello = hello;
module.exports.bye   = bye;
},{}],3:[function(require,module,exports){
var domutils = require("./lib.dom.utils.js");

domutils.addEvent("click", function(){ alert("Hello!"); })
},{"./lib.dom.utils.js":1}]},{},[3])