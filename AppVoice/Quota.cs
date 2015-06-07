using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Quota
    {
        [JsonProperty(PropertyName = "quota")]
        public long Total { get; internal set; }

        [JsonProperty(PropertyName = "shared")]
        public long Shared { get; internal set; }

        [JsonProperty(PropertyName = "normal")]
        public long Normal { get; internal set; }
    }
}