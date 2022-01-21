using System.Collections.Generic;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Data
{
    public interface IChannelReader
    {
        IList<Input> ReadChannel();
        IList<Scalar> ReadParameters();
    }
}
