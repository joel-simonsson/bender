using System;

interface IBender : IEquatable<IBender>
{
    Point Position { get; }
    Direction CurrentDirection { get; }
    bool Drunk { get; }
    bool Magnetized { get; }
}
