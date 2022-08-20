using CompGraph.Objects;

namespace CompGraph.Objects
{
    public interface IObject
    {
        public bool IsRayInterception(Point start, Vector direction);

        public Point GetRayInterceptionPoint(Point start, Vector direction);

        public Vector GetNormalOnPoint(Point point);

        public object RotateX(float degree);

        public object RotateY(float degree);

        public object RotateZ(float degree);

        public object Scale(float kx, float ky, float kz);

        public object Translate(Vector direction);
    }
}