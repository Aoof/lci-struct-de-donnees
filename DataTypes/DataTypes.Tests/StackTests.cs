namespace DataTypes.Tests;

public class StackTests
{
    [Fact]
    public void PushAndPop_ShouldRespectLifoAndCount()
    {
        DataTypes.Stack<int> stack = new();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Count);
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Clear_ShouldResetCountAndContent()
    {
        DataTypes.Stack<int> stack = new();
        stack.Push(8);
        stack.Push(9);

        stack.Clear();

        Assert.Equal(0, stack.Count);
        Assert.False(stack.Contains(8));
        Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_OnEmptyStack_ShouldThrow()
    {
        DataTypes.Stack<int> stack = new();
        Assert.Throws<IndexOutOfRangeException>(() => stack.Peek());
    }
}
