/// <reference path="_test_references.ts" />
var WebElementExplorer;
(function (WebElementExplorer) {
    QUnit.module("MainViewTemplate");
    QUnit.module("MainViewTemplate.convertObjectToCssStyle");
    test("smoke - can convert object to CSS", function (assert) {
        var subject = new WebElementExplorer.MainViewTemplate();
        var sample = {
            "border": "1px solid black",
            "margin-bottom": "0px ",
            "font-variant": "normal !important",
        };
        var expected = "border: 1px solid black; margin-bottom: 0px; font-variant: normal !important";
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });
    test("returns empty string when object is empty", function (assert) {
        var subject = new WebElementExplorer.MainViewTemplate();
        var sample = {};
        var expected = "";
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });
    test("returns empty string when object is null", function (assert) {
        var subject = new WebElementExplorer.MainViewTemplate();
        var sample = null;
        var expected = "";
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });
    test("returns empty string when object is undefined", function (assert) {
        var subject = new WebElementExplorer.MainViewTemplate();
        var sample = void 0;
        var expected = "";
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });
})(WebElementExplorer || (WebElementExplorer = {}));
