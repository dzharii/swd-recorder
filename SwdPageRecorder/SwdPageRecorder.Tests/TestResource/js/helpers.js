
// simulatedClick(document.getElementById('yourButtonId')) 
// http://stackoverflow.com/a/6158160/1126595
function simulatedClick(target, options) {

            var event = target.ownerDocument.createEvent('MouseEvents'),
                options = options || {};

            //Set your default options to the right of ||
            var opts = {
                type: options.type                  || 'click',
                canBubble:options.canBubble             || true,
                cancelable:options.cancelable           || true,
                view:options.view                       || target.ownerDocument.defaultView, 
                detail:options.detail                   || 1,
                screenX:options.screenX                 || 0, //The coordinates within the entire page
                screenY:options.screenY                 || 0,
                clientX:options.clientX                 || 0, //The coordinates within the viewport
                clientY:options.clientY                 || 0,
                ctrlKey:options.ctrlKey                 || false,
                altKey:options.altKey                   || false,
                shiftKey:options.shiftKey               || false,
                metaKey:options.metaKey                 || false, //I *think* 'meta' is 'Cmd/Apple' on Mac, and 'Windows key' on Win. Not sure, though!
                button:options.button                   || 0, //0 = left, 1 = middle, 2 = right
                relatedTarget:options.relatedTarget     || null,
            }

            //Pass in the options
            event.initMouseEvent(
                opts.type,
                opts.canBubble,
                opts.cancelable,
                opts.view, 
                opts.detail,
                opts.screenX,
                opts.screenY,
                opts.clientX,
                opts.clientY,
                opts.ctrlKey,
                opts.altKey,
                opts.shiftKey,
                opts.metaKey,
                opts.button,
                opts.relatedTarget
            );

            //Fire the event
            target.dispatchEvent(event);
}

function simulate(element, eventName)
{
    var options = extend(defaultOptions, arguments[2] || {});
    var oEvent, eventType = null;

    for (var name in eventMatchers)
    {
        if (eventMatchers[name].test(eventName)) { eventType = name; break; }
    }

    if (!eventType)
        throw new SyntaxError('Only HTMLEvents and MouseEvents interfaces are supported');

    if (document.createEvent)
    {
        oEvent = document.createEvent(eventType);
        if (eventType == 'HTMLEvents')
        {
            oEvent.initEvent(eventName, options.bubbles, options.cancelable);
        }
        else
        {
            oEvent.initMouseEvent(eventName, options.bubbles, options.cancelable, document.defaultView,
            options.button, options.pointerX, options.pointerY, options.pointerX, options.pointerY,
            options.ctrlKey, options.altKey, options.shiftKey, options.metaKey, options.button, element);
        }
        element.dispatchEvent(oEvent);
    }
    else
    {
        options.clientX = options.pointerX;
        options.clientY = options.pointerY;
        var evt = document.createEventObject();
        oEvent = extend(evt, options);
        element.fireEvent('on' + eventName, oEvent);
    }
    return element;
}

function extend(destination, source) {
    for (var property in source)
      destination[property] = source[property];
    return destination;
}

var eventMatchers = {
    'HTMLEvents': /^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,
    'MouseEvents': /^(?:click|dblclick|mouse(?:down|up|over|move|out))$/
}
var defaultOptions = {
    pointerX: 0,
    pointerY: 0,
    button: 0,
    ctrlKey: false,
    altKey: false,
    shiftKey: false,
    metaKey: false,
    bubbles: true,
    cancelable: true
}