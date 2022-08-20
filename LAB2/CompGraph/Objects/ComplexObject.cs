
namespace CompGraph.Objects
{
    public class MultipleObject
    {
        
        public List<IObject> objects;

        public MultipleObject(List<IObject> objects)
        {
            this.objects = objects;
        }

        public object RotateX(float degree)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = (IObject)objects[i].RotateX(degree);
            }
            return this;
        }

        public object RotateY(float degree)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = (IObject)objects[i].RotateY(degree);
            }
            return this;
        }

        public object RotateZ(float degree)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = (IObject)objects[i].RotateZ(degree);
            }
            return this;
        }

        public object Scale(float kx, float ky, float kz)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = (IObject)objects[i].Scale(kx, ky, kz);
            }
            return this;
        }

        public object Translate(Vector direction)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Translate(direction);
            }
            return this;
        }
    }
}