enum Direction : byte
{
    North,
    East,
    South,
    West
}

public class CoordinateCalculator
{
    private readonly string directions;
    private Direction direction = Direction.North;
    private int posX = 0;
    private int posY = 0;
    private (int, int) partTwoLocation;
    private HashSet<(int, int)> previousPositions = new HashSet<(int, int)>();
    public CoordinateCalculator(string directions)
    {
        this.directions = directions;
        previousPositions.Add((0, 0));
        Move();
    }

    private void Move()
    {
        foreach (var item in directions.Split(", "))
        {
            var turn = item[0];
            var distance = int.Parse(new string(item.Skip(1).ToArray()));

            TurnAndMove(turn, distance);
        }
    }

    private void TurnAndMove(char turn, int distance)
    {
        switch (turn)
        {
            case 'R':
                direction++;
                if ((byte)direction == 4) direction = Direction.North;
                break;
            case 'L':
                direction--;
                if ((byte)direction == 255) direction = Direction.West;
                break;
        }

        switch (direction)
        {
            case Direction.North:
                for (int d = 0; d < distance; d++)
                {
                    if (!previousPositions.Add((posX, ++posY)) && partTwoLocation == (0, 0)) partTwoLocation = (posX, posY);
                }
                break;
            case Direction.East:
                for (int d = 0; d < distance; d++)
                {
                    if (!previousPositions.Add((++posX, posY)) && partTwoLocation == (0, 0)) partTwoLocation = (posX, posY);
                }
                break;
            case Direction.South:
                for (int d = 0; d < distance; d++)
                {
                    if (!previousPositions.Add((posX, --posY)) && partTwoLocation == (0, 0)) partTwoLocation = (posX, posY);
                }
                break;
            case Direction.West:
                for (int d = 0; d < distance; d++)
                {
                    if (!previousPositions.Add((--posX, posY)) && partTwoLocation == (0, 0)) partTwoLocation = (posX, posY);
                }
                break;
        }
    }

    public int DistanceFromStart => Math.Abs(posX) + Math.Abs(posY);

    public int DistanceOfFirstLocationVisitedTwice => Math.Abs(partTwoLocation.Item1) + Math.Abs(partTwoLocation.Item2);
}