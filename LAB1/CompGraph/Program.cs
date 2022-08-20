using CompGraph;
using CompGraph.Objects;

Camera camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), 100, 100);
Light light = new Light(Vector.Normilize(new Vector(-1, 1, 1)));
Scene scene = new Scene(camera, light);

Sphere sphere = new Sphere(new Point(0, 0, 3), 1);
scene.AddObject(sphere);

Plane plane = new Plane(new Point(-1, 0, 0), new Vector(1, 0, 0));
scene.AddObject(plane);

float[,] screen = scene.GetScreen();

for (int i = 0; i < camera.width; i++)
{
    for (int j = 0; j < camera.height; j++)
    {
        if (screen[i, j] == 0)
        {
            Console.Write(' ');
        }
        else
        {
            if (screen[i, j] > 0 && screen[i, j] < 0.2)
            {
                Console.Write('.');
            }
            else if (screen[i, j] > 0.2 && screen[i, j] < 0.5)
            {
                Console.Write('*');
            }
            else if (screen[i, j] > 0.5 && screen[i, j] < 0.8)
            {
                Console.Write('O');
            }
            else if (screen[i, j] > 0.8)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write(' ');
            }
        }
    }
    Console.WriteLine();
}