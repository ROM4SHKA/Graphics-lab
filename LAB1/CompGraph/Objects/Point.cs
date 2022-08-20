using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Point
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator +(Point point, Vector vector)
        {
            return new Vector(point.x + vector.x, point.y + vector.y, point.z + vector.z);
        }

        public static Vector operator -(Point pointOne, Point pointTwo)
        {
            return new Vector(pointOne.x - pointTwo.x, pointOne.y - pointTwo.y, pointOne.z - pointTwo.z);
        }


        public static float GetDistance(Point pointOne, Point pointTwo)
        {
            float deltaX = pointTwo.x - pointOne.x;
            float deltaY = pointTwo.y - pointOne.y;
            float deltaZ = pointTwo.z - pointOne.z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}