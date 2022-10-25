using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet
{
    public class SplitWiseClientOptions
    {
        public string Version { get; set; } = "v3.0";
        public string ApiKey { get; set; }
        public string ClientSecret { get; set; }
        public string ConsumerKey { get; set; }
    }
}
