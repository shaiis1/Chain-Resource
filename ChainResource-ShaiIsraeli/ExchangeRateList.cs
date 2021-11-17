using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChainResource_ShaiIsraeli
{
    public class ExchangeRateList
    {
        [XmlElementAttribute(Order = 1)]
        [JsonPropertyAttribute("rates")]
        public Dictionary<String, Double> Rates { get; set; }
    }
}
