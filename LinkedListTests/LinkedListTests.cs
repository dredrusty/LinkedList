using System;
using System.Collections;
using NUnit.Framework;

namespace VV.DataStructure.LinkedList;

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
    [TestCaseSource(nameof(Count_ElementsInGivenList_ReturnsCorrect_Data))]
    [Test]
    public void Count_ElementsInGivenList_ReturnsCorrect<T>(LinkedList<T> list, int expected)
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
    [TestCaseSource(nameof(ConstructorLinkedList_WhenParametrIsIEnumerableCollection_ReturnsInstance_Data))]
    [Test]
    public void ConstructorLinkedList_WhenParametrIsIEnumerableCollection_ReturnsInstance<T>(T[] array)
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
    [TestCaseSource(nameof(ConstructorLinkedList_WhenParametrIsCollectionIsNull_ThrowsException_Data))]
    [Test]
    public void ConstructorLinkedList_WhenParametrIsCollectionIsNull_ThrowsException(int[] array)
    {
        //Arrange
        LinkedList<int> list = new();

        //Act
        var exception = Assert.Throws<ArgumentNullException>(()
            => list = new(array));

        //Assert
        Assert.That(exception!.Message, Is.EqualTo("Collection is null. (Parameter 'collection')"));
    }

    /// <summary>
    /// Test for default value of the IsReadonly method.
    /// </summary>
    /// <param name="list"></param>
    [TestCaseSource(nameof(IsReadonly_ReturnsDefaultFalse_Data))]
    [Test]
    public void IsReadonly_ReturnsDefaultFalse<T>(LinkedList<T> list)
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
    [TestCaseSource(nameof(Get_Index_ReturnsCorrectValue_Data))]
    [Test]
    public void Get_Index_ReturnsCorrectValue<T>(LinkedList<T> list, int index, T expectedValue)
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
    [TestCaseSource(nameof(Get_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data))]
    [Test]
    public void Get_IncorrectIndex_ThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index)
        where T : IComparable<T>
    {
        //Arrange
        T resultGet;

        //Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => resultGet = list[index]);

        //Assert
        Assert.That(exception!.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
    }

    /// <summary>
    /// Test for Add(value) method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="value"></param>
    /// <param name="expected"></param>
    [TestCaseSource(nameof(Add_NewItem_NewItemInTheEndOfTheList_Data))]
    [Test]
    public void Add_NewItem_NewItemInTheEndOfTheList<T>(LinkedList<T> list, T value, T expected)
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
    [TestCaseSource(nameof(Update_ValueOfTheItemByIndex_NewValueOfTheGivenItem_Data))]
    [Test]
    public void Update_ValueOfTheItemByIndex_NewValueOfTheGivenItem<T>(LinkedList<T> list, int index, T value, T expected)
    where T : IComparable<T>
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
    [TestCaseSource(nameof(Update_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data))]
    [Test]
    public void Update_IncorrectIndex_ThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index, T value)
        where T : IComparable<T>
    {
        //Arrange

        //Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => list.Update(index, value));

        //Assert
        Assert.That(exception!.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
    }

    /// <summary>
    /// Test for ToString() method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="expected"></param>
    [TestCaseSource(nameof(Tostring_List_ReturnsStringOfTheItemsOfTheList_Data))]
    [Test]
    public void Tostring_List_ReturnsStringOfItemsOfTheList<T>(LinkedList<T> list, string expected)
        where T : IComparable<T>
    {
        //Arrange

        //Act
        var result = list.ToString();

        //Assert
        Assert.That(expected, Is.EqualTo(result));
    }

    /// <summary>
    /// Test for CanIndexOf(item) method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="item"></param>
    /// <param name="expected"></param>
    [TestCaseSource(nameof(IndexOf_Value_ReturnsIndexOfTheItem_Data))]
    [Test]
    public void IndexOf_Value_ReturnsIndexOfTheItem<T>(LinkedList<T> list, T item, int expected)
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
    [TestCaseSource(nameof(Insert_NewItemByIndex_ListContainsCorrectValueByCorrectIndex_Data))]
    [Test]
    public void Insert_NewItemByIndex_ListContainsCorrectValueByCorrectIndex<T>(LinkedList<T> list, int index, T item, T expectedItem)
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
    /// Test for Insert(index, value) method, when index is out of range.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="index"></param>
    /// <param name="value"></param>
    [TestCaseSource(nameof(Insert_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data))]
    [Test]
    public void Insert_IncorrectIndex_ThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index, T value)
    where T : IComparable<T>
    {
        //Arrange

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => list.Insert(index, value));

        //Assert
        Assert.That(exception!.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
    }

    /// <summary>
    /// Test for RemoveAt(index) method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="index"></param>
    /// <param name="expectedItem"></param>
    /// <param name="expectedCount"></param>
    [TestCaseSource(nameof(RemoveAt_ItemByIndex_ListDoesNotContainItemByIndex_Data))]
    [Test]
    public void RemoveAt_ItemByIndex_ListDoesNotContainItemByIndex<T>(LinkedList<T> list, int index, T expectedItem, int expectedCount)
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
    [TestCaseSource(nameof(RemoveAt_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data))]
    [Test]
    public void RemoveAt_IncorrectIndex_ThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int index)
        where T : IComparable<T>
    {
        //Arrange

        //Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => list.RemoveAt(index));

        //Assert
        Assert.That(exception!.Message, Is.EqualTo("You are trying to get non-existent element. (Parameter 'index')"));
    }

    /// <summary>
    /// Test for Clear() method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="expectedCount"></param>
    [TestCaseSource(nameof(Clear_ReturnsEmptyList_Data))]
    [Test]
    public void Clear_ReturnsEmptyList<T>(LinkedList<T> list, int expectedCount)
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
    [TestCaseSource(nameof(Clear_EmptyList_ThrowsArgumentOutOfRangeExeptionList_Data))]
    [Test]
    public void Clear_EmptyList_ThrowsArgumentOutOfRangeExeptionList<T>(LinkedList<T> list)
        where T : IComparable<T>
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(list.Clear);
    }

    /// <summary>
    /// Test for Contains(item) method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="value"></param>
    /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(Contains_Value_TrueIfYesFalseIfNot_Data))]
    [Test]
    public void Contains_Value_TrueIfYesFalseIfNot<T>(LinkedList<T> list, T value, bool expectedResult)
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
    [TestCaseSource(nameof(CopyTo_List_ArrayWithListsItemsInCorrectOrder_Data))]
    [Test]
    public void CopyTo_List_ArrayWithListsItemsInCorrectOrder<T>(LinkedList<T> list, int arrayIndex, T[] expectedResult)
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
    [TestCaseSource(nameof(CopyTo_IncorrectLengthOrIndex_ThrowsArgumentOutOfRangeException_Data))]
    [Test]
    public void CopyTo_IncorrectLengthOrIndex_ThrowsArgumentOutOfRangeException<T>(LinkedList<T> list, int arrayIndex)
        where T : IComparable<T>
    {
        //Arrange
        T[] array = new T[10];

        //Act
        var exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => list.CopyTo(array, arrayIndex));

        //Assert
        Assert.That(exception!.ParamName, Is.EqualTo("Copying is not possible. Check arrayIndex or receiving part of the array."));
    }

    /// <summary>
    /// Test for IsRemove(value) method.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="value"></param>
    /// <param name="expectedResult"></param>
    [TestCaseSource(nameof(Remove_Item_ReturnsTrueIfDeletedAndFalseIfNotOrNotFound_Data))]
    [Test]
    public void Remove_Item_ReturnsTrueIfDeletedAndFalseIfNotOrNotFound<T>(LinkedList<T> list, T value, bool expectedResult)
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
    [TestCaseSource(nameof(GetEnumerator_ForeachWorksCorrectly_Data))]
    [Test]
    public void GetEnumerator_ForeachWorksCorrectly<T>(LinkedList<T> list, int expected)
        where T : IComparable<T>
    {
        //Arrange
        int check = 0;

        //Act
        foreach (var item in list)
        { check++; }


        //Assert
        Assert.That(expected, Is.EqualTo(check));
    }

    /// <summary>
    /// Test for Clone() method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Clone_List_NewObjectThatIsCopyOfTheList_Data))]
    [Test]
    public void Clone_List_NewObjectThatIsCopyOfTheList<T>(LinkedList<T> list)
    where T : IComparable<T>
    {
        //Arrange

        //Act
        var listCloned = (LinkedList<T>)list.Clone();
        var result = ReferenceEquals(listCloned, list);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(list, Has.Count.EqualTo(listCloned.Count));
            Assert.That(ReferenceEqualsForListsItemsAndClonedListsItems(list, listCloned), Is.False);
        });

            static bool ReferenceEqualsForListsItemsAndClonedListsItems<TItems>(LinkedList<TItems> list, LinkedList<TItems> listCloned)
                where TItems : IComparable<TItems>
            {
                if (list.Count != listCloned.Count)
                    throw new ArgumentOutOfRangeException(nameof(listCloned));

            var flag = false;

            var node = list.head!;
            var nodeCloned = listCloned.head!;

                while (node is not null)
                {
                    if (ReferenceEquals(node, nodeCloned))
                        flag = true;

                    node = node.Next!;
                    nodeCloned = nodeCloned.Next!;
                }

            return flag;
        }
    }
    #region
    private static IEnumerable Count_ElementsInGivenList_ReturnsCorrect_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 2 };
        yield return new object[] { new LinkedList<int>(), 0 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
        yield return new object[] { new LinkedList<string>() { "dd", "rf", "dfer", "dfd", "dfdss" }, 5 };
    }

    private static IEnumerable ConstructorLinkedList_WhenParametrIsIEnumerableCollection_ReturnsInstance_Data()
    {
        yield return new object[] { new[] { 1, 2 } };
        yield return new object[] { Array.Empty<int>() };
        yield return new object[] { new[] { 1, 2, 5, 0, 8 } };
        yield return new object[] { new[] { "rgrt", "trhty", "DFbee" } };
    }

    private static IEnumerable ConstructorLinkedList_WhenParametrIsCollectionIsNull_ThrowsException_Data()
    {
        yield return new object[] { null! };
    }

    private static IEnumerable IsReadonly_ReturnsDefaultFalse_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 } };
        yield return new object[] { new LinkedList<int>() };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee" } };
    }

    private static IEnumerable Get_Index_ReturnsCorrectValue_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 1 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, 7 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 3, "8" };
    }

    private static IEnumerable Get_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 2 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -1 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 4 };
    }

    private static IEnumerable Add_NewItem_NewItemInTheEndOfTheList_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, 5 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 11, 11 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "8", "8" };
        yield return new object[] { new LinkedList<int>(), 4, 4 };
    }

    private static IEnumerable Update_ValueOfTheItemByIndex_NewValueOfTheGivenItem_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 14, 14 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, 11, 11 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 3, "2", "2" };
    }

    private static IEnumerable Update_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, 14 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, -5, "yth" };
    }

    private static IEnumerable Tostring_List_ReturnsStringOfTheItemsOfTheList_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, "1 2" };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, "5 -8 11 7" };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, "1 2 5 0 8" };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "rgrt trhty DFbee 8" };
    }

    private static IEnumerable IndexOf_Value_ReturnsIndexOfTheItem_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 5, -1 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "DFbee", 2 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 8, 0, 8 }, 8, 2 };
        yield return new object[] { new LinkedList<int>(), 5, -1 };
    }

    private static IEnumerable Insert_NewItemByIndex_ListContainsCorrectValueByCorrectIndex_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 1, -1, -1 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0, 11, 11 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 3, 15, 15 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 1, " ", " " };
    }

        private static IEnumerable Insert_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data()
        {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, -2, -1 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 4, 11 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 8, 15 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 4, "Bam" };
        }

    private static IEnumerable RemoveAt_ItemByIndex_ListDoesNotContainItemByIndex_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 0, 2, 1 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, 11, 3 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 2, 0, 4 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 3, "DFbee", 3 };
    }

    private static IEnumerable RemoveAt_IncorrectIndex_ThrowsArgumentOutOfRangeException_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, -5 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 4 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 8 };
    }

    private static IEnumerable Clear_ReturnsEmptyList_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 0 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 0 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 0 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 0 };
    }

    private static IEnumerable Clear_EmptyList_ThrowsArgumentOutOfRangeExeptionList_Data()
    {
        yield return new object[] { new LinkedList<int>() };
        yield return new object[] { new LinkedList<string>() };
    }

    private static IEnumerable Contains_Value_TrueIfYesFalseIfNot_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 2, true };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -8, true };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 22, false };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "rggth", false };
    }

    private static IEnumerable CopyTo_List_ArrayWithListsItemsInCorrectOrder_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 3 }, 0, new[] { 1, 3, 0, 0, 0, 0, 0, 0, 0, 0 } };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 3, new[] { 0, 0, 0, 5, -8, 11, 7, 0, 0, 0 } };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 6, new[] { null!, null!, null!, null!, null!, null!, "rgrt", "trhty", "DFbee", "8" } };
    }

    private static IEnumerable CopyTo_IncorrectLengthOrIndex_ThrowsArgumentOutOfRangeException_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 3, 4, 24, 7, 11, 74 }, 5 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, -1 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 10 };
    }

    private static IEnumerable Remove_Item_ReturnsTrueIfDeletedAndFalseIfNotOrNotFound_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 1, true };
        yield return new object[] { new LinkedList<int>() { 5, -8, 5, 7 }, 5, true };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 11, false };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, "8", true };
    }

    private static IEnumerable GetEnumerator_ForeachWorksCorrectly_Data()
    {
        yield return new object[] { new LinkedList<int>() { 1, 2 }, 2 };
        yield return new object[] { new LinkedList<int>() { 5, -8, 11, 7 }, 4 };
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 }, 5 };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" }, 4 };
    }

        private static IEnumerable Clone_List_NewObjectThatIsCopyOfTheList_Data()
        {
        yield return new object[] { new LinkedList<int>() { 1, 2, 5, 0, 8 } };
        yield return new object[] { new LinkedList<string>() { "rgrt", "trhty", "DFbee", "8" } };
        }
        #endregion
    }