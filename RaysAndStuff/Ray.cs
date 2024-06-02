using System.Text;
using System.Numerics;

namespace RaysAndStuff
{
    /*
     * Represents a ray in 3 dimensional space. Contains origin and direction vectors.
     */
    internal struct Ray
    {
        public Vector3 Start;
        public Vector3 Dir;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Start:");
            sb.Append(Start.ToString());
            sb.Append(" Dir:");
            sb.Append(Dir.ToString());
            return sb.ToString();
        }
    }
}
