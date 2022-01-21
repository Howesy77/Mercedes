using System;
using System.Collections.Generic;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Functions
{
    public interface IFunction
    {
        Tuple<IList<Scalar>, IList<Input>> Process(IList<Scalar> parameters, IList<Input> inputs);
    }
}
