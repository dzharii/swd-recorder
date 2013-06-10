using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwdPageRecorder.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SwdPageRecorder.Console
{
    class Program
    {

        public class TravelNode
        {
            public string NodeName { get; set; }
            public int NodeIndex { get; set; }
        }
        
        private static List<TravelNode>  GetTreeTravelDataFromXPath(string xpath)
        {
            var result = new List<TravelNode>();
            var selectors = xpath.Split('/').Skip(1);
            foreach (var selector in selectors)
            {
                                
                Match match = Regex.Match(selector, @"^(\w+)(?:\[(\d+)\])?", RegexOptions.IgnoreCase);
                var nodeName = match.Groups[1].Value;
                
                var nodelIndexString =  match.Groups[2].Value;
                nodelIndexString = String.IsNullOrWhiteSpace(nodelIndexString) ? "1" : nodelIndexString;

                var nodeIndex = Convert.ToInt32(nodelIndexString);
                nodeIndex--;

                result.Add(new TravelNode() { NodeName = nodeName, NodeIndex = nodeIndex });
            }

            return result;
        }
        
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SwdMainView());


            GetTreeTravelDataFromXPath("/html/body/div[3]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/form[1]/table[1]/tbody[1]/tr[1]/td[1]/span[1]/span[1]/div[1]/input[1]");
            //GetTreeTravelDataFromXPath("/html/body/div[3]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/form[1]/table[1]/tbody[1]/tr[1]/td[1]/span[1]/span[1]/div[1]/input[1]");

        }
    }
}
