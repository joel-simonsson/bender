using System;

class VisitState : IEquatable<VisitState>
{
    private readonly IBender bender;
    private readonly int obstacles;

    public VisitState(IBender bender, int obstacles)
    {
        this.bender = bender;
        this.obstacles = obstacles;
    }

    public bool Equals(VisitState other)
    {
        return bender.Equals(other.bender) && (obstacles == other.obstacles);
    }
}
