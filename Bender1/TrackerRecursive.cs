using System;
using System.Collections.Generic;
using System.Linq;

class TrackerRecursive : ITracker
{
    private readonly ILoopTracker loopTracker;
    private readonly IMap map;
    private readonly IMovePattern movePattern;

    public TrackerRecursive(IMap map, IMovePattern movePattern, ILoopTracker loopTracker)
    {
        this.map = map;
        this.movePattern = movePattern;
        this.loopTracker = loopTracker;
    }

    public IEnumerable<string> TrackBender()
    {
        try
        {
            return TrackBender(new Bender(map.Start, movePattern.InitialDirection, false, false));
        }
        catch (Exception c)
        {
            return new List<string> { "LOOP" };
        }
    }

    private IEnumerable<string> TrackBender(IBender bender)
    {
        //Console.Error.WriteLine(bender.CurrentDirection);
        loopTracker.Visit(bender, map.NrOfObstacles);

        var ret = new List<string>();

        var directions = new List<Direction> { bender.CurrentDirection };
        directions.AddRange(movePattern.NextDirections(bender.Magnetized));

        var nextBender = directions.Select(direction => new Bender(bender.Position, direction, bender.Drunk, bender.Magnetized)).First(b =>
        {
            return movePattern.IsAllowed(map.MapTile(b.GetDesiredPosition()), b.Drunk);
        });
        var currentDirection = nextBender.CurrentDirection;

        var nextPosition = nextBender.GetDesiredPosition();
        var nextTile = map.MapTile(nextPosition);
        if (nextTile == Tile.Beer)
        {
            nextBender = new Bender(nextPosition, nextBender.CurrentDirection, !nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.Magnetize)
        {
            nextBender = new Bender(nextPosition, nextBender.CurrentDirection, nextBender.Drunk, !nextBender.Magnetized);
        }
        else if (nextTile == Tile.Transporter)
        {
            nextBender = new Bender(map.OtherTransporter(nextPosition), nextBender.CurrentDirection, nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.Obstacle)
        {
            map.ClearObstacle(nextPosition);
            nextBender = new Bender(nextPosition, nextBender.CurrentDirection, nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.South)
        {
            nextBender = new Bender(nextPosition, Direction.SOUTH, nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.East)
        {
            nextBender = new Bender(nextPosition, Direction.EAST, nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.North)
        {
            nextBender = new Bender(nextPosition, Direction.NORTH, nextBender.Drunk, nextBender.Magnetized);
        }
        else if (nextTile == Tile.West)
        {
            nextBender = new Bender(nextPosition, Direction.WEST, nextBender.Drunk, nextBender.Magnetized);
        }
        else
        {
            nextBender = new Bender(nextPosition, nextBender.CurrentDirection, nextBender.Drunk, nextBender.Magnetized);
        }

        ret.Add(currentDirection.ToString());
        if (nextTile == Tile.SuicideBooth)
        {
            return ret;
        }

        ret.AddRange(TrackBender(nextBender));
        return ret;
    }
}
