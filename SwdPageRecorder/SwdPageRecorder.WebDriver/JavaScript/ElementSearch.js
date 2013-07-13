(function () {
    // =================== XPATH 

    // Migrated
    function pseudoGuid() {
        var result = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx';
        result = result.replace(/[xy]/g, function(c) 
                 {
                     var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
                     return v.toString(16);
                 });

        return result;
    }

    // Migrated
    function getPathTo(element) {
        if (element.id !== '')
            return 'id("' + element.id + '")';
        if (element === document.body)
            return '/html/' + element.tagName.toLowerCase();

        var ix = 0;
        var siblings = element.parentNode.childNodes;
        for (var i = 0; i < siblings.length; i++) {
            var sibling = siblings[i];
            if (sibling === element)
                return getPathTo(element.parentNode) + '/' + element.tagName.toLowerCase() + '[' + (ix + 1) + ']';
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

    // ====== SHOW DIV Coords==============

    function showPos(event, xpath) {
        
        var el, x, y;

        el = document.getElementById('SwdPR_PopUp');
        
        if (window.event) {
            x = window.event.clientX + document.documentElement.scrollLeft + document.body.scrollLeft;
            y = window.event.clientY + document.documentElement.scrollTop + document.body.scrollTop;
        }
        else {
            x = event.clientX + window.scrollX;
            y = event.clientY + window.scrollY;
        }
        x -= 2; y -= 2;
        y = y+15;

        el.style.background = "white";
        el.style.position = "absolute";
        el.style.left = x + "px";
        el.style.top = y + "px";
        el.style.display = "block";
        el.style.border = "3px solid black";
        el.style.padding = "5px 5px 5px 5px";
        el.style.zIndex = 2147483647;

        
        
        
        document.getElementById("SwdPR_PopUp_XPathLocator").innerHTML = xpath;
        document.getElementById("SwdPR_PopUp_ElementText").innerHTML = pseudoGuid();
        document.getElementById("SwdPR_PopUp_CodeIDText").value = '';

        
        

        console.log(x + ";" + y);
    }

    // ================= ADD button
    function addButton(container) {
        //Create an input type dynamically.   
        var element = document.createElement("input");
        //Assign different attributes to the element. 
        element.type = 'button';
        element.value = 'Click Me'; 
        element.name = '';  
        element.onclick = function() { // Note this is a function
            alert("blabla");
        };

        container.appendChild(element);
    }

    // Migrated
    function createElementForm() {
        //Create an input type dynamically.   
        var element = document.createElement("div");
        //Assign different attributes to the element. 
        element.id = 'SwdPR_PopUp';
        document.getElementsByTagName('body')[0].appendChild(element);

        var closeClickHandler = "document.getElementById('SwdPR_PopUp').style.display = 'none';";
        element.innerHTML = 
        ' <table id="SWDTable">' +
        '   <tr>' +
        '     <td>Code identifier</td>' +
        '     <td><div id="SwdPR_PopUp_Element_Name"><span id="SwdPR_PopUp_CodeID"><input type="text" id="SwdPR_PopUp_CodeIDText"></span><span id="SwdPR_PopUp_CodeClose"></span><span id="SwdPR_PopUp_CloseButton" onclick="' + closeClickHandler + '">X</span></div></td>' +
        '   </tr>' +
        '   <tr>' +
        '     <td>Element</td>' +
        '     <td><span id="SwdPR_PopUp_ElementName">Element</span></td>' +
        '   </tr>' +
        '   <tr>' +
        '     <td>Text:</td>' +
        '     <td><span id="SwdPR_PopUp_ElementText">Element</span></td>' +
        '   </tr>' +
        '   <tr>' +
        '     <td>XPathLocator</td>' +
        '     <td><span id="SwdPR_PopUp_XPathLocator">Element</span></td>' +
        '   </tr>' +
        '   </table>' + 
        '<input type="button" value="Add element" onclick="window.Swd_addElement()">' + 
        '' + 
        '' + 
        '' + 
        ''; 

    }

    window.Swd_addElement = function addElement() {
        var JsonData = {
            "Command": "AddElement",
            "Caller": "addElement",
            "CommandId": pseudoGuid(),

            "ElementCodeName" : document.getElementById("SwdPR_PopUp_CodeIDText").value,
            "ElementXPath"    : document.getElementById("SwdPR_PopUp_XPathLocator").firstChild.nodeValue,

        };

        var myJSONText = JSON.stringify(JsonData, null, 2);

        // TODO: Reduce this copy-paste
        var body = document.getElementsByTagName('body')[0];
        body.setAttribute("swdpr_command", myJSONText);        

    };


    //===========================


    function addStyle(str) {
        var el = document.createElement('style');
        if (el.styleSheet) el.styleSheet.cssText = str;
        else {
            el.appendChild(document.createTextNode(str));
        }
        return document.getElementsByTagName('head')[0].appendChild(el);
    }

    function preventEvent(event)
    {
        if (event.preventDefault) event.preventDefault();
        event.returnValue = false;

        //IE9 & Other Browsers
        if (event.stopPropagation) {
            event.stopPropagation();
        }
            //IE8 and Lower
        else {
            event.cancelBubble = true;
        }

        return false;
    }


    // ========== MAIN !!!!!! ============================
    addStyle(".highlight { background-color:silver !important}");
    addStyle("table#SWDTable { background-color:white; border-collapse:collapse;} table#SWDTable,table#SWDTable th, table#SWDTable td { font-family: Verdana, Arial; font-size: 10pt; padding-left:10pt; padding-right:10pt; border-bottom: 1px solid black; }");
    addStyle("input#SwdPR_PopUp_CodeIDText { display:table-cell; width:95%;}");

      
    addStyle("span#SwdPR_PopUp_CloseButton {  display:table-cell; width:10px; border: 2px solid #c2c2c2; padding: 1px 5px; top: -20px; background-color: #980000; border-radius: 20px; font-size: 15px; font-weight: bold; color: white;text-decoration: none; cursor:pointer; }");
    addStyle("div#SwdPR_PopUp { display:none; } div#SwdPR_PopUp_Element_Name { display:table; width: 100%; } ");
    



    createElementForm();
    //===================================================================

    var prev;

    if (document.body.addEventListener) {
        document.body.addEventListener('mouseover', handler, false);
        document.addEventListener('contextmenu', rightClickHandler, false);
    }
    else if (document.body.attachEvent) {
        document.body.attachEvent('mouseover', function (e) {
            return handler(e || window.event);
        });
        document.body.attachEvent('oncontextmenu', function (e) {
            return rightClickHandler(e || window.event);
        });
    }
    else {
        document.body.onmouseover = handler;
        document.body.onmouseover = rightClickHandler;
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
        if (event.target && event.ctrlKey) {
            prev = event.target;
            prev.className += " highlight";
        }
    }

    // =========================
    function rightClickHandler(event) { // Ctrl + Right button
         if (event.ctrlKey) {
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

             var JsonData = {
                 "Command": "GetXPathFromElement",
                 "Caller": "EventListener : mousedown",
                 "CommandId": pseudoGuid(),
                 "XPathValue" : xpath,

             };

             var myJSONText = JSON.stringify(JsonData, null, 2);

             body.setAttribute("swdpr_command", myJSONText);

             // !!! Add button

             // addButton(event.target);

             showPos(event, xpath);

             return preventEvent(event);
         }
     }


    // ====================


})();


