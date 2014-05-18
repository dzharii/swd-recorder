# TODO: Description 
say = (something) -> console.log something if console?

dbg = (something) -> console.log "DBG:" + something if console?

hello = (something) -> dbg "(begin): " + something
bye   = (something) -> dbg "(end): " + something

# TODO: Description 
pseudoGuid = () ->
    hello "pseudoGuid"

    result = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'
    result = result.replace /[xy]/g, (re_match) ->
                        random_value = Math.random() * 16 | 0
                        replacement = if re_match is 'x' then  random_value else random_value & 0x3 | 0x8
                        return replacement.toString(16)

    bye "pseudoGuid"
    return result

# TODO: Description 
getInputElementsByTypeAndValue = (inputType, inputValue) ->
    hello "getInputElementsByTypeAndValue"
    allDocumentInputElements = document.getElementsByTagName('input')

    result = new Array();

    for inputElement in allDocumentInputElements
        if inputElement.type is inputType and inputElement.value is inputValue
            result.push inputElement

    bye "getInputElementsByTypeAndValue"
    return result;

# TODO: Description 
getPathTo = (element) ->
    hello "getPathTo"
    elementTagName = element.tagName.toLowerCase()

    # Check if node has ID and this ID is unique over the document
    if element.id and document.getElementById(element.id) is element
        return "id(\"#{element.id}\")"

    # Check element name
    else if element.name and document.getElementsByName(element.name).length is 1
        return "//#{elementTagName}[@name='#{element.name}']"
    

    if element is document.body
        return "/html/#{elementTagName}"

    ix = 0
    siblings = element.parentNode.childNodes

    ELEMENT_NODE_TYPE = 1

    for sibling in siblings
        
        continue if sibling.nodeType isnt ELEMENT_NODE_TYPE

        if sibling is element
            return "#{getPathTo(element.parentNode)}/#{elementTagName}[#{ix + 1}]"
        
        siblingTagName = sibling.tagName.toLowerCase()
        elementTagName = element.tagName.toLowerCase()

        ix++ if sibling.nodeType is 1 and siblingTagName is elementTagName
    bye "getPathTo"
# TODO: Description 
getPageXY = (element) ->
    hello "getPageXY"
    x = 0
    y = 0;
    while element
        x += element.offsetLeft
        y += element.offsetTop
        element = element.offsetParent
    bye "getPageXY"
    return [x, y]

# TODO: Description
createCommand = (jsonData) ->
    hello "createCommand"
    myJSONText = JSON.stringify(jsonData, null, 2)
    document.swdpr_command = myJSONText
    bye "createCommand"    

# TODO: Description
addStyle = (css) ->
    hello "addStyle"    

    head = document.getElementsByTagName('head')[0]
    style = document.createElement('style')

    style.type = 'text/css'
    if style.styleSheet
        style.styleSheet.cssText = css
    else 
      style.appendChild(document.createTextNode(css))


    head.appendChild(style);
    bye "addStyle"

# TODO: Description
preventEvent = (event) -> 
    hello "preventEvent"    
    event.preventDefault() if (event.preventDefault) 
    event.returnValue = false

    # IE9 & Other Browsers
    if event.stopPropagation
        event.stopPropagation()
    
    # IE8 and Lower
    else
        event.cancelBubble = true
    bye "preventEvent"    
    return false

# Globals
prev = undefined
document.Swd_prevActiveElement = undefined

# TODO: Description
handler = (event) ->
   hello "handler"       
   return unless document.SWD_Page_Recorder?
   return if event.target is document.body or prev is event.target

   if prev
       prev.className = prev.className.replace(/\s?\bhighlight\b/, '')
       prev = undefined

   if event.target and event.ctrlKey
       prev = event.target
       prev.className += " highlight"
   bye "handler"       

# Ctrl + Right button
rightClickHandler = (event) -> 
    hello "rightClickHandler"
    return unless document.SWD_Page_Recorder?

    if event.ctrlKey
        event = window.event unless event?  #IE hack
        target = if 'target' of event then event.target else event.srcElement # another IE hack

        root = if document.compatMode is 'CSS1Compat' then document.documentElement else document.body
        mxy  = [event.clientX + root.scrollLeft, event.clientY + root.scrollTop]

        path = getPathTo(target)
        txy  = getPageXY(target)

        body = document.getElementsByTagName('body')[0]
        xpath = path

        JsonData = 
            "Command":   "GetXPathFromElement"
            "Caller":    "EventListener : mousedown"
            "CommandId":  pseudoGuid()
            "XPathValue": xpath

        createCommand(JsonData)

        document.SWD_Page_Recorder.showPos(event, xpath)

        eventPreventingResult = preventEvent(event)
        bye "rightClickHandler"
        return eventPreventingResult