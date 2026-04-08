namespace DataTypes.Tests;

public class DynamicArrayTests
{
    [Fact]
    public void Add_ShouldGrowCapacity_WhenFull()
    {
        DynamicArray<int> array = new(2);

        array.Add(1);
        array.Add(2);
        array.Add(3);

        Assert.Equal(3, array.Count);
        Assert.True(array.Capacity >= 3);
    }

    [Fact]
    public void RemoveAt_ShouldShiftTailLeft()
    {
        DynamicArray<int> array = new([10, 20, 30, 40]);

        array.RemoveAt(1);

        Assert.Equal(3, array.Count);
        Assert.False(array.Contains(20));
        Assert.True(array.Contains(30));
        Assert.True(array.Contains(40));
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemNotFound()
    {
        DynamicArray<int> array = new([1, 2, 3]);
        Assert.False(array.Remove(99));
    }
}
