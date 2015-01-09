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

    QUnit.module("Doc.getTagName");
    test("Should return the tag name always in lowercase ;)", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            expectedInput.id = "findmeFindMe";
            var actualElement = WebElementExplorer.findOneById("findmeFindMe");

            assert.equal(WebElementExplorer.getTagName(actualElement), "input");
        });
    });

    QUnit.module("Doc.canFindById");
    test("Returns true if the passed element can be found by Id", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherElement) {
            otherElement.id = "otherId";
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.id = "youCanFindMeById";
                var actualResult = WebElementExplorer.canFindById(expectedInput);

                assert.equal(actualResult, true);
            });
        });
    });

    test("Returns false in tricky case, when two elements has same Id", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherElement) {
            otherElement.id = "youCanFindMeById";
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.id = "youCanFindMeById";
                var actualResult = WebElementExplorer.canFindById(expectedInput);

                assert.equal(actualResult, false);
            });
        });
    });

    QUnit.module("Doc.canFindByName");
    test("returns true if there is a and element with Unique name inside DOM", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherElement) {
            otherElement.setAttribute("name", "otherName");
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.setAttribute("name", "uniqueName");
                var actualResult = WebElementExplorer.canFindByName(expectedInput);

                assert.equal(actualResult, true);
            });
        });
    });

    test("returns false when the element has no name", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherElement) {
            otherElement.setAttribute("name", "otherName");
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.setAttribute("title", "uniqueName");
                var actualResult = WebElementExplorer.canFindByName(expectedInput);

                assert.equal(actualResult, false);
            });
        });
    });

    test("returns false when there is another element with the same name", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (otherElement) {
            otherElement.setAttribute("name", "otherName");
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.setAttribute("name", "otherName");
                var actualResult = WebElementExplorer.canFindByName(expectedInput);

                assert.equal(actualResult, false);
            });
        });
    });

    QUnit.module("Doc.buldFullXPath");
    test("Build a valid full XPath for the newly created element", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            expectedInput.setAttribute("name", "someElement");
            var actualXPath = WebElementExplorer.buldFullXPath(expectedInput);
            assert.equal(actualXPath, "/html/body/input[1]");
        });
    });

    test("Build a valid full XPath with index 2 for repeated input element", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
                expectedInput.setAttribute("name", "someElement");
                var actualXPath = WebElementExplorer.buldFullXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[2]");
            });
        });
    });

    QUnit.module("Doc.getPageXY");
    test("that the element coordinates should be match to expected or at least greater than expected", function (assert) {
        WebElementExplorer.Helper.withTempElement("INPUT", function (expectedInput) {
            expectedInput.setAttribute("name", "someElement");
            var X = 0;
            var Y = 1;

            var expectedCoords = [8, 226];
            var actualCoords = WebElementExplorer.getElementCoordiantes(expectedInput);

            assert.equal(actualCoords[X], expectedCoords[X]);
            assert.ok(actualCoords[Y] >= expectedCoords[Y]);
        });
    });
})(WebElementExplorer || (WebElementExplorer = {}));
//# sourceMappingURL=Spec_Doc.js.map
