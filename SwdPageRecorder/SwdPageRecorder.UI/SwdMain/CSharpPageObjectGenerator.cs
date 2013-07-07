using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RazorEngine;

namespace SwdPageRecorder.UI
{
    public class CSharpPageObjectGenerator
    {
        private List<string> html = new List<string>();

        private int lastTabsIndent = 0;
        private void AddLine(string line, int indent) 
        {
            var tabls = new String('\t', indent);
            html.Add(line);
            lastTabsIndent = indent;
        }

        private void AddLine(string line)
        {
            AddLine(line, lastTabsIndent);
        }

        
        internal string[] Generate(WebElementDefinition[] definitions, string fullTemplatePath)
        {

            var template = File.ReadAllText(fullTemplatePath);
            var result = Razor.Parse(template, 
                new {
                        WebElementDefinitions = definitions,
                
                    });
            
            return Utils.SplitSingleLineToMultyLine(result);

            
            GenerateCodeHeader();

            AddLine("// Web Elements", 1);
            foreach (var element in definitions)
            {
                EmptyLine();
                GenerateElementDefinition(element);
                EmptyLine();
            }
            GenerateCodeFooter();

            return html.ToArray();
        }

        
        private void GenerateElementDefinition(WebElementDefinition element)
        {
            //         [FindsBy(How = How.Name, Using = "wpName Похулиганим")]
            
            string howName = Enum.GetName(typeof(LocatorSearchMethod), element.HowToSearch);
            string how = String.Format("How = How.{0}", howName);
            string usingValue = String.Format(@"Using = ""{0}""", element.Locator);

            string findsByAttribute = String.Format("[FindsBy({0}, {1}]", how, usingValue);
            string propertyName = String.Format("public IWebElement {0} {{get; set;}}", element.Name);

            AddLine(findsByAttribute);
            AddLine(propertyName);

        }

        private void EmptyLine()
        {
            AddLine("");
        }

        private void GenerateCodeFooter()
        {
            AddLine("}");
        }

        private void GenerateCodeHeader()
        {
            AddLine("public class Page");
            AddLine("{");
        }
    }
}
