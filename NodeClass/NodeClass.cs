namespace DSLinkedList;

/// <summary>
/// Describes an element of the data structure LinkedList.
/// Generics are used.
/// </summary>
public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}