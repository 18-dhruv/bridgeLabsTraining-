namespace LinkedList;

public class Node<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T Data)
    {
        this.Data = Data;
        this.Next = null;
    }
}