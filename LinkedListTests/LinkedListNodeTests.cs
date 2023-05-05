using System;
using VV.DataStructure.LinkedList;
using NUnit.Framework;
using System.Collections;


namespace LinkedListTests
{
    /// <summary>
    /// Class that contains testing methods for LinkedList functionality.
    /// </summary>
    [TestFixture]
    public class NodeTests
    {
        /// <summary>
        /// Test for creating the Node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(CanCreateNode_Data))]
        [Test]
        public void CanCreateNode<T>(T value, T expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            LinkedListNode<T> node = new(value);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(node.Value));
        }

        /// <summary>
        /// Test for Equals(obj) override method.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(IsEquals_Data))]
        [Test]
        public void IsEquals<T>(LinkedListNode<T> node, object item, bool expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node.Equals(item);            

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for CompareTo(LinkedListNode) method.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(CanCompare_Data))]
        [Test]
        public void CanCompare<T>(LinkedListNode<T> node, LinkedListNode<T> item, int expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            int result = node.CompareTo(item);
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override equality opertor.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideEqualityOperator_Data))]
        [Test]
        public void TestOverrideEqualityOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 == node2;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override inequality opertor.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideInequalityOperator_Data))]
        [Test]
        public void TestOverrideInequalityOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 != node2;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override less than operator.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideLessThanOperator_Data))]
        [Test]
        public void TestOverrideLessThanOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 < node2;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override greater than operator.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideGreaterThanOperator_Data))]
        [Test]
        public void TestOverrideGreaterThanOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 > node2;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override less than or equals operator.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideLessThanOrEqualThenOperator_Data))]
        [Test]
        public void TestOverrideLessThanOrEqualThenOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 <= node2;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override greater than or equals operator.
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(TestOverrideGreaterThanOrEqualThenOperator_Data))]
        [Test]
        public void TestOverrideGreaterThanOrEqualThenOperator<T>(LinkedListNode<T> node1, LinkedListNode<T> node2, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = node1 >= node2;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        private static IEnumerable CanCreateNode_Data()
        {
            yield return new object[] { 7, 7 };
            yield return new object[] { 0, 0 };
            yield return new object[] { -5, -5 };
            yield return new object[] { "gty", "gty" };
        }

        private static IEnumerable IsEquals_Data()
        {
            yield return new object[] { new LinkedListNode<int>(2), new LinkedListNode<int>(2), true };
            yield return new object[] { new LinkedListNode<int>(0), new LinkedListNode<int>(-8), false };
            yield return new object[] { new LinkedListNode<int>(5), new LinkedListNode<int>(15), false };
            yield return new object[] { new LinkedListNode<string>("boom"), new LinkedListNode<string>("boom"), true };
        }

        private static IEnumerable CanCompare_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(2), 1 };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), -1 };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), 0 };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), 0 };
            yield return new object[] { new LinkedListNode<string>("boom"), new LinkedListNode<string>("boo"), 1 };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("hboo"), -1 };
        }

        private static IEnumerable TestOverrideEqualityOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), false };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(23), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

        private static IEnumerable TestOverrideInequalityOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), true };
        }

        private static IEnumerable TestOverrideLessThanOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(15), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(30), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(7), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("nboo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

        private static IEnumerable TestOverrideGreaterThanOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(70), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("jboo"), false };
        }

        private static IEnumerable TestOverrideLessThanOrEqualThenOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(11), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

        private static IEnumerable TestOverrideGreaterThanOrEqualThenOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(8), new LinkedListNode<int>(51), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("nboo"), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("lboo"), false };
        }
    }
}
