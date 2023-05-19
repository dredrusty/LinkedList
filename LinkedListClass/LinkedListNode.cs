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
    /// Node thats follow the current one.
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
    /// <returns>true, if the specified object is equal to the current Node; oterwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        
        LinkedListNode<TValue> node = (LinkedListNode<TValue>)obj;

        if (obj is not LinkedListNode<TValue>)
            return false;

            if (Value!.CompareTo(node.Value) == 0)
                return true;
            return false;
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
    /// <param name="node2">the righr operand</param>
    /// <returns>true, if Nodes are equal; otherwise, false.</returns>
    public static bool operator ==(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) == 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines if two Nodes are not eqaul.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if Nodes are not equal; otherwise, false.</returns>
    public static bool operator !=(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2) =>
        !(node1 == node2);

    /// <summary>
    /// Determines if the first Node less than the second one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node less than the right one; otherwise, false.</returns>
    public static bool operator <(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) < 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines if the first Node greater than the second one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node greater than the right one; otherwise, false.</returns>
    public static bool operator >(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2)
    {
        if (node1.Value!.CompareTo(node2.Value) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// Determines, if the first Node less than or equal to the second one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node less than or equal to the right one; otherwise, false.</returns>
    public static bool operator <=(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2)
    {
        if ((node1.Value!.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) < 0))
            return true;
        return false;
    }

    /// <summary>
    /// Determines, if the first Node greater than or equal to the second one.
    /// </summary>
    /// <param name="node1">the left operand</param>
    /// <param name="node2">the right operand</param>
    /// <returns>true, if the left Node greater than or equal to the right one; otherwise, false.</returns>
    public static bool operator >=(LinkedListNode<TValue> node1, LinkedListNode<TValue> node2)
    {
        if ((node1.Value!.CompareTo(node2.Value) == 0) ||
            (node1.Value.CompareTo(node2.Value) > 0))
            return true;
        return false;
    }
}