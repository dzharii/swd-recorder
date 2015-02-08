/// <reference path="_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    QUnit.module("MainViewTemplate");
    QUnit.module("MainViewTemplate");
    test("Can find an element inside Dom by Id", function (assert) {
        WebElementExplorer.Helper.withTempElement("div", function (expectedDiv) {
            expectedDiv.id = "tryToFindMe";
            var actualElement = WebElementExplorer.findOneById(expectedDiv.id);
            assert.strictEqual(actualElement, expectedDiv);
        });
    });
})(WebElementExplorer || (WebElementExplorer = {}));
