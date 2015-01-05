using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.WebDriver
{
    public class BrowserPageFrame
    {
        public string GetTitle()
        {

            string title = "";

            if (ParentFrame == null)
            {
                title = "DefaultContent";
            }
            else
            {
                List<string> frameTitles = new List<string>();
                var frame = this; 
                while (frame.ParentFrame != null)
                {
                    string frameTitle = !String.IsNullOrEmpty(frame.LocatorNameOrId)
                                        ? frame.LocatorNameOrId
                                        : frame.Index.ToString();
                    frameTitles.Add(frameTitle);
                    frame = frame.ParentFrame;
                }
                
                frameTitles.Reverse();

                title = String.Join(".", frameTitles);
            }

            return title;

        }

        public override string ToString()
        {
            return GetTitle();
        }

        public int      Index { get; set; }
        public string   LocatorNameOrId { get; set; }

        public BrowserPageFrame ParentFrame { get; set; }
        public List<BrowserPageFrame> ChildFrames { get; set; }


        public int[] GetPath()
        {
            List<int> path = new List<int>();
            BrowserPageFrame currentFrame = this;
            
            while (currentFrame != null)
            {
                path.Add(currentFrame.Index);
                currentFrame = currentFrame.ParentFrame;
            }
            path.Reverse();
            return path.ToArray();
        }
        
        public List<BrowserPageFrame> ToList()
        {
            List<BrowserPageFrame> result = new List<BrowserPageFrame>();
            result.Add(this);

            foreach (var child in ChildFrames)
            {
                result.AddRange(child.ToList());
            }

            return result;
        }


    }
}
