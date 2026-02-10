namespace ReferenceTypes2;

class Program
{
    public static void Main(string[] args)
    {
        Coordinate[] coorsArray = new Coordinate[3];
        coorsArray[0] = new Coordinate(0, 0);
        coorsArray[1] = new Coordinate(1, 1);
        coorsArray[2] = new Coordinate(2, 2);

        for (int i = 0; i < coorsArray.Length; i++)
        {
            Console.WriteLine($"[{i}] = " + coorsArray[i]);
        }
        
        Coordinate[] coorsArray2 = new Coordinate[coorsArray.Length];
        for (int i = 0; i < coorsArray.Length; i++)
        {
            coorsArray2[i] = coorsArray[i];
        }

        Coordinate.Increment(ref coorsArray2[0]);
    }
}