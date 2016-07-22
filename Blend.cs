namespace NoiseLibrary
{

    public class CImplicitBlend : CImplicitModuleBase
    {
        private CScalarParameter m_low, m_high, m_control;

        public CImplicitBlend() : base()
        { m_low = new CScalarParameter(0.0); m_high = new CScalarParameter(0.0); m_control = new CScalarParameter(0.0); }
        public CImplicitBlend(double low, double high, double control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control); }
        public CImplicitBlend(double low, double high, CImplicitModuleBase control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control); }
        public CImplicitBlend(double low, CImplicitModuleBase high, double control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }
        public CImplicitBlend(CImplicitModuleBase low, double high, double control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }
        public CImplicitBlend(double low, CImplicitModuleBase high, CImplicitModuleBase control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }
        public CImplicitBlend(CImplicitModuleBase low, double high, CImplicitModuleBase control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }
        public CImplicitBlend(CImplicitModuleBase low, CImplicitModuleBase high, double control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }
        public CImplicitBlend(CImplicitModuleBase low, CImplicitModuleBase high, CImplicitModuleBase control) : base()
        { m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); m_control = new CScalarParameter(control);  }


        private void setLowSource(CImplicitModuleBase b)
        {
            m_low.set(b);
        }

        private void setHighSource(CImplicitModuleBase b)
        {
            m_high.set(b);
        }

        private void setControlSource(CImplicitModuleBase b)
        {
            m_control.set(b);
        }

        private void setLowSource(double v)
        {
            m_low.set(v);
        }

        private void setHighSource(double v)
        {
            m_high.set(v);
        }

        private void setControlSource(double v)
        {
            m_control.set(v);
        }

        public override double get(double x, double y)
        {
            double v1 = m_low.get(x, y);
            double v2 = m_high.get(x, y);
            double blend = m_control.get(x, y);
            blend = (blend + 1.0) * 0.5;

            return Misc.Lerp(blend, v1, v2);
        }

        public override double get(double x, double y, double z)
        {
            double v1 = m_low.get(x, y, z);
            double v2 = m_high.get(x, y, z);
            double blend = m_control.get(x, y, z);
            return Misc.Lerp(blend, v1, v2);
        }

        public override double get(double x, double y, double z, double w)
        {
            double v1 = m_low.get(x, y, z, w);
            double v2 = m_high.get(x, y, z, w);
            double blend = m_control.get(x, y, z, w);
            return Misc.Lerp(blend, v1, v2);
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            double v1 = m_low.get(x, y, z, w, u, v);
            double v2 = m_high.get(x, y, z, w, u, v);
            double blend = m_control.get(x, y, z, w, u, v);
            return Misc.Lerp(blend, v1, v2);
        }
    }
}
