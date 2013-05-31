function addStyle(str){
    var el= document.createElement('style');
    if(el.styleSheet) el.styleSheet.cssText= str;
    else{
        el.appendChild(document.createTextNode(str));
    }
    return document.getElementsByTagName('head')[0].appendChild(el);
}


addStyle(".highlight { border: 2px solid red }");


(function() {
  var prev;

  if (document.body.addEventListener) {
    document.body.addEventListener('mouseover', handler, false);
    document.addEventListener("mousedown",function(event) {
        if( event.ctrlKey || event.button == 2 ) {
            alert("Xpath");
        }
    });
  }
  else if (document.body.attachEvent) {
    document.body.attachEvent('mouseover', function(e) {
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