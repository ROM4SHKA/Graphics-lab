using CompGraph;
using CompGraph.Objects;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();

Camera camera = new Camera(new Point(0, 0, -2), new Vector(0, 0, 1), 400, 400);
Light light = new Light(new Vector(-1, 1, 1));
Scene scene = new Scene(camera, light);

Plane plane = new Plane(new Point(-0.65f, 0, 0), new Vector(1, 0, 0));
scene.AddObject(plane);

Sphere asd = new Sphere(0,0,0,3);
scene.AddObject(asd);

string path = @"C:\work\graph_labs\Graphics-lab\LAB2\cow.obj";

MultipleObject objectsasd = new MultipleObject(CompGraph.File.File.ReadObject(path));
Transform newPos = new Transform(
    new SimpleVector(0, 0, 0),
    new SimpleVector(120, 90, 0),
    new SimpleVector(2, 2, 2)
    );
objectsasd.ChangeTransform(newPos);
scene.AddObjects(objectsasd.objects);

sw.Start();
float[,] screen = scene.GetScreen();
sw.Stop();

Console.WriteLine($"Elapsed time:{sw.Elapsed}");

string imagePath = @"C:\work\graph_labs\Graphics-lab\LAB2\cow.ppm";
CompGraph.File.File.WriteImage(imagePath, screen);