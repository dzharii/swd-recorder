var WebElementExplorer;
(function (WebElementExplorer) {
    var MainViewTemplate = (function () {
        function MainViewTemplate() {
        }
        MainViewTemplate.prototype.convertObjectToCssStyle = function (jsObject) {
            var result = "";
            return result;
        };
        MainViewTemplate.prototype.style = function (key) {
            return {};
        };
        MainViewTemplate.prototype.render = function () {
            //================= HTML ===================================
            //==========================================================
            var htmlTemplate = "\n<div>\n    \n</div>\n".trim();
            //==========================================================
        };
        return MainViewTemplate;
    })();
    WebElementExplorer.MainViewTemplate = MainViewTemplate;
})(WebElementExplorer || (WebElementExplorer = {}));
