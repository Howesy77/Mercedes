using System.Collections.Generic;

namespace ChannelProcessingSystem.Functions
{
    public class FunctionsFactory
    {
        public IList<IFunction> GetFunctions(string channelType)
        {
            if (channelType == "F1")
            {
                return new List<IFunction>
                {
                    new Function1(),
                    new Function3(),
                    new Function2(),
                    new Function4()
                };
            }

            return null;
        }
    }
}
