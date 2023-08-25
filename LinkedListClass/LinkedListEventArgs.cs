
using System;
using System.Runtime.CompilerServices;

namespace VV.DataStructure.LinkedList;

/// <summary>
/// Describes object that containes the event data.
/// </summary>
/// <typeparam name="T">The type of the value contained in the LinkedList.</typeparam>
public record LinkedListEventArgs<T>
    where T : IComparable<T>
{
    /// <summary>
    /// Gets the value of the node associated with the event.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Gets the index of the node associated with the event.
    /// </summary>
    public int Index { get; }

    /// <summary>
    /// Gets the name of the method that triggered the event.
    /// </summary>
    public string TriggerMethod { get; }

    /// <summary>
    /// Initializes a new instance of the LinkedListEventArgs class with the specified value, index and method that rised event.
    /// </summary>
    /// <param name="value">Value of the node associated with the event.</param>
    /// <param name="index">The index of the node associated with the event.</param>
    /// <param name="triggerMethod">The name of the method that triggered the event.</param>
    public LinkedListEventArgs(T value, int index, [CallerMemberName] string triggerMethod = "")
    {
        Value = value;
        Index = index;
        TriggerMethod = triggerMethod;
    }

    /// <summary>
    /// Initializes a new instance of the LinkedListEventArgs class with the name of the calling method.
    /// </summary>
    /// <param name="triggerMethod">The name of the method that triggered the event.</param>
    public LinkedListEventArgs([CallerMemberName] string triggerMethod = "")
    {
        TriggerMethod = triggerMethod;
    }
}