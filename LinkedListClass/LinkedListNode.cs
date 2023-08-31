using System;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes an element of the data structure LinkedList.
/// </summary>
/// <typeparam name="TValue">the type received by the instance</typeparam>
internal class LinkedListNode<TValue> : IComparable<LinkedListNode<TValue>>
    where TValue : IComparable<TValue>
{
    /// <summary>
    /// Value of the current node.
    /// </summary>
    public TValue? Value { get; set; }

    /// <summary>
    /// Node that follow the current one.
    /// </summary>
    public LinkedListNode<TValue>? Next { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="value">the value of the instance being created</param>
    public LinkedListNode(TValue value)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current Node.
    /// </summary>
    /// <param name="obj">the object being compared by value to the current Node</param>
    /// <returns>true, if the specified object is equal to the current Node; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        var node = (LinkedListNode<TValue>)obj;

        if (obj is not LinkedListNode<TValue>)
            return false;

        return Value!.CompareTo(node.Value) == 0;
    }

    /// <summary>
    /// Serves as an default hash function.
    /// </summary>
    /// <returns>a hash code for the current object</returns>
    public override int GetHashCode() =>
        HashCode.Combine(Value);

    /// <inheritdoc/>
    public int CompareTo(LinkedListNode<TValue>? other) =>
        Value!.CompareTo(other!.Value);

    /// <summary>
    /// Determines if two Nodes are equal.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if Nodes are equal; otherwise, false.</returns>
    public static bool operator ==(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return node1.Value!.CompareTo(node2.Value) == 0;
    }

    /// <summary>
    /// Determines if two Nodes are not equal.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if Nodes are not equal; otherwise, false.</returns>
    public static bool operator !=(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return !(node1 == node2);
    }

    /// <summary>
    /// Determines if the left Node less than the right one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node less than the right one; otherwise, false.</returns>
    public static bool operator <(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return node1.Value!.CompareTo(node2.Value) < 0;
    }

    /// <summary>
    /// Determines if the left Node greater than the right one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node greater than the right one; otherwise, false.</returns>
    public static bool operator >(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return node1.Value!.CompareTo(node2.Value) > 0;
    }

    /// <summary>
    /// Determines, if the left Node less than or equal to the right one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node less than or equal to the right one; otherwise, false.</returns>
    public static bool operator <=(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return (node1 == node2) || (node1 < node2);
    }

    /// <summary>
    /// Determines, if the left Node greater than or equal to the right one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node greater than or equal to the right one; otherwise, false.</returns>
    public static bool operator >=(LinkedListNode<TValue>? node1, LinkedListNode<TValue>? node2)
    {
        if (node1 is null || node2 is null)
            return false;
        return (node1 == node2) || (node1 > node2);
    }
}