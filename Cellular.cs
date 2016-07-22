namespace NoiseLibrary
{
    public class CImplicitCellular : CImplicitModuleBase
    {

        private CCellularGenerator m_generator;
        private double[] m_coefficients = new double[4];

        public CImplicitCellular() : base()
        {
            m_generator = null;
            setCoefficients(1, 0, 0, 0);
        }
        public CImplicitCellular(double a, double b, double c, double d) : base() 
        {
            m_generator = null;
            setCoefficients(a, b, c, d);
        }

        public CImplicitCellular(CCellularGenerator m, double a = 1, double b = 0, double c = 0, double d = 0) : base()
        {
            m_generator = m;
            setCoefficients(a, b, c, d);
        }

        public void setCoefficients(double a, double b, double c, double d)
        {
            m_coefficients[0] = a;
            m_coefficients[1] = b;
            m_coefficients[2] = c;
            m_coefficients[3] = d;
        }

        void setCellularSource(CCellularGenerator m)
        {
            m_generator = m;
        }

        public double get(double x, double y)
        {
            if (!m_generator) return 0.0;

            SCellularCache & c = m_generator->get(x, y);
            return c.f[0] * m_coefficients[0] + c.f[1] * m_coefficients[1] + c.f[2] * m_coefficients[2] + c.f[3] * m_coefficients[3];
        }

        public double get(double x, double y, double z)
        {
            if (!m_generator) return 0.0;

            SCellularCache & c = m_generator->get(x, y, z);
            return c.f[0] * m_coefficients[0] + c.f[1] * m_coefficients[1] + c.f[2] * m_coefficients[2] + c.f[3] * m_coefficients[3];
        }
        public double get(double x, double y, double z, double w)
        {
            if (!m_generator) return 0.0;

            SCellularCache & c = m_generator->get(x, y, z, w);
            return c.f[0] * m_coefficients[0] + c.f[1] * m_coefficients[1] + c.f[2] * m_coefficients[2] + c.f[3] * m_coefficients[3];
        }
        public double get(double x, double y, double z, double w, double u, double v)
        {
            if (!m_generator) return 0.0;

            SCellularCache & c = m_generator->get(x, y, z, w, u, v);
            return c.f[0] * m_coefficients[0] + c.f[1] * m_coefficients[1] + c.f[2] * m_coefficients[2] + c.f[3] * m_coefficients[3];
        }

    }

    public class CImplicitVoronoi : CImplicitModuleBase
    {
        private CCellularGenerator m_generator;

        public CImplicitVoronoi() : base()
        {
        }

        public CImplicitVoronoi(CCellularGenerator m) : base()
        {
            m_generator = m;
        }


        public double get(double x, double y)
        {
            if (!m_generator) return 0.0;
            SCellularCache & c = m_generator->get(x, y);
            return c.d[0];
        }


        public double get(double x, double y, double z)
        {
            if (!m_generator) return 0.0;
            SCellularCache & c = m_generator->get(x, y, z);
            return c.d[0];
        }

        public double get(double x, double y, double z, double w)
        {
            if (!m_generator) return 0.0;
            SCellularCache & c = m_generator->get(x, y, z, w);
            return c.d[0];
        }

        public double get(double x, double y, double z, double w, double u, double v)
        {
            if (!m_generator) return 0.0;
            SCellularCache & c = m_generator->get(x, y, z, w, u, v);
            return c.d[0];
        }
    }
}
