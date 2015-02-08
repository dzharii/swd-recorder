/// <reference path="../_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    var Helper;
    (function (Helper) {
        function withTempElement(elementType, elementAddedCallback) {
            var newElement = document.createElement(elementType);
            document.body.appendChild(newElement);
            try {
                elementAddedCallback(newElement);
            }
            catch (e) {
                document.body.removeChild(newElement);
                throw e;
            }
            document.body.removeChild(newElement);
        }
        Helper.withTempElement = withTempElement;
    })(Helper = WebElementExplorer.Helper || (WebElementExplorer.Helper = {}));
})(WebElementExplorer || (WebElementExplorer = {}));
//# sourceMappingURL=Helper.js.map