class Bender : IBender
{
    private readonly Point position;
    private readonly Direction direction;
    private readonly bool drunk;
    private readonly bool magnetized;

    public Bender(Point position, Direction direction, bool drunk, bool magnetized)
    {
        this.position = position;
        this.direction = direction;
        this.drunk = drunk;
        this.magnetized = magnetized;
    }

    public Point Position
    {
        get
        {
            return position;
        }
    }

    public Direction CurrentDirection
    {
        get
        {
            return direction;
        }
    }

    public bool Drunk
    {
        get
        {
            return drunk;
        }
    }

    public bool Magnetized
    {
        get
        {
            return magnetized;
        }
    }

    public bool Equals(IBender other)
    {
        return (CurrentDirection == other.CurrentDirection) && (Position.Equals(other.Position)) && (Drunk == other.Drunk) && (Magnetized == other.Magnetized);
    }
}
