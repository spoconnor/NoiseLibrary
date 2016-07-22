namespace NoiseLibrary
{
    class CImplicitConstant : CImplicitModuleBase
    {
        private double m_constant;

        public CImplicitConstant() : base()
        { m_constant = 0.0; }
        public CImplicitConstant(double c) : base()
        { m_constant = c; }

        private void setConstant(double c) { m_constant = c; }

        public override double get(double x, double y) { return m_constant; }
        public override double get(double x, double y, double z) { return m_constant; }
        public override double get(double x, double y, double z, double w) { return m_constant; }
        public override double get(double x, double y, double z, double w, double u, double v) { return m_constant; }
    }
}
