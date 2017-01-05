using System.Collections.Generic;
using System.Linq;

class Map : IMap
{
    private char[,] map;
    private readonly Point start;
    List<Point> transporters = new List<Point>();
    private int nrOfObstacles = 0;

    public Map(int width, int height, string[] mapSource)
    {
        map = new char[width, height];
        for (int y = 0; y < mapSource.Length; y++)
        {
            var row = mapSource[y].ToCharArray();
            for (int x = 0; x < row.Length; x++)
            {
                var tileChar = row[x];
                var tile = row[x].GetTile();
                map[x, y] = tileChar;
                if (tile == Tile.Start)
                {
                    start = new Point(x, y);
                }
                if (tile == Tile.Transporter)
                {
                    transporters.Add(new Point(x, y));
                }
                if (tile == Tile.Obstacle)
                {
                    nrOfObstacles++;
                }
            }
        }
    }

    public Point Start
    {
        get
        {
            return start;
        }
    }

    public int NrOfObstacles
    {
        get
        {
            return nrOfObstacles;
        }
    }

    public Point OtherTransporter(Point point)
    {
        return transporters.First(transporter => !transporter.Equals(point));
    }

    public Tile MapTile(Point tile)
    {
        return map[tile.X, tile.Y].GetTile();
    }

    public void ClearObstacle(Point tile)
    {
        map[tile.X, tile.Y] = ' ';
        nrOfObstacles--;
    }
}
