static class Extensions
{
    public static Tile GetTile(this char tileChar)
    {
        switch (tileChar)
        {
            case '@':
                return Tile.Start;
            case '$':
                return Tile.SuicideBooth;
            case 'X':
                return Tile.Obstacle;
            case '#':
                return Tile.HardObstacle;
            case 'B':
                return Tile.Beer;
            case 'I':
                return Tile.Magnetize;
            case 'T':
                return Tile.Transporter;
            case 'N':
                return Tile.North;
            case 'S':
                return Tile.South;
            case 'W':
                return Tile.West;
            case 'E':
                return Tile.East;
            default:
                return Tile.Normal;
        }
    }

    public static Point GetDesiredPosition(this IBender bender)
    {
        switch (bender.CurrentDirection)
        {
            case Direction.SOUTH:
                return bender.Position.AddY(1);
            case Direction.EAST:
                return bender.Position.AddX(1);
            case Direction.NORTH:
                return bender.Position.AddY(-1);
            case Direction.WEST:
                return bender.Position.AddX(-1);
            default:
                return bender.Position;
        }
    }

    public static Point AddX(this Point point, int x)
    {
        return new Point(point.X + x, point.Y);
    }

    public static Point AddY(this Point point, int y)
    {
        return new Point(point.X, point.Y + y);
    }
}