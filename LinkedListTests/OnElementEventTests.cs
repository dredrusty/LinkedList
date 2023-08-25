using System;
using System.Collections;
using NUnit.Framework;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Test class for rising events in <see cref="LinkedList{TValue}"/> methods.
/// </summary>
[TestFixture]
public class OnElementEventTests
{
    /// <summary>
    /// Test for successful rising OnElementInsert event in <see cref="LinkedList{TValue}.Add"/> method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="inputValue"></param>
    /// <param name="inputMethodName"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Add_RisesOnElementInsert_Data))]
    [Test]
    public void Add_RisesOnElementInsert<T>(int inputIndex, T inputValue, string inputMethodName, LinkedList<T> list)
        where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementInsert += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.Add(inputValue);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(inputValue));
            Assert.That(actualIndex, Is.EqualTo(inputIndex));
            Assert.That(actualMethodName, Is.EqualTo(inputMethodName));
        });
    }

    /// <summary>
    /// Test for successful rising OnElementUpdate event in <see cref="LinkedList{TValue}.Update"/> method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="inputValue"></param>
    /// <param name="inputMethodName"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Update_RisesOnElementUpdate_Data))]
    [Test]
    public void Update_RisesOnElementUpdate<T>(int inputIndex, T inputValue, string inputMethodName, LinkedList<T> list)
        where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementUpdate += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.Update(inputIndex, inputValue);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(inputValue));
            Assert.That(actualIndex, Is.EqualTo(inputIndex));
            Assert.That(actualMethodName, Is.EqualTo(inputMethodName));
        });
    }

    /// <summary>
    /// Test for successful rising OnElementInsert event in <see cref="LinkedList{TValue}.Insert"/> method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="inputValue"></param>
    /// <param name="inputMethodName"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Insert_RisesOnElementInsert_Data))]
    [Test]
    public void Insert_RisesOnElementInsert<T>(int inputIndex, T inputValue, string inputMethodName, LinkedList<T> list)
            where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementInsert += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.Insert(inputIndex, inputValue);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(inputValue));
            Assert.That(actualIndex, Is.EqualTo(inputIndex));
            Assert.That(actualMethodName, Is.EqualTo(inputMethodName));
        });
    }

    /// <summary>
    /// Test for successful rising OnElementRemove event in <see cref="LinkedList{TValue}.RemoveAt"/> method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="inputValue"></param>
    /// <param name="inputMethodName"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(RemoveAt_RisesOnElementRemove_Data))]
    [Test]
    public void RemoveAt_RisesOnElementRemove<T>(int inputIndex, T inputValue, string inputMethodName, LinkedList<T> list)
        where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementRemove += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.RemoveAt(inputIndex);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(inputValue));
            Assert.That(actualIndex, Is.EqualTo(inputIndex));
            Assert.That(actualMethodName, Is.EqualTo(inputMethodName));
        });
    }

    /// <summary>
    /// Test for successful rising OnElementRemove event in <see cref="LinkedList{TValue}.Remove"/> method.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="inputValue"></param>
    /// <param name="inputMethodName"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Remove_RisesOnElementRemove_Data))]
    [Test]
    public void Remove_RisesOnElementRemove<T>(int inputIndex, T inputValue, string inputMethodName, LinkedList<T> list)
        where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementRemove += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.Remove(inputValue);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(inputValue));
            Assert.That(actualIndex, Is.EqualTo(inputIndex));
            Assert.That(actualMethodName, Is.EqualTo(inputMethodName));
        });
    }

    /// <summary>
    /// Test for confirmation that OnElementRemove rises only in <see cref="LinkedList{TValue}.Remove"/> method.
    /// And doesn't rise in <see cref="LinkedList{TValue}.RemoveAt"/> which called inside <see cref="LinkedList{TValue}.Remove"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inputIndex"></param>
    /// <param name="list"></param>
    [TestCaseSource(nameof(Remove_IsInvokedByIsTrue_DoesNotRiseOnElementRemoveInRemoveAt_Data))]
    [Test]
    public void Remove_IsInvokedByIsTrue_DoesNotRiseOnElementRemoveInRemoveAt<T>(int inputIndex, LinkedList<T> list)
            where T : IComparable<T>
    {
        //Arrange
        T? actualValue = default!;
        int actualIndex = -1;
        string actualMethodName = null!;

        //Act
        list.OnElementRemove += (s, e) =>
        {
            actualValue = e.Value;
            actualIndex = e.Index;
            actualMethodName = e.TriggerMethod;
        };

        list.IsInvokedBy = true;

        list.RemoveAt(inputIndex);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(actualValue, Is.EqualTo(default(T)));
            Assert.That(actualIndex, Is.EqualTo(-1));
            Assert.That(actualMethodName, Is.Null);
        });
    }

    #region
    private static IEnumerable Add_RisesOnElementInsert_Data()
    {
        yield return new object[] { 3, 8055, "Add", new LinkedList<int>() { 5, 8, 14 } };
        yield return new object[] { 0, 54, "Add", new LinkedList<int>() };
        yield return new object[] { 5, "Mon", "Add", new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    private static IEnumerable Update_RisesOnElementUpdate_Data()
    {
        yield return new object[] { 3, 8055, "Update", new LinkedList<int>() { 5, 8, 14, 47, 17 } };
        yield return new object[] { 0, "Mon", "Update", new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    private static IEnumerable Insert_RisesOnElementInsert_Data()
    {
        yield return new object[] { 2, 8055, "Insert", new LinkedList<int>() { 5, 8, 14 } };
        yield return new object[] { 0, "Mon", "Insert", new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    private static IEnumerable RemoveAt_RisesOnElementRemove_Data()
    {
        yield return new object[] { 0, 5, "RemoveAt", new LinkedList<int>() { 5, 8, 14 } };
        yield return new object[] { 4, "Sat", "RemoveAt", new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    private static IEnumerable Remove_RisesOnElementRemove_Data()
    {
        yield return new object[] { 0, 5, "Remove", new LinkedList<int>() { 5, 8, 14 } };
        yield return new object[] { 4, "Sat", "Remove", new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    private static IEnumerable Remove_IsInvokedByIsTrue_DoesNotRiseOnElementRemoveInRemoveAt_Data()
    {
        yield return new object[] { 2, new LinkedList<int>() { 5, 8, 14 } };
        yield return new object[] { 0, new LinkedList<string>() { "Wed", "Sun", "Tue", "Fri", "Sat" } };
    }

    #endregion
}