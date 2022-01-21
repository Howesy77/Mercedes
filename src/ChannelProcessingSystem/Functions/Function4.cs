using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Functions
{
    public class Function4 : IFunction
    {
        public Tuple<IList<Scalar>, IList<Input>> Process(IList<Scalar> parameters, IList<Input> inputs)
        {
            try
            {
                var b = parameters.Single(s => s.Identifier.Equals("b")).Value;

                var result = inputs
                    .Single(i => i.Identifier.Equals("X"))
                    .Data
                    .Select(x => x + b)
                    .ToList();

                return new Tuple<IList<Scalar>, IList<Input>>(null, new List<Input>
                {
                    new Input
                    {
                        Identifier = "C",
                        Data = result
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
