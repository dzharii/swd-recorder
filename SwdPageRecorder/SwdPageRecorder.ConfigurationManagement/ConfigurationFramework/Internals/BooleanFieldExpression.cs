using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NLog;
using Newtonsoft.Json;

namespace SwdPageRecorder.ConfigurationManagement.ConfigurationFramework.Internals
{
     public class BooleanFieldExpression
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool HasMatches(string applyValue, JObject jObj)
        {
            if (applyValue == null) return false;
            if (jObj == null)       return false;

            logger.Debug($"Evaluating expression {applyValue}");
            string[] paramValuePair = applyValue.Split(':');

            if (paramValuePair.Length != 2)
            {
                string msg = $"Unexpected expression result. paramValue.Length != 2 (param, value)\n"
                           + $"Context:\n"
                           + $"Expression: <{applyValue}>\n"
                           + $"jObj: <{jObj.ToString(Formatting.Indented)}>";
                logger.Warn(msg);
            }

            var parameter = paramValuePair[0];
            var expectedValue = paramValuePair[1];

            JProperty property = jObj.Property(parameter);

            if (property != null)
            {
                string propValue = property.Value.ToString().ToLower().Trim();
                expectedValue = expectedValue.ToLower().Trim();
                bool result = (propValue == expectedValue);
                return result;
            }
            return false;
        }
    }
}
