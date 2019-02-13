namespace Program
{
    interface INode<T>
    {
        T[] Neighbours { get; }
        Point Position { get; }
    }
}