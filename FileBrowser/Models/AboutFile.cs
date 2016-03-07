using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FileBrowser.Models
{
    /// <summary>
    /// Represents file information.
    /// </summary>
    public class AboutFile
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "modificationDate")]
        public string ModificationDate { get; set; }

        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }
    }
}