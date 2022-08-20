using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Vector
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }

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

        public static float GetLenght(Vector u)
        {
            return (float)(Math.Sqrt(u * u));
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

        public object RotateX(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newY = (float)(y * Math.Cos(degree) - z * Math.Sin(degree));
            float newZ = (float)(y * Math.Sin(degree) + z * Math.Cos(degree));
            y = newY;
            z = newZ;
            return this;

        }

        public object RotateZ(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newX = (float)(x * Math.Cos(degree) + z * Math.Sin(degree));
            float newZ = (float)(z * Math.Cos(degree) - x * Math.Sin(degree));
            x = newX;
            z = newZ;
            return this;
        }

        public object RotateY(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);

            float newX = (float)(x * Math.Cos(degree) - y * Math.Sin(degree));
            float newY = (float)(y * Math.Cos(degree) + x * Math.Sin(degree));
            x = newX;
            y = newY;
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            x *= kx;
            y *= ky;
            z *= kz;
            return this;
        }

        public object Translate(Vector direction)
        {
            x += direction.x;
            y += direction.y;
            z += direction.z;
            return this;
        }
    }
}