using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Point
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }

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

        public object RotateX(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newY = (float)(y * Math.Cos(degree) - z * Math.Sin(degree));
            float newZ = (float)(y * Math.Sin(degree) + z * Math.Cos(degree));
            y = newY;
            z = newZ;
            return this;

        }

        public object RotateY(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newX = (float)(x * Math.Cos(degree) + z * Math.Sin(degree));
            float newZ = (float)(z * Math.Cos(degree) - x * Math.Sin(degree));
            x = newX;
            z = newZ;
            return this;
        }

        public object RotateZ(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);

            float newX = (float)(x * Math.Cos(degree) - y * Math.Sin(degree));
            float newY = (float)(y * Math.Cos(degree) + x * Math.Sin(degree));
            x = newX;
            y = newY;
            return this;
        }

        public object Translate(Vector direction)
        {
            x += direction.x;
            y += direction.y;
            z += direction.z;
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            x *= kx;
            y *= ky;
            z *= kz;
            return this;
        }

        public static float GetDistance(Point pointOne, Point pointTwo)
        {
            float deltaX = pointTwo.x - pointOne.x;
            float deltaY = pointTwo.y - pointOne.y;
            float deltaZ = pointTwo.z - pointOne.z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
        public static float Distance(Point pointOne, Point pointTwo)
        {
            float deltaX = pointTwo.x - pointOne.x;
            float deltaY = pointTwo.y - pointOne.y;
            float deltaZ = pointTwo.z - pointOne.z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}