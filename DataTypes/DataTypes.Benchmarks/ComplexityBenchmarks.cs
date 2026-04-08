using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using DataTypes;

namespace DataTypes.Benchmarks;

[MemoryDiagnoser]
[ShortRunJob]
public class ComplexityBenchmarks
{
    [Params(500, 5_000, 50_000, 500_000)]
    public int N;

    private int[] dataset = Array.Empty<int>();

    [GlobalSetup]
    public void Setup()
    {
        dataset = Enumerable.Range(0, N).ToArray();
    }

    [Benchmark]
    public void StackPush_PushN()
    {
        DataTypes.Stack<int> stack = new();
        for (int i = 0; i < N; i++)
            stack.Push(dataset[i]);
    }

    [Benchmark]
    public void QueueEnqueue_EnqueueN()
    {
        DataTypes.Queue<int> queue = new();
        for (int i = 0; i < N; i++)
            queue.Enqueue(dataset[i]);
    }

    [Benchmark]
    public bool QueueContains_LastElement()
    {
        DataTypes.Queue<int> queue = new();
        for (int i = 0; i < N; i++)
            queue.Enqueue(dataset[i]);

        return queue.Contains(N - 1);
    }

    [Benchmark]
    public void DynamicArrayAdd_AddN()
    {
        DynamicArray<int> array = new(2);
        for (int i = 0; i < N; i++)
            array.Add(dataset[i]);
    }

    [Benchmark]
    public bool DynamicArrayContains_LastElement()
    {
        DynamicArray<int> array = new(dataset);
        return array.Contains(N - 1);
    }

    [Benchmark]
    public int LinkedListFind_LastElement()
    {
        DataTypes.LinkedList<int> list = new();
        for (int i = 0; i < N; i++)
            list.AddLast(dataset[i]);

        return list.Find(N - 1);
    }

    [Benchmark]
    public int DoublyLinkedListFindLast_FirstElement()
    {
        DataTypes.DoublyLinkedList<int> list = new();
        for (int i = 0; i < N; i++)
            list.AddLast(dataset[i]);

        return list.FindLast(0);
    }
}
