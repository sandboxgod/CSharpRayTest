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
            Ray ray = new Ray() { Start = new Vector3(100,0,0), Dir = new Vector3(-1, 0, 0) };
            float t = 0;
            Vector3 hitPt = new Vector3();
            foreach (Plane plane in planes)
            {
                if (plane.RayIntersection(ray.Start, ray.Dir, ref t, ref hitPt))
                {
                    Console.WriteLine("Ray hit plane:" + hitPt + " at " + t);
                } else
                {
                    Console.WriteLine("Ray missed plane");
                }
            }
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
            Console.WriteLine(p1.Normal.ToString());
        }
        private List<Plane> planes = new List<Plane>();
    }
}
