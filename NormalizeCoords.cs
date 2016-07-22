using System;

namespace NoiseLibrary
{
    class CImplicitNormalizeCoords : CImplicitModuleBase
    {
        private CScalarParameter m_source;
        private CScalarParameter m_length;

        public CImplicitNormalizeCoords() : base()
        { m_source = new CScalarParameter(0.0); m_length = new CScalarParameter(1.0); }
        public CImplicitNormalizeCoords(double s, double l) : base()
        { m_source = new CScalarParameter(s); m_length = new CScalarParameter(l); }
        public CImplicitNormalizeCoords(double s, CImplicitModuleBase l) : base()
        { m_source = new CScalarParameter(s); m_length = new CScalarParameter(l); }
        public CImplicitNormalizeCoords(CImplicitModuleBase s, double l) : base()
        { m_source = new CScalarParameter(s); m_length = new CScalarParameter(l); }
        public CImplicitNormalizeCoords(CImplicitModuleBase s, CImplicitModuleBase l) : base()
        { m_source = new CScalarParameter(s); m_length = new CScalarParameter(l); }

        private void setSource(double v)
        {
            m_source.set(v);
        }
        private void setSource(CImplicitModuleBase v)
        {
            m_source.set(v);
        }

        private void setLength(double v)
        {
            m_length.set(v);
        }
        private void setLength(CImplicitModuleBase v)
        {
            m_length.set(v);
        }

        public override double get(double x, double y)
        {
            if (x == 0 && y == 0) return m_source.get(x, y);

            double len = Math.Sqrt(x * x + y * y);
            double r = m_length.get(x, y);
            return m_source.get(x / len * r, y / len * r);
        }

        public override double get(double x, double y, double z)
        {
            if (x == 0 && y == 0 && z == 0) return m_source.get(x, y, z);

            double len = Math.Sqrt(x * x + y * y + z * z);
            double r = m_length.get(x, y, z);
            return m_source.get(x / len * r, y / len * r, z / len * r);
        }
        public override double get(double x, double y, double z, double w)
        {
            if (x == 0 && y == 0 && z == 0 && w == 0) return m_source.get(x, y, z, w);

            double len = Math.Sqrt(x * x + y * y + z * z + w * w);
            double r = m_length.get(x, y, z, w);
            return m_source.get(x / len * r, y / len * r, z / len * r, w / len * r);
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            if (x == 0 && y == 0 && z == 0 && w == 0 && u == 0 && v == 0) return m_source.get(x, y, z, w, u, v);

            double len = Math.Sqrt(x * x + y * y + z * z + w * w + u * u + v * v);
            double r = m_length.get(x, y, z, w, u, v);
            return m_source.get(x / len * r, y / len * r, z / len * r, w / len * r, u / len * r, v / len * r);
        }
    }
}

