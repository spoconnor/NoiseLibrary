using System;

namespace NoiseLibrary
{
   

    public class CImplicitSeamlessMapping : CImplicitModuleBase
    {
        public enum EMappingModes
        {
            SEAMLESS_NONE,
            SEAMLESS_X,
            SEAMLESS_Y,
            SEAMLESS_Z,
            SEAMLESS_XY,
            SEAMLESS_XZ,
            SEAMLESS_YZ,
            SEAMLESS_XYZ
        };

        private CImplicitModuleBase m_source;
        private double m_periodx, m_periody, m_periodz;
        private EMappingModes m_seamlessmode;

        public CImplicitSeamlessMapping() : base()
        { m_source = null; m_seamlessmode = EMappingModes.SEAMLESS_NONE; m_periodx = 1; m_periody = 1; m_periodz = 1; }

        public CImplicitSeamlessMapping(CImplicitModuleBase source, EMappingModes seamlessmode, double periodx = 1, double periody = 1, double periodz = 1) : base()
        { m_source = source; m_seamlessmode = seamlessmode; m_periodx = periodx; m_periody = periody; m_periodz = periodz; }

        private void setSource(CImplicitModuleBase src)
        {
            m_source = src;
        }

        private void setMapping(EMappingModes seamlessmode)
        {
            m_seamlessmode = seamlessmode;
            if (m_seamlessmode < 0) m_seamlessmode = 0;
            if (m_seamlessmode > EMappingModes.SEAMLESS_XYZ) m_seamlessmode = EMappingModes.SEAMLESS_XYZ;
        }

        private void setPeriodX(double p)
        {
            m_periodx = p;
        }

        private void setPeriodY(double p)
        {
            m_periody = p;
        }

        private void setPeriodZ(double p)
        {
            m_periodz = p;
        }

        public override double get(double x, double y)
        {
            if (m_source==null) return 0;
            double pi2 = 3.141592 * 2.0;
            switch (m_seamlessmode)
            {
                case EMappingModes.SEAMLESS_NONE: return m_source.get(x, y); 
                case EMappingModes.SEAMLESS_X:
                    {
                        double p = x / m_periodx * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, y);
                    } 
                case EMappingModes.SEAMLESS_Y:
                    {
                        double p = y / m_periody * pi2;
                        return m_source.get(x, Math.Cos(p) * m_periody / pi2, Math.Sin(p) * m_periody / pi2);
                    } 
                case EMappingModes.SEAMLESS_Z:
                    {
                        return m_source.get(x, y, Math.Cos(0) * m_periodz / pi2, Math.Sin(0) * m_periodz / pi2);
                    } 
                case EMappingModes.SEAMLESS_XY:
                    {
                        double p = x / m_periodx * pi2;
                        double q = y / m_periody * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, Math.Cos(q) * m_periody / pi2, Math.Sin(q) * m_periody / pi2);
                    }
                case EMappingModes.SEAMLESS_XZ:
                    {
                        double p = x / m_periodx * pi2;
                        double q = 0;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, y, Math.Cos(q) * m_periodz / pi2, Math.Sin(q) * m_periodz / pi2, 0);
                    } 
                case EMappingModes.SEAMLESS_YZ:
                    {
                        double p = y / m_periody * pi2;
                        double q = 0;
                        return m_source.get(x, Math.Cos(p) * m_periody / pi2, Math.Sin(p) * m_periody / pi2, Math.Cos(q) * m_periodz / pi2, Math.Sin(1) * m_periodz / pi2, 0);
                    } 
                case EMappingModes.SEAMLESS_XYZ:
                    {
                        double p = x / m_periodx * pi2;
                        double q = y / m_periody * pi2;
                        double r = 0;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, Math.Cos(q) * m_periody / pi2, Math.Sin(q) * m_periody / pi2, Math.Cos(r) * m_periodz / pi2, Math.Sin(r) * m_periodz / pi2);
                    } 

                default: return m_source.get(x, y); 
            }
        }

        public override double get(double x, double y, double z)
        {
            if (m_source == null) return 0;
            double pi2 = 3.141592 * 2.0;
            switch (m_seamlessmode)
            {
                case EMappingModes.SEAMLESS_NONE: return m_source.get(x, y); 
                case EMappingModes.SEAMLESS_X:
                    {
                        double p = x / m_periodx * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, y, z);
                    } 
                case EMappingModes.SEAMLESS_Y:
                    {
                        double p = y / m_periody * pi2;
                        return m_source.get(x, Math.Cos(p) * m_periody / pi2, Math.Sin(p) * m_periody / pi2, z);
                    } 
                case EMappingModes.SEAMLESS_Z:
                    {
                        double p = z / m_periodz * pi2;
                        return m_source.get(x, y, Math.Cos(p) * m_periodz / pi2, Math.Sin(p) * m_periodz / pi2);
                    } 
                case EMappingModes.SEAMLESS_XY:
                    {
                        double p = x / m_periodx * pi2;
                        double q = y / m_periody * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, Math.Cos(q) * m_periody / pi2, Math.Sin(q) * m_periody / pi2, z, 0);
                    }
                case EMappingModes.SEAMLESS_XZ:
                    {
                        double p = x / m_periodx * pi2;
                        double r = z / m_periodz * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, y, Math.Cos(r) * m_periodz / pi2, Math.Sin(r) * m_periodz / pi2, 0);
                    } 
                case EMappingModes.SEAMLESS_YZ:
                    {
                        double q = y / m_periody * pi2;
                        double r = z / m_periodz * pi2;
                        return m_source.get(x, Math.Cos(q) * m_periody / pi2, Math.Sin(q) * m_periody / pi2, Math.Cos(r) * m_periodz / pi2, Math.Sin(r) * m_periodz / pi2, 0);
                    } 
                case EMappingModes.SEAMLESS_XYZ:
                    {
                        double p = x / m_periodx * pi2;
                        double q = y / m_periody * pi2;
                        double r = z / m_periodz * pi2;
                        return m_source.get(Math.Cos(p) * m_periodx / pi2, Math.Sin(p) * m_periodx / pi2, Math.Cos(q) * m_periody / pi2, Math.Sin(q) * m_periody / pi2, Math.Cos(r) * m_periodz / pi2, Math.Sin(r) * m_periodz / pi2);
                    } 

                default: return m_source.get(x, y); 
            }
        }

        public override double get(double x, double y, double z, double w)
        {
            // Orders higher than 3 fall back to 3
            return get(x, y, z);
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            return get(x, y, z);
        }
    }
}
