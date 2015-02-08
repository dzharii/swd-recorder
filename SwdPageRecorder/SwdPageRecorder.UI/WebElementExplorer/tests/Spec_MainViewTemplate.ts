/// <reference path="_test_references.ts" />

module WebElementExplorer {

    QUnit.module("MainViewTemplate");
    QUnit.module("MainViewTemplate.convertObjectToCssStyle");

    test("smoke - can convert object to CSS",(assert) => {
        var subject = new MainViewTemplate();
        var sample = {
            "border": "1px solid black",
            "margin-bottom": "0px ",
            "font-variant": "normal !important",
        }


        var expected = "border: 1px solid black; margin-bottom: 0px; font-variant: normal !important"
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });

    test("returns empty string when object is empty",(assert) => {
        var subject = new MainViewTemplate();
        var sample = {};

        var expected = ""
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });

    test("returns empty string when object is null",(assert) => {
        var subject = new MainViewTemplate();
        var sample = null;

        var expected = ""
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });

    test("returns empty string when object is undefined",(assert) => {
        var subject = new MainViewTemplate();
        var sample = void 0;

        var expected = ""
        var actual = subject.convertObjectToCssStyle(sample);
        assert.strictEqual(actual, expected);
    });


}