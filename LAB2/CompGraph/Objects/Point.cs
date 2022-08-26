using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Point
    {
        public Transform transform { get; set; }

        public Point(Vector vector)
        {
            transform = new Transform(vector);
        }
        public Point(Transform transform)
        {
            this.transform = transform;
        }

        public Point(float x, float y, float z)
        {
            transform = new Transform(new SimpleVector(x, y, z));
        }

        public static Vector operator +(Point point, Vector vector)
        {
            return new Vector(point.transform.position.x + vector.x, point.transform.position.y + vector.y, point.transform.position.z + vector.z);
        }

        public static Vector operator -(Point pointOne, Point pointTwo)
        {
            return new Vector(pointOne.transform.position.x - pointTwo.transform.position.x,
                pointOne.transform.position.y - pointTwo.transform.position.y,
                pointOne.transform.position.z - pointTwo.transform.position.z);
        }

        public object ChangeTransform(Transform transform)
        {
            Translate(new Vector(transform.position));
            Rotate(new Vector(transform.rotation));
            Scale(new Vector(transform.scale));
            return this;
        }

        public object Translate(Vector direction)
        {
            transform.position.x += direction.x;
            transform.position.y += direction.y;
            transform.position.z += direction.z;
            return this;
        }
        public object Rotate(Vector rotation)
        {
            transform.rotation = rotation;
            RotateX(rotation.x);
            RotateY(rotation.y);
            RotateZ(rotation.z);
            return this;
        }
        public object Scale(Vector scale)
        {
            transform.scale = scale;
            transform.position.x *= scale.x;
            transform.position.y *= scale.y;
            transform.position.z *= scale.z;
            return this;
        }


        private object RotateX(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newY = (float)(transform.position.y * Math.Cos(degree) - transform.position.z * Math.Sin(degree));
            float newZ = (float)(transform.position.y * Math.Sin(degree) + transform.position.z * Math.Cos(degree));
            transform.position.y = newY;
            transform.position.z = newZ;
            return this;
        }

        private object RotateY(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);
            float newX = (float)(transform.position.x * Math.Cos(degree) + transform.position.z * Math.Sin(degree));
            float newZ = (float)(transform.position.z * Math.Cos(degree) - transform.position.x * Math.Sin(degree));
            transform.position.x = newX;
            transform.position.z = newZ;
            return this;
        }

        private object RotateZ(float degree)
        {
            degree = (float)(degree * Math.PI / 180.0);

            float newX = (float)(transform.position.x * Math.Cos(degree) - transform.position.y * Math.Sin(degree));
            float newY = (float)(transform.position.y * Math.Cos(degree) + transform.position.x * Math.Sin(degree));
            transform.position.x = newX;
            transform.position.y = newY;
            return this;
        }
        public static float GetDistance(Point pointOne, Point pointTwo)
        {
            float deltaX = pointTwo.transform.position.x - pointOne.transform.position.x;
            float deltaY = pointTwo.transform.position.y - pointOne.transform.position.y;
            float deltaZ = pointTwo.transform.position.z - pointOne.transform.position.z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
        public static float Distance(Point pointOne, Point pointTwo)
        {
            float deltaX = pointTwo.transform.position.x - pointOne.transform.position.x;
            float deltaY = pointTwo.transform.position.y - pointOne.transform.position.y;
            float deltaZ = pointTwo.transform.position.z - pointOne.transform.position.z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}