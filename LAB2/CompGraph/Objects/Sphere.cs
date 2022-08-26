using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Sphere : IObject
    {
        public float Radius { get; private set; }

        public Transform transform { get; set; }

        public Point Center { get; private set; }

        public Sphere(float x, float y, float z, float radius)
        {
            transform = new Transform(new SimpleVector(x, y, z));
            Center = new Point(transform);
            Radius = radius;
        }

        public bool IsRayInterception(Point start, Vector direction)
        {
            Vector k = start - Center;
            var a = direction * direction;
            var b = 2 * (direction * k);
            var c = k * k - Radius * Radius;
            var D = b * b - 4 * a * c;
            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (D < 0)
                return false;

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
            var t = (-b - Math.Sqrt(D)) / (2 * a);

            if (D < 0)
                return null;

            if (t < 0)
                return null;

            var x = (float)(start.transform.position.x + t * direction.x);
            var y = (float)(start.transform.position.y + t * direction.y);
            var z = (float)(start.transform.position.z + t * direction.z);
            return new Point(x, y, z);
        }
        
        public Vector GetNormalOnPoint(Point point)
        {
            return Vector.GetVector(Center, point);
        }


        public object ChangeTransform(Transform transform)
        {
            Center = (Point)Center.Translate(new Vector(transform.position));
            Radius *= transform.position.x;
            transform = Center.transform;
            return this;
        }
    }
}