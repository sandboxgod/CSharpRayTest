using System.Numerics;

namespace RaysAndStuff
{
    /*
     * Represents a 3 dimensional flat surface that extends indefinitely.
     */
    internal class Plane
    {
        public enum Halfspace
        {
            Halfspace_BEHIND, //behind the plane
            Halfspace_ON_PLANE,
            Halfspace_FRONT, //in front of plane
        };

        public Plane(Vector3 A, Vector3 B, Vector3 C)
        {
            Normal = Vector3.Cross((B - A), (C - A));  // NORMAL = AB X AC
            Normal = Vector3.Normalize(Normal);      // REQUIRES NORMALIZED NORMAL
            D = -Vector3.Dot(Normal, A);            // EVALUATE EQUATION WITH NORM AND PT ON PLANE TO GET D
        }

        public Plane(Vector3 normal, float d)
        {
            Normal = normal;
            D = d;
        }

        //Performs a hit test between a ray and a plane
        public bool RayIntersection(Vector3 Start, Vector3 Dir, ref float t, ref Vector3 HitPt)
        {
            float denom = Vector3.Dot(Normal, Dir);                   // DOT-PROD BETWEEN NORMAL AND RAY DIR

            //If denom > 0 then the normal of the plane is pointing away from the ray
            //If denom==0 RAY AND PLANE ARE PARALLEL
            if (Math.Abs(denom) <= 1e-4f)
                return (false);

            float dist = -(Vector3.Dot(Normal, Start) + D);
            t = dist / denom;                             // CALC PARAMETRIC T-VAL
            if (t > 0)                              // IF INTERSECTION NOT "BEHIND" RAY
            {
                HitPt = Start + Dir * t;                // CALC HIT POINT
                return (true);                       // INTERSECTION FOUND!
            }
            return (false);
        }

        // RETURNS THE DIST TO PT FROM PLANE (+ in dir of normal, - in opposite dir)
        public float DistanceTo(Vector3 P)
        {
            return Vector3.Dot(Normal, P) + D;
        }

        public Halfspace ClassifyPoint(Vector3 P)
        {
            float d = DistanceTo(P);
            if (d == 0) return Halfspace.Halfspace_ON_PLANE;
            if (d > 0) return Halfspace.Halfspace_FRONT;
            return Halfspace.Halfspace_BEHIND;
        }

        public readonly Vector3 Normal; // Normalized vector perpendicular to the plane
        public readonly float D;  // Distance from a point to the plane.
    }
}
