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
