var WebElementExplorer;
(function (WebElementExplorer) {
    var SwdPageRecorder = (function () {
        function SwdPageRecorder() {
        }
        return SwdPageRecorder;
    })();
})(WebElementExplorer || (WebElementExplorer = {}));

/// <reference path="_reference.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    function findOneById(id) {
        return document.getElementById(id);
    }
    WebElementExplorer.findOneById = findOneById;
    function findManyByName(name) {
        return document.getElementsByName(name);
    }
    WebElementExplorer.findManyByName = findManyByName;
    function getTagName(element) {
        return element.tagName.toLowerCase();
    }
    WebElementExplorer.getTagName = getTagName;
    function canFindById(element) {
        var result = null;
        if (!(element && element.id))
            return false;
        var elementExists = findOneById(element.id) === element;
        return elementExists;
    }
    WebElementExplorer.canFindById = canFindById;
    function canFindByName(element) {
        var result = null;
        if (!(element && element["name"]))
            return false;
        var listOfElements = document.getElementsByName(element["name"]);
        var elementExists = listOfElements.length === 1 && listOfElements[0] == element;
        return elementExists;
    }
    WebElementExplorer.canFindByName = canFindByName;
    function buldFullXPath(element) {
        var elementTagName = getTagName(element);
        if (element === document.body) {
            return "/html/" + elementTagName;
        }
        // XPath count starts from 1
        var xpathOrder = 1;
        var siblings = element.parentNode.childNodes;
        var ELEMENT_NODE_TYPE = 1;
        for (var i = 0, siblingsCount = siblings.length; i < siblingsCount; i++) {
            var sibling = siblings[i];
            if (sibling.nodeType !== ELEMENT_NODE_TYPE) {
                continue;
            }
            if (sibling === element) {
                return "" + (getXPath(element.parentNode)) + "/" + elementTagName + "[" + (xpathOrder) + "]";
            }
            var siblingTagName = getTagName(sibling);
            var hasSameTagAsCurrentElement = sibling.nodeType === ELEMENT_NODE_TYPE && siblingTagName === elementTagName;
            if (hasSameTagAsCurrentElement) {
                xpathOrder++;
            }
        }
    }
    WebElementExplorer.buldFullXPath = buldFullXPath;
    function getXPath(element) {
        WebElementExplorer.hello("getXPath");
        var result = "";
        var elementTagName = getTagName(element);
        var findResult = "";
        if (canFindById(element)) {
            result = "id(\"" + element.id + "\")";
        }
        else if (canFindByName(element)) {
            result = "//" + elementTagName + "[@name='" + element["name"] + "']";
        }
        else {
            result = buldFullXPath(element);
        }
        WebElementExplorer.bye("getXPath");
        return result;
    }
    WebElementExplorer.getXPath = getXPath;
    function getElementCoordiantes(element) {
        WebElementExplorer.hello("getPageXY");
        var x = 0, y = 0;
        while (element) {
            x += element.offsetLeft;
            y += element.offsetTop;
            element = element.offsetParent;
        }
        WebElementExplorer.bye("getPageXY");
        return [x, y];
    }
    WebElementExplorer.getElementCoordiantes = getElementCoordiantes;
    ;
})(WebElementExplorer || (WebElementExplorer = {}));

var WebElementExplorer;
(function (WebElementExplorer) {
    var MainPresenter = (function () {
        function MainPresenter() {
        }
        return MainPresenter;
    })();
    WebElementExplorer.MainPresenter = MainPresenter;
})(WebElementExplorer || (WebElementExplorer = {}));

var WebElementExplorer;
(function (WebElementExplorer) {
    var MainView = (function () {
        function MainView() {
        }
        return MainView;
    })();
    WebElementExplorer.MainView = MainView;
})(WebElementExplorer || (WebElementExplorer = {}));

