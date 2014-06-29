using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RazorEngine;
using SwdPageRecorder.UI.CodeGeneration;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public class CSharpPageObjectGenerator
    {
        internal string[] Generate(SwdPageObject pageObject, string fullTemplatePath)
        {
            var template = File.ReadAllText(fullTemplatePath);
            
            object model = new {
                                        PageObject = pageObject,
                                        ExternalGenerator = new ExternalGenerator(),
                                    };

            string result = "not parsed";
            try
            {
                result = Razor.Parse(template, model);
            }
            catch
            {
                throw;
            }
            return Utils.SplitSingleLineToMultyLine(result);
        }
    }
}
