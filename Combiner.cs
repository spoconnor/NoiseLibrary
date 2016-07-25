namespace NoiseLibrary
{
    public enum ECombinerTypes
    {
        ADD,
        MULT,
        MAX,
        MIN,
        AVG
    }

    public class CImplicitCombiner : CImplicitModuleBase
    {
        private const int MaxSources = 4;
        private CImplicitModuleBase[] m_sources = new CImplicitModuleBase[MaxSources];
        ECombinerTypes m_type;

        public CImplicitCombiner(ECombinerTypes type)
        {
            m_type = type;
            clearAllSources();
        }
        public CImplicitCombiner(ECombinerTypes type, CImplicitModuleBase source0, CImplicitModuleBase source1=null, CImplicitModuleBase source2=null, CImplicitModuleBase source3=null)
        {
            m_type = type;
            m_sources[0] = source0;
            m_sources[1] = source1;
            m_sources[2] = source2;
            m_sources[3] = source3;
        }

        private void setType(ECombinerTypes type)
        {
            m_type = type;
        }

        private void clearAllSources()
        {
            for (int c = 0; c < MaxSources; ++c) m_sources[c] = null;
        }

        private void setSource(int which, CImplicitModuleBase b)
        {
            if (which < 0 || which >= MaxSources) return;
            m_sources[which] = b;
        }

        public override double get(double x, double y)
        {
            switch (m_type)
            {
                case ECombinerTypes.ADD: return Add_get(x, y); 
                case ECombinerTypes.MULT: return Mult_get(x, y); 
                case ECombinerTypes.MAX: return Max_get(x, y); 
                case ECombinerTypes.MIN: return Min_get(x, y); 
                case ECombinerTypes.AVG: return Avg_get(x, y); 
                default: return 0.0; 
            }
        }

        public override double get(double x, double y, double z)
        {
            switch (m_type)
            {
                case ECombinerTypes.ADD: return Add_get(x, y, z); 
                case ECombinerTypes.MULT: return Mult_get(x, y, z); 
                case ECombinerTypes.MAX: return Max_get(x, y, z); 
                case ECombinerTypes.MIN: return Min_get(x, y, z); 
                case ECombinerTypes.AVG: return Avg_get(x, y, z); 
                default: return 0.0; 
            }
        }

        public override double get(double x, double y, double z, double w)
        {
            switch (m_type)
            {
                case ECombinerTypes.ADD: return Add_get(x, y, z, w); 
                case ECombinerTypes.MULT: return Mult_get(x, y, z, w); 
                case ECombinerTypes.MAX: return Max_get(x, y, z, w); 
                case ECombinerTypes.MIN: return Min_get(x, y, z, w); 
                case ECombinerTypes.AVG: return Avg_get(x, y, z, w); 
                default: return 0.0; 
            }
        }

        public override double get(double x, double y, double z, double w, double u, double v)
        {
            switch (m_type)
            {
                case ECombinerTypes.ADD: return Add_get(x, y, z, w, u, v); 
                case ECombinerTypes.MULT: return Mult_get(x, y, z, w, u, v); 
                case ECombinerTypes.MAX: return Max_get(x, y, z, w, u, v); 
                case ECombinerTypes.MIN: return Min_get(x, y, z, w, u, v); 
                case ECombinerTypes.AVG: return Avg_get(x, y, z, w, u, v);
                default: return 0.0; 
            }
        }
        
        double Add_get(double x, double y)
        {
            double value = 0.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c]!=null) value += m_sources[c].get(x, y);
            }
            return value;
        }
        double Add_get(double x, double y, double z)
        {
            double value = 0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value += m_sources[c].get(x, y, z);
            }
            return value;
        }
        double Add_get(double x, double y, double z, double w)
        {
            double value = 0.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value += m_sources[c].get(x, y, z, w);
            }
            return value;
        }
        double Add_get(double x, double y, double z, double w, double u, double v)
        {
            double value = 0.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value += m_sources[c].get(x, y, z, w, u, v);
            }
            return value;
        }

        double Mult_get(double x, double y)
        {
            double value = 1.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value *= m_sources[c].get(x, y);
            }
            return value;
        }
        double Mult_get(double x, double y, double z)
        {
            double value = 1.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value *= m_sources[c].get(x, y, z);
            }
            return value;
        }
        double Mult_get(double x, double y, double z, double w)
        {
            double value = 1.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value *= m_sources[c].get(x, y, z, w);
            }
            return value;
        }
        double Mult_get(double x, double y, double z, double w, double u, double v)
        {
            double value = 1.0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null) value *= m_sources[c].get(x, y, z, w, u, v);
            }
            return value;
        }

        double Min_get(double x, double y)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y);
                    if (v < mn) mn = v;
                }
            }

            return mn;
        }

        double Min_get(double x, double y, double z)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y, z);
                    if (v < mn) mn = v;
                }
            }

            return mn;
        }

        double Min_get(double x, double y, double z, double w)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z, w);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y, z, w);
                    if (v < mn) mn = v;
                }
            }

            return mn;
        }

        double Min_get(double x, double y, double z, double w, double u, double v)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z, w, u, v);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double val = m_sources[d].get(x, y, z, w, u, v);
                    if (val < mn) mn = val;
                }
            }

            return mn;
        }

        double Max_get(double x, double y)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y);
                    if (v > mn) mn = v;
                }
            }

            return mn;
        }

        double Max_get(double x, double y, double z)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y, z);
                    if (v > mn) mn = v;
                }
            }

            return mn;
        }

        double Max_get(double x, double y, double z, double w)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z, w);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double v = m_sources[d].get(x, y, z, w);
                    if (v > mn) mn = v;
                }
            }

            return mn;
        }

        double Max_get(double x, double y, double z, double w, double u, double v)
        {
            double mn;
            int c = 0;
            while (c < MaxSources && m_sources[c] == null) ++c;
            if (c == MaxSources) return 0.0;
            mn = m_sources[c].get(x, y, z, w, u, v);

            for (int d = c; d < MaxSources; ++d)
            {
                if (m_sources[d]!=null)
                {
                    double val = m_sources[d].get(x, y, z, w, u, v);
                    if (val > mn) mn = val;
                }
            }

            return mn;
        }

        double Avg_get(double x, double y)
        {
            double count = 0;
            double value = 0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null)
                {
                    value += m_sources[c].get(x, y);
                    count += 1.0;
                }
            }
            if (count == 0.0) return 0.0;
            return value / count;
        }

        double Avg_get(double x, double y, double z)
        {
            double count = 0;
            double value = 0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null)
                {
                    value += m_sources[c].get(x, y, z);
                    count += 1.0;
                }
            }
            if (count == 0.0) return 0.0;
            return value / count;
        }

        double Avg_get(double x, double y, double z, double w)
        {
            double count = 0;
            double value = 0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null)
                {
                    value += m_sources[c].get(x, y, z, w);
                    count += 1.0;
                }
            }
            if (count == 0.0) return 0.0;
            return value / count;
        }

        double Avg_get(double x, double y, double z, double w, double u, double v)
        {
            double count = 0;
            double value = 0;
            for (int c = 0; c < MaxSources; ++c)
            {
                if (m_sources[c] != null)
                {
                    value += m_sources[c].get(x, y, z, w, u, v);
                    count += 1.0;
                }
            }
            if (count == 0.0) return 0.0;
            return value / count;
        }
    }
}
