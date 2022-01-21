using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Data
{
    public class FileChannelReader : IChannelReader
    {
        private readonly string _channelFileName;
        private readonly string _parameterFileName;

        public FileChannelReader(string channelFileName, string parameterFileName)
        {
            _channelFileName = channelFileName;
            _parameterFileName = parameterFileName;
        }

        public IList<Input> ReadChannel()
        {
            var lines = System.IO.File.ReadAllLines(_channelFileName);
            return lines.Select(ParseChannelLine).ToList();
        }

        public IList<Scalar> ReadParameters()
        {
            var lines = System.IO.File.ReadAllLines(_parameterFileName);
            return lines.Select(ParseParameterLine).ToList();
        }

        private Input ParseChannelLine(string line)
        {
            var data = line.Split(',');
            var input  = new Input();

            input.Identifier = data[0];
            input.Data = data.Skip(1).Select(float.Parse).ToList();

            return input;
        }

        private Scalar ParseParameterLine(string line)
        {
            var data = line.Split(',');
            var parameter = new Scalar();

            parameter.Identifier = data[0];
            parameter.Value = float.Parse(data[1]);

            return parameter;
        }
    }
}
