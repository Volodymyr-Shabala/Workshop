using System;
using DefaultNamespace;
using NUnit.Framework;

// This is a project demonstrating how to improve writing automated tests.
// If you have any question you can write to me at volodymyr.shabala@maginteractive.se
namespace Tests
{
    public class TestScript
    {
        // The old way of writing tests.
        [TestCase(2, 3, ExpectedResult = 5)]
        [TestCase(-1, 1, ExpectedResult = 0)]
        public int AddTwoNumbers(int x, int y)
        {
            int result = x + y;
            return result;
        }

        // Test for class OneInt.cs with Predicate to assert.
        [TestCaseSource(nameof(TestingOneInt))]
        public void TestOneInt(OneInt oneInt, Predicate<OneInt> validator)
        {
            Assert.IsTrue(validator(oneInt));
        }

        // Example of test data with using Predicate to Assert that values we get are values we expect.
        public static TestCaseData[] TestingOneInt()
        {
            TestCaseData[] testCaseData = new TestCaseData[5];
            OneInt[] oneIntValues = OneIntValues();
            Predicate<OneInt> validator = i => i != null;

            for (int i = 0; i < 5; i++)
            {
                testCaseData[i] = new TestCaseData(oneIntValues[i], validator);
            }

            // You can add more data here. For example adding null instead of a class:
            // testCaseData[4] = new TestCaseData(null, validator);
            return testCaseData;
        }

        // Test for class IntAndString.cs
        [TestCaseSource(nameof(TestingIntAndString))]
        public void TestIntAndString(IntAndString cl)
        {
        }

        public static TestCaseData[] TestingIntAndString()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[5];
            for (int i = 0; i < 5; i++)
            {
                testCaseDatas[i] = new TestCaseData(new IntAndString(IntValues[i], StringValues[i]));
            }

            return testCaseDatas;
        }

        // Test for class ClassWithReferenceToOneIntAndOneInt.cs
        [TestCaseSource(nameof(TestingReference))]
        public void TestingCalssWithReference(ClassWithReferenceToOneIntAndOneInt cl)
        {
        }

        public static TestCaseData[] TestingReference()
        {
            TestCaseData[] testCaseDatas = new TestCaseData[5];
            ClassWithReferenceToOneIntAndOneInt[] cls = clas();
            for (int i = 0; i < 5; i++)
            {
                testCaseDatas[i] = new TestCaseData(cls[i]);
            }

            return testCaseDatas;
        }

        // Class with a reference to another other class
        public static ClassWithReferenceToOneIntAndOneInt[] clas()
        {
            ClassWithReferenceToOneIntAndOneInt[] returnValue = new ClassWithReferenceToOneIntAndOneInt[5];
            OneInt[] oneInts = OneIntValues();
            int[] intValues = IntValues;
            for (int i = 0; i < 5; i++)
            {
                returnValue[i] = new ClassWithReferenceToOneIntAndOneInt(oneInts[i], intValues[i]);
            }

            return returnValue;
        }

        // Class with primitive data
        // You can provide arguments to this function. For example
        // You can provide a bool called allowBadData to adjust if this function will return bad data or not.
        // Ideally you should create a generic function that takes in any Collection or a Class and returns 
        // A new array populated with bad values like null and default
        public static OneInt[] OneIntValues()
        {
            OneInt[] oneInts = new OneInt[5];
            for (int i = 0; i < 5; i++)
            {
                oneInts[i] = new OneInt(IntValues[i]);
            }

            return oneInts;
        }
        
        // Primitive type data
        // All of the test are based on this data.
        // To add more, you can create more properties returning different primitive types
        public static readonly int[] IntValues =
        {
            int.MinValue, -2234, 0, 214, int.MaxValue
        };

        public static readonly string[] StringValues =
        {
            string.Empty, default, "  g", "erer", "-1"
        };
    }
}