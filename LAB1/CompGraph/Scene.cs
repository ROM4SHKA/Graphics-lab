using System;
using System.Collections.Generic;
using System.Text;
using CompGraph.Objects;

namespace CompGraph
{
    public class Scene
    {
        private List<IObject> objects = new List<IObject>();
        private Camera Camera;
        private Light light;
        private float[,] screen;

        public Scene(Camera camera,Light light)
        {
            this.light = light;
            Camera = camera;
            screen = new float[camera.width, camera.height];
        }

        public void AddObject(IObject newObject)
        {
            objects.Add(newObject);
        }

        public float[,] GetScreen()
        {
            var u = Vector.Cross(Camera.Direction, Camera.UpVector);
            var v = Vector.Cross(u, Camera.Direction);

            var pixelHeight = Camera.planeHeight / Camera.height;
            var pixelWidth = Camera.planeWidht / Camera.width;

            var scanlineStart = Camera.PlaneOrigin - (Camera.width / 2) * pixelWidth * u + (pixelWidth / 2) * u +
                (Camera.height / 2) * pixelHeight * v - (pixelHeight / 2) * v;
            var scanlineStartPoint = new Point(scanlineStart.x, scanlineStart.y, scanlineStart.z);

            var pixelWidthU = pixelWidth * u;
            var pixelHeightV = pixelHeight * v;
            
            for (int x = 0; x < Camera.height; x++)
            {
                int yIterator = 0;
                var pixelCenter = new Point(scanlineStartPoint.x, scanlineStartPoint.y, scanlineStartPoint.z);

                for (int y = 0; y < Camera.width; y++)
                {
                    var ray = pixelCenter - Camera.Position;
                    var result = GetNearestObjectNormal(Camera.Position,ray);

                    if (result!=null)
                    {
                        screen[x, yIterator] = Vector.Negate(result) * light.Direction;
                    }
                    else
                    {
                        screen[x, yIterator] = 0;
                    }

                    yIterator++;

                    pixelCenter = new Point(pixelCenter.x + pixelWidthU.x, pixelCenter.y + pixelWidthU.y, +pixelCenter.z + pixelWidthU.z);
                }
                scanlineStartPoint = new Point(scanlineStartPoint.x - pixelHeightV.x, scanlineStartPoint.y - pixelHeightV.y, +scanlineStartPoint.z - pixelHeightV.z);
            }
            return screen;
        }

        public Vector GetNearestObjectNormal(Point start, Vector vector)
        {
            float minDistance = Int32.MaxValue;
            IObject obj = null;
            Point intercept = null;
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].IsRayInterception(start, vector))
                {
                    Point tempIntercept = objects[i].GetRayInterceptionPoint(start, vector);
                    float distance = Point.GetDistance(tempIntercept, start);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        obj = objects[i];
                        intercept = tempIntercept;
                    }
                }
            }

            if (obj!=null)
                return obj.GetNormalOnPoint(intercept);
            
            return null;
        }
    }
}
