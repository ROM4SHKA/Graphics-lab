using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Vector
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector GetVector(Point p1, Point p2)
        {
            return new Vector(p2.x - p1.x, p2.y - p1.y, p2.z - p1.z);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public static Vector Normilize(Vector vector)
        {
            var mag = vector.Magnitude();
            if (mag > 0)
            {
                return new Vector(vector.x / mag, vector.y / mag, vector.z / mag);
            }
            return vector;
        }

        public static Vector Cross(Vector u, Vector v)
        {
            return new Vector(
                u.y * v.z - u.z * v.y,
                u.z * v.x - u.x * v.z,
                u.x * v.y - u.y * v.x);
        }

        public static Vector Negate(Vector u)
        {
            return new Vector(-u.x, -u.y, -u.z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator *(float v1, Vector v2)
        {
            return new Vector(v1 * v2.x, v1 * v2.y, v1 * v2.z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static float operator *(Vector v1, Vector v2)
        {
            return (float)(v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        }
    }
}