using System;
using VV.DataStructure.LinkedList;
using NUnit.Framework;
using System.Collections;

namespace LinkedListTests;

namespace LinkedListTests
{
    /// <summary>
    /// Class that contains testing methods for LinkedList functionality.
    /// </summary>
    [TestFixture]
internal class NodeTests
    {
        /// <summary>
        /// Test for creating the Node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(Contructor_CreateNode_ReturnsNewNode_Data))]
        [Test]
    public void Contructor_CreateNode_ReturnsNewNode<T>(T value, T expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            LinkedListNode<T> node = new(value);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(node.Value));
        }

        /// <summary>
    /// Test for LinkedListNode Next.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(NodeNext_ReturnsTheNextNode_Data))]
    [Test]
    public void NodeNext_ReturnsTheNextNode<T>(LinkedList<T> list, T expectedResult)
        where T : IComparable<T>
    {
        //Arrange

        //Act
        LinkedListNode<T> node = list.HeadForTest();
        LinkedListNode<T>? nodeNext = node.Next;
        var result = nodeNext!.Value;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(result));
    }

    /// <summary>
        /// Test for Equals(obj) override method.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideEquals_ObjectWithNodeByValue_ReturnsTrueIfEqual_Data))]
        [Test]
    public void OverrideEquals_ObjectWithNodeByValue_ReturnsTrueIfEqual<T>(LinkedListNode<T> node, object item, bool expectedResult)
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
    /// <param name="other"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideCompareTo_TwoNodes_ReturnsCorrectly_Data))]
        [Test]
    public void OverrideCompareTo_TwoNodes_ReturnsCorrectly<T>(LinkedListNode<T> node, LinkedListNode<T> other, int expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
        int result = node.CompareTo(other);
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override equality opertor.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideEqualityOperator_TwoNodes_ReturnsTrueIfEqual_Data))]
        [Test]
    public void OverrideEqualityOperator_TwoNodes_ReturnsTrueIfEqual<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft == nodeRight;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override inequality opertor.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideInequalityOperator_TwoNodes_ReturnsTrueIfNotEqual_Data))]
        [Test]
    public void OverrideInequalityOperator_TwoNodes_ReturnsTrueIfNotEqual<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft != nodeRight;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override less than operator.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideLessThanOperator_TwoNodes_ReturnsTrueIfLeftLessThanRight_Data))]
        [Test]
    public void OverrideLessThanOperator_TwoNodes_ReturnsTrueIfLeftLessThanRight<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft < nodeRight;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override greater than operator.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideGreaterThanOperator_TwoNodes_ReturnsTrueIfLeftGreaterThanRight_Data))]
        [Test]
    public void OverrideGreaterThanOperator_TwoNodes_ReturnsTrueIfLeftGreaterThanRight<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft > nodeRight;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override less than or equals operator.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideLessThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftLessOrEqualRight_Data))]
        [Test]
    public void OverrideLessThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftLessOrEqualRight<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft <= nodeRight;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for override greater than or equals operator.
        /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nodeLeft"></param>
    /// <param name="nodeRight"></param>
        /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(OverrideGreaterThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftGreaterOrEqualRight_Data))]
        [Test]
    public void OverrideGreaterThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftGreaterOrEqualRight<T>(LinkedListNode<T> nodeLeft, LinkedListNode<T> nodeRight, bool expectedResult) 
            where T : IComparable<T>
        {
            //Arrange

            //Act
        bool result = nodeLeft >= nodeRight;
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    #region
    private static IEnumerable Contructor_CreateNode_ReturnsNewNode_Data()
        {
            yield return new object[] { 7, 7 };
            yield return new object[] { 0, 0 };
            yield return new object[] { -5, -5 };
            yield return new object[] { "gty", "gty" };
        }

    private static IEnumerable NodeNext_ReturnsTheNextNode_Data()
    {
        yield return new object[] { new LinkedList<int>() { 7, 8, 21 }, 8 };
        yield return new object[] { new LinkedList<string>() { "gty", "gty" }, "gty" };
    }

    private static IEnumerable OverrideEquals_ObjectWithNodeByValue_ReturnsTrueIfEqual_Data()
        {
            yield return new object[] { new LinkedListNode<int>(2), new LinkedListNode<int>(2), true };
            yield return new object[] { new LinkedListNode<int>(0), new LinkedListNode<int>(-8), false };
            yield return new object[] { new LinkedListNode<int>(5), new LinkedListNode<int>(15), false };
            yield return new object[] { new LinkedListNode<string>("boom"), new LinkedListNode<string>("boom"), true };
        }

    private static IEnumerable OverrideCompareTo_TwoNodes_ReturnsCorrectly_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(2), 1 };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), -1 };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), 0 };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), 0 };
            yield return new object[] { new LinkedListNode<string>("boom"), new LinkedListNode<string>("boo"), 1 };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("hboo"), -1 };
        }

    private static IEnumerable OverrideEqualityOperator_TwoNodes_ReturnsTrueIfEqual_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), false };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(23), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

    private static IEnumerable OverrideInequalityOperator_TwoNodes_ReturnsTrueIfNotEqual_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(51), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), true };
        }

    private static IEnumerable OverrideLessThanOperator_TwoNodes_ReturnsTrueIfLeftLessThanRight_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(15), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(30), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(7), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("nboo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

    private static IEnumerable OverrideGreaterThanOperator_TwoNodes_ReturnsTrueIfLeftGreaterThanRight_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(1), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(70), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("jboo"), false };
        }

    private static IEnumerable OverrideLessThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftLessOrEqualRight_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(50), true };
            yield return new object[] { new LinkedListNode<int>(51), new LinkedListNode<int>(11), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("boo"), true };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("aboo"), false };
        }

    private static IEnumerable OverrideGreaterThanOrEqualThenOperator_TwoNodes_ReturnsTrueIfLeftGreaterOrEqualRight_Data()
        {
            yield return new object[] { new LinkedListNode<int>(10), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(23), new LinkedListNode<int>(10), true };
            yield return new object[] { new LinkedListNode<int>(8), new LinkedListNode<int>(51), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("nboo"), false };
            yield return new object[] { new LinkedListNode<string>("boo"), new LinkedListNode<string>("lboo"), false };
        }
    #endregion
}
