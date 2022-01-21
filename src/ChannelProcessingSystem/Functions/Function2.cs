using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Models;

namespace ChannelProcessingSystem.Functions
{
    public class Function2 : IFunction
    {
        public Tuple<IList<Scalar>, IList<Input>> Process(IList<Scalar> parameters, IList<Input> inputs)
        {
            try
            {
                var A = inputs.Single(s => s.Identifier.Equals("A")).Data;
                var Y = inputs.Single(s => s.Identifier.Equals("Y")).Data;

                var B = new Input()
                {
                    Identifier = "B",
                    Data = new List<float>()
                };

                for (var i = 0; i < A.Count; ++i)
                {
                    B.Data.Add(A[i] + Y[i]);
                }

                return new Tuple<IList<Scalar>, IList<Input>>
                (
                    new List<Scalar>
                    {
                        new Scalar
                        {
                            Identifier = "b",
                            Value = B.Data.Average()
                        }
                    },
                    new List<Input>
                    {
                        B
                    }
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
