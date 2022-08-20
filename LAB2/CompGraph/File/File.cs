using CompGraph.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraph.File
{
    public class File
    {
        public static List<IObject> ReadObject(string path)
        {
            StreamReader sourceFile = new StreamReader(path);
            List<Point> points = new List<Point>();
            List<Vector> normals = new List<Vector>();
            List<IObject> objects = new List<IObject>();

            using (sourceFile)
            {
                string line;
                while ((line = sourceFile.ReadLine()) != null)
                {
                    if (line == "")
                        continue;
                    string[] lineArray = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (lineArray[0] == "v")
                        points.Add(new Point(
                            float.Parse(lineArray[1], CultureInfo.InvariantCulture),
                            float.Parse(lineArray[2], CultureInfo.InvariantCulture),
                            float.Parse(lineArray[3], CultureInfo.InvariantCulture)));
                    else if (lineArray[0] == "vn")
                        normals.Add(new Vector(
                            float.Parse(lineArray[1], CultureInfo.InvariantCulture),
                            float.Parse(lineArray[2], CultureInfo.InvariantCulture),
                            float.Parse(lineArray[3], CultureInfo.InvariantCulture)));
                    else if (lineArray[0] == "f")
                    {
                        int[] pointCoord = new int[3];
                        int[] vectorCoord = new int[3];
                        for (int i = 1; i < lineArray.Length; i++)
                        {
                            string[] coordinates = lineArray[i].Split("/");
                            pointCoord[i - 1] = Int32.Parse(coordinates[0]);
                            vectorCoord[i - 1] = Int32.Parse(coordinates[2]);
                        }

                        objects.Add(new Triangle(
                            new Point(points[pointCoord[0] - 1].x, points[pointCoord[0] - 1].y, points[pointCoord[0] - 1].z),
                            new Point(points[pointCoord[1] - 1].x, points[pointCoord[1] - 1].y, points[pointCoord[1] - 1].z),
                            new Point(points[pointCoord[2] - 1].x, points[pointCoord[2] - 1].y, points[pointCoord[2] - 1].z),
                            new Vector(normals[vectorCoord[0] - 1].x, normals[vectorCoord[0] - 1].y, normals[vectorCoord[0] - 1].z),
                            new Vector(normals[vectorCoord[1] - 1].x, normals[vectorCoord[1] - 1].y, normals[vectorCoord[1] - 1].z),
                            new Vector(normals[vectorCoord[2] - 1].x, normals[vectorCoord[2] - 1].y, normals[vectorCoord[2] - 1].z)));
                    }
                }
            }
            return objects;
        }

        public static void WriteImage(string filename, float[,] screen)
        {
            StreamWriter destination = new StreamWriter(filename);
            destination.Write("P3\n{0} {1} {2}\n", screen.GetUpperBound(1), screen.GetUpperBound(0), 255);
            destination.Flush();

            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < screen.GetUpperBound(0); i++)
            {
                for (int j = 0; j < screen.GetUpperBound(1); j++)
                {
                    var result = Convert.ToInt32(screen[i, j] * 255);

                    if (result > 255)
                    {
                        result = 255;
                    }
                    else if (result < 0)
                    {
                        result = 0;
                    }

                    output.Append(result);
                    output.Append(" ");
                    output.Append(result);
                    output.Append(" ");
                    output.Append(result);
                    output.Append(" ");
                }
                destination.WriteLine(output);
                output.Clear();

            }
            destination.Close();
        }
    }
}
