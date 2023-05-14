using VV.DataStructure.LinkedList.Resources;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes LinkedList data structure, implements CRUD functionality via IList's methods.
/// </summary>
public class LinkedList<T> : IList<T>
    where T : IComparable<T>
{
    private LinkedListNode<T>? head;
    private LinkedListNode<T>? tail;

    /// <summary>
    /// Default empty constructor.
    /// </summary>
    public LinkedList() 
    {
    
    }

    /// <summary>
    /// Create an instance from given IEnumerable collection.
    /// </summary>
    /// <param name="collection"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public LinkedList(IEnumerable<T> collection) 
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

            LinkedListNode<T> node = head!;

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

    /// <inheritdoc/>
    public T this[int i]
    {
        get => Get(i)!;
        set => Update(i, value!);
    }

    /// <summary>
    /// Finding a value of the element by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>Returns value of the element corresponding to the given index.</returns>
    public T? Get(int index)
    {
        var counter = 0;

        LinkedListNode<T>? node = head;

        if (node is null)
            return default;

        if (index > Count || index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        while (counter != index)
        {
            node = node.Next!;
            counter++;
        }

        return node.Value;
    }

    /// <summary>
    /// Add the element in the end of LinkedList. 
    /// </summary>
    /// <param name="item"></param>
    /// <exception cref="InvalidOperationException"></exception>    
    public void Add(T item)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);
        
        LinkedListNode<T>? node = new(item);

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
    /// Update value of the element according to given index and value.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Update(int index, T value)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);

        if (index < 0 || index > Count - 1)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        var counter = 0;

        LinkedListNode<T>? node = head;

        while (counter != index)
        {
            node = node!.Next;
            counter++;
        }
        node!.Value = value;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        LinkedListNode<T>? node = head;
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

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode<T> node = head!;

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
    /// <param name="item"></param>
    /// <returns>The index of the item if found in the LinkedList; otherwise, -1.</returns>
    public int IndexOf(T item)
    {
        LinkedListNode<T> node = head!;

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
    /// <param name="index"></param>
    /// <param name="item"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Insert(int index, T item)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);
        
        LinkedListNode<T> node = new(item);
        
        LinkedListNode<T>? current = head;
        LinkedListNode<T>? previuos = null;
        
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
    /// <param name="index"></param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void RemoveAt(int index)
    {
        if (IsReadOnly)
            throw new InvalidOperationException(LinkedListRes.InvalidOperationExceptionText);
        

        if (index < 0 || index > Count-1)
            throw new ArgumentOutOfRangeException(nameof(index), LinkedListRes.ArgumentOutOfRangeExceptionText);

        else
        {
            LinkedListNode<T>? current = head;
            LinkedListNode<T>? previuos = null;
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
    /// <exception cref="InvalidOperationException"></exception>
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
    /// <param name="item"></param>
    /// <returns>true, if item is found in the LinkedList; otherwise, false.</returns>
    public bool Contains(T item)
    {
        LinkedListNode<T>? node = head;

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
    /// <param name="array"></param>
    /// <param name="arrayIndex"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if ((Count > array.Length - arrayIndex) 
            || (arrayIndex < 0) 
            || (arrayIndex > array.Length-1))
            throw new ArgumentOutOfRangeException(LinkedListRes.ArgumentOutOfRangeExceptionCopyToMethodText); 

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(this[i], arrayIndex++);
        }    
    }

    /// <summary>
    /// Removes the first occurrence of the specified item from the LinkedList.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>true, if item was successfully removed from LinkedList; otherwise, false.
    /// The method also returns false, if item is not found in the LinkedList.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public bool Remove(T item)
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
}