using System;
using VV.DataStructure.LinkedList;
using NUnit.Framework;
using IEnumerable = System.Collections.Generic.IEnumerable<object[]>;


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
        public void CanCreateNode(int value, int expectedResult)
        {
            //Arrange

            //Act
            LinkedListNode<int> node = new(value);

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
        public void IsEquals(LinkedListNode<int> node, object item, bool expectedResult)
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
        public void CanCompare(LinkedListNode<int> node, LinkedListNode<int> item, int expectedResult)
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
        public void TestOverrideEqualityOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        public void TestOverrideInequalityOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        public void TestOverrideLessThanOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        public void TestOverrideGreaterThanOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        public void TestOverrideLessThanOrEqualThenOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        public void TestOverrideGreaterThanOrEqualThenOperator(LinkedListNode<int> node1, LinkedListNode<int> node2, bool expectedResult)
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
        }

        private static IEnumerable IsEquals_Data()
        {
            yield return new object[] { new LinkedListNode<int>(2), new LinkedListNode<int>(2), true };
            yield return new object[] { new LinkedListNode<int>(0), new LinkedListNode<int>(-8), false };
            yield return new object[] { new LinkedListNode<int>(5), new LinkedListNode<int>(15), false };
        }

        private static IEnumerable CanCompare_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(2), 1 };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), -1 };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), 0 };
        }

        private static IEnumerable TestOverrideEqualityOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), false };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(23), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), true };
        }

        private static IEnumerable TestOverrideInequalityOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), false };
        }

        private static IEnumerable TestOverrideLessThanOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(15), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(30), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(7), false };
        }

        private static IEnumerable TestOverrideGreaterThanOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(70), false };
        }

        private static IEnumerable TestOverrideLessThanOrEqualThenOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(11), false };
        }

        private static IEnumerable TestOverrideGreaterThanOrEqualThenOperator_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(8), new LinkedListNode<int>(51), false };
        }
    }
}
