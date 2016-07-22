namespace NoiseLibrary
{


    class CImplicitClamp : CImplicitModuleBase
    {
        private CScalarParameter m_source, m_low, m_high;

        public CImplicitClamp() :base()
        { m_source = new CScalarParameter(0.0); m_low = new CScalarParameter(0.0); m_high = new CScalarParameter(1.0); }
        public CImplicitClamp(double source, double low, double high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high);  }
        public CImplicitClamp(double source, double low, CImplicitModuleBase high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high);  }
        public CImplicitClamp(double source, CImplicitModuleBase low, double high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); }
        public CImplicitClamp(double source, CImplicitModuleBase low, CImplicitModuleBase high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); }
        public CImplicitClamp(CImplicitModuleBase source, double low, double high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); }
        public CImplicitClamp(CImplicitModuleBase source, double low, CImplicitModuleBase high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high);  }
        public CImplicitClamp(CImplicitModuleBase source, CImplicitModuleBase low, double high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); }
        public CImplicitClamp(CImplicitModuleBase source, CImplicitModuleBase low, CImplicitModuleBase high) : base()
        { m_source = new CScalarParameter(source); m_low = new CScalarParameter(low); m_high = new CScalarParameter(high); }

        private void setRange(double low, double high)
        {
            m_low.set(low);
            m_high.set(high);
        }

        private void setRange(double low, CImplicitModuleBase high)
        {
            m_low.set(low);
            m_high.set(high);
        }

        private void setRange(CImplicitModuleBase low, double high)
        {
            m_low.set(low);
            m_high.set(high);
        }

        private void setRange(CImplicitModuleBase low, CImplicitModuleBase high)
        {
            m_low.set(low);
            m_high.set(high);
        }


        private void setSource(double b)
        {
            m_source.set(b);
        }

        private void setSource(CImplicitModuleBase b)
        {
            m_source.set(b);
        }

        public override double get(double x, double y)
        {
            return Misc.Clamp(m_source.get(x, y), m_low.get(x, y), m_high.get(x, y));
        }

        public override double get(double x, double y, double z)
        {
            return Misc.Clamp(m_source.get(x, y, z), m_low.get(x, y, z), m_high.get(x, y, z));
        }

        public override double get(double x, double y, double z, double w)
        {
            return Misc.Clamp(m_source.get(x, y, z, w), m_low.get(x, y, z, w), m_high.get(x, y, z, w));
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            return Misc.Clamp(m_source.get(x, y, z, w, u, v), m_low.get(x, y, z, w, u, v), m_high.get(x, y, z, w, u, v));
        }
    }
}
