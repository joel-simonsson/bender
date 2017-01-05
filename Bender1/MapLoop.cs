using System.Collections.Generic;


class MapLoop : Map
{
    private List<string> map;

    public MapLoop() : base(15, 15, new string[] {
        "###############",
        "#      IXXXXX #",
        "#  @          #",
        "#E S          #",
        "#             #",
        "#  I          #",
        "#  B          #",
        "#  B   S     W#",
        "#  B   T      #",
        "#             #",
        "#         T   #",
        "#         B   #",
        "#N          W$#",
        "#        XXXX #",
        "###############"
    })
    {
    }
}