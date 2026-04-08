namespace DataTypes.Tests;

public class DoublyLinkedListTests
{
    [Fact]
    public void AddInsertRemove_ShouldMaintainForwardAndReverseTraversal()
    {
        DoublyLinkedList<int> list = new();

        list.AddFirst(2);
        list.AddFirst(1);
        list.AddLast(4);
        list.InsertAt(2, 3);

        Assert.Equal(new[] { 1, 2, 3, 4 }, list.ToArray());
        Assert.Equal(new[] { 4, 3, 2, 1 }, list.EnumerateReverse().ToArray());

        Assert.Equal(3, list.RemoveAt(2));
        Assert.Equal(4, list.RemoveLast());
        Assert.Equal(1, list.RemoveFirst());
        Assert.Equal(new[] { 2 }, list.ToArray());
        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void FindAndFindLast_ShouldWorkFromBothDirections()
    {
        DoublyLinkedList<int> list = new();
        list.AddLast(7);
        list.AddLast(9);
        list.AddLast(7);

        Assert.Equal(0, list.Find(7));
        Assert.Equal(2, list.FindLast(7));
        Assert.Equal(-1, list.Find(100));
    }

    [Fact]
    public void RemoveFirst_OnEmpty_ShouldThrow()
    {
        DoublyLinkedList<int> list = new();
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveFirst());
    }
}
