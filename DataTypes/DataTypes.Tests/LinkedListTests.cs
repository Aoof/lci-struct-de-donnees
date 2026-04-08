namespace DataTypes.Tests;

public class LinkedListTests
{
    [Fact]
    public void AddFirstAddLast_InsertAndRemove_ShouldKeepOrderAndCount()
    {
        DataTypes.LinkedList<int> list = new();

        list.AddFirst(2);
        list.AddFirst(1);
        list.AddLast(4);
        list.InsertAt(2, 3);

        Assert.Equal(4, list.Count);
        Assert.Equal(new[] { 1, 2, 3, 4 }, list.ToArray());

        Assert.Equal(1, list.RemoveFirst());
        Assert.Equal(4, list.RemoveLast());
        Assert.Equal(2, list.RemoveAt(0));
        Assert.Equal(1, list.Count);
        Assert.Equal(new[] { 3 }, list.ToArray());
    }

    [Fact]
    public void FindAndFindLast_ShouldReturnExpectedIndices()
    {
        DataTypes.LinkedList<int> list = new();
        list.AddLast(5);
        list.AddLast(7);
        list.AddLast(5);

        Assert.Equal(0, list.Find(5));
        Assert.Equal(2, list.FindLast(5));
        Assert.Equal(-1, list.Find(99));
    }

    [Fact]
    public void RemoveAt_InvalidIndex_ShouldThrow()
    {
        DataTypes.LinkedList<int> list = new();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
    }
}
