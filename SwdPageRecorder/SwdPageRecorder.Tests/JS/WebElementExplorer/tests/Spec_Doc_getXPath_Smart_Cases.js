/// <reference path="../_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    QUnit.module("Doc.getXPath");
    test("for the elements without ID or Name, returns full XPath", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            var actualXPath = WebElementExplorer.getXPath(expectedInput);
            assert.equal(actualXPath, "/html/body/input[1]");
        });
    });

    test("for the elements with ID, returns id-optimized XPath", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            expectedInput.id = "HeyIHaveId";
            var actualXPath = WebElementExplorer.getXPath(expectedInput);
            assert.equal(actualXPath, "id(\"HeyIHaveId\")");
        });
    });

    test("for the elements with name, returns name-optimized XPath", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            expectedInput.setAttribute("name", "HeyIHaveName");
            var actualXPath = WebElementExplorer.getXPath(expectedInput);
            assert.equal(actualXPath, "//input[@name='HeyIHaveName']");
        });
    });

    test("for the elements with not unique names, returns full XPath", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherInput) {
            otherInput.setAttribute("name", "HeyIHaveName");
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.setAttribute("name", "HeyIHaveName");
                var actualXPath = WebElementExplorer.getXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[2]");
            });
        });
    });
})(WebElementExplorer || (WebElementExplorer = {}));
//# sourceMappingURL=Spec_Doc_getXPath_Smart_Cases.js.map
