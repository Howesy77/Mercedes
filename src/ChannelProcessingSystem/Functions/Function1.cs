using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Functions
{
    public class Function1 : IFunction
    {
        public Tuple<IList<Scalar>, IList<Input>> Process(IList<Scalar> parameters, IList<Input> inputs)
        {
            try
            {
                var m = parameters.Single(s => s.Identifier.Equals("m")).Value;
                var c = parameters.Single(s => s.Identifier.Equals("c")).Value;

                var result = inputs
                    .Single(i => i.Identifier.Equals("X"))
                    .Data
                    .Select(x => (x * m) + c)
                    .ToList();

                return new Tuple<IList<Scalar>, IList<Input>>(null, new List<Input>
                {
                    new Input
                    {
                        Identifier = "Y",
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
