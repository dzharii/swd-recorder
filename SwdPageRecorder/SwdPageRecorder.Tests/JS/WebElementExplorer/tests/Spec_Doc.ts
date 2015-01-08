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

            assert.equal(actualElements.length, 1, "There is only one element in the list");
            assert.equal(actualElements[0], expectedInput, "And that element equals to the expected");
        });

    });

    test("Should return an empty array when no any elements found", (assert) => {
        Helper.withTempElement("input", (expectedInput) => {
            var name = "This Element does not exist";
            var actualElements = findManyByName(name);

            assert.equal(actualElements.length, 0);
        });
    });

    QUnit.module("Doc.getTagName");
    test("Should return the tag name always in lowercase ;)", (assert) => {
        Helper.withTempElement("INPUT", (expectedInput) => {
            expectedInput.id = "findmeFindMe";
            var actualElement = findOneById("findmeFindMe");

            assert.equal(getTagName(actualElement), "input");
        });
    });

    QUnit.module("Doc.canFindById");
    test("Returns true if the passed element can be found by Id", (assert) => {
        Helper.withTempElement("INPUT", (otherElement) => {
            otherElement.id = "otherId";
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.id = "youCanFindMeById";
                var actualResult = canFindById(expectedInput);

                assert.equal(actualResult, true);
            });
        })
    });

    test("Returns false in tricky case, when two elements has same Id", (assert) => {
        Helper.withTempElement("INPUT", (otherElement) => {
            otherElement.id = "youCanFindMeById";
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.id = "youCanFindMeById";
                var actualResult = canFindById(expectedInput);

                assert.equal(actualResult, false);
            });
        })
    });

    QUnit.module("Doc.canFindByName");
    test("returns true if there is a and element with Unique name inside DOM", (assert) => {
        Helper.withTempElement("INPUT", (otherElement) => {
            otherElement.setAttribute("name", "otherName");
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("name", "uniqueName");
                var actualResult = canFindByName(expectedInput);

                assert.equal(actualResult, true);
            });
        });
    });

    test("returns false when the element has no name", (assert) => {
        Helper.withTempElement("INPUT", (otherElement) => {
            otherElement.setAttribute("name", "otherName");
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("title", "uniqueName");
                var actualResult = canFindByName(expectedInput);

                assert.equal(actualResult, false);
            });
        });
    });

    test("returns false when there is another element with the same name", (assert) => {
        Helper.withTempElement("INPUT", (otherElement) => {
            otherElement.setAttribute("name", "otherName");
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("name", "otherName");
                var actualResult = canFindByName(expectedInput);

                assert.equal(actualResult, false);
            });
        });
    });

    QUnit.module("Doc.buldFullXPath");
    test("Build a valid full XPath for the newly created element", (assert) => {
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("name", "someElement");
                var actualXPath = buldFullXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[1]");
            });
    });

    test("Build a valid full XPath with index 2 for repeated input element", (assert) => {
        Helper.withTempElement("INPUT", (expectedInput) => {
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("name", "someElement");
                var actualXPath = buldFullXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[2]");
            });
        });
    });

    QUnit.module("Doc.getPageXY");
    test("next", (assert) => {
        assert.equal(true, false);
    });


}