var WebElementExplorer;
(function (WebElementExplorer) {
    var CSS = (function () {
        function CSS() {
        }
        CSS.DEFAULT_BOX = "DEFAULT_BOX";
        CSS.WINDOW_CONTAINER = "WINDOW_CONTAINER";
        CSS.TOP_DRAGGING_AREA = "TOP_DRAGGING_AREA";
        return CSS;
    })();
    var MainViewTemplate = (function () {
        function MainViewTemplate() {
            this.TEMPLATE_CONTAINER_HTML_ID = "swdPageRecorder_WebElementExplorer";
        }
        MainViewTemplate.prototype.convertObjectToCssStyle = function (jsObject) {
            if (!jsObject)
                return "";
            var propNames = Object.getOwnPropertyNames(jsObject);
            if (propNames.length < 1)
                return "";
            var result = "";
            for (var i = 0; i < propNames.length; i++) {
                var prefixSemicolon = (i === 0) ? "" : "; ";
                var cssKey = propNames[i].trim();
                var cssValue = jsObject[cssKey].trim();
                result += "" + prefixSemicolon + cssKey + ": " + cssValue;
            }
            return result;
        };
        MainViewTemplate.prototype.getStyle = function (key) {
            var styles = {};
            styles[CSS.DEFAULT_BOX] = {
                "width": "auto",
                "height": "auto",
                "margin": "0",
                "padding": "0",
                "border": "0",
                "outline": "0",
                "vertical-align": "baseline",
                "background": "0 0",
                "text-align": "left !important",
                "line-height": "normal",
                "border-radius": "0",
                "font-variant": "normal !important",
                "font-weight": "normal",
                "cursor": "default",
                "font-family": "Segoe UI, Helvetica, sans-serif !important",
                "letter-spacing": "normal !important",
                "clear": "none",
                "box-sizing": "content-box",
            };
            styles[CSS.WINDOW_CONTAINER] = {
                "z-index": "2147483647",
                "box-shadow": "0 3px 11px",
                "overflow": "hidden",
            };
            styles[CSS.TOP_DRAGGING_AREA] = {
                "cursor": "move",
                "background-color": "#D01345",
                "background": "linear-gradient(to bottom,#A61E2D 0,#D01345 100%)",
                "width": "auto",
                "height": "auto",
                "min-height": "20pt",
            };
            if (!styles[key]) {
                WebElementExplorer.logError(new Error("MainViewTemplate: style " + key + " is not defined"));
            }
            return this.convertObjectToCssStyle(styles[key]);
        };
        MainViewTemplate.prototype.render = function () {
            //================= HTML ===================================
            //==========================================================
            var htmlTemplate = ("\n<div style=\"" + this.getStyle(CSS.DEFAULT_BOX) + "\">\n    <div data-role=\"container\" style=\"" + this.getStyle(CSS.WINDOW_CONTAINER) + "\">\n        <div style=\"" + this.getStyle(CSS.TOP_DRAGGING_AREA) + "\"> \n                 Header\n        </div>\n        <div>\n        Hello World 4!\n        </div>\n    </div>\n</div>\n").trim().replace(/^\s+|\s+$/gm, "");
            //==========================================================
            this.showForm(htmlTemplate);
        };
        MainViewTemplate.prototype.showForm = function (html) {
            if (!document || !document.body)
                return;
            var containerDiv = document.getElementById(this.TEMPLATE_CONTAINER_HTML_ID);
            if (!containerDiv) {
                containerDiv = document.createElement("div");
                containerDiv.id = this.TEMPLATE_CONTAINER_HTML_ID;
            }
            containerDiv.innerHTML = html;
            document.body.appendChild(containerDiv);
        };
        return MainViewTemplate;
    })();
    WebElementExplorer.MainViewTemplate = MainViewTemplate;
})(WebElementExplorer || (WebElementExplorer = {}));

/// <reference path="_reference.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    function say(something) {
        if (typeof console !== "undefined" && console !== null) {
            return console.log(something);
        }
    }
    WebElementExplorer.say = say;
    function logError(something) {
        if (typeof console !== "undefined" && console !== null) {
            return console.error(something);
        }
    }
    WebElementExplorer.logError = logError;
    function dbg(something) {
        if (typeof console !== "undefined" && console !== null) {
            return console.log("DBG:" + something);
        }
    }
    WebElementExplorer.dbg = dbg;
    function hello(something) {
        return dbg("(begin): " + something);
    }
    WebElementExplorer.hello = hello;
    function bye(something) {
        return dbg("(end): " + something);
    }
    WebElementExplorer.bye = bye;
    function pseudoGuid() {
        var result;
        hello("pseudoGuid");
        function pseudoPart(mode) {
            var p = (Math.random().toString(16) + "000000000").substr(2, 8);
            return mode ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
        }
        result = pseudoPart(false) + pseudoPart(true) + pseudoPart(true) + pseudoPart(false);
        bye("pseudoGuid");
        return result;
    }
    WebElementExplorer.pseudoGuid = pseudoGuid;
})(WebElementExplorer || (WebElementExplorer = {}));

/// <reference path="utils.ts" />
/// <reference path="app.ts" />
/// <reference path="doc.ts" />
/// <reference path="mainpresenter.ts" />
/// <reference path="mainview.ts" />
/// <reference path="mainviewtemplate.ts" />
