using System.Collections.Generic;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Data
{
    public interface IChannelWriter
    {
        void WriteChannel(IList<Input> inputs);
        void WriteParameters(IList<Scalar> parameters);
    }
}
