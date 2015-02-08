/// <reference path="_test_references.ts" />

module WebElementExplorer {


    QUnit.module("Doc.getXPath");
    test("for the elements without ID or Name, returns full XPath", (assert) => {
            Helper.withTempElement("INPUT", (expectedInput) => {
                var actualXPath = getXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[1]");
            });
    });

    test("for the elements with ID, returns id-optimized XPath", (assert) => {
        Helper.withTempElement("INPUT", (expectedInput) => {
            expectedInput.id = "HeyIHaveId"
            var actualXPath = getXPath(expectedInput);
            assert.equal(actualXPath, "id(\"HeyIHaveId\")");
        });
    });

    test("for the elements with name, returns name-optimized XPath", (assert) => {
        Helper.withTempElement("INPUT", (expectedInput) => {
            expectedInput.setAttribute("name", "HeyIHaveName")
            var actualXPath = getXPath(expectedInput);
            assert.equal(actualXPath, "//input[@name='HeyIHaveName']");
        });
    });

    test("for the elements with not unique names, returns full XPath", (assert) => {
        Helper.withTempElement("INPUT", (otherInput) => {
            otherInput.setAttribute("name", "HeyIHaveName")
            Helper.withTempElement("INPUT", (expectedInput) => {
                expectedInput.setAttribute("name", "HeyIHaveName")
                var actualXPath = getXPath(expectedInput);
                assert.equal(actualXPath, "/html/body/input[2]");
            });
        });
    });


}