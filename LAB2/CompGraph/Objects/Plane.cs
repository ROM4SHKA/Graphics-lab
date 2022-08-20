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

            var x = start.x + t * direction.x;
            var y = start.y + t * direction.y;
            var z = start.z + t * direction.z;

            return new Point(x, y, z);
        }

        public object RotateX(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Position.RotateX(degree);
            Direction.RotateX(degree);
            return this;
        }

        public object RotateY(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Position.RotateY(degree);
            Direction.RotateY(degree);
            return this;
        }

        public object RotateZ(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            Position.RotateZ(degree);
            Direction.RotateZ(degree);
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            return this;
        }

        public object Translate(Vector direction)
        {
            Position.Translate(direction);
            Direction.Translate(direction);
            return this;
        }
    }
}