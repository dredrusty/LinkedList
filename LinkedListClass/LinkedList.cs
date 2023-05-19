using VV.DataStructure.LinkedList.Resources;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes LinkedList data structure, implements CRUD functionality and IList methods.
/// </summary>
public class LinkedList<TValue> : IList<TValue>, ICloneable
    where TValue : IComparable<TValue>
{
    internal LinkedListNode<TValue>? head;
    private LinkedListNode<TValue>? tail;

    internal LinkedListNode<TValue> HeadForTest()
    {
        return head!;
    }

    /// <summary>
    /// Default empty constructor.
    /// </summary>
    public LinkedList() 
    {
    
    }

    /// <summary>
    /// Create an instance from given IEnumerable collection.
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
    public int Count
    {
        get
        {
            int count = 0;

            LinkedListNode<TValue> node = head!;

            while (node is not null)
            {
                node = node.Next!;
                count++;
            }

            return count;
        }
    }

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
        set => Update(i, value!);
    }

    /// <summary>
    /// Finds a value of the element by specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Returns value of the element corresponding to the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public TValue? Get(int index)
    {
        var counter = 0;

        LinkedListNode<TValue>? node = head;

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
        
        LinkedListNode<TValue>? node = new(item);

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
    }

    /// <summary>
    /// Updates value of an element at a specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <exception cref="InvalidOperationException">If IsReadOnly is true, you are not allow to change this LinkedList.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Index can not be negative or greater than Count-1.</exception>
    public void Update(int index, TValue value)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        var counter = 0;

        LinkedListNode<TValue>? node = head;

        while (counter != index)
        {
            node = node!.Next;
            counter++;
        }
        node!.Value = value;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        LinkedListNode<TValue>? node = head;
        StringBuilder tmp = new();

        foreach (var item in this)
        {
            tmp.Append(node!.Value);
            tmp.Append(' ');
            node = node.Next;
        }

        string result = tmp.ToString().TrimEnd(' ');

        return result;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>an enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<TValue> GetEnumerator()
    {
        LinkedListNode<TValue> node = head!;

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
        LinkedListNode<TValue> node = head!;

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
        
        if(index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);
        
        LinkedListNode<TValue> node = new(item);
        
        LinkedListNode<TValue>? current = head;
        LinkedListNode<TValue>? previuos = null;
        
        int counter = 0;

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
                previuos = current;
                current = current!.Next;

                counter++;
            }

            previuos!.Next = node;
            node.Next = current;
        }
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

        else
        {
            LinkedListNode<TValue>? current = head;
            LinkedListNode<TValue>? previuos = null;
            int counter = 0;

            while (counter != index)
            {
                previuos = current;
                current = current!.Next;

                counter++;
            }

            if (previuos is null)
            {
                head = current!.Next;
            }
            else
            {
                current = current!.Next;
                previuos.Next = current;
            }
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
        
        int count = Count;

        while (count != 0)
        {
            RemoveAt(0);
            count--;
        }
    }

    /// <summary>
    /// Determines whether the LinkedList contains a specific value.
    /// </summary>
    /// <param name="item">the value of the item being checked for occurrence</param>
    /// <returns>true, if item is found in the LinkedList; otherwise, false.</returns>
    public bool Contains(TValue item)
    {
        LinkedListNode<TValue>? node = head;

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
    /// <exception cref="ArgumentOutOfRangeException">The index cannot be negative or greater than the length of array-1. The number of elements of the copied LinkedList cannot exceed the capacity of the array.</exception>
    public void CopyTo(TValue[] array, int arrayIndex)
    {
        if ((Count > array.Length - arrayIndex) 
            || (arrayIndex < 0) 
            || (arrayIndex >= array.Length))
            throw new ArgumentOutOfRangeException(LinkedListRes.ArgumentOutOfRangeExceptionCopyToMethodText); 

        for (int i = 0; i < Count; i++)
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

        int count = Count;

        if (IndexOf(item) < 0)
            return false;
            
        RemoveAt(IndexOf(item));
            
        if (count > Count)
            return true;
        return false;
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