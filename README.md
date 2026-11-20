# Data Structures in C# (Structures de données)

My work for the Data Structures course at Collège LaSalle (February to April 2026): classic data structures written from scratch in C#, with unit tests, benchmarks that show their time complexity, and plots of the results.

## What's inside

| Folder | Contents |
| --- | --- |
| `DataTypes/` | Generic `DynamicArray<T>`, `Stack<T>`, `Queue<T>`, singly and doubly `LinkedList<T>` and a `BinarySearchTree`, with `IStack` and `IQueue` interfaces |
| `DataTypes/DataTypes.Tests/` | xUnit tests for the dynamic array, stack, queue and both linked lists |
| `DataTypes/DataTypes.Benchmarks/` | BenchmarkDotNet runs at N = 500, 5,000, 50,000 and 500,000 to compare growth rates |
| `DataTypes/tools/plot_benchmarks.py` | Turns the BenchmarkDotNet CSV report into time and memory charts |
| `SortingAlgorithms/` | Bubble, insertion and selection sort, with analysis code |
| `ManipulationDeTableaux/` | Array exercises, each method annotated with its time and space complexity |
| `ReferenceTypes2/` | Exercise on value types versus reference types |

## Run it
Requires the [.NET 9 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/Aoof/lci-struct-de-donnees.git
cd lci-struct-de-donnees/DataTypes

# Unit tests
dotnet test DataTypes.Tests

# Benchmarks (Release build; takes a few minutes)
dotnet run -c Release --project DataTypes.Benchmarks

# Plots (Python 3)
pip install -r requirements-plotting.txt
python tools/plot_benchmarks.py --out benchmark-plots
```

By default the plot script reads `BenchmarkDotNet.Artifacts/results/DataTypes.Benchmarks.ComplexityBenchmarks-report.csv`; pass `--csv` to point it at another report.

Each exercise folder (`SortingAlgorithms`, `ManipulationDeTableaux`, `ReferenceTypes2`) is its own project and runs with `dotnet run` from inside the folder.

## Author
Abdulrahman (Aoof) Mousa · [aoof.ca](https://aoof.ca)
