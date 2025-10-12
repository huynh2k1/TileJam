using UnityEngine;

public static class DirectionUtils
{
    public static Vector2Int ToOffset(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up: return new Vector2Int(1, 0);
            case Direction.Down: return new Vector2Int(-1, 0);
            case Direction.Left: return new Vector2Int(0, -1);
            case Direction.Right: return new Vector2Int(0, 1);
            default: return Vector2Int.zero;
        }
    }

    public static Direction Opposite(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up: return Direction.Down;
            case Direction.Down: return Direction.Up;
            case Direction.Left: return Direction.Right;
            case Direction.Right: return Direction.Left;
            default: return dir;
        }
    }

    public static Vector3 ToEulerAngles(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return new Vector3(0, 0, 0);
            case Direction.Right:
                return new Vector3(0, 90, 0);
            case Direction.Down:
                return new Vector3(0, 180, 0);
            case Direction.Left:
                return new Vector3(0, -90, 0);
            default:
                return Vector3.zero;
        }
    }
}
