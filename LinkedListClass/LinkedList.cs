using VV.DataStructure.LinkedList.Resources;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes LinkedList data structure, implements CRUD functionality, <see cref="IList"/> methods and 
/// some events: <see cref="OnElementInsert"/>, <see cref="OnElementRemove"/>, <see cref="OnElementUpdate"/>, <see cref="OnListChanged"/>.
/// </summary>
/// <typeparam name="TValue">Any data type, value or reference, whose values can be contained in a LinkedList.</typeparam>
public class LinkedList<TValue> : IList<TValue>, ICloneable
    where TValue : IComparable<TValue>
{
    private int _count;
    private LinkedListNode<TValue>? tail;
    internal LinkedListNode<TValue>? head;
    internal bool IsInvokedBy;

    /// <summary>
    /// EventHandler delegate.
    /// </summary>
    /// <param name="sender">The source of event.</param>
    /// <param name="e">An object that contains the event data.</param>    
    public delegate void LinkedListEventHandler(object sender, LinkedListEventArgs<TValue> e);

    /// <summary>
    /// Event for inserting a node, that calls by <see cref = "Insert"/> and <see cref="Add"/> method.
    /// </summary>
    public event LinkedListEventHandler? OnElementInsert;

    /// <summary>
    /// Event for removing a node, that calls by <see cref = "Remove"/> and <see cref="RemoveAt"/> method.
    /// </summary>
    public event LinkedListEventHandler? OnElementRemove;

    /// <summary>
    /// Event for updating a node, that calls by <see cref = "Update"/> method.
    /// </summary>
    public event LinkedListEventHandler? OnElementUpdate;

    /// <summary>
    /// Event for changing LinkedList, that calls by <see cref="Add"/>, <see cref="Insert"/>, <see cref="Update"/>,
    /// <see cref="Remove"/>, <see cref="RemoveAt"/> and <see cref="Clear"/>.
    /// </summary>
    public event LinkedListEventHandler? OnListChanged;

    /// <summary>
    /// Default empty constructor.
    /// </summary>
    public LinkedList()
    {

    }

    /// <summary>
    /// Creates an instance from given IEnumerable collection.
    /// </summary>
    /// <param name="collection">any IEnumerable collection from which a new LinkedList will be created.</param>
    /// <exception cref="ArgumentNullException">Will be thrown if collection is null.</exception>
    public LinkedList(IEnumerable<TValue> collection)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection), LinkedListRes.ArgumentNullExceptionText);
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    /// <summary>
    /// Gets the number of elements contained in the LinkedList.
    /// </summary>
    /// <returns>The number of elements contained in the LinkedList.</returns>
    public int Count => _count;

    /// <summary>
    /// Gets a value indicating whether the LinkedList is read-only.
    /// </summary>
    /// <returns>true, if the LinkedList is read-only; otherwise, false.</returns>>
    public bool IsReadOnly
        => false;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="i">the index of the element to be accessed or modified</param>
    /// <returns>The element at the specified index.</returns>
    public TValue this[int i]
    {
        get => Get(i)!;
        set => Update(i, value);
    }

    /// <summary>
    /// Finds a value of the element by specified index.
    /// </summary>
    /// <param name="index">the index of the element whose value is to be found</param>
    /// <returns>Returns value of the element corresponding to the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public TValue? Get(int index)
    {
        var counter = 0;

        var node = head;

        if (node is null)
            return default;

        if (index >= Count || index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        while (counter != index)
        {
            node = node.Next!;
            counter++;
        }

        return node.Value;
    }

    /// <summary>
    /// Adds the item in the end of LinkedList. 
    /// </summary>
    /// <param name="item">the value of the element to be added</param>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>    
    public void Add(TValue item)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        LinkedListNode<TValue> node = new(item);

        if (head is null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail!.Next = node;
            tail = node;
        }

        _count++;

        var index = IndexOf(item);

        OnElementInsert?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));
        OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));
    }

    /// <summary>
    /// Updates value of an element at a specified index.
    /// </summary>
    /// <param name="index">the index of the element whose value is to be changed</param>
    /// <param name="value">new value for element</param>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public void Update(int index, TValue value)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        var counter = 0;

        var node = head;

        while (counter != index)
        {
            node = node!.Next;
            counter++;
        }
        node!.Value = value;

        OnElementUpdate?.Invoke(this, new LinkedListEventArgs<TValue>(value, index));
        OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>(value, index));
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var node = head;
        StringBuilder tmp = new();

        foreach (var _ in this)
        {
            tmp.Append(node!.Value);
            tmp.Append(' ');
            node = node.Next;
        }

        var result = tmp.ToString().TrimEnd(' ');

        return result;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<TValue> GetEnumerator()
    {
        var node = head!;

        while (node is not null)
        {
            yield return node.Value!;
            node = node.Next!;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Determines the index of a specific item in the LinkedList.
    /// </summary>
    /// <param name="item">the value of the searched item</param>
    /// <returns>The index of the item if found in the LinkedList; otherwise, -1.</returns>
    public int IndexOf(TValue item)
    {
        var node = head!;

        if (node is null)
        {
            return -1;
        }
        else
        {
            for (int i = 0; i < Count; i++)
            {
                if (node.Value!.Equals(item))

                    return i;

                node = node.Next!;
            }
            return -1;
        }
    }

    /// <summary>
    /// Inserts an item to the LinkedList at the specified index.
    /// </summary>
    /// <param name="index">the index where the new element should be inserted</param>
    /// <param name="item">the value of the inserted item</param>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public void Insert(int index, TValue item)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        LinkedListNode<TValue> node = new(item);

        var current = head;
        LinkedListNode<TValue>? previous = null;

        var counter = 0;

        if (index == 0)
        {
            node.Next = head;
            head = node;
            if (node.Next is null)
                tail = node;
        }

        else
        {
            while (counter != index)
            {
                previous = current;
                current = current!.Next;

                counter++;
            }

            previous!.Next = node;
            node.Next = current;
        }

        _count++;

        OnElementInsert?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));
        OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));
    }

    /// <summary>
    /// Removes the LinkedList item at the specified index.
    /// </summary>
    /// <param name="index">index of the item to be removed</param>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public void RemoveAt(int index)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);


        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        var item = Get(index);

        var current = head;
        LinkedListNode<TValue>? previous = null;
        var counter = 0;

        while (counter != index)
        {
            previous = current;
            current = current!.Next;

            counter++;
        }

        if (previous is null)
        {
            head = current!.Next;
        }
        else
        {
            current = current!.Next;
            previous.Next = current;
        }

        _count--;

        if (!IsInvokedBy)
        {
            OnElementRemove?.Invoke(this, new LinkedListEventArgs<TValue>(item!, index));
            OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>(item!, index));
        }
    }

    /// <summary>
    /// Removes all items from the LinkedList.
    /// </summary>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public void Clear()
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        if (Count == 0)
            throw new ArgumentOutOfRangeException(LinkedListRes.ArgumentOutOfRangeExceptionClearMethodText);

        IsInvokedBy = true;

        while (Count != 0)
        {
            RemoveAt(0);
        }

        IsInvokedBy = false;

        OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>());
    }

    /// <summary>
    /// Determines whether the LinkedList contains a specific value.
    /// </summary>
    /// <param name="item">the value of the item being checked for occurrence</param>
    /// <returns>true, if item is found in the LinkedList; otherwise, false.</returns>
    public bool Contains(TValue item)
    {
        var node = head;

        for (int i = 0; i < Count; i++)
        {
            if (node!.Value!.Equals(item))
                return true;
            node = node.Next;
        }
        return false;
    }

    /// <summary>
    /// Copies the elements of the LinkedList to an Array, starting at a particular Array index.
    /// </summary>
    /// <param name="array">the array to which the LinkedList is copied</param>
    /// <param name="arrayIndex">index of the array where the first element of LinkedList will be copied</param>
    /// <exception cref="ArgumentOutOfRangeException">The index cannot be negative or greater than the length of array-1. 
    /// The number of elements of the copied LinkedList cannot exceed the capacity of the array.</exception>
    public void CopyTo(TValue[] array, int arrayIndex)
    {
        if ((Count > array.Length - arrayIndex)
            || (arrayIndex < 0)
            || (arrayIndex >= array.Length))
            throw new ArgumentOutOfRangeException(LinkedListRes.ArgumentOutOfRangeExceptionCopyToMethodText);

        for (var i = 0; i < Count; i++)
        {
            array.SetValue(this[i], arrayIndex++);
        }
    }

    /// <summary>
    /// Removes the first occurrence of the specified item from the LinkedList.
    /// </summary>
    /// <param name="item">the value of the item to be removed</param>
    /// <returns>true, if item was successfully removed from LinkedList; otherwise, false.
    /// The method also returns false, if item is not found in the LinkedList.</returns>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    public bool Remove(TValue item)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        var index = IndexOf(item);

        if (IndexOf(item) < 0)
            return false;

        IsInvokedBy = true;

        RemoveAt(index);

        IsInvokedBy = false;

        OnElementRemove?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));
        OnListChanged?.Invoke(this, new LinkedListEventArgs<TValue>(item, index));

        return true;
    }

    /// <summary>
    /// Creates a new object that is copy of the current LinkedList instance.
    /// </summary>
    /// <returns>a new object that is a copy of this LinkedList instance</returns>
    public object Clone()
    {
        return new LinkedList<TValue>(this);
    }
}