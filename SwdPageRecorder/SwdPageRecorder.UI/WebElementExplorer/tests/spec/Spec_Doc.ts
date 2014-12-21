/// <reference path="../_test_references.ts" />

module WebElementExplorer {
    describe("Doc", () => {
        describe("findOneById", () => {
            it("can find an element inside Dom by Id", () => {

                var expectedDiv = document.createElement("div");
                expectedDiv.id = "tryToFindMe";
                document.body.appendChild(expectedDiv);

                var actualElement = findOneById(expectedDiv.id);
                expect(actualElement).toBe(expectedDiv);

                document.body.removeChild(expectedDiv);
            })
        })

    })


}
