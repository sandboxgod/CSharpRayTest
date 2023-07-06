using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Xml.Linq;

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
            return "Start:" + Start.ToString() + " Dir:" + Dir.ToString();
        }
    }
}
