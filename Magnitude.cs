using System;

namespace NoiseLibrary
{
    class CImplicitMagnitude : CImplicitModuleBase
    {
        private CScalarParameter m_x, m_y, m_z, m_w, m_u, m_v;

        CImplicitMagnitude() : base()
        {
            m_x = new CScalarParameter(0.0); m_y = new CScalarParameter(0.0); m_z = new CScalarParameter(0.0);
            m_w = new CScalarParameter(0.0); m_u = new CScalarParameter(0.0);
            m_v = new CScalarParameter(0.0);
        }

        void setX(double f) { m_x.set(f); }
        void setY(double f) { m_y.set(f); }
        void setZ(double f) { m_z.set(f); }
        void setW(double f) { m_w.set(f); }
        void setU(double f) { m_u.set(f); }
        void setV(double f) { m_v.set(f); }

        void setX(CImplicitModuleBase f) { m_x.set(f); }
        void setY(CImplicitModuleBase f) { m_y.set(f); }
        void setZ(CImplicitModuleBase f) { m_z.set(f); }
        void setW(CImplicitModuleBase f) { m_w.set(f); }
        void setU(CImplicitModuleBase f) { m_u.set(f); }
        void setV(CImplicitModuleBase f) { m_v.set(f); }

        public override double get(double x, double y)
        {
            double xx = m_x.get(x, y);
            double yy = m_y.get(x, y);
            return Math.Sqrt(xx * xx + yy * yy);
        }

        public override double get(double x, double y, double z)
        {
            double xx = m_x.get(x, y, z);
            double yy = m_y.get(x, y, z);
            double zz = m_z.get(x, y, z);
            return Math.Sqrt(xx * xx + yy * yy + zz * zz);
        }

        public override double get(double x, double y, double z, double w)
        {
            double xx = m_x.get(x, y, z, w);
            double yy = m_y.get(x, y, z, w);
            double zz = m_z.get(x, y, z, w);
            double ww = m_w.get(x, y, z, w);
            return Math.Sqrt(xx * xx + yy * yy + zz * zz + ww * ww);
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            double xx = m_x.get(x, y, z, w, u, v);
            double yy = m_y.get(x, y, z, w, u, v);
            double zz = m_z.get(x, y, z, w, u, v);
            double ww = m_w.get(x, y, z, w, u, v);
            double uu = m_u.get(x, y, z, w, u, v);
            double vv = m_v.get(x, y, z, w, u, v);
            return Math.Sqrt(xx * xx + yy * yy + zz * zz + ww * ww + uu * uu + vv * vv);
        }
    }
}

