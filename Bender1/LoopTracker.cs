using System;
using System.Collections.Generic;
using System.Linq;

class LoopTracker : ILoopTracker
{
    private readonly Dictionary<Point, List<VisitState>> visits;

    public LoopTracker()
    {
        visits = new Dictionary<Point, List<VisitState>>();
    }

    public ILoopTracker Visit(IBender bender, int obstacles)
    {
        var place = bender.Position;
        var visitState = new VisitState(bender, obstacles);
        if (!visits.ContainsKey(place))
        {
            visits[place] = new List<VisitState>();
            visits[place].Add(visitState);
        }
        else if (!visits[place].Contains(visitState))
        {
            visits[place].Add(visitState);
        }
        else if (visits[place].Contains(visitState))
        {
            throw new Exception("LOOP");
        }
        return this;
    }
}
