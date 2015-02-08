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
