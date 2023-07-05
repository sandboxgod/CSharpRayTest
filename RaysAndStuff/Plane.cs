using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RaysAndStuff
{
    internal class Plane
    {
        public Plane(Vector3 A, Vector3 B, Vector3 C)
        {
            Normal = Vector3.Cross((B - A), (C - A));  // NORMAL = AB X AC
            Normal = Vector3.Normalize(Normal);      // REQUIRES NORMALIZED NORMAL
            D = -Vector3.Dot(Normal, A);            // EVALUATE EQUATION WITH NORM AND PT ON PLANE TO GET D
        }

        //Performs a hit test between a ray and a plane
        public bool RayIntersection(Vector3 Start, Vector3 Dir, ref float t, ref Vector3 HitPt)
        {
            float denom = Vector3.Dot(Normal, Dir);                   // DOT-PROD BETWEEN NORMAL AND RAY DIR

            //If denom > 0 then the normal of the plane is pointing away from the ray
            //If denom==0 RAY AND PLANE ARE PARALLEL
            if (Math.Abs(denom) <= 1e-4f)
                return (false);

            float v0 = -(Vector3.Dot(Normal, Start) + D);
            t = v0 / denom;                             // CALC PARAMETRIC T-VAL
            if (t > 0)                              // IF INTERSECTION NOT "BEHIND" RAY
            {
                HitPt = Start + Dir * t;                // CALC HIT POINT
                return (true);                       // INTERSECTION FOUND!
            }
            return (false);
        }

        public readonly Vector3 Normal;
        public readonly float D;
    }
}
