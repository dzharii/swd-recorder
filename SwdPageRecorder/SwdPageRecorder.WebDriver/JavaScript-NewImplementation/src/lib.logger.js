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