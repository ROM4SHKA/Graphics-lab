using CompGraph;
using CompGraph.Objects;
using System.Diagnostics;

Stopwatch sw = new Stopwatch();

Camera camera = new Camera(new Point(0, 0, -2), new Vector(0, 0, 1), 100, 100);
Light light = new Light(new Vector(-1, 1, 1));
Scene scene = new Scene(camera, light);

Plane plane = new Plane(new Point(-0.65f, 0, 0), new Vector(1, 0, 0));
scene.AddObject(plane);

Sphere asd = new Sphere(new Point(0,0,0),3);
scene.AddObject(asd);

string path = @"path";

MultipleObject objectsasd = new MultipleObject(CompGraph.File.File.ReadObject(path));
objectsasd.RotateY(90);
objectsasd.RotateX(120);
objectsasd.Scale(2, 2, 2);
scene.AddObjects(objectsasd.objects);

sw.Start();
float[,] screen = scene.GetScreen();
sw.Stop();

Console.WriteLine($"Elapsed time:{sw.Elapsed}");

string imagePath = @"ppm path";
CompGraph.File.File.WriteImage(imagePath, screen);