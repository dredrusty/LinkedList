namespace DSLinkedList;

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
    /// Method that compares given Node<T> with the calling Node<T> by value.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
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
    /// Needs for override nethods ==, !=, >, >=, <, <=).
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Node<T>? other) => 
        Value.CompareTo(other.Value);

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
        if (node1.Value.CompareTo(node2.Value) < 0)
            return true;
        return false;
    }

    public static bool operator >(Node<T> node1, Node<T> node2)
    {
        if (node1.Value.CompareTo(node2.Value) > 0)
            return true;
        return false;
    }

    public static bool operator <=(Node<T> node1, Node<T> node2)
    {
        if ((node1.Value.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) < 0))
            return true;
        return false;
    }

    public static bool operator >=(Node<T> node1, Node<T> node2)
    {
        if ((node1.Value.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) > 0))
            return true;
        return false;
    }
}