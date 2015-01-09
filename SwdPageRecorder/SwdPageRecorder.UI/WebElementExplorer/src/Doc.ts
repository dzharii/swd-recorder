/// <reference path="_reference.ts" />
module WebElementExplorer {


    export function findOneById(id : string): HTMLElement {
        return document.getElementById(id);
    }

    export function findManyByName(name: string): NodeList {
        return document.getElementsByName(name);
    }

    export function getTagName(element: HTMLElement): string {
        return element.tagName.toLowerCase();
    }

    export function canFindById(element: HTMLElement): boolean {
        var result: string = null;
        if (!(element && element.id)) return false;

        var elementExists = findOneById(element.id) === element;
        return elementExists;
    }

    export function canFindByName(element: HTMLElement): boolean {
        var result: string = null;

        if (!(element && element["name"])) return false;

        var listOfElements = document.getElementsByName(element["name"]);

        var elementExists = listOfElements.length === 1
                            && listOfElements[0] == element;
            

        return elementExists;
    }

    export function buldFullXPath(element: HTMLElement): string {

        var elementTagName = getTagName(element);
        if (element === document.body) {
            return "/html/" + elementTagName;
        }
        
        // XPath count starts from 1
        var xpathOrder = 1; 
        var siblings = element.parentNode.childNodes;

        var ELEMENT_NODE_TYPE: number = 1;

        for (var i = 0, siblingsCount = siblings.length; i < siblingsCount; i++) {
            var sibling = siblings[i];
            if (sibling.nodeType !== ELEMENT_NODE_TYPE) {
                continue;
            }
            if (sibling === element) {


                return ""
                    + (getXPath(<HTMLElement>element.parentNode))
                    + "/"
                    + elementTagName
                    + "["
                    + (xpathOrder)
                    + "]";
            }
            var siblingTagName = getTagName(<HTMLElement>sibling);

            var hasSameTagAsCurrentElement = sibling.nodeType === ELEMENT_NODE_TYPE
                                             && siblingTagName === elementTagName;

            if (hasSameTagAsCurrentElement) {
                xpathOrder++;
            }
        }
    }
    

    export function getXPath(element: HTMLElement): string {
        hello("getXPath");
        var result: string = "";

        var elementTagName : string = getTagName(element);

        var findResult: string = "";

        if (canFindById(element)) {
            result = "id(\"" + element.id + "\")";
        } else if (canFindByName(element) ) {
            result = "//" + elementTagName + "[@name='" + element["name"] + "']";
        }
        else {
            result = buldFullXPath(element);

        }
        bye("getXPath");
        return result;
    }

    export function getElementCoordiantes(element) {
        hello("getPageXY");
        var x = 0, y = 0;
        while (element) {
            x += element.offsetLeft;
            y += element.offsetTop;
            element = element.offsetParent;
        }
        bye("getPageXY");
        return [x, y];
    };
}
