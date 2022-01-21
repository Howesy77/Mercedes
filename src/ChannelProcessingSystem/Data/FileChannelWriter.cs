using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Data
{
    public class FileChannelWriter : IChannelWriter
    {
        private readonly string _channelFileName;
        private readonly string _parameterFileName;

        public FileChannelWriter(string channelFileName, string parameterFileName)
        {
            _channelFileName = channelFileName;
            _parameterFileName = parameterFileName;
        }

        public void WriteChannel(IList<Input> inputs)
        {
            System.IO.File.WriteAllLines(_channelFileName, inputs.Select(i => i.ToString()));
        }

        public void WriteParameters(IList<Scalar> parameters)
        {
            System.IO.File.WriteAllLines(_parameterFileName, parameters.Select(p => p.ToString()));
        }
    }
}