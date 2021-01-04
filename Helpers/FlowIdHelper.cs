using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using LoggingPOC.Enums;

namespace LoggingPOC.Helpers
{
    public class FlowIdHelper
    {
        public static FlowId SetFlowId(string path)
        {
            return path switch
            {
                "/error/exception" => FlowId.GetException,
                "/error/argumentnullexception" => FlowId.GetArgumentNullException,
                _ => FlowId.GetWeather
            };
        }
    }
}
