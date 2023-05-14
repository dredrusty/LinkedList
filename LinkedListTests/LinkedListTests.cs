using System;
using System.Collections;
using NUnit.Framework;
using VV.DataStructure.LinkedList;

namespace LinkedListTests
{
    /// <summary>
    /// Class that contains test methods for LinkedList functionality.
    /// </summary>
    [TestFixture]
    public class LinkedListTests
    {
        /// <summary>
        /// Test for Count method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanCount_Data))]
        [Test]
        public void CanCount<T>(LinkedList<T> list,int expected)
            where T : IComparable<T>
        {
            //Arrange
            
            //Act
            var result = list.Count;

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Test for new LinkedList(Collection).
        /// </summary>
        /// <param name="array"></param>
        [TestCaseSource(nameof(ConstructorLinkedListWhenParametrIsCollection_Data))]
        [Test]
        public void ConstructorLinkedListWhenParametrIsCollection<T>(T[] array)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            LinkedList<T> list = new(array);

           //Assert
            CollectionAssert.AreEqual(array, list);
        }

        /// <summary>
        /// Test for throwing ArgumentNullException when constructor gets parameter as Collection is null.
        /// </summary>
        /// <param name="array"></param>
        [TestCaseSource(nameof(ConstructorLinkedListWhenParametrIsCollectionIsNullException_Data))]
        [Test]
        public void ConstructorLinkedListWhenParametrIsCollectionIsNullException(int [] array)
        {
            //Arrange
            LinkedList<int> list = new();

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() 
                => list = new(array));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("Collection is null. (Parameter 'collection')"));
        }

        /// <summary>
        /// Test for default value of the IsReadonly method.
        /// </summary>
        /// <param name="list"></param>
        [TestCaseSource(nameof(IsReadonlyByDefault_Data))]
        [Test]
        public void IsReadonlyByDefault<T>(LinkedList<T> list)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = list.IsReadOnly;

            //Assert
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Test for Get(index) method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="expectedValue"></param>
        [TestCaseSource(nameof(GetByIndex_Data))]
        [Test]
        public void GetByIndex<T>(LinkedList<T> list, int index, T expectedValue)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            var result = list.Get(index);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for throwing ArgumentOutOfRangeException in Get(index) method, when index out of range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        [TestCaseSource(nameof(GetByIndexThrowsArgumentOutOfRangeException_Data))]
        [Test]
        public void GetByIndexThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index)
            where T : IComparable<T>
        {
            //Arrange
            T resultGet;

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() 
                => resultGet = list[index]);

            //Assert
            Assert.That(exception.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
        }

        /// <summary>
        /// Test for Add(value) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanAdd_Data))]
        [Test]
        public void CanAdd<T>(LinkedList<T> list, T value, T expected)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            list.Add(value);

            //Assert
            Assert.That(expected, Is.EqualTo(list[^1]));
        }

        /// <summary>
        /// Test for Update(index, value) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanUpdate_Data))]
        [Test]
        public void CanUpdate<T>(LinkedList<T> list, int index, T value, T expected)
            where T: IComparable<T>
        {
            //Arrange

            //Act
            list.Update(index, value);

            //Assert
            Assert.That(expected, Is.EqualTo(list[index]));
        }

        /// <summary>
        /// Test for Update(index, value) method, when index is out of range.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        [TestCaseSource(nameof(CanUpdateThrowsArgumentOutOfRangeException_Data))]
        [Test]
        public void CanUpdateThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index, T value)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() 
                => list.Update(index, value));

            //Assert
            Assert.That(exception.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
        }

        /// <summary>
        /// Test for ToString() method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanToString_Data))]
        [Test]
        public void CanTostring<T>(LinkedList<T> list, string expected)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            string result = list.ToString();

            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for CanIndexOf(item) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanIndexOf_Data))]
        [Test]
        public void CanIndexOf<T>(LinkedList<T> list, T item, int expected)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            int result = list.IndexOf(item);

            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        /// <summary>
        /// Test fot Insert(index, item) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <param name="expectedItem"></param>
        [TestCaseSource(nameof(CanInsert_Data))]
        [Test]
        public void CanInsert<T>(LinkedList<T> list, int index, T item, T expectedItem)
            where T : IComparable<T>
        {
            //Arrange
            var expectedCount = list.Count + 1;

            //Act
            list.Insert(index, item);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(expectedItem, Is.EqualTo(list[index]));
                Assert.That(expectedCount, Is.EqualTo(list.Count));
            });
        }

        /// <summary>
        /// Test for RemoveAt(index) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="expectedItem"></param>
        /// <param name="expectedCount"></param>
        [TestCaseSource(nameof(CanRemoveAt_Data))]
        [Test]
        public void CanRemoveAt<T>(LinkedList<T> list, int index, T expectedItem, int expectedCount)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            list.RemoveAt(index);

            //Assert
            Assert.Multiple(() =>
            {
                if (index >= list.Count)
                {
                    Assert.That(expectedItem, Is.EqualTo(list[^1]));
                    Assert.That(expectedCount, Is.EqualTo(list.Count));
                }
                else 
                {
                    Assert.That(expectedItem, Is.EqualTo(list[index]));
                    Assert.That(expectedCount, Is.EqualTo(list.Count));
                }
            });
        }

        /// <summary>
        /// Test for RemoveAt(index) method, when index is out of range.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        [TestCaseSource(nameof(CanRemoveAtThrowsArgumentOutOfRangeException_Data))]
        [Test]
        public void CanRemoveAtThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() 
                => list.RemoveAt(index));
            
            //Assert
            Assert.That(exception.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
        }

        /// <summary>
        /// Test for Clear() method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="expectedCount"></param>
        [TestCaseSource(nameof(CanClear_Data))]
        [Test]
        public void CanClear<T>(LinkedList<T> list, int expectedCount)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            list.Clear();

            //Assert
            Assert.That(expectedCount, Is.EqualTo(list.Count));
        }

        /// <summary>
        /// Test for Clear() method, when LinkedList is empty.
        /// </summary>
        /// <param name="list"></param>
        [TestCaseSource(nameof(CanClearThrowsArgumentOutOfRangeExeptionList_Data))]
        [Test]
        public void CanClearThrowsArgumentOutOfRangeExeptionList<T>(LinkedList<T> list)
            where T : IComparable<T>
        {
            //Arrange

            //Act
                        
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => list.Clear());
        }

        /// <summary>
        /// Test for Contains(item) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(IsContains_Data))]
        [Test]
        public void IsContains<T>(LinkedList<T> list, T value, bool expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = list.Contains(value);
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for CopyTo(array, arrayIndex) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="arrayIndex"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(CanCopyTo_Data))]
        [Test]
        public void CanCopyTo<T>(LinkedList<T> list, int arrayIndex, T[] expectedResult)
            where T : IComparable<T>
        {
            //Arrange
            T[] array = new T[10];

            //Act
            list.CopyTo(array, arrayIndex);

            //Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }

        /// <summary>
        /// Test for CopyTo(array, index) method, when index is out of bounds of the array or 
        /// LinkedList doesn't fit in the allocated part of the array.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="arrayIndex"></param>
        [TestCaseSource(nameof(CopyToThrowsArgumentOutOfRangeException_Data))]
        [Test]
        public void CopyToThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int arrayIndex)
            where T : IComparable<T>
        {
            //Arrange
            T[] array = new T[10];

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() 
                => list.CopyTo(array, arrayIndex));

            //Assert
            Assert.That(exception.ParamName, Is.EqualTo("Copying is not possible. Check arrayIndex or receiving part of the array."));
        }

        /// <summary>
        /// Test for IsRemove(value) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="expectedResult"></param>
        [TestCaseSource(nameof(IsRemove_Data))]
        [Test]
        public void IsRemove<T>(LinkedList<T> list, T value, bool expectedResult)
            where T : IComparable<T>
        {
            //Arrange

            //Act
            bool result = list.Remove(value);
            
            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        /// <summary>
        /// Test for GetEnumerator.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanGetEnumeratorCreateForeach_Data))]
        [Test]
        public void CanGetEnumeratorCreateForeach<T>(LinkedList<T> list, int expected)
            where T : IComparable<T>
        {
            //Arrange
            int check = 0;

            //Act
            foreach (T item in list)
            { check++; }


            //Assert
            Assert.That(expected, Is.EqualTo(check));
        }

        private static IEnumerable CanCount_Data()
        {
            yield return new object[] { new LinkedList<int>(){ 1,2 }, 2 };
            yield return new object[] { new LinkedList<int>() { }, 0 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
            yield return new object[] { new LinkedList<string>() { "dd", "rf", "dfer", "dfd", "dfdss" }, 5 };
        }

        private static IEnumerable ConstructorLinkedListWhenParametrIsCollection_Data()
        {
            yield return new object[] { new int[] { 1, 2 } };
            yield return new object[] { Array.Empty<int>() };
            yield return new object[] { new int[] { 1, 2, 5, 0, 8 } };
            yield return new object[] { new string[] { "rgrt", "trhty", "DFbee" } };
        }

        private static IEnumerable ConstructorLinkedListWhenParametrIsCollectionIsNullException_Data()
        {
            yield return new object[] { null! };
        }

        private static IEnumerable IsReadonlyByDefault_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 } };
            yield return new object[] { new LinkedList<int>() { } };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee" } };
        }

        private static IEnumerable GetByIndex_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 1 };
            yield return new object[] { new LinkedList<int>() {5, -8, 11, 7 }, 1, -8 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 3, "8" };
        }

        private static IEnumerable GetByIndexThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 3 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -1 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 10 };
        }

        private static IEnumerable CanAdd_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, 5 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11, 11 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "8", "8" };
            yield return new object[] { new LinkedList<int>() { }, 4, 4 };
        }
        
        private static IEnumerable CanUpdate_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 14 , 14 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 1, 11, 11 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 3, "2", "2" };
        }

        private static IEnumerable CanUpdateThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, 14 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, -5, "yth"};
        }

        private static IEnumerable CanToString_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, "1 2" };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, "5 -8 11 7" };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, "1 2 5 0 8" };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "rgrt trhty DFbee 8" };
        }

        private static IEnumerable CanIndexOf_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, -1 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "DFbee", 2 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 8, 4 };
            yield return new object[] { new LinkedList<int>() { }, 5, -1 };
        }

        private static IEnumerable CanInsert_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, -1, -1};
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0, 11, 11};
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 3, 15, 15};
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 1, " ", " " };
        }

        private static IEnumerable CanRemoveAt_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 2, 1 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, 11, 3 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 2, 0, 4 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 1, "DFbee", 3 };
        }

        private static IEnumerable CanRemoveAtThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, -5 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 8 };
        }

        private static IEnumerable CanClear_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 0 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 0 };
        }

        private static IEnumerable CanClearThrowsArgumentOutOfRangeExeptionList_Data()
        {
            yield return new object[] { new LinkedList<int>() { } };
            yield return new object[] { new LinkedList<string>() { } };
        }

        private static IEnumerable IsContains_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, true };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -8, true };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 22, false };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "rggth", false};
        }

        private static IEnumerable CanCopyTo_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 3 }, 0, new int[]{ 1, 3, 0, 0, 0, 0, 0, 0, 0, 0 } };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, new int[] { 0, 0, 0, 5, -8, 11, 7, 0, 0, 0 } };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 6, new string[] { null!, null!, null!, null!, null!, null!, "rgrt", "trhty", "DFbee", "8" } };
        }

        private static IEnumerable CopyToThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 3, 4, 24, 7 }, 6 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -3 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 10 };
        }

        private static IEnumerable IsRemove_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 1, true };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 5, true };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 11, false };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "8", true };
        }

        private static IEnumerable CanGetEnumeratorCreateForeach_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 4 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
            yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 4 };
        }
    }
}