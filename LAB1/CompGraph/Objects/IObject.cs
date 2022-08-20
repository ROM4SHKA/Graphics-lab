using CompGraph.Objects;

namespace CompGraph.Objects
{
    public interface IObject
    {
        public bool IsRayInterception(Point start, Vector direction);

        public Point GetRayInterceptionPoint(Point start, Vector direction);

        public Vector GetNormalOnPoint(Point point);
    }
}