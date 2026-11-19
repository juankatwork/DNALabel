using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DNALabelSync
{
    public class BCSerialTracker
    {
        [JsonPropertyName("SerialNo")]
        public string SerialNo { get; set; }

        [JsonPropertyName("ProductionDate")]
        public string ProductionDate { get; set; }

        [JsonPropertyName("Location")]
        public string Location { get; set; }

        [JsonPropertyName("AssemblyLineNo")]
        public string AssemblyLineNo { get; set; }

        [JsonPropertyName("ItemModelNo")]
        public string ItemModelNo { get; set; }

        [JsonPropertyName("EngineSerialNo")]
        public string EngineSerialNo { get; set; }

    }
}
