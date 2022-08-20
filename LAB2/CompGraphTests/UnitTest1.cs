using CompGraph.Objects;

namespace CompGraphTests
{
    public class Tests
    {
        [Test]
        public void IsIntersectionOfVectorAndPlaneReturnCorrectValue()
        {
            Plane plane1 = new Plane(new Point(0, 0, 0), new Vector(1, 0, 0));
            Plane plane2 = new Plane(new Point(0, 0, 5), new Vector(0, 0, -1));
            Point start = new Point(0, 0, 0);
            Vector forward = new Vector(0, 0, 1);

            Assert.Multiple(() =>
            {
                Assert.That(plane1.IsRayInterception(start, forward), Is.EqualTo(false));
                Assert.That(plane2.IsRayInterception(start, forward), Is.EqualTo(true));
            });
        }

        [Test]
        public void IsIntersectionOfVectorAndSphereReturnCorrectValue()
        {
            Sphere sphere1 = new Sphere(new Point(3, 0, 10), 4);
            Sphere sphere2 = new Sphere(new Point(0, 0, 10), 4);
            Sphere sphere3 = new Sphere(new Point(5, 0, 10), 3);

            Point start = new Point(0, 0, 0);
            Vector forward = new Vector(0, 0, 1);

            Assert.Multiple(() =>
            {
                Assert.That(sphere1.IsRayInterception(start, forward), Is.EqualTo(true));
                Assert.That(sphere2.IsRayInterception(start, forward), Is.EqualTo(true));
                Assert.That(sphere3.IsRayInterception(start, forward), Is.EqualTo(false));
            });
        }
    }
}