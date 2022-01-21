using System;
using System.Collections.Generic;
using ChannelProcessingSystem.Data;
using ChannelProcessingSystem.Functions;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Application
{
    public class Channel : IChannel
    {
        private readonly FunctionsFactory _functionsFactory;
        private readonly IChannelWriter _writer;
        private readonly IChannelReader _reader;

        public Channel(
            FunctionsFactory functionsFactory,
            IChannelReader reader,
            IChannelWriter writer)
        {
            _functionsFactory = functionsFactory;
            _reader = reader;
            _writer = writer;
        }

        public void Process()
        {
            var inputs = new List<Input>();
            var parameters = new List<Scalar>();

            var functions = _functionsFactory.GetFunctions("F1");

            inputs.AddRange(_reader.ReadChannel());
            parameters.AddRange(_reader.ReadParameters());

            foreach (var function in functions)
            {
                var (scalar, input) = function.Process(parameters, inputs);

                if(scalar != null) parameters.AddRange(scalar);
                if(input != null) inputs.AddRange(input);
            }

            _writer.WriteChannel(inputs);
            _writer.WriteParameters(parameters);
        }
    }
}
