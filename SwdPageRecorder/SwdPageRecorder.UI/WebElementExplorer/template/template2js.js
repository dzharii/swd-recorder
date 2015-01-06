function compileTemplate(template) {
    var indent = "   ";
    var variables = {};
    var result = template.trim().replace(/\r*\n/g,"\"\n " + indent + "+ \"" );
    
    var result = result.replace(/\{\{(.+)\}\}/g, function(match, p1, offset, string) {
        variables[p1] = variables[p1] || true;
        return "\" + " +  p1 +  " + \"";
    });

    var templateVars = Object.keys(variables).map(function(name) {
        name = name.trim();
        return  name + " = (typeof data." + name + " === \"undefined\" || data." + name + " === null) ? \"\" : data." + name;
    }).join(",\n" + indent);

    templateVars = "var " + templateVars + ";\n";

    result = "(function(data) {\n"
             + indent + templateVars
             + indent + "var compiled  = \"" + result + "\";\n"
             + indent + "return compiled\n"
             + "})(data);\n";

    return result;
}


var inputTemplateName = process.argv[2];
var outputFile = process.argv[3];

var fs = require("fs");
var templateContent = fs.readFileSync(inputTemplateName, "utf8");

console.dir(templateContent);

var data = compileTemplate(templateContent);

fs.writeFileSync(outputFile, data);

console.log("Done");


