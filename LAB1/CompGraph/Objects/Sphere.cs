using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Sphere : IObject
    {
        public Point Center { get; }
        public float Radius { get; }

        public Sphere(Point center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool IsRayInterception(Point start, Vector direction)
        {
            Vector k = start - Center; 
            var a = direction * direction; 
            var b = 2 * (direction * k);
            var c = k * k - Radius * Radius;
            var D = b * b - 4 * a * c;

            if (D < 0)
                return false;
            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (t >= 0)
                return true;
            return false;
        }

        public Point GetRayInterceptionPoint(Point start, Vector direction)
        {
            Vector k = start - Center; 
            var a = direction * direction; 
            var b = 2 * (direction * k);
            var c = k * k - Radius * Radius;
            var D = b * b - 4 * a * c;

            if (D < 0)
                return null;

            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (t < 0)
                return null;

            var x = (float)(start.x + t * direction.x);
            var y = (float)(start.y + t * direction.y);
            var z = (float)(start.z + t * direction.z);
            return new Point(x, y, z);
        }

        public Vector GetNormalOnPoint(Point point)
        {
            return Vector.GetVector(Center, point);
        }
    }
}