using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class SimpleVector
    {
        public float x { get;  set; }
        public float y { get;  set; }
        public float z { get;  set; }

        public SimpleVector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public SimpleVector(SimpleVector vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

    }
    public class Transform
    {
        public SimpleVector position { get;  set; }
        public SimpleVector rotation { get;  set; }
        public SimpleVector scale { get;  set; }

        public Transform()
        {
            position = new SimpleVector(0, 0, 0); 
            rotation = new SimpleVector(0, 0, 0);
            scale = new SimpleVector(1, 1, 1);
        }

        public Transform(SimpleVector position)
        {
            this.position = position;
            rotation = new SimpleVector(0, 0, 0);
            scale = new SimpleVector(1, 1, 1);
        }

        public Transform(SimpleVector position, SimpleVector rotation, SimpleVector scale) : this(position)
        {
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
