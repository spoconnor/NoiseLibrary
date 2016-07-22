namespace NoiseLibrary
{
    public enum EFunctionGradientAxis
    {
        X_AXIS,
        Y_AXIS,
        Z_AXIS,
        W_AXIS,
        U_AXIS,
        V_AXIS
    };

    public class CImplicitFunctionGradient : CImplicitModuleBase
    {

        private CScalarParameter m_source;
        private EFunctionGradientAxis m_axis;
        private double m_spacing;

        public CImplicitFunctionGradient() : base()
        { m_source = null; m_axis = EFunctionGradientAxis.X_AXIS; m_spacing = 0.001; }
        public CImplicitFunctionGradient(double s, EFunctionGradientAxis axis = EFunctionGradientAxis.X_AXIS, double spacing = 0.001) : base()
        { m_source = new CScalarParameter(s); m_axis = axis; m_spacing = spacing; }
        public CImplicitFunctionGradient(CImplicitModuleBase s, EFunctionGradientAxis axis = EFunctionGradientAxis.X_AXIS, double spacing = 0.001) : base()
        { m_source = new CScalarParameter(s); m_axis = axis; m_spacing = spacing; }

        void setSource(double v)
        {
            m_source.set(v);
        }
        void setSource(CImplicitModuleBase m)
        {
            m_source.set(m);
        }
        void setAxis(EFunctionGradientAxis axis)
        {
            m_axis = axis;
            if (m_axis < EFunctionGradientAxis.X_AXIS) m_axis = EFunctionGradientAxis.X_AXIS;
            if (m_axis > EFunctionGradientAxis.V_AXIS) m_axis = EFunctionGradientAxis.V_AXIS;
        }
        void setSpacing(double s)
        {
            m_spacing = s;
        }

        public override double get(double x, double y)
        {
            switch (m_axis)
            {
                case EFunctionGradientAxis.X_AXIS: return (m_source.get(x - m_spacing, y) - m_source.get(x + m_spacing, y)) / m_spacing; break;
                case EFunctionGradientAxis.Y_AXIS: return (m_source.get(x, y - m_spacing) - m_source.get(x, y + m_spacing)) / m_spacing; break;
                case EFunctionGradientAxis.Z_AXIS: return 0.0; break;
                case EFunctionGradientAxis.W_AXIS: return 0.0; break;
                case EFunctionGradientAxis.U_AXIS: return 0.0; break;
                case EFunctionGradientAxis.V_AXIS: return 0.0; break;
            }
            return 0.0;
        }
        public override double get(double x, double y, double z)
        {
            switch (m_axis)
            {
                case EFunctionGradientAxis.X_AXIS: return (m_source.get(x - m_spacing, y, z) - m_source.get(x + m_spacing, y, z)) / m_spacing; break;
                case EFunctionGradientAxis.Y_AXIS: return (m_source.get(x, y - m_spacing, z) - m_source.get(x, y + m_spacing, z)) / m_spacing; break;
                case EFunctionGradientAxis.Z_AXIS: return (m_source.get(x, y, z - m_spacing) - m_source.get(x, y, z + m_spacing)) / m_spacing; break;
                case EFunctionGradientAxis.W_AXIS: return 0.0; break;
                case EFunctionGradientAxis.U_AXIS: return 0.0; break;
                case EFunctionGradientAxis.V_AXIS: return 0.0; break;
            }
            return 0.0;
        }
        public override double get(double x, double y, double z, double w)
        {
            switch (m_axis)
            {
                case EFunctionGradientAxis.X_AXIS: return (m_source.get(x - m_spacing, y, z, w) - m_source.get(x + m_spacing, y, z, w)) / m_spacing; break;
                case EFunctionGradientAxis.Y_AXIS: return (m_source.get(x, y - m_spacing, z, w) - m_source.get(x, y + m_spacing, z, w)) / m_spacing; break;
                case EFunctionGradientAxis.Z_AXIS: return (m_source.get(x, y, z - m_spacing, w) - m_source.get(x, y, z + m_spacing, w)) / m_spacing; break;
                case EFunctionGradientAxis.W_AXIS: return (m_source.get(x, y, z, w - m_spacing) - m_source.get(x, y, z, w + m_spacing)) / m_spacing; break;
                case EFunctionGradientAxis.U_AXIS: return 0.0; break;
                case EFunctionGradientAxis.V_AXIS: return 0.0; break;
            }
            return 0.0;
        }
        public override double get(double x, double y, double z, double w, double u, double v)
        {
            switch (m_axis)
            {
                case EFunctionGradientAxis.X_AXIS: return (m_source.get(x - m_spacing, y, z, w, u, v) - m_source.get(x + m_spacing, y, z, w, u, v)) / m_spacing; break;
                case EFunctionGradientAxis.Y_AXIS: return (m_source.get(x, y - m_spacing, z, w, u, v) - m_source.get(x, y + m_spacing, z, w, u, v)) / m_spacing; break;
                case EFunctionGradientAxis.Z_AXIS: return (m_source.get(x, y, z - m_spacing, w, u, v) - m_source.get(x, y, z + m_spacing, w, u, v)) / m_spacing; break;
                case EFunctionGradientAxis.W_AXIS: return (m_source.get(x, y, z, w - m_spacing, u, v) - m_source.get(x, y, z, w + m_spacing, u, v)) / m_spacing; break;
                case EFunctionGradientAxis.U_AXIS: return (m_source.get(x, y, z, w, u - m_spacing, v) - m_source.get(x, y, z, w, u + m_spacing, v)) / m_spacing; break;
                case EFunctionGradientAxis.V_AXIS: return (m_source.get(x, y, z, w, u, v - m_spacing) - m_source.get(x, y, z, w, u, v + m_spacing)) / m_spacing; break;
            }
            return 0.0;
        }
    }
}
