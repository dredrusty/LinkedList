using System;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes an element of the data structure LinkedList.
/// </summary>
public class LinkedListNode<T> : IComparable<LinkedListNode<T>>
    where T : IComparable<T>
{
    /// <summary>
    /// Value of the current node.
    /// </summary>
    public T? Value { get; set; }

    /// <summary>
    /// Node, following the current one.
    /// </summary>
    public LinkedListNode<T>? Next { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value"></param>
    public LinkedListNode(T value)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current Node.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>true, if the specified object is equal to the current Node; oterwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        else
        {
            LinkedListNode<T> node = (LinkedListNode<T>)obj;
            if (Value!.CompareTo(node.Value) == 0)
                return true;
            return false;
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode() =>
        HashCode.Combine(Value);

    /// <inheritdoc/>
    public int CompareTo(LinkedListNode<T>? other) => 
        Value!.CompareTo(other!.Value);

    /// <summary>
    /// Determines if two Nodes are equal.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>true, if Nodes are equal; otherwise, false.</returns>
    public static bool operator ==(LinkedListNode<T> node1, LinkedListNode<T> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) == 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines if two Nodes are not eqaul.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>True, if Nodes are not equal; otherwise, false.</returns>
    public static bool operator !=(LinkedListNode<T> node1, LinkedListNode<T> node2) =>
        !(node1 == node2);

    /// <summary>
    /// Determines if the first Node less than the second one.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>True, if the first Node less than the second one; otherwise, false.</returns>
    public static bool operator <(LinkedListNode<T> node1, LinkedListNode<T> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) < 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines if the first Node greater than the second one.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>True, if the first Node greater than the second one; otherwise, false.</returns>
    public static bool operator >(LinkedListNode<T> node1, LinkedListNode<T> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines, if the first Node less than or equal to the second one.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>True, if the first Node less than or equal to the second one; otherwise, false.</returns>
    public static bool operator <=(LinkedListNode<T> node1, LinkedListNode<T> node2)
    {
        if ((node1.Value!.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) < 0))
            return true;
        return false;
    }

    /// <summary>
    /// Determines, if the first Node greater than or equal to the second one.
    /// </summary>
    /// <param name="node1"></param>
    /// <param name="node2"></param>
    /// <returns>True, if the first Node greater than or equal to the second one; otherwise, false.</returns>
    public static bool operator >=(LinkedListNode<T> node1, LinkedListNode<T> node2)
    {
        if ((node1.Value!.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) > 0))
            return true;
        return false;
    }
}