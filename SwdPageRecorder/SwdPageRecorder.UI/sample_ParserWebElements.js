function readAllFile(filename)
{
    var fso = new ActiveXObject ("Scripting.FileSystemObject");
    var fileStream = fso.openTextFile (filename);
    var fileData = fileStream.readAll();
    fileStream.Close();
    return fileData;
}

function includeFile (filename) 
{
      var fileData = readAllFile(filename);
      eval(fileData);
}

includeFile("sample_ParserWebElements.lib.json2.js");
var pageObjectJson = readAllFile("WebElementDefinitions.json");

var pageObject = JSON.parse(pageObjectJson);

WScript.Echo("Page: " + pageObject.PageObjectName    + "\n");
WScript.Echo("================================\n");

var webElements = pageObject.Items;

for (var i = 0; i < webElements.length; i++)
{
    var element = webElements[i];
    WScript.Echo("    Element: " + element.Name    + "\n");
    WScript.Echo("    Locator: " + element.Locator + "\n");
    WScript.Echo("    ~ ~ ~ ~ ~\n");
}