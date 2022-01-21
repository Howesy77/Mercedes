using ChannelProcessingSystem.Functions;
using NUnit.Framework;

namespace ChannelProcessingSystem.UnitTests.Functions
{
    public class FunctionFactoryUnitTests
    {
        private FunctionsFactory _functionsFactory;

        [SetUp]
        public void Setup()
        {
            _functionsFactory = new FunctionsFactory();
        }

        [TestCase]
        public void Given_Valid_ChannelType_Then_Correct_Functions_Are_Returned()
        {
            var result = _functionsFactory.GetFunctions("F1");

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(typeof(Function1), result[0].GetType());
            Assert.AreEqual(typeof(Function3), result[1].GetType());
            Assert.AreEqual(typeof(Function2), result[2].GetType());
            Assert.AreEqual(typeof(Function4), result[3].GetType());
        }
    }
}
