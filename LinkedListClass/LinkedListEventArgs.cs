
using System;

namespace VV.DataStructure.LinkedList;


public class LinkedListEventArgs<T>
    where T : IComparable<T>
{
    public string Text { get; }

    public LinkedListEventArgs(string text)
    {
        Text = text;
    }
}