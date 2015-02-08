var WebElementExplorer;
(function (WebElementExplorer) {
    var CSS = (function () {
        function CSS() {
        }
        CSS.DEFAULT_BOX = "defaultBox";
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
            styles[CSS.DEFAULT_BOX] = {};
            if (!styles[key]) {
                WebElementExplorer.logError(new Error("MainViewTemplate: style " + key + " is not defined"));
            }
            return this.convertObjectToCssStyle(styles[key]);
        };
        MainViewTemplate.prototype.render = function () {
            //================= HTML ===================================
            //==========================================================
            var htmlTemplate = ("\n<div style=\"" + this.getStyle(CSS.DEFAULT_BOX) + "\">\n    Hello World 4!\n</div>\n").trim();
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
