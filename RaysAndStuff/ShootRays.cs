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
                if (RayIntersection(plane, ray.Start, ray.Dir, ref t, ref hitPt))
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
            Plane p1 = Plane.CreateFromVertices(v1, v2, v3);
            planes.Add(p1);
            Console.WriteLine(p1.Normal.ToString());
        }

        //Performs a hit test between a ray and a plane
        private bool RayIntersection(Plane plane, Vector3 Start, Vector3 Dir, ref float t, ref Vector3 HitPt)
		{

            float vd = Vector3.Dot(plane.Normal, Dir);					// DOT-PROD BETWEEN NORMAL AND RAY DIR

			//If Vd > 0 then the normal of the plane is pointing away from the ray
			//If Vd==0 RAY AND PLANE ARE PARALLEL
			if (Math.Abs(vd)<= 1e-4f)
				return(false);

			float v0 = -(Vector3.Dot(plane.Normal, Start) + plane.D);
            t = v0/vd;								// CALC PARAMETRIC T-VAL
			if (t>0)								// IF INTERSECTION NOT "BEHIND" RAY
			{
				HitPt = Start + Dir* t;				// CALC HIT POINT
				return(true);                       // INTERSECTION FOUND!
			}
			return(false);
		}
        private List<Plane> planes = new List<Plane>();
    }
}
