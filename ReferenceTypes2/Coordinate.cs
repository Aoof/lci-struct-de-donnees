namespace ReferenceTypes2;

class Coordinate
{
    private int x;
    private int y;

    public int X {get { return x; } private set { x = value; }}
    public int Y {get { return y; } private set { y = value; }}

    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Coordinate() : this(0, 0) {}
    public Coordinate(Coordinate entity) : this(entity.X, entity.Y) {}

    public Coordinate Clone()
    {
        return (Coordinate)MemberwiseClone();
    }

    public override string ToString()
    {
        return $"X = {X}, Y = {Y}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinate coordinate)
        {
            return X == coordinate.X && Y == coordinate.Y;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static void Increment(ref int a)
    {
        a++;
        Console.WriteLine("Inside: " + a);
    }

    public static void Increment(ref Coordinate coor)
    {
        coor.X++;
        coor.Y++;
        Console.WriteLine("Inside: " + coor);
    }

}