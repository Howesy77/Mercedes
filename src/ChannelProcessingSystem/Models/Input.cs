using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ChannelProcessingSystem.Models
{
    public class Input
    {
        public string Identifier { get; set; }
        public List<float> Data { get; set; }

        public override string ToString()
        {
            return $"{Identifier},{string.Join(",", Data.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray())}";
        }
    }
}
