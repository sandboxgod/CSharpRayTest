using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace RaysAndStuff
{
    internal class ShootRays
    {
        public ShootRays()
        {
            CreatePlanes();
            CreateRays();
        }

        /*
         * Creates a list of 3d planes.
         */
        private void CreatePlanes()
        {
            // Used https://www.geogebra.org/classic/3d to create these planes
            Vector3 v1 = new Vector3(-0.48f, 4.09f, 0);
            Vector3 v2 = new Vector3(0, 0, 6);
            Vector3 v3 = new Vector3(-4.3f, 0, 0);
            Plane p1 = new Plane(v1, v2, v3);
            planes.Add(p1);
            planes.Add(new Plane(new Vector3(0.0f, 1.0f, 0.0f), 0.0f));
            Console.WriteLine(p1.Normal.ToString());
        }

        void CreateRays()
        {
            Ray ray1 = new Ray() { Start = new Vector3(100, 0, 0), Dir = new Vector3(-1, 0, 0) };
            Ray ray2 = new Ray() { Start = new Vector3(0, 100, 0), Dir = new Vector3(0, -1, 0) };
            rays.Add(ray1);
            rays.Add(ray2);
        }

        public void runTest()
        {
            float t = 0;
            Vector3 hitPt = new Vector3();
            int count = 0;
            for (int r = 0; r < rays.Count; r++)
            {
                Ray ray = rays[r];
                Console.WriteLine($"Ray {r}: {ray}");
                foreach (Plane plane in planes)
                {
                    if (plane.RayIntersection(ray.Start, ray.Dir, ref t, ref hitPt))
                    {
                        Console.WriteLine($"Ray {r} hit plane: {hitPt} at time: {t}");
                    }
                    else
                    {
                        Console.WriteLine($"Ray {r} missed plane {count}");
                    }
                    float dist1 = plane.DistanceTo(ray.Start);
                    Console.WriteLine($"Plane: {count} distance: {dist1}");
                    Plane.Halfspace halfspace = plane.ClassifyPoint(ray.Start);
                    var text = halfspace.ToString();
                    Console.WriteLine($"Classification Ray.start: {text}");
                    count++;
                }
            }
        }

        private List<Plane> planes = new List<Plane>();
        private List<Ray> rays = new List<Ray>();
    }
}
