/// <reference path="../_test_references.ts" />

module WebElementExplorer {
    describe("Doc", () => {
        describe("findOneById", () => {
            it("Can find an element inside Dom by Id", () => {
                Helper.withTempElement("div", (expectedDiv) => {

                    expectedDiv.id = "tryToFindMe";
                    var actualElement = findOneById(expectedDiv.id);
                    expect(actualElement).toBe(expectedDiv);

                });
            });
          });

            // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .

            describe("findManyByName", () => {
                it("Can find an element inside Dom by Name", () => {
                    Helper.withTempElement("input", (expectedInput) => {
                        var name = "tryToFindMeByName";
                        expectedInput.setAttribute("name", name);
                        var actualElements = findManyByName(name);
                        expect(actualElements.length).toBe(1);
                        expect(actualElements[0]).toBe(expectedInput);
                    });
                });

                it("Should return an empty array when no element any element found", () => {
                    var name = "This Element does not exist";
                    var actualElements = findManyByName(name);
                    expect(actualElements.length).toBe(0);
                });
            // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .

        })
    })
}
