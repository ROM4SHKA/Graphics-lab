using System;
using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Camera
    {
        public Point Position { get; }
        public Vector Direction { get; }

        public Vector RightVector { get; }

        public Vector UpVector { get; }
        public Vector PlaneOrigin { get; }

        public float planeHeight { get; }
        public float planeWidht { get; }

        public int height { get; }
        public int width { get; }

        public Camera(Point position, Vector direction, int height, int width)
        {
            this.Position = position;
            this.Direction = Vector.Normilize(direction);

            this.height = height;
            this.width = width;

            PlaneOrigin = position + Vector.Normilize(direction);

            var fovInRad = 60 / 180f * Math.PI;
            planeHeight = (float)Math.Tan(fovInRad);
            planeWidht = planeHeight / height * width;

            RightVector = Vector.Normilize(Vector.Cross(direction, Vector.Normilize(new Vector(1, 0, 0))));
            UpVector = Vector.Cross(direction, Vector.Negate(RightVector));
        }
    }
}