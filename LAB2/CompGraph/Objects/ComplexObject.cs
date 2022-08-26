
namespace CompGraph.Objects
{
    public class MultipleObject
    {

        public List<IObject> objects;

        public MultipleObject(List<IObject> objects)
        {
            this.objects = objects;
        }

        public object ChangeTransform(Transform transform)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = (IObject)objects[i].ChangeTransform(transform);
            }
            return this;
        }
    }
}