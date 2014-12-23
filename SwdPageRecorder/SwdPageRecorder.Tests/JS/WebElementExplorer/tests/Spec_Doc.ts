/// <reference path="../_test_references.ts" />

module WebElementExplorer {

    QUnit.module("Doc.findOneById");
    test("Can find an element inside Dom by Id", (assert) => {
        Helper.withTempElement("div", (expectedDiv) => {

            expectedDiv.id = "tryToFindMe";
            var actualElement = findOneById(expectedDiv.id);
            assert.strictEqual(actualElement, expectedDiv)
        });

    });

    QUnit.module("Doc.findManyByName");
    test("Can find an element inside Dom by Name", (assert) => {
        Helper.withTempElement("input", (expectedInput) => {
            var name = "tryToFindMeByName";
            expectedInput.setAttribute("name", name);
            var actualElements = findManyByName(name);

            assert.equal(actualElements.length, 1);
            assert.equal(actualElements[0], expectedInput);
        });

    });

    test("Should return an empty array when no any elements found", (assert) => {
        Helper.withTempElement("input", (expectedInput) => {
            var name = "This Element does not exist";
            var actualElements = findManyByName(name);

            assert.equal(actualElements.length, 0);
        });

    });
}