using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Plane : IObject
    {
        public Point Position { get; }
        public Vector Direction { get; }

        public Plane(Point position, Vector direction)
        {
            this.Position = position;
            this.Direction = Vector.Normilize(direction);
        }

        public Vector GetNormalOnPoint(Point point)
        {
            return Direction;
        }

        public bool IsRayInterception(Point start, Vector direction)
        {
            float denom = -(Direction * direction);

            if (denom > 0)
            {
                Vector k = Position - start;
                var t = -(k * Direction) / denom;
                return (t >= 0);
            }

            return false;
        }

        public Point GetRayInterceptionPoint(Point start, Vector direction)
        {
            float denom = -(Direction * direction);

            if (denom < 0)
                return null;

            Vector k = Position - start;
            var t = -(k * Direction) / denom;

            if (t < 0)
                return null;

            var x = start.transform.position.x + t * direction.x;
            var y = start.transform.position.y + t * direction.y;
            var z = start.transform.position.z + t * direction.z;

            return new Point(x, y, z);
        }

        public object ChangeTransform(Transform transform)
        {
            Position.ChangeTransform(transform);
            Direction.ChangeTransform(transform);
            return this;
        }
    }
}