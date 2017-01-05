using System.Collections.Generic;

class MovePattern : IMovePattern
{
    public Direction InitialDirection
    {
        get
        {
            return Direction.SOUTH;
        }
    }

    public List<Direction> NextDirections(bool magnetized)
    {
        if (!magnetized)
        {
            return new List<Direction> { Direction.SOUTH, Direction.EAST, Direction.NORTH, Direction.WEST };
        }
        return new List<Direction> { Direction.WEST, Direction.NORTH, Direction.EAST, Direction.SOUTH };
    }

    public bool IsAllowed(Tile tile, bool drunk)
    {
        var okToMove = new List<Tile> {
            Tile.Normal,
            Tile.North,
            Tile.East,
            Tile.West,
            Tile.South,
            Tile.Beer,
            Tile.Magnetize,
            Tile.Transporter,
            Tile.SuicideBooth
        };

        if (okToMove.Contains(tile))
        {
            return true;
        }
        if (drunk && tile == Tile.Obstacle)
        {
            return true;
        }
        return false;
    }
}
