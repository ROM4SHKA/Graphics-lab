using CompGraph.Objects;

namespace CompGraph.Objects
{
    public class Light
    {
        public Vector Direction { get; set; }

        public Light(Vector direction)
        {
            this.Direction = direction;
        }
    }
}