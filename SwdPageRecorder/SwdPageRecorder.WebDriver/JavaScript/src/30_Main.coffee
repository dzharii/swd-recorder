############################## MAIN ############################################


addStyle ".highlight { background-color:silver !important}"
addStyle "table#SWDTable { 
            background-color:white; 
            border-collapse:collapse;
           } 
           
           table#SWDTable,table#SWDTable th, table#SWDTable td  { 
            font-family: Verdana, Arial; 
            font-size: 10pt; 
            padding-left:10pt; 
            padding-right:10pt; 
            border-bottom: 1px solid black; 
           }"

addStyle "input#SwdPR_PopUp_CodeIDText { 
            display:table-cell; 
            width:95%;
          }"



addStyle "span#SwdPR_PopUp_CloseButton {  
            display:table-cell;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            -o-border-radius: 4px;
            border-radius: 4px;
            border: 1px solid #ccc;
            color: white;
            background-color: #980000;
            cursor: pointer;
            font-size: 10pt;
            padding: 0px 2px;
            font-weight: bold;
            position: absolute;
            right: 3px;
            top: 8px;
          }"

###
addStyle "span#SwdPR_PopUp_CloseButton {  
            display:table-cell; 
            width:10px; 
            border: 2px solid #c2c2c2; 
            padding: 1px 5px; 
            top: -20px; 
            background-color: #980000; 
            border-radius: 20px; 
            font-size: 15px; 
            font-weight: bold; 
            color: white;text-decoration: none; cursor:pointer; 
          }"
###
addStyle "div#SwdPR_PopUp { 
            display:none; 
          } 
          div#SwdPR_PopUp_Element_Name { 
            display:table; 
            width: 100%; 
          }"


### 
    Important!
    It wont work if the document has no body, such as top frameset pages. 
###

if document.body?

    if document.body.addEventListener
        document.body.addEventListener 'mouseover',   handler,           false
        document.addEventListener      'contextmenu', rightClickHandler, false

    else if document.body.attachEvent
        document.body.attachEvent 'mouseover',     (e) -> handler(e || window.event)
        document.body.attachEvent 'oncontextmenu', (e) -> rightClickHandler(e || window.event)

    else
        document.body.onmouseover = handler
        document.body.onmouseover = rightClickHandler


    document.SWD_Page_Recorder = new SWD_Page_Recorder()
    document.SWD_Page_Recorder.createElementForm()
else
    say "Document has no body tag... Injecting empty SWD"
    document.SWD_Page_Recorder = "STUB. Document has no body tag :("
