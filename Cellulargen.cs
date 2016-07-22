namespace NoiseLibrary
{

    /********************************************************
    CCellularGen
        Implement a class to generate and cache cellular noise. Multiple front-end classes can
    call this, and as long as the input coords remain the same, the cached value will be returned.
    Generates F1..F4 and V1..V4.
    *********************************************************/

    namespace NoiseLibrary
    {
        enum EDistanceFunction
        {
            EUCLID,
            MANHATTAN,
            GREATESTAXIS,
            LEASTAXIS
        };

        struct SCellularCache
        {
            public double[] f;
            public double[] d;
            public double x, y, z, w, u, v;
            public bool valid;

            public SCellularCache()
            {
                f = new double[4];
                d = new double[4];
                x = 0;
                y = 0;
                z = 0;
                w = 0;
                u = 0;
                v = 0;
                valid = false;
            }
        }


        public class CCellularGenerator
        {
            private uint m_seed;
            private SCellularCache m_cache2, m_cache3, m_cache4, m_cache6;
            private dist_func2 m_dist2;
            private dist_func3 m_dist3;
            private dist_func4 m_dist4;
            private dist_func6 m_dist6;

            public CCellularGenerator()
            {
                setSeed(1000);
                setDistanceFunction(EUCLID);
            }

            public CCellularGenerator(int distfunc)
            {
                setSeed(1000);
                setDistanceFunction(distfunc);
            }

            private void setDistanceFunction(int distfunc)
            {
                if (distfunc < EUCLID) distfunc = EUCLID;
                if (distfunc > LEASTAXIS) distfunc = LEASTAXIS;

                switch (distfunc)
                {
                    case EUCLID: m_dist2 = distEuclid2; m_dist3 = distEuclid3; m_dist4 = distEuclid4; m_dist6 = distEuclid6; break;
                    case MANHATTAN: m_dist2 = distManhattan2; m_dist3 = distManhattan3; m_dist4 = distManhattan4; m_dist6 = distManhattan6; break;
                    case GREATESTAXIS: m_dist2 = distGreatestAxis2; m_dist3 = distGreatestAxis3; m_dist4 = distGreatestAxis4; m_dist6 = distGreatestAxis6; break;
                    case LEASTAXIS: m_dist2 = distLeastAxis2; m_dist3 = distLeastAxis3; m_dist4 = distLeastAxis4; m_dist6 = distLeastAxis6; break;
                    default: break;
                }
            }


            public SCellularCache get(double x, double y)
            {
                if (!m_cache2.valid || x != m_cache2.x || y != m_cache2.y)
                {
                    cellular_function2D(x, y, m_seed, m_cache2.f, m_cache2.d, m_dist2);
                    m_cache2.x = x;
                    m_cache2.y = y;
                    m_cache2.valid = true;
                }
                return m_cache2;
            }

            public SCellularCache get(double x, double y, double z)
            {
                if (!m_cache3.valid || x != m_cache3.x || y != m_cache3.y || z != m_cache3.z)
                {
                    cellular_function3D(x, y, z, m_seed, m_cache3.f, m_cache3.d, m_dist3);
                    m_cache3.x = x;
                    m_cache3.y = y;
                    m_cache3.z = z;
                    m_cache3.valid = true;
                }
                return m_cache3;
            }

            public SCellularCache get(double x, double y, double z, double w)
            {
                if (!m_cache4.valid || x != m_cache4.x || y != m_cache4.y || z != m_cache4.z || w != m_cache4.w)
                {
                    cellular_function4D(x, y, z, w, m_seed, m_cache4.f, m_cache4.d, m_dist4);
                    m_cache4.x = x;
                    m_cache4.y = y;
                    m_cache4.z = z;
                    m_cache4.w = w;
                    m_cache4.valid = true;
                }
                return m_cache4;
            }

            public SCellularCache get(double x, double y, double z, double w, double u, double v)
            {
                if (!m_cache6.valid || x != m_cache6.x || y != m_cache6.y || z != m_cache6.z || w != m_cache6.w || u != m_cache6.u || v != m_cache6.v)
                {
                    cellular_function6D(x, y, z, w, u, v, m_seed, m_cache6.f, m_cache6.d, m_dist6);
                    m_cache6.x = x;
                    m_cache6.y = y;
                    m_cache6.z = z;
                    m_cache6.w = w;
                    m_cache6.u = u;
                    m_cache6.v = v;
                    m_cache6.valid = true;
                }

                return m_cache6;
            }

            private void setSeed(uint seed)
            {
                m_seed = seed;
                m_cache2.valid = false;
                m_cache3.valid = false;
                m_cache4.valid = false;
                m_cache6.valid = false;
            }
        }
    }
