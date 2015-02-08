/// <reference path="_reference.d.ts" />
declare module WebElementExplorer {
    function findOneById(id: string): HTMLElement;
    function findManyByName(name: string): NodeList;
    function getTagName(element: HTMLElement): string;
    function canFindById(element: HTMLElement): boolean;
    function canFindByName(element: HTMLElement): boolean;
    function buldFullXPath(element: HTMLElement): string;
    function getXPath(element: HTMLElement): string;
    function getElementCoordiantes(element: any): number[];
}
