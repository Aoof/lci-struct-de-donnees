namespace DataTypes.Tests;

public class QueueTests
{
    [Fact]
    public void EnqueueAndDequeue_ShouldRespectFifoAndCount()
    {
        DataTypes.Queue<int> queue = new();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Dequeue());
        Assert.Equal(30, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Contains_ShouldTraverseEntireQueue()
    {
        DataTypes.Queue<int> queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.True(queue.Contains(3));
        Assert.False(queue.Contains(99));
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ShouldThrow()
    {
        DataTypes.Queue<int> queue = new();
        Assert.Throws<IndexOutOfRangeException>(() => queue.Dequeue());
    }

    [Fact]
    public void Queue_ShouldRecoverAfterBecomingEmpty()
    {
        DataTypes.Queue<int> queue = new();
        queue.Enqueue(5);

        Assert.Equal(5, queue.Dequeue());
        Assert.Equal(0, queue.Count);

        queue.Enqueue(9);
        Assert.Equal(9, queue.Peek());
        Assert.Equal(1, queue.Count);
    }
}
