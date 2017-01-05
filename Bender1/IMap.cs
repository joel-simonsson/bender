interface IMap
{
    Point Start { get; }
    void ClearObstacle(Point nextTile);
    Tile MapTile(Point point);
    Point OtherTransporter(Point point);
    int NrOfObstacles { get; }
}
