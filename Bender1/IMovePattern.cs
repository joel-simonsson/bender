using System.Collections.Generic;


interface IMovePattern
{
    Direction InitialDirection { get; }
    List<Direction> NextDirections(bool magnetized);
    bool IsAllowed(Tile tile, bool drunk);
}
