using System;
using System.Linq;

/**
* Auto-generated code below aims at helping you parse
* the standard input according to the problem statement.
**/
class Solution
{
    static void Main(string[] args)
    {
        IMap map = new Map1515();
        IMovePattern movePattern = new MovePattern();
        ILoopTracker loopTracker = new LoopTracker();
        ITracker tracker = new TrackerRecursive(map, movePattern, loopTracker);
        var path = tracker.TrackBender().ToList();
      
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        path.ToList().ForEach(Console.WriteLine);
        Console.ReadLine();
    }
}
