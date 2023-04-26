using System;
using NUnit.Framework;
using VV.DataStructure.LinkedList;
using IEnumerable = System.Collections.Generic.IEnumerable<object[]>;

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
        public void CanCount(LinkedList<int> list,int expected)
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
        public void ConstructorLinkedListWhenParametrIsCollection(int[] array)
        {
            //Arrange

            //Act
            LinkedList<int> list = new(array);

           //Assert
            CollectionAssert.AreEqual(array, list);
        }

        /// <summary>
        /// Test for throwing ArgumentNullException when constructor gets parameter as Collection is null.
        /// </summary>
        /// <param name="array"></param>
        [TestCaseSource(nameof(ConstructorLinkedListWhenParametrIsCollectionIsNullException_Data))]
        [Test]
        public void ConstructorLinkedListWhenParametrIsCollectionIsNullException(int[] array)
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
        public void IsReadonlyByDefault(LinkedList<int> list)
        {
            //Arrange

            //Act
            bool result = list.IsReadOnly;

            //Assert
            Assert.That(result, Is.False);
        }

        /// <summary>
        /// Test for this[value].
        /// </summary>
        /// <param name="list"></param>
        /// <param name="indexGet"></param>
        /// <param name="indexSet"></param>
        /// <param name="valueSet"></param>
        /// <param name="expectedGet"></param>
        /// <param name="expectedSet"></param>
        [TestCaseSource(nameof(GetOrSetByIndex_Data))]
        [Test]
        public void GetOrSetByIndex(LinkedList<int> list, int indexGet, int indexSet, int valueSet, int expectedGet, int expectedSet)
        {
            //Arrange

            //Act
            var resultGet = list[indexGet];

            list[indexSet] = valueSet;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(expectedGet, Is.EqualTo(resultGet));
                Assert.That(expectedSet, Is.EqualTo(list[indexSet]));
            });
        }

        /// <summary>
        /// Test for throwing ArgumentOutOfRangeException, when index out of range.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="indexGet"></param>
        /// <param name="indexSet"></param>
        /// <param name="valueSet"></param>
        [TestCaseSource(nameof(GetOrSetByIndexThrowsArgumentOutOfRangeException_Data))]
        [Test]
        public void GetOrSetByIndexThrowsArgumentOutOfRangeException(LinkedList<int> list, int indexGet, int indexSet, int valueSet)
        {
            //Arrange
            int resultGet;

            //Act
            var exceptionGet = Assert.Throws<ArgumentOutOfRangeException>(() 
                => resultGet = list[indexGet]);

            var exceptionSet = Assert.Throws<ArgumentOutOfRangeException>(()
                => list[indexSet] = valueSet);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exceptionGet.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
                Assert.That(exceptionSet.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
            });
        }

        /// <summary>
        /// Test for Add(value) method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestCaseSource(nameof(CanAdd_Data))]
        [Test]
        public void CanAdd(LinkedList<int> list, int value, int expected)
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
        public void CanUpdate(LinkedList<int> list, int index, int value, int expected)
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
        public void CanUpdateThrowsArgumentOutOfRangeException(LinkedList<int> list, int index, int value)
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
        public void CanTostring(LinkedList<int> list, string expected)
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
        public void CanIndexOf(LinkedList<int> list, int item, int expected)
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
        public void CanInsert(LinkedList<int> list, int index, int item, int expectedItem)
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
        public void CanRemoveAt(LinkedList<int> list, int index, int expectedItem, int expectedCount)
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
        public void CanRemoveAtThrowsArgumentOutOfRangeException(LinkedList<int> list, int index)
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
        public void CanClear(LinkedList<int> list, int expectedCount)
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
        public void CanClearThrowsArgumentOutOfRangeExeptionList(LinkedList<int> list)
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
        public void IsContains(LinkedList<int> list, int value, bool expectedResult)
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
        public void CanCopyTo(LinkedList<int> list, int arrayIndex, int[] expectedResult)
        {
            //Arrange
            int[] array = new int[10];

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
        public void CopyToThrowsArgumentOutOfRangeException(LinkedList<int> list, int arrayIndex)
        {
            //Arrange
            int[] array = new int[10];

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
        public void IsRemove(LinkedList<int> list, int value, bool expectedResult)
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
        public void CanGetEnumeratorCreateForeach(LinkedList<int> list, int expected)
        {
            //Arrange
            int check = 0;

            //Act
            foreach (int item in list)
            { check++; }


            //Assert
            Assert.That(expected, Is.EqualTo(check));
        }

        private static IEnumerable CanCount_Data()
        {
            yield return new object[] { new LinkedList<int>(){ 1,2 }, 2 };
            yield return new object[] { new LinkedList<int>() { }, 0 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
        }

        private static IEnumerable ConstructorLinkedListWhenParametrIsCollection_Data()
        {
            yield return new object[] { new int[] { 1, 2 } };
            yield return new object[] { Array.Empty<int>() };
            yield return new object[] {new int[] { 1, 2, 5, 0, 8 } };
        }

        private static IEnumerable ConstructorLinkedListWhenParametrIsCollectionIsNullException_Data()
        {
            yield return new object[] { null! };
        }

        private static IEnumerable IsReadonlyByDefault_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 } };
            yield return new object[] { new LinkedList<int>() { } };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 } };
        }

        private static IEnumerable GetOrSetByIndex_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 1, 8, 1, 8 };
            yield return new object[] { new LinkedList<int>() {5, -8, 11, 7 }, 1, 3, 8, -8, 8 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 4, 1, 8, 8, 8 };
        }

        private static IEnumerable GetOrSetByIndexThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 3, 2, 8 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -1, 8, 8 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 10, -1, 8 };
        }

        private static IEnumerable CanAdd_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, 5 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11, 11 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 8, 8 };
            yield return new object[] { new LinkedList<int>() { }, 4, 4 };
        }
        
        private static IEnumerable CanUpdate_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 14 , 14 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 1, 11, 11 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 4, 2, 2 };
        }

        private static IEnumerable CanUpdateThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, 14 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -5, 11};
        }

        private static IEnumerable CanToString_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, "1 2" };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, "5 -8 11 7" };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, "1 2 5 0 8" };
        }

        private static IEnumerable CanIndexOf_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, -1 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11, 2 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 8, 4 };
            yield return new object[] { new LinkedList<int>() { }, 5, -1 };
        }

        private static IEnumerable CanInsert_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, -1, -1};
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0, 11, 11};
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 3, 15, 15};
        }

        private static IEnumerable CanRemoveAt_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 2, 1 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, 11, 3 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 2, 0, 4 };
        }

        private static IEnumerable CanRemoveAtThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, -5 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11 };
        }

        private static IEnumerable CanClear_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 0 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 0 };
        }

        private static IEnumerable CanClearThrowsArgumentOutOfRangeExeptionList_Data()
        {
            yield return new object[] { new LinkedList<int>() { } };
        }

        private static IEnumerable IsContains_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, true };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -8, true };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 22, false };
        }

        private static IEnumerable CanCopyTo_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 3 }, 0, new int[]{ 1, 3, 0, 0, 0, 0, 0, 0, 0, 0 } };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, new int[] { 0, 0, 0, 5, -8, 11, 7, 0, 0, 0 } };
        }

        private static IEnumerable CopyToThrowsArgumentOutOfRangeException_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 3, 4, 24, 7 }, 6 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -3 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 10 };
        }

        private static IEnumerable IsRemove_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 1, true };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 5, true };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 11, false };
        }

        private static IEnumerable CanGetEnumeratorCreateForeach_Data()
        {
            yield return new object[] { new LinkedList<int>() { 1, 2 }, 2 };
            yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 4 };
            yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
        }
    }
}