using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Vector : SimpleVector
    {
        public Transform transform { get; set; }

        public Vector(SimpleVector vector) :base (vector)
        {
            transform = new Transform(vector);
        }

        public Vector(float x, float y, float z) : base(x, y, z)
        {
            transform = new Transform(new SimpleVector(x, y, z));
        }

        public static Vector GetVector(Point p1, Point p2)
        {
            return new Vector(p2.transform.position.x - p1.transform.position.x, 
                p2.transform.position.y - p1.transform.position.y, 
                p2.transform.position.z - p1.transform.position.z);
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
            SynchronizeCoord();
            return this;
        }
        public object Rotate(Vector rotation)
        {
            transform.rotation = rotation;
            RotateX(rotation.x);
            RotateY(rotation.y);
            RotateZ(rotation.z);
            SynchronizeCoord();
            return this;
        }
        public object Scale(Vector scale)
        {
            transform.scale = scale;
            transform.position.x *= scale.x;
            transform.position.y *= scale.y;
            transform.position.z *= scale.z;
            SynchronizeCoord();
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

        private object SynchronizeCoord()
        {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            return this;
        }
    }
}