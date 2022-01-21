using System;
using System.Collections.Generic;
using System.Linq;
using ChannelProcessingSystem.Functions;
using ChannelProcessingSystem.Models;
using NUnit.Framework;

namespace ChannelProcessingSystem.UnitTests.Functions
{
    public class Tests
    {
        private IFunction _function;

        [SetUp]
        public void Setup()
        {
            _function = new Function1();
        }

        [TestCaseSource("TestCases")]
        public void Given_Data_IsValid_Valid_Results_Are_Returned(List<Input> inputs, List<Scalar> parameters, List<float> expected)
        {
            var result = _function.Process(parameters, inputs);

            Assert.IsNull(result.Item1);
            Assert.AreEqual(1, result.Item2.Count);
            Assert.AreEqual("Y", result.Item2.First().Identifier);
            CollectionAssert.AreEqual(expected, result.Item2.First().Data);
        }

        [TestCase]
        public void Given_Parameters_Are_Missing_Then_Exception_Is_Throw()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => _function.Process(new List<Scalar>(), new List<Input>
            {
                new Input
                {
                    Identifier = "X",
                    Data = new List<float> {3.76F, 6.87F, 5.43F}
                }
            }));

            Assert.That(ex.Message, Is.EqualTo("Sequence contains no matching element"));
        }

        private static readonly object[] TestCases =
        {
            new object[]
            {
                new List<Input>
                {
                    new Input
                    {
                        Identifier = "X",
                        Data = new List<float> {3.76F, 6.87F, 5.43F}
                    }
                },
                new List<Scalar>
                {
                    new Scalar
                    {
                        Identifier = "m",
                        Value = 2.5F
                    },
                    new Scalar
                    {
                        Identifier = "c",
                        Value = 1.25F
                    }
                },
                new List<float> { 10.6499996f, 18.4249992f, 14.8249998f }
            }
        };
    }
}