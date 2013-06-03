(function () {
    // =================== XPATH 

    function getPathTo(element) {
        if (element.id !== '')
            return 'id("' + element.id + '")';
        if (element === document.body)
            return element.tagName;

        var ix = 0;
        var siblings = element.parentNode.childNodes;
        for (var i = 0; i < siblings.length; i++) {
            var sibling = siblings[i];
            if (sibling === element)
                return getPathTo(element.parentNode) + '/' + element.tagName + '[' + (ix + 1) + ']';
            if (sibling.nodeType === 1 && sibling.tagName === element.tagName)
                ix++;
        }
    }

    function getPageXY(element) {
        var x = 0, y = 0;
        while (element) {
            x += element.offsetLeft;
            y += element.offsetTop;
            element = element.offsetParent;
        }
        return [x, y];
    }


    // ==========================


    function addStyle(str) {
        var el = document.createElement('style');
        if (el.styleSheet) el.styleSheet.cssText = str;
        else {
            el.appendChild(document.createTextNode(str));
        }
        return document.getElementsByTagName('head')[0].appendChild(el);
    }

    addStyle(".highlight { background-color:yellow }");
    //===================================================================

    var prev;

    if (document.body.addEventListener) {
        document.body.addEventListener('mouseover', handler, false);
        document.addEventListener("mousedown", function (event) {
            if (event.ctrlKey && event.button == 0) {
                // =====================

                if (event === undefined) event = window.event;                     // IE hack
                var target = 'target' in event ? event.target : event.srcElement; // another IE hack

                var root = document.compatMode === 'CSS1Compat' ? document.documentElement : document.body;
                var mxy = [event.clientX + root.scrollLeft, event.clientY + root.scrollTop];

                var path = getPathTo(target);
                var txy = getPageXY(target);
                // alert('Clicked element '+path+' offset '+(mxy[0]-txy[0])+', '+(mxy[1]-txy[1]));

                // xpath = 'Clicked element '+path+' offset '+(mxy[0]-txy[0])+', '+(mxy[1]-txy[1]);

                var body = document.getElementsByTagName('body')[0];
                var xpath = path;

                body.setAttribute("xpath", xpath);
                return false;

            }
        });
    }
    else if (document.body.attachEvent) {
        document.body.attachEvent('mouseover', function (e) {
            return handler(e || window.event);
        });
    }
    else {
        document.body.onmouseover = handler;
    }

    function handler(event) {
        if (event.target === document.body ||
            (prev && prev === event.target)) {
            return;
        }
        if (prev) {
            prev.className = prev.className.replace(/\bhighlight\b/, '');
            prev = undefined;
        }
        if (event.target) {
            prev = event.target;
            prev.className += " highlight";
        }
    }

})();


