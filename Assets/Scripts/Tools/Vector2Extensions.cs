using UnityEngine;

public static class Vector2Extensions
{
    public static bool IsCloserThan(this Vector2 start, Vector2 other, float currentSqrDistance)
    {
        return start.SqrDistance(other) < currentSqrDistance;
    }

    public static float SqrDistance(this Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }
}
