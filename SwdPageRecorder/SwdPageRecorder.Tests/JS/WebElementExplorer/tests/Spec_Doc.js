/// <reference path="../_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    QUnit.module("Doc.findOneById");
    test("Can find an element inside Dom by Id", function (assert) {
        WebElementExplorer.Helper.withTempElement("div", function (expectedDiv) {
            expectedDiv.id = "tryToFindMe";
            var actualElement = WebElementExplorer.findOneById(expectedDiv.id);
            assert.strictEqual(actualElement, expectedDiv);
        });
    });

    QUnit.module("Doc.findManyByName");
    test("Can find an element inside Dom by Name", function (assert) {
        WebElementExplorer.Helper.withTempElement("input", function (expectedInput) {
            var name = "tryToFindMeByName";
            expectedInput.setAttribute("name", name);
            var actualElements = WebElementExplorer.findManyByName(name);

            assert.equal(actualElements.length, 1, "There is only one element in the list");
            assert.equal(actualElements[0], expectedInput, "And that element equals to the expected");
        });
    });

    test("Should return an empty array when no any elements found", function (assert) {
        WebElementExplorer.Helper.withTempElement("input", function (expectedInput) {
            var name = "This Element does not exist";
            var actualElements = WebElementExplorer.findManyByName(name);

            assert.equal(actualElements.length, 0);
        });
    });
})(WebElementExplorer || (WebElementExplorer = {}));
//# sourceMappingURL=Spec_Doc.js.map
