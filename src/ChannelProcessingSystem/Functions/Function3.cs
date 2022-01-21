using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Functions
{
    public class Function3 : IFunction
    {
        public Tuple<IList<Scalar>, IList<Input>> Process(IList<Scalar> parameters, IList<Input> inputs)
        {
            try
            {
                var result = inputs
                    .Single(i => i.Identifier.Equals("X"))
                    .Data
                    .Select(x => 1 / x)
                    .ToList();

                return new Tuple<IList<Scalar>, IList<Input>>(null, new List<Input>
                {
                    new Input
                    {
                        Identifier = "A",
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
