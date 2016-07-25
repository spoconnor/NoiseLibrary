using System;
using System.Collections.Generic;

namespace NoiseLibrary
{
    // Radial applies a translation from angle/radius to x/y.

    public class CImplicitTranslateRadial : CImplicitModuleBase
    {
        private CImplicitModuleBase m_source;

        public CImplicitTranslateRadial(CImplicitModuleBase source) : base()
        {
            m_source = source;
        }

        public override double get(double x, double y)
        {
            var o = y - 0.5;
            var a = x - 0.5;
            if (o==0 && a==0) return m_source.get(0, Math.Sqrt(0.5 * 0.5 + 0.5 * 0.5));
            var r = Math.Sqrt(0.5 * 0.5 + 0.5 * 0.5)-Math.Sqrt(o*o+a*a);
            var d = Math.Atan(o / a);
            return m_source.get(d/(2*Math.PI), r/(Math.Sqrt(0.5*0.5+0.5*0.5)));
        }

        public override double get(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public override double get(double x, double y, double z, double w)
        {
            throw new NotImplementedException();
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            throw new NotImplementedException();
        }
    }
}
