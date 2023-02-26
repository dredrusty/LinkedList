using System.Collections;
using System.Text;


namespace DSLinkedList;

/// <summary>
/// Describes LinkedList data structure and implements CRUD functionality.
/// </summary>
public class LinkedListClass<T> : IEnumerable<T>
    where T: IComparable<T>
{
    /// <summary>
    /// Implement indexator.
    /// Allow to access to node through []:
    /// 1. var q = "name of LinkedList"[index];
    /// 2. "name of LinkedList"[index] = value;
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public T? this[int i]
    {
        get => Get(i).Value;
        set => Get(i).Value = value;
    }

    private Node<T>? head;
    private Node<T>? tail;

    /// <summary>
    /// Counter of the elements in LinkedList.
    /// </summary>
    /// <returns></returns>
    public int CountElements()
    {
        int count = 1;
        
        Node<T> current = head;

        while (current.Next != null)
        {
            current = current.Next;
            count ++;
        }
        return count;
    }

    /// <summary>
    /// Adding a new node in the end of the LinkedList.
    /// If LinkedList is empty, node will be added in the first position.
    /// </summary>
    /// <param name="value"></param>
    public void AddNode(T value)
    {
        Node<T> node = new(value);

        if (head == null)
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
    public void AddNode(int index, T value)
    {
        Node<T> node = new(value);

        Node<T> current = head;
        Node<T> previuos = null;
        int counter = 0;

        if (index == 0)
        {
            node.Next = head;
            head = node;
            if (node.Next == null)
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
    /// Removing a node by a value.
    /// </summary>
    /// <param name="value"></param>
    public void DeleteNode(T value)
    {
        Node<T>? current = head;
        Node<T>? previous = null;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        tail = previous;
                    }
                }
                else
                {
                    head = head.Next;

                    if (head == null)
                    {
                        tail = null;
                    }
                }
            }
            previous = current;
            current = current.Next;
        }
    }

    /// <summary>
    /// Delete a node by index.
    /// </summary>
    /// <param name="index"></param>
    public void DeleteNodeByIndex(int index)
    {
        Node<T> current = head;
        Node<T> previuos = null;
        int counter = 0;

        while (counter != index)
        {
            previuos = current;
            current = current.Next;

            counter++;
        }
        current = current.Next;
        previuos.Next = current;
    }

    /// <summary>
    /// Finding a value of the node by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Node<T> Get(int index)
    {
        var counter = 0;

        Node<T> node = head;

        while (counter != index)
        {
            node = node.Next;
            counter++;
        }

        return node;
    }

    /// <summary>
    /// Updates value of the given by index node.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Update(int index, T value)
    {
        var counter = 0;

        Node<T> node = head;

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
    /// Method from IEnumerable interface that enables to use foreach.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        Node<T> node = head;

        while (node.Next is not null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    #region
    /// <summary>
    /// Describes an element of the data structure LinkedList.
    /// Generics are used.
    /// </summary>
    public class Node<T> : IComparable<Node<T>>
        where T : IComparable<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Method that compares given object with the calling Fraction's object by value.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Node<T>)
                return false;
            else
            {
                Node<T> node = (Node<T>)obj;
                if (Value.CompareTo(node.Value) == 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Because of overrided Equals(object? obj).
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() =>
            HashCode.Combine(Value);

        /// <summary>
        /// Allow to use method Sort.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Node<T>? other)
        {
            return Value.CompareTo(other.Value);
        }

        public static bool operator ==(Node<T> node1, Node<T> node2)
        {
            if (node1.Value.CompareTo(node2.Value) == 0)
                return true;
            return false;
        }

        public static bool operator !=(Node<T> node1, Node<T> node2) =>
            !(node1 == node2);

        public static bool operator <(Node<T> node1, Node<T> node2)
        {
            if (node1.Value.CompareTo(node2.Value) == -1)
                return true;
            return false;
        }

        public static bool operator >(Node<T> node1, Node<T> node2)
        {
            if (node1.Value.CompareTo(node2.Value) == 1)
                return true;
            return false;
        }

        public static bool operator <=(Node<T> node1, Node<T> node2)
        {
            if ((node1.Value.CompareTo(node2.Value) == 0) || 
                (node1.Value.CompareTo(node2.Value) == -1))
                return true; 
            return false;
        }

        public static bool operator >=(Node<T> node1, Node<T> node2)
        {
            if ((node1.Value.CompareTo(node2.Value) == 0) ||
                (node1.Value.CompareTo(node2.Value) == 1))
                return true;
            return false;
        }
    }
    #endregion
}

