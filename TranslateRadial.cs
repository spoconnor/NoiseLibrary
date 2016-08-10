using System;
using System.Collections.Generic;

namespace NoiseLibrary
{
    // Radial applies a translation from angle/radius to x/y.

    public class CImplicitTranslateRadial : CImplicitModuleBase
    {
        private CImplicitModuleBase m_source;
        private double xCentre;
        private double zCentre;
        private double xzLength; // calculated

        public CImplicitTranslateRadial(CImplicitModuleBase source, double xCentre = 0.5, double zCentre = 0.5) : base()
        {
            this.m_source = source;
            this.xCentre = xCentre;
            this.zCentre = zCentre;
            this.xzLength = Math.Sqrt(xCentre * xCentre + zCentre * zCentre);
        }

        public override double get(double x, double y, double z)
        {
            var o = z - zCentre;
            var a = x - xCentre;
            if (o==0 && a==0) return m_source.get(0, 1);
            var r = xzLength-Math.Sqrt(o*o+a*a);
            if (r < 0) r = 0;
            var d = Math.Atan2(o, a);
            return m_source.get(d/(2*Math.PI), r/xzLength);
        }

        public override double get(double x, double y)
        {
            return get(x, y, 0.5);
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
