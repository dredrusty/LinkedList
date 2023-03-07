using System.Collections;
using System.Text;


namespace DSLinkedList;

/// <summary>
/// Describes LinkedList data structure, implements CRUD functionality via IList's methods.
/// </summary>
public class LinkedList<T> : IList<T>
    where T : IComparable<T>
{
    private Node<T>? head;
    private Node<T>? tail;

    int ICollection<T>.Count { get; }


    public bool IsReadOnly { get { return false; }
    }

    /// <summary>
    /// Allow to access to node through []:
    /// 1. var q = "name of LinkedList"[index];
    /// 2. "name of LinkedList"[index] = value;
    /// The node cannot be accessed directly from outside. 
    /// Value of the node can be changed by Update(int index, T value) method.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T? this[int i]
    {
        get => Get(i);
        set => Update(i, value);
    }

    /// <summary>
    /// Finding a value of the node by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T Get(int index)
    {
        var counter = 0;

        Node<T>? node = head;

        while (counter != index)
        {
            node = node.Next;
            counter++;
        }

        return node.Value;
    }

    /// <summary>
    /// Method for counting the elements in LinkedList.
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        int count = 0;

        Node<T> node = head;

        while (node is not null)
        {
            node = node.Next;
            count++;
        }

        return count;

    }

    /// <summary>
    /// Adding a new node in the end of the LinkedList.
    /// If LinkedList is empty, node will be added in the first position.
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        Node<T>? node = new(value);

        if (head is null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }
    }

    /// <summary>
    /// Adding a new node in a particulare place by index.
    /// If index == 0, the node will be added in the first position.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Add(int index, T value)
    {
        Node<T> node = new(value);

        Node<T>? current = head;
        Node<T>? previuos = null;
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
                current = current.Next;

                counter++;
            }

            previuos.Next = node;
            node.Next = current;
        }
    }

    /// <summary>
    /// Delete a node from the LinkedList according index provided as parametr.
    /// </summary>
    /// <param name="index"></param>
    public void Delete(int index)
    {
        Node<T>? current = head;
        Node<T>? previuos = null;
        int counter = 0;

        while (counter != index)
        {
            previuos = current;
            current = current.Next;

            counter++;
        }

        if (previuos is null)
        {
            head = current.Next;
        }
        else
        {
            current = current.Next;
            previuos.Next = current;
        }
    }

    /// <summary>
    /// Update value of the node according to given index and value.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Update(int index, T value)
    {
        var counter = 0;

        Node<T>? node = head;

        while (counter != index)
        {
            node = node.Next;
            counter++;
        }
        node.Value = value;
    }

    /// <summary>
    /// Display LinkedList.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        Node<T>? node = head;
        StringBuilder tmp = new();

        foreach (var item in this)
        {
            tmp.Append(node.Value);
            tmp.Append(' ');
            node = node.Next;
        }

        string result = tmp.ToString();

        return result;
    }

    /// <summary>
    /// Method from IEnumerable interface that enables to use foreach for user's value type.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> node = head;

        while (node is not null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    /// <summary>
    /// Method from IEnumerable interface that enables to use foreach for systems value type.
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Find index of the node according to given value.
    /// Retutns -1 if such value doesn't exist.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int IndexOf(T item)
    {
        Node<T> temp = head;

        if (temp is null)
        {
            return -1;
        }
        else
        {
            for (int i = 0; i < Count(); i++)
            {
                if (temp.Value.Equals(item))
                    return i;
                temp = temp.Next;
            }
            return -1;
        }
    }

    /// <summary>
    /// Inserts a node with given value in the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    public void Insert(int index, T item)
    {
        Node<T> node = new(item);

        Node<T>? current = head;
        Node<T>? previuos = null;
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
                current = current.Next;

                counter++;
            }

            previuos.Next = node;
            node.Next = current;
        }
    }

    /// <summary>
    /// Deletes a node by given index.
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAt(int index)
    {
        Node<T>? current = head;
        Node<T>? previuos = null;
        int counter = 0;

        while (counter != index)
        {
            previuos = current;
            current = current.Next;

            counter++;
        }

        if (previuos is null)
        {
            head = current.Next;
        }
        else
        {
            current = current.Next;
            previuos.Next = current;
        }
    }

    /// <summary>
    /// Deletes all nodes from LinkedList.
    /// </summary>
    public void Clear()
    {
        int count = Count();
        while (count != 0)
        {
            RemoveAt(0);
            count--;
        }
        if (Count() == 0)
        {
            Console.WriteLine("List is empty.");
        }
    }

    /// <summary>
    /// Returns true if given node exists in LinkedList.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        Node<T> node = head;

        for (int i = 0; i < Count(); i++)
        {
            if (node.Value.Equals(item))
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
    public void CopyTo(T[] array, int arrayIndex)
    {
        for (int i = 0; i < Count(); i++)
        {
            array.SetValue(this[i], arrayIndex++);
        }    
    }

    /// <summary>
    /// Removes the first occurrence of a given object from the LinkedList. 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Remove(T item)
    {
        int count = Count();

        RemoveAt(IndexOf(item));

        if (count > Count())
            return true;
        return false;
    }  
}