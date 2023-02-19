namespace DSLinkedList;

/// <summary>
/// Describes LinkedList data structure and implements CRUD functionality.
/// </summary>
public class LinkedList<T>
{
    /// <summary>
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
    public int Count()
    {
        int count = 0;
        
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
    public void Add(T value)
    {
        Node<T> node = new(value);

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

        Node<T> current = head;
        Node<T> previuos = null;
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
    /// Delete a node by index.
    /// </summary>
    /// <param name="index"></param>
    public void Delete(int index)
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
}