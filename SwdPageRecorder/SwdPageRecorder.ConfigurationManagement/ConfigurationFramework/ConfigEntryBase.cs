using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.ConfigurationFramework
{
    public abstract class ConfigEntryBase
    {
        public virtual string Name { get; set; }
        public virtual string[] ApplyTo { get; set; }
    }
}
