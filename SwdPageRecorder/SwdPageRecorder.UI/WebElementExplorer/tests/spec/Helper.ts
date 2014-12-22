/// <reference path="../_test_references.ts" />

module WebElementExplorer {
    export module Helper {

        export function withTempElement(elementType: string, elementAddedCallback: (addedElement: HTMLElement) => void) {
            var newElement = document.createElement(elementType);
            document.body.appendChild(newElement);
            try {
                elementAddedCallback(newElement);
            }
            catch (e) {
                document.body.removeChild(newElement);
                throw e;
            }

            document.body.removeChild(newElement);

        }
    }
}


