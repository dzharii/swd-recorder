/// <reference path="../_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    (function (Helper) {
        function withTempElement(elementType, elementAddedCallback) {
            var newElement = document.createElement(elementType);
            document.body.appendChild(newElement);
            try  {
                elementAddedCallback(newElement);
            } catch (e) {
                document.body.removeChild(newElement);
                throw e;
            }

            document.body.removeChild(newElement);
        }
        Helper.withTempElement = withTempElement;
    })(WebElementExplorer.Helper || (WebElementExplorer.Helper = {}));
    var Helper = WebElementExplorer.Helper;
})(WebElementExplorer || (WebElementExplorer = {}));
//# sourceMappingURL=Helper.js.map
