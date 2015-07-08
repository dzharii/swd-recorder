using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;
using SwdPageRecorder.UI.CodeGeneration;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public class TemplateViewModel
    {
        public SwdPageObject PageObject { get; set; }
    }

    public class CSharpPageObjectGenerator
    {
        public string[] Generate(SwdPageObject pageObject, string fullTemplatePath)
        {
            var template = File.ReadAllText(fullTemplatePath);

            object model = new TemplateViewModel() { PageObject = pageObject };

            string result = "not parsed";
            try
            {
            	#pragma warning disable 618
                result = Razor.Parse(template, model);
                #pragma warning restore 618
            }
            catch
            {
                throw;
            }
            return Utils.SplitSingleLineToMultyLine(result);
        }
    }
}